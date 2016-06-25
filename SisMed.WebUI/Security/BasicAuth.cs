using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SisMed.WebUI.Security
{
    public class BasicAuth : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                return;
            }

            if (filterContext.Controller.GetType().GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                return;
            }

            Usuario usuario = SessionManager.UsuarioLogado;

            var httpContext = filterContext.HttpContext;

            bool temAutorizacao = AuthorizeCore(httpContext);
            bool temSession = usuario != null;

            if (temSession && temAutorizacao)
            {
                string[] roles = new string[1];
                roles[0] = usuario.Papel.ToString();

                var identidade = new GenericIdentity(usuario.Email);
                var principal = new GenericPrincipal(identidade, roles);

                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                base.OnAuthorization(filterContext);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}

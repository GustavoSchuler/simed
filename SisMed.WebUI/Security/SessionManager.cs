using SisMed.Domain.Entities;
using System.Web;
using System.Web.Security;

namespace SisMed.WebUI.Security
{
    public class SessionManager
    {
        private const string USUARIO_LOGADO = "USUARIO_LOGADO";

        public static Usuario UsuarioLogado
        {
            get
            {
                return HttpContext.Current.Session[USUARIO_LOGADO] as Usuario;
            }
        }

        public static void CreateSession(Usuario usuarioAutenticado)
        {
            var usuarioLogado = usuarioAutenticado;

            FormsAuthentication.SetAuthCookie(usuarioLogado.Email, true);

            HttpContext.Current.Session[USUARIO_LOGADO] = usuarioLogado;
        }
    }
}

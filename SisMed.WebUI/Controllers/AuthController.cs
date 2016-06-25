using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.WebUI.Security;
using SisMed.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SisMed.WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUsuarioAppService mUsuarioApp;

        public AuthController(IUsuarioAppService usuarioApp)
        {
            mUsuarioApp = usuarioApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

                Usuario usuario = mUsuarioApp.ObterAutenticacao(clienteDomain);

                if (usuario != null)
                {
                    SessionManager.CreateSession(usuario);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");

            return View("Index", usuarioViewModel);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if(SessionManager.UsuarioLogado != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(); 
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);

                mUsuarioApp.Add(usuarioDomain);
            }

            return View("Index", usuarioViewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
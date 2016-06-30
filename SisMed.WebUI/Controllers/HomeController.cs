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

namespace SisMed.WebUI.Controllers
{
    [BasicAuth()]
    public class HomeController : Controller
    {
        private readonly IConsultaAppService mConsultaApp;
        private readonly IMedicoAppService mMedicoApp;

        public HomeController(IConsultaAppService consultaApp, IMedicoAppService medicoApp)
        {
            mConsultaApp = consultaApp;
            mMedicoApp = medicoApp;
        }
        public ActionResult Index()
        {
            int id = SessionManager.UsuarioLogado.Id;

            if (SessionManager.UsuarioLogado.Papel.ToString().Equals("MEDICO"))
            {
                id = mMedicoApp.GetAll().FirstOrDefault(m => m.idUsuario == SessionManager.UsuarioLogado.Id).Id;
            }

            var consultaViewModel = Mapper.Map<IEnumerable<Consulta>, IEnumerable<ConsultaViewModel>>(mConsultaApp.GetByUserId(id, SessionManager.UsuarioLogado.Papel.ToString()));
            return View(consultaViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
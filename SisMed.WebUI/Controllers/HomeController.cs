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

        public HomeController(IConsultaAppService consultaApp)
        {
            mConsultaApp = consultaApp;
        }
        public ActionResult Index()
        {
            var consultaViewModel = Mapper.Map<IEnumerable<Consulta>, IEnumerable<ConsultaViewModel>>(mConsultaApp.GetByUserId(SessionManager.UsuarioLogado.Id, SessionManager.UsuarioLogado.Papel.ToString()));
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
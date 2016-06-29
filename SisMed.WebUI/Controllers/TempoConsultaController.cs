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
    [BasicAuth(Roles = "MEDICO")]
    public class TempoConsultaController : Controller
    {
        private readonly ITempoConsultaAppService mTempoConsultaApp;
        private readonly ITipoConsultaAppService mTipoConsultaApp;

        public TempoConsultaController(ITempoConsultaAppService tempoConsultaApp, ITipoConsultaAppService tipoConsultaApp)
        {
            mTempoConsultaApp = tempoConsultaApp;
            mTipoConsultaApp = tipoConsultaApp;
        }

        // GET: TempoConsulta
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<TempoConsulta>, IEnumerable<TempoConsultaViewModel>>(mTempoConsultaApp.GetAll());
            return View(clienteViewModel);
        }

        // GET: TempoConsulta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TempoConsulta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempoConsulta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TempoConsultaViewModel tempoConsulta)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<TempoConsultaViewModel, TempoConsulta>(tempoConsulta);
                mTempoConsultaApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(tempoConsulta);
        }

        // GET: TempoConsulta/Edit/5
        public ActionResult Edit(int id)
        {
            var tempoConsulta = mTempoConsultaApp.GetById(id);
            var TempoConsultaViewModel = Mapper.Map<TempoConsulta, TempoConsultaViewModel>(tempoConsulta);

            return View(TempoConsultaViewModel);
        }

        // POST: TempoConsulta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TempoConsultaViewModel tempoConsulta)
        {
            if (ModelState.IsValid)
            {
                var tempoConsultaDomain = Mapper.Map<TempoConsultaViewModel, TempoConsulta>(tempoConsulta);
                mTempoConsultaApp.Update(tempoConsultaDomain);
            }

            return RedirectToAction("Index");
        }

        // GET: TempoConsulta/Delete/5
        public ActionResult Delete(int id)
        {
            var tempoConsulta = mTempoConsultaApp.GetById(id);
            var TempoConsultaViewModel = Mapper.Map<TempoConsulta, TempoConsultaViewModel>(tempoConsulta);

            return View(TempoConsultaViewModel);
        }

        // POST: TempoConsulta/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmado(int id)
        {
            var tempoConsulta = mTempoConsultaApp.GetById(id);
            var TempoConsultaViewModel = Mapper.Map<TempoConsulta, TempoConsultaViewModel>(tempoConsulta);

            mTempoConsultaApp.Remove(tempoConsulta);

            return RedirectToAction("Index");
        }
    }
}

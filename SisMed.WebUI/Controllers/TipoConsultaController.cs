using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisMed.WebUI.Controllers
{
    public class TipoConsultaController : Controller
    {
        private readonly ITipoConsultaAppService mTipoConsultaApp;


        public TipoConsultaController(ITipoConsultaAppService tipoConsultaApp)
        {
            mTipoConsultaApp = tipoConsultaApp;
        }

        // GET: TipoConsulta
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<TipoConsulta>, IEnumerable<TipoConsultaViewModel>>(mTipoConsultaApp.GetAll());
            return View(clienteViewModel);
        }

        // GET: TipoConsulta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoConsulta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoConsultaViewModel tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<TipoConsultaViewModel, TipoConsulta>(tipoConsulta);
                mTipoConsultaApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(tipoConsulta);
        }

        // GET: TipoConsulta/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoConsulta = mTipoConsultaApp.GetById(id);
            var TipoConsultaViewModel = Mapper.Map<TipoConsulta, TipoConsultaViewModel>(tipoConsulta);

            return View(TipoConsultaViewModel);
        }

        // POST: TipoConsulta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoConsultaViewModel tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                var tipoConsultaDomain = Mapper.Map<TipoConsultaViewModel, TipoConsulta>(tipoConsulta);
                mTipoConsultaApp.Update(tipoConsultaDomain);
            }

            return RedirectToAction("Index");
        }

        // GET: TipoConsulta/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoConsulta = mTipoConsultaApp.GetById(id);
            var TipoConsultaViewModel = Mapper.Map<TipoConsulta, TipoConsultaViewModel>(tipoConsulta);

            return View(TipoConsultaViewModel);
        }

        // POST: TipoConsulta/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmado(int id)
        {
            var tipoConsulta = mTipoConsultaApp.GetById(id);
            var TipoConsultaViewModel = Mapper.Map<TipoConsulta, TipoConsultaViewModel>(tipoConsulta);

            mTipoConsultaApp.Remove(tipoConsulta);

            return RedirectToAction("Index");
        }
    }
}

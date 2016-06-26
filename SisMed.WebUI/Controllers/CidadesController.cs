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
    [BasicAuth(Roles = "ADMIN")]
    public class CidadesController : Controller
    {
        private readonly ICidadeAppService mCidadeApp;


        public CidadesController(ICidadeAppService cidadeApp)
        {
            mCidadeApp = cidadeApp;
        }

        public ActionResult Index()
        {
            var cidadeViewModel = Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(mCidadeApp.GetAll());
            return View(cidadeViewModel);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CidadeViewModel cidade)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<CidadeViewModel, Cidade>(cidade);
                mCidadeApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        public ActionResult Edit(int id)
        {
            var cidade = mCidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CidadeViewModel cidade)
        {
            if (ModelState.IsValid)
            {
                var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidade);
                mCidadeApp.Update(cidadeDomain);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cidade = mCidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            var cidade = mCidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            mCidadeApp.Remove(cidade);

            return RedirectToAction("Index");
        }
    }
}

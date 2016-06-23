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

        // GET: Cidade
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(mCidadeApp.GetAll());
            return View(clienteViewModel);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
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

        // GET: Cidade/Edit/5
        public ActionResult Edit(int id)
        {
            var cidade = mCidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        // POST: Cidade/Edit/5
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

        // GET: Cidade/Delete/5
        public ActionResult Delete(int id)
        {
            var cidade = mCidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        // POST: Cidade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var cidade = mCidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            mCidadeApp.Remove(cidade);

            return RedirectToAction("Index");
        }
    }
}

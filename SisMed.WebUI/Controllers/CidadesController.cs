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
    [Authorize]
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

        // GET: Cidade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cidade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cidade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cidade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

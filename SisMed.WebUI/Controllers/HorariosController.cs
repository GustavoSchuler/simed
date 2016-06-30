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
    public class HorariosController : Controller
    {
        private readonly IConsultaAppService mConsultaApp;
        private readonly IMedicoAppService mMedicoApp;

        public HorariosController(IConsultaAppService consultaApp, IMedicoAppService medicoApp)
        {
            mConsultaApp = consultaApp;
            mMedicoApp = medicoApp;
        }

        // GET: Horarios
        public ActionResult Index()
        {
            var cidadeViewModel = Mapper.Map<IEnumerable<Consulta>, IEnumerable<ConsultaViewModel>>(mConsultaApp.GetAll().Where(c => c.IdMedico == c.IdUsuario));
            return View(cidadeViewModel);
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultaViewModel consulta)
        {
            var medico = mMedicoApp.GetAll().FirstOrDefault(m => m.idUsuario == SessionManager.UsuarioLogado.Id);

            consulta.IdMedico = medico.Id;
            consulta.IdUsuario = medico.Id;
            consulta.Observacao = "123123";
            consulta.IdTipoConsulta = 1;
            consulta.HorarioInicio = consulta.Data;

            if (ModelState.IsValid)
            {
                var consultaDomain = Mapper.Map<ConsultaViewModel, Consulta>(consulta);
                mConsultaApp.Add(consultaDomain);
                
                return RedirectToAction("Index");
            }

            return View(consulta);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Horarios/Edit/5
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

        // GET: Horarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Horarios/Delete/5
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

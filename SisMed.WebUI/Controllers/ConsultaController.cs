using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;
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
    public class ConsultaController : Controller
    {
        private readonly IConsultaAppService mConsultaApp;
        private readonly IMedicoAppService mMedicoApp;
        private readonly ITipoConsultaAppService mTipoConsultaApp;
        private readonly IEspecialidadeAppService mEspecialidadeApp;
        private readonly ICidadeAppService mCidadeApp;

        public ConsultaController(IConsultaAppService consultaApp, IMedicoAppService medicoApp, ITipoConsultaAppService tipoConsultaApp, IEspecialidadeAppService especialidadeApp, ICidadeAppService cidadeApp)
        {
            mConsultaApp = consultaApp;
            mMedicoApp = medicoApp;
            mTipoConsultaApp = tipoConsultaApp;
            mEspecialidadeApp = especialidadeApp;
            mCidadeApp = cidadeApp;
        }

        // GET: Consulta
        /*public ActionResult Index()
        {
            var consultaViewModel = Mapper.Map<IEnumerable<Consulta>, IEnumerable<ConsultaViewModel>>(mConsultaApp.GetByUserId(SessionManager.UsuarioLogado.Id, SessionManager.UsuarioLogado.Papel.ToString()));
            return View(consultaViewModel);
        }*/

        // GET: Consulta/Details/5
        public ActionResult Details(int id)
        {
            return View(mConsultaApp.GetById(id));
        }

        // GET: Consulta/Create
        public ActionResult Create()
        {
            ViewBag.IdEspecialidade = new SelectList(mEspecialidadeApp.GetAll(), "Id", "Descricao");
            ViewBag.IdCidade = LoadCities();
            ViewBag.IdTipoConsulta = new SelectList(mTipoConsultaApp.GetAll(), "Id", "Descricao");
            ViewBag.IdMedico = new SelectList(mMedicoApp.GetAll(), "Id", "Nome");

            return View();
        }

        public SelectList LoadCities()
        {
            return new SelectList(mCidadeApp.GetAll(), "Id", "NomeCidade");
        }

        public SelectList LoadDoctors(int IdCidade)
        {

            var query1 = mMedicoApp.GetAll().Where(c => c.idCidade == IdCidade).Select(c => new { c.Id, c.Nome }).AsEnumerable().ToList();

            return new SelectList(query1, "Id", "Nome");
        }

        // POST: Consulta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultaViewModel consulta)
        {
            ViewBag.IdEspecialidade = new SelectList(mEspecialidadeApp.GetAll(), "Id", "Descricao");
            ViewBag.IdTipoConsulta = new SelectList(mTipoConsultaApp.GetAll(), "Id", "Descricao");

            var IdCidade = Request["IdCidade"];
            ViewBag.IdCidade = new SelectList(mCidadeApp.GetAll(), "Id", "NomeCidade", IdCidade);
            ViewBag.IdMedico = LoadDoctors(Convert.ToInt32(IdCidade));
            
            if (ModelState.IsValid)
            {
                var ConsultaDomain = Mapper.Map<ConsultaViewModel, Consulta>(consulta);
                mConsultaApp.Add(ConsultaDomain);

                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        // GET: Consulta/Edit/5
        public ActionResult Edit(int id)
        {
            var consulta = mConsultaApp.GetById(id);
            var ConsultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(consulta);

            return View(ConsultaViewModel);
        }

        // POST: Consulta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsultaViewModel consulta)
        {
            if (ModelState.IsValid)
            {
                var ConsultaDomain = Mapper.Map<ConsultaViewModel, Consulta>(consulta);
                mConsultaApp.Update(ConsultaDomain);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Consulta/Delete/5
        public ActionResult Delete(int id)
        {
            var consulta = mConsultaApp.GetById(id);
            var ConsultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(consulta);

            return View(ConsultaViewModel);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            var consulta = mConsultaApp.GetById(id);
            var ConsultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(consulta);

            mConsultaApp.Remove(consulta);

            return RedirectToAction("Index", "Home");
        }
    }
}

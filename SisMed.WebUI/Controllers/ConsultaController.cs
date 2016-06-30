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
        private readonly ITempoConsultaAppService mTempoConsultaApp;

        public ConsultaController(IConsultaAppService consultaApp, IMedicoAppService medicoApp, ITipoConsultaAppService tipoConsultaApp, IEspecialidadeAppService especialidadeApp, ICidadeAppService cidadeApp, ITempoConsultaAppService tempoConsultaApp)
        {
            mConsultaApp = consultaApp;
            mMedicoApp = medicoApp;
            mTipoConsultaApp = tipoConsultaApp;
            mEspecialidadeApp = especialidadeApp;
            mCidadeApp = cidadeApp;
            mTempoConsultaApp = tempoConsultaApp;
        }

        public ActionResult Details(int id)
        {
            Consulta c = mConsultaApp.GetById(id);

            var ConsultaViewModel = Mapper.Map<Consulta, ConsultaViewModel>(c);
            return View(ConsultaViewModel);
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

        public SelectList LoadDoctors(int IdCidade = 0, int IdEspecialidade = 0, int IdMedico = 0)
        {

            var query1 = mMedicoApp.GetAll();
            if (IdCidade != 0)
                query1 = query1.Where(c => c.idCidade == IdCidade);
            if (IdEspecialidade != 0)
                query1 = query1.Where(c => c.idEspecialidade == IdEspecialidade);

            query1 = query1.AsEnumerable().ToList();

            if (IdMedico != 0)
            {
                ViewBag.MinDate = 1;

                var horarioInicial = query1.Where(m => m.Id == IdMedico).Select(m => m.HorarioInicial).AsEnumerable().ToList()[0].TimeOfDay.Hours;
                ViewBag.HorarioInicialHoje = (horarioInicial > DateTime.Now.Hour) ? horarioInicial : DateTime.Now.Hour;
                ViewBag.HorarioInicial = horarioInicial;

                var horarioFinal = query1.Where(m => m.Id == IdMedico).Select(m => m.HorarioFinal).AsEnumerable().ToList()[0].TimeOfDay.Hours;
                ViewBag.HorarioFinal = horarioFinal;
                ViewBag.HorarioFinalHoje = (horarioFinal < ViewBag.HorarioInicialHoje) ? 0 : horarioFinal;

                if (ViewBag.HorarioFinalHoje == 0)
                {
                    ViewBag.MinDate = 1;
                }

                return new SelectList(query1, "Id", "Nome", IdMedico);
            }
            else
            {
                return new SelectList(query1, "Id", "Nome");
            }
            
        }

        public int GetTempoConsulta(int IdMedico = 0, int IdTipoConsulta = 0)
        {
            int tempoConsulta = 0;

            var query = mTempoConsultaApp.GetAll()
                        .Where(t => t.IdMedico == IdMedico)
                        .Where(t => t.IdTipoConsulta == IdTipoConsulta)
                        .Select(t => t.TempoMedio ).AsEnumerable().ToList();

            tempoConsulta = Convert.ToInt32(query[0]);

            return tempoConsulta;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultaViewModel consulta)
        {
            int IdCidade = 0;
            int IdEspecialidade = 0;
            int idMedico = 0;
            int idTipoConsulta = 0;


            if (!Request["IdCidade"].Equals(""))
            {
                IdCidade = Convert.ToInt32(Request["IdCidade"]);
            }
            if (!Request["IdEspecialidade"].Equals(""))
            {
                IdEspecialidade = Convert.ToInt32(Request["IdEspecialidade"]);
            }

            ViewBag.IdCidade = new SelectList(mCidadeApp.GetAll(), "Id", "NomeCidade", IdCidade);
            ViewBag.IdEspecialidade = new SelectList(mEspecialidadeApp.GetAll(), "Id", "Descricao", IdEspecialidade);

            if (!Request["IdMedico"].Equals("") && !Request["IdTipoConsulta"].Equals(""))
            {
                idMedico = Convert.ToInt32(Request["IdMedico"]);
                idTipoConsulta = Convert.ToInt32(Request["IdTipoConsulta"]);

                ViewBag.TempoMedio = GetTempoConsulta(idMedico, idTipoConsulta);

                ViewBag.IdMedico = LoadDoctors(IdCidade, IdEspecialidade, idMedico);

                if (idTipoConsulta == 2)
                {
                    var query2 = mConsultaApp.GetAll()
                        .Where(c => c.Data < DateTime.Now)
                        .Where(c => c.IdUsuario == SessionManager.UsuarioLogado.Id)
                        .Where(c => c.IdTipoConsulta != 2)
                        .Where(c => c.IdMedico == idMedico)
                        .Select(c => c.Id).AsEnumerable().ToList();

                    if (query2.ToList().Count == 0)
                    {
                        idTipoConsulta = 0;
                    } 

                }

                ViewBag.IdTipoConsulta = new SelectList(mTipoConsultaApp.GetAll(), "Id", "Descricao", idTipoConsulta);
            }
            else
            {
                ViewBag.IdMedico = LoadDoctors(IdCidade, IdEspecialidade);
                ViewBag.IdTipoConsulta = new SelectList(mTipoConsultaApp.GetAll(), "Id", "Descricao");
            }

            bool error = false;

            if (!Request["HorarioInicio"].Equals(""))
            {

                DateTime horarioInicio = Convert.ToDateTime(Request["HorarioInicio"]);
                DateTime dataConsulta = Convert.ToDateTime(Request["Data"]);

                var query = mConsultaApp.GetAll()
                    .Where(c => c.IdMedico == idMedico)
                    .Where(c => c.Data.Date == dataConsulta.Date).ToList();

                var consultas = query.ToList();

                foreach (var c in consultas)
                {
                    double tempoConsulta = mTempoConsultaApp.GetAll()
                        .Where(t => t.IdMedico == idMedico)
                        .Where(t => t.IdTipoConsulta == idTipoConsulta)
                        .Select(t => t.TempoMedio).FirstOrDefault();

                    if (horarioInicio >= c.HorarioInicio && horarioInicio < c.HorarioInicio.AddMinutes(tempoConsulta))
                    {
                        ModelState.AddModelError("HorarioInicio", "Horário não disponível");
                        error = true;
                        ViewBag.IdUsuario = SessionManager.UsuarioLogado.Id;
                        return View("Create");
                    }
                }
            }

            if (ModelState.IsValid && error == false)
            {
                var ConsultaDomain = Mapper.Map<ConsultaViewModel, Consulta>(consulta);
                mConsultaApp.Add(ConsultaDomain);

                return RedirectToAction("Index", "Home");
            }

            ModelState.Clear();

            ViewBag.IdUsuario = SessionManager.UsuarioLogado.Id;

            return View("Create");
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

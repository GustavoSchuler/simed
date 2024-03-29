﻿using AutoMapper;
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
    [BasicAuth(Roles = "ADMIN")]
    public class MedicosController : Controller
    {
        private readonly IMedicoAppService mMedicoApp;
        private readonly ICidadeAppService mCidadeApp;
        private readonly IEspecialidadeAppService mEspecialidadeApp;
        private readonly IUsuarioAppService mUsuarioApp;
        private readonly ITipoConsultaAppService mTipoConsultaApp;


        public MedicosController(IMedicoAppService MedicoApp, IEspecialidadeAppService EspecialidadeApp, ICidadeAppService CidadeApp, IUsuarioAppService UsuarioApp, ITipoConsultaAppService TipoConsultaApp)
        {
            mMedicoApp = MedicoApp;
            mEspecialidadeApp = EspecialidadeApp;
            mCidadeApp = CidadeApp;
            mUsuarioApp = UsuarioApp;
            mTipoConsultaApp = TipoConsultaApp;
        }

        public ActionResult Index()
        {
            return View(mMedicoApp.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(mMedicoApp.GetById(id));
        }

        public ActionResult Create()
        {
            ViewBag.idEspecialidade = new SelectList(mEspecialidadeApp.GetAll(), "Id", "Descricao");
            ViewBag.idCidade = new SelectList(mCidadeApp.GetAll(), "Id", "NomeCidade");
            ViewBag.idUsuario = new SelectList(mUsuarioApp.GetAll(), "Id", "Email");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicoViewModel medico)
        {
            if (ModelState.IsValid)
            {
                var MedicoDomain = Mapper.Map<MedicoViewModel, Medico>(medico);

                mMedicoApp.Add(MedicoDomain);

                mUsuarioApp.AlterarRoleUsuario(MedicoDomain.idUsuario, Papel.MEDICO);

                mTipoConsultaApp.AdicionarMedicoTodosTipos(MedicoDomain.Id);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var medico = mMedicoApp.GetById(id);
            var MedicoViewModel = Mapper.Map<Medico, MedicoViewModel>(medico);

            ViewBag.idEspecialidade = new SelectList(mEspecialidadeApp.GetAll(), "Id", "Descricao");
            ViewBag.idCidade = new SelectList(mCidadeApp.GetAll(), "Id", "NomeCidade");
            ViewBag.idUsuario = new SelectList(mUsuarioApp.GetAll(), "Id", "Email");

            return View(MedicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicoViewModel medico)
        {
            if (ModelState.IsValid)
            {
                var MedicoDomain = Mapper.Map<MedicoViewModel, Medico>(medico);
                mMedicoApp.Update(MedicoDomain);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var medico = mMedicoApp.GetById(id);
            var MedicoViewModel = Mapper.Map<Medico, MedicoViewModel>(medico);

            return View(MedicoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            var medico = mMedicoApp.GetById(id);
            var MedicoViewModel = Mapper.Map<Medico, MedicoViewModel>(medico);

            mMedicoApp.Remove(medico);

            return RedirectToAction("Index");
        }
    }
}
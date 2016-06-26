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
    [BasicAuth(Roles = "ADMIN")]
    public class EspecialidadesController : Controller
    {
        private readonly IEspecialidadeAppService mEspecialidadeApp;

        public EspecialidadesController(IEspecialidadeAppService EspecialidadeApp)
        {
            mEspecialidadeApp = EspecialidadeApp;
        }

        public ActionResult Index()
        {
            var EspecialidadeViewModel = Mapper.Map<IEnumerable<Especialidade>, IEnumerable<EspecialidadeViewModel>>(mEspecialidadeApp.GetAll());

            return View(EspecialidadeViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecialidadeViewModel especialidade)
        {
            if (ModelState.IsValid)
            {
                var EspecialidadeDomain = Mapper.Map<EspecialidadeViewModel, Especialidade>(especialidade);
                mEspecialidadeApp.Add(EspecialidadeDomain);

                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        public ActionResult Edit(int id)
        {
            var especialidade = mEspecialidadeApp.GetById(id);
            var EspecialidadeViewModel = Mapper.Map<Especialidade, EspecialidadeViewModel>(especialidade);

            return View(EspecialidadeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EspecialidadeViewModel especialidade)
        {
            if (ModelState.IsValid)
            {
                var EspecialidadeDomain = Mapper.Map<EspecialidadeViewModel, Especialidade>(especialidade);
                mEspecialidadeApp.Update(EspecialidadeDomain);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var especialidade = mEspecialidadeApp.GetById(id);
            var especialidadeViewModel = Mapper.Map<Especialidade, EspecialidadeViewModel>(especialidade);

            return View(especialidadeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            var especialidade = mEspecialidadeApp.GetById(id);
            var EspecialidadeViewModel = Mapper.Map<Especialidade, EspecialidadeViewModel>(especialidade);

            mEspecialidadeApp.Remove(especialidade);

            return RedirectToAction("Index");
        }
    }
}

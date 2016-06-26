using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.WebUI.Security;
using SisMed.WebUI.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
namespace SisMed.WebUI.Controllers
{
    [BasicAuth(Roles = "ADMIN")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService mUsuarioApp;

        public UsuariosController(IUsuarioAppService usuarioApp)
        {
            mUsuarioApp = usuarioApp;
        }

        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(mUsuarioApp.GetAll());

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel especialidade)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(especialidade);
                mUsuarioApp.Add(usuarioDomain);

                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        public ActionResult Edit(int id)
        {
            var usuario = mUsuarioApp.GetById(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
                mUsuarioApp.Update(usuarioDomain);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var usuario = mUsuarioApp.GetById(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            var usuario = mUsuarioApp.GetById(id);
            var usuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);

            mUsuarioApp.Remove(usuario);

            return RedirectToAction("Index");
        }
    }
}

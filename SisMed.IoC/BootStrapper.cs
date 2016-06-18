using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SisMed.Application;
using SisMed.Application.Interface;
using SisMed.Data.Repositories;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;
using SisMed.Domain.Services;
using SisMedIdentity.Configuration;
using SisMedIdentity.Context;
using SisMedIdentity.Model;

namespace SisMed.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container)
        {
            container.RegisterPerWebRequest<ApplicationDbContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            container.RegisterPerWebRequest<IUsuarioRepository, UsuarioRepository>();

            container.Register<ICidadeAppService, CidadeAppService>(Lifestyle.Scoped);
            container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);
            container.Register<ICidadeRepository, CidadeRepository>(Lifestyle.Scoped);
        }
    }
}

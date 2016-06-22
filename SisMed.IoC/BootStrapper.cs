using SimpleInjector;
using SisMed.Application;
using SisMed.Application.Interface;
using SisMed.Data.Repositories;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;
using SisMed.Domain.Services;

namespace SisMed.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container)
        {
            container.RegisterPerWebRequest<IUsuarioRepository, UsuarioRepository>();

            container.Register<ICidadeAppService, CidadeAppService>(Lifestyle.Scoped);
            container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);
            container.Register<ICidadeRepository, CidadeRepository>(Lifestyle.Scoped);

            container.Register<IConsultaAppService, ConsultaAppService>(Lifestyle.Scoped);
            container.Register<IConsultaService, ConsultaService>(Lifestyle.Scoped);
            container.Register<IConsultaRepository, ConsultaRepository>(Lifestyle.Scoped);

            container.Register<IEspecialidadeAppService, EspecialidadeAppService>(Lifestyle.Scoped);
            container.Register<IEspecialidadeService, EspecialidadeService>(Lifestyle.Scoped);
            container.Register<IEspecialidadeRepository, EspecialidadeRepository>(Lifestyle.Scoped);

            container.Register<IMedicoAppService, MedicoAppService>(Lifestyle.Scoped);
            container.Register<IMedicoService, MedicoService>(Lifestyle.Scoped);
            container.Register<IMedicoRepository, MedicoRepository>(Lifestyle.Scoped);

            container.Register<ITempoConsultaAppService, TempoConsultaAppService>(Lifestyle.Scoped);
            container.Register<ITempoConsultaService, TempoConsultaService>(Lifestyle.Scoped);
            container.Register<ITempoConsultaRepository, TempoConsultaRepository>(Lifestyle.Scoped);

            container.Register<ITipoConsultaAppService, TipoConsultaAppService>(Lifestyle.Scoped);
            container.Register<ITipoConsultaService, TipoConsultaService>(Lifestyle.Scoped);
            container.Register<ITipoConsultaRepository, TipoConsultaRepository>(Lifestyle.Scoped);
        }
    }
}

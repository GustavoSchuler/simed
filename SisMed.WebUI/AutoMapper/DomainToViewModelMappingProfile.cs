using System;
using AutoMapper;
using SisMed.WebUI.ViewModel;
using SisMed.Domain.Entities;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }
        protected override void Configure()
        {
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<TipoConsultaViewModel, TipoConsulta>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<EspecialidadeViewModel, Especialidade>();
            CreateMap<MedicoViewModel, Medico>();
        }
    }
}

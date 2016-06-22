using AutoMapper;
using SisMed.Domain.Entities;
using SisMed.WebUI.ViewModel;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
        protected override void Configure()
        {
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<TipoConsulta, TipoConsultaViewModel>();
        }
    }
}

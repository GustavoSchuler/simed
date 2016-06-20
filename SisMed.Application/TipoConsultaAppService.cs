using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Application
{
    public class TipoConsultaAppService : AppServiceBase<TipoConsulta>, ITipoConsultaAppService
    {
        private readonly ITipoConsultaService mTipoConsultaService;
        public TipoConsultaAppService(ITipoConsultaService tipoConsulta) : base(tipoConsulta)
        {
            mTipoConsultaService = tipoConsulta;
        }
    }
}

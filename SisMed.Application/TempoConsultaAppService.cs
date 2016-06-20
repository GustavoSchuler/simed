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
    public class TempoConsultaAppService : AppServiceBase<TempoConsulta>, ITempoConsultaAppService
    {
        private readonly ITempoConsultaService mTempoConsultaService;
        public TempoConsultaAppService(ITempoConsultaService tempoConsulta) : base(tempoConsulta)
        {
            mTempoConsultaService = tempoConsulta;
        }
    }
}

using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisMed.Domain.Interfaces.Services;
using SisMed.Application.Interface;

namespace SisMed.Application
{
    public class ConsultaAppService : AppServiceBase<Consulta>, IConsultaAppService
    {
        private readonly IConsultaService mConsultaService;
        public ConsultaAppService(IConsultaService consultaService) : base(consultaService)
        {
            mConsultaService = consultaService;
        }
    }
}

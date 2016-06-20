using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisMed.Domain.Interfaces.Repositories;

namespace SisMed.Domain.Services
{
    public class TempoConsultaService : ServiceBase<TempoConsulta>, ITempoConsultaService
    {
        private readonly ITempoConsultaRepository mTempoConsultaRepository;
        public TempoConsultaService(ITempoConsultaRepository tempoConsultaRepository) : base(tempoConsultaRepository)
        {
            mTempoConsultaRepository = tempoConsultaRepository;
        }
    }
}

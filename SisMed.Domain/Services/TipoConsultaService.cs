using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Services
{
    public class TipoConsultaService : ServiceBase<TipoConsulta>, ITipoConsultaService
    {
        private readonly ITipoConsultaRepository mTipoConsultaRepository;
        public TipoConsultaService(ITipoConsultaRepository tipoConsultaRepository) : base(tipoConsultaRepository)
        {
            mTipoConsultaRepository = tipoConsultaRepository;
        }
    }
}

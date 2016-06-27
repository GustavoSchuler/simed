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
    public class ConsultaService : ServiceBase<Consulta>, IConsultaService
    {
        private readonly IConsultaRepository mConsultaRepository;
        public ConsultaService(IConsultaRepository consultaRepository) : base(consultaRepository)
        {
            mConsultaRepository = consultaRepository;
        }

        public IEnumerable<Consulta> GetByUserId(int userId, string userRole)
        {
            return mConsultaRepository.GetByUserId(userId, userRole);
        }
    }
}

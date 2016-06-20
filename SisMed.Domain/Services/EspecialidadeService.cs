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
    public class EspecialidadeService : ServiceBase<Especialidade>, IEspecialidadeService
    {
        private readonly IEspecialidadeRepository mEspecialidadeRepository;
        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository) : base(especialidadeRepository)
        {
            mEspecialidadeRepository = especialidadeRepository;
        }
    }
}

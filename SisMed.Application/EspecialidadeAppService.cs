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
    public class EspecialidadeAppService : AppServiceBase<Especialidade>, IEspecialidadeAppService
    {
        private readonly IEspecialidadeService mEspecialidadeService;

        public EspecialidadeAppService(IEspecialidadeService especialidadeService) : base(especialidadeService)
        {
            mEspecialidadeService = especialidadeService;
        }
    }
}

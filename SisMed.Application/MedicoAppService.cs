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
    public class MedicoAppService : AppServiceBase<Medico>, IMedicoAppService
    {
        private readonly IMedicoService mMedicoService;
        public MedicoAppService(IMedicoService medicoService) : base(medicoService)
        {
            mMedicoService = medicoService;
        }
    }
}

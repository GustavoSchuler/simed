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
    public class MedicoService : ServiceBase<Medico>, IMedicoService
    {
        private readonly IMedicoRepository mMedicoRepository;
        public MedicoService(IMedicoRepository medicoRepository) : base(medicoRepository)
        {
            mMedicoRepository = medicoRepository;
        }
    }
}

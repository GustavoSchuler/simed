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
    public class CidadeService :ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository mCidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository) : base(cidadeRepository)
        {
            mCidadeRepository = cidadeRepository;
        }
    }
}

using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
   public class CidadeAppService : AppServiceBase<Cidade>, ICidadeAppService
   {
        private readonly ICidadeService mCidadeService;

        public CidadeAppService(ICidadeService cidadeService)
            :base(cidadeService)
        {
            mCidadeService = cidadeService;
        }
    }
}

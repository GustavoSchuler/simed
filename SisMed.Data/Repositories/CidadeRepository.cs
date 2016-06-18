using SisMed.Data.Migrations;
using SisMed.Domain.Interfaces;
using SisMed.Domain.Entities;

namespace SisMed.Data.Repositories
{
    public class CidadeRepository : RepositoryBase<Domain.Entities.Cidade>, Domain.Interfaces.Repositories.ICidadeRepository
    {
    }
}

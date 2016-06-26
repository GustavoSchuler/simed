using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisMed.Domain.Entities;

namespace SisMed.Data.Repositories
{
    public class ConsultaRepository : RepositoryBase<Domain.Entities.Consulta>, Domain.Interfaces.Repositories.IConsultaRepository
    {
        public IEnumerable<Consulta> GetByUserId(int userId)
        {
            IEnumerable<Consulta> consulta = GetAll();

            IEnumerable<Consulta> res = (from c in consulta
                        where c.IdUsuario == userId
                        select c).AsEnumerable().ToList();

            return res;
        }
    }
}

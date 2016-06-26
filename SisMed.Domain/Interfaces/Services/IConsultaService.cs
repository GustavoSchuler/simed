using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Interfaces.Services
{
    public interface IConsultaService : IServiceBase<Consulta>
    {
        IEnumerable<Consulta> GetByUserId(int userId);
    }
}

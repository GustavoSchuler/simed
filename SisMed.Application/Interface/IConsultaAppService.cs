﻿using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Application.Interface
{
    public interface IConsultaAppService : IAppServiceBase<Consulta>
    {
        IEnumerable<Consulta> GetByUserId(int userId, string userRole);
    }
}

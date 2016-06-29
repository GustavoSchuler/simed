using SisMed.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Repositories
{
    public class TipoConsultaRepository : RepositoryBase<Domain.Entities.TipoConsulta>, Domain.Interfaces.Repositories.ITipoConsultaRepository
    {
        private readonly SisMedContext mDb;

        public TipoConsultaRepository()
        {
            mDb = new SisMedContext();
        }
        public void AdicionarMedicoTodosTipos(int idMedico)
        {
            mDb.TipoConsultas.ToList().ForEach(t => mDb.TempoConsultas.Add(new Domain.Entities.TempoConsulta() { IdMedico = idMedico, IdTipoConsulta = t.Id }));
            mDb.SaveChanges();
        }
    }
}

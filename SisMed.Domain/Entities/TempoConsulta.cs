using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Entities
{
    class TempoConsulta
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public virtual Medico Medico { get; set; }
        public int IdTipoConsulta { get; set; }
        public virtual TipoConsulta TipoConsulta { get; set; }
        public double TempoMedio { get; set; }
    }
}

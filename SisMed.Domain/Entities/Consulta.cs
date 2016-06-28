using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        [ForeignKey("IdMedico")]
        public virtual Medico Medico { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
        public int IdTipoConsulta { get; set; }
        [ForeignKey("IdTipoConsulta")]
        public virtual TipoConsulta TipoConsulta { get; set; }
        public DateTime Data { get; set; }
        public DateTime HorarioInicio { get; set; }
        public string Observacao { get; set; }

    }
}

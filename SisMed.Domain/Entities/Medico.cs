using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public int Crm { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public bool AtendePorConvenio { get; set; }
        public bool TemClinica { get; set; }
        public string WebSiteBlog { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public int idCidade { get; set; }
        [ForeignKey("idCidade")]
        public virtual Cidade Cidade { get; set; }
        public int idEspecialidade { get; set; }
        [ForeignKey("idEspecialidade")]
        public virtual Especialidade Especialidade { get; set; }
    }
}

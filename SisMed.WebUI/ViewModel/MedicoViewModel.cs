using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.WebUI.ViewModel
{
    public class MedicoViewModel
    {
        public int Id { get; set; }

        public int Crm { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Email { get; set; }

        public bool AtendePorConvenio { get; set; }

        [Display(Name = "Possui clínica")]
        public bool TemClinica { get; set; }

        [Display(Name = "WebSite")]
        public string WebSiteBlog { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Horário inicial")]
        public DateTime HorarioInicial { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Horário final")]
        public DateTime HorarioFinal { get; set; }

        public int idCidade{ get; set; }

        public int idEspecialidade { get; set; }

        public int idUsuario { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual Especialidade Especialidade { get; set; }

        public virtual Usuario Usuario { get; set; }


    }
}

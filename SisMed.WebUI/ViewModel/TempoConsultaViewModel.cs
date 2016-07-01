using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SisMed.WebUI.ViewModel
{
    public class TempoConsultaViewModel
    {
        [Key]
        public int Id { get; set; }

        public int IdMedico { get; set; }

        public int IdTipoConsulta { get; set; }

        [Required(ErrorMessage = "Preencha o campo tempo médio")]
        [Display(Name = "Tempo médio de consulta")]
        public double TempoMedio { get; set; }

        public virtual TipoConsulta TipoConsulta { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
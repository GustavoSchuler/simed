using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SisMed.WebUI.ViewModel
{
    public class ConsultaViewModel
    {
        public int Id { get; set; }

        public int IdMedico { get; set; }

        [Display(Name = "Médico")]
        public virtual Medico Medico { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        public int IdTipoConsulta { get; set; }

        [Display(Name = "Tipo da consulta")]
        public virtual TipoConsulta TipoConsulta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora início")]
        public DateTime HorarioInicio { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }
    }
}
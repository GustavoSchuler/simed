﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.WebUI.ViewModel
{
    public class TipoConsultaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mímino de {0} caracteres")]
        [Display(Name = "Tipo de consulta")]
        public string Descricao { get; set; }
    }
}

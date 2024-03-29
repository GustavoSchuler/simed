﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.WebUI.ViewModel
{
    public class CidadeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo cidade")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mímino de {0} caracteres")]
        [Display(Name = "Nome da Cidade")]
        public string NomeCidade { get; set; }
    }
}

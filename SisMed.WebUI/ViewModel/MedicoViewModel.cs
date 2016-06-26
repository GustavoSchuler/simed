﻿using System;
using System.Collections.Generic;
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

        public bool TemClinica { get; set; }

        public string WebSiteBlog { get; set; }

        public DateTime HorarioInicial { get; set; }

        public DateTime HorarioFinal { get; set; }

        public int Cidade { get; set; }

        public int Especialidade { get; set; }
    }
}
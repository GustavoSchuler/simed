﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Domain.Entities
{
    public class TempoConsulta
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        [ForeignKey("IdMedico")]
        public virtual Medico Medico { get; set; }
        public int IdTipoConsulta { get; set; }
        [ForeignKey("IdTipoConsulta")]
        public virtual TipoConsulta TipoConsulta { get; set; }
        public double TempoMedio { get; set; }
    }
}

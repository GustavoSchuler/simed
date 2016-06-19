using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Configurations
{
    public class TempoConsultaConfiguration : EntityTypeConfiguration<TempoConsulta>
    {
        public TempoConsultaConfiguration()
        {
            HasKey(t => t.Id);

            HasRequired(t => t.Medico)
               .WithMany()
               .HasForeignKey(t => t.IdMedico);

            HasRequired(t => t.TipoConsulta)
               .WithMany()
               .HasForeignKey(t => t.IdTipoConsulta);

        }
    }
}

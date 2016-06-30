using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Configurations
{
    public class ConsultaConfiguration : EntityTypeConfiguration<Consulta>
    {
        public ConsultaConfiguration()
        {
            HasKey(c => c.Id);

            HasRequired(c => c.Medico)
               .WithMany()
               .HasForeignKey(c => c.IdMedico);

            HasRequired(c => c.Usuario)
               .WithMany()
               .HasForeignKey(c => c.IdUsuario);

            HasRequired(c => c.TipoConsulta)
               .WithMany()
               .HasForeignKey(c => c.IdTipoConsulta);

            Property(c => c.Data)
                .IsRequired();

            Property(c => c.HorarioInicio)
                .IsRequired();

            Property(c => c.Observacao)
                .HasMaxLength(250);

        }
    }
}

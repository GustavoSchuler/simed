using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Configurations
{
    public class TipoConsultaConfiguration : EntityTypeConfiguration<TipoConsulta>
    {
        public TipoConsultaConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

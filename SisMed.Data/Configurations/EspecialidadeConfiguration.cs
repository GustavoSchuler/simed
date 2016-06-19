using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Configurations
{
    public class EspecialidadeConfiguration : EntityTypeConfiguration<Especialidade>
    {
        public EspecialidadeConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}

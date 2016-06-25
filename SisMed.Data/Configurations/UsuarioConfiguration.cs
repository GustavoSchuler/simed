using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Configurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired();

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.PasswordHash)
                .IsRequired().
                HasMaxLength(128);

            Property(u => u.Papel);
        }
    }
}

using SisMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisMed.Data.Configurations
{
    public class MedicoConfiguration : EntityTypeConfiguration<Medico>
    {
        public MedicoConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Crm)
                .IsRequired();

            Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(m => m.Endereco)
                .IsRequired()
                .HasMaxLength(50);

            Property(m => m.Bairro)
                .IsRequired()
                .HasMaxLength(30);

            Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);

            Property(m => m.HorarioInicial)
                .IsRequired();

            Property(m => m.HorarioFinal)
                .IsRequired();

            HasRequired(m => m.Cidade)
               .WithMany()
               .HasForeignKey(m => m.IdCidade);

            HasRequired(m => m.Especialidade)
               .WithMany()
               .HasForeignKey(m => m.IdEspecialidade);
        }
    }
}

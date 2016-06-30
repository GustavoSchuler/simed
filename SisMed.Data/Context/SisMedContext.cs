
using SisMed.Data.Configurations;
using SisMed.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SisMed.Data.Context
{
    public class SisMedContext : DbContext
    {
        public SisMedContext() : base("SisMed")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<TempoConsulta> TempoConsultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<TipoConsulta> TipoConsultas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CidadeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new ConsultaConfiguration());
            modelBuilder.Configurations.Add(new TempoConsultaConfiguration());
            modelBuilder.Configurations.Add(new MedicoConfiguration());
            modelBuilder.Configurations.Add(new TipoConsultaConfiguration());
            modelBuilder.Configurations.Add(new EspecialidadeConfiguration());
        }
    }
}

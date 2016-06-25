namespace SisMed.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SisMed.Data.Context.SisMedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SisMed.Data.Context.SisMedContext context)
        {
            context.Usuarios.AddOrUpdate(
                u => u.Id, 
                new Domain.Entities.Usuario() { Id = 1, Email = "admin@admin.com", PasswordHash = "123123", Papel = Domain.Entities.Papel.ADMIN },
                new Domain.Entities.Usuario() { Id = 2, Email = "usuario@usuario.com", PasswordHash = "123123", Papel = Domain.Entities.Papel.USUARIO },
                new Domain.Entities.Usuario() { Id = 3, Email = "medico@medico.com", PasswordHash = "123123", Papel = Domain.Entities.Papel.MEDICO });
        }
    }
}

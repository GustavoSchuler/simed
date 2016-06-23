namespace SisMed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoUsuario : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Usuario");
            AddColumn("dbo.Usuario", "Papel", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "PasswordHash", c => c.String(nullable: false, maxLength: 128, unicode: false));
            DropColumn("dbo.Usuario", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "UserName", c => c.String(nullable: false, maxLength: 256, unicode: false));
            AlterColumn("dbo.Usuario", "PasswordHash", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Usuario", "Papel");
            RenameTable(name: "dbo.Usuario", newName: "AspNetUsers");
        }
    }
}

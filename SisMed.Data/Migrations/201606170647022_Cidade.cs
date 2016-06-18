namespace SisMed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cidade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeID = c.Int(nullable: false, identity: true),
                        NomeCidade = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.CidadeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cidade");
        }
    }
}

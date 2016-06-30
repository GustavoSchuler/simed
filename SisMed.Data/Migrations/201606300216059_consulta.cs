namespace SisMed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consulta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Consulta", "Observacao", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Consulta", "Observacao", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}

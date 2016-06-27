namespace SisMed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alterando_Medico : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medico", "Cidade_CidadeID", "dbo.Cidade");
            DropForeignKey("dbo.Medico", "Especialidade_Id", "dbo.Especialidade");
            DropIndex("dbo.Medico", new[] { "Cidade_CidadeID" });
            DropIndex("dbo.Medico", new[] { "Especialidade_Id" });
            DropColumn("dbo.Medico", "Cidade_CidadeID");
            DropColumn("dbo.Medico", "Especialidade_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medico", "Especialidade_Id", c => c.Int());
            AddColumn("dbo.Medico", "Cidade_CidadeID", c => c.Int());
            CreateIndex("dbo.Medico", "Especialidade_Id");
            CreateIndex("dbo.Medico", "Cidade_CidadeID");
            AddForeignKey("dbo.Medico", "Especialidade_Id", "dbo.Especialidade", "Id");
            AddForeignKey("dbo.Medico", "Cidade_CidadeID", "dbo.Cidade", "CidadeID");
        }
    }
}

namespace SisMed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCidade = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consulta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedico = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdTipoConsulta = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        HorarioInicio = c.DateTime(nullable: false),
                        Observacao = c.String(maxLength: 100, unicode: false),
                        Medico_Id = c.Int(),
                        TipoConsulta_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medico", t => t.Medico_Id)
                .ForeignKey("dbo.TipoConsulta", t => t.TipoConsulta_Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.TipoConsulta_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Crm = c.Int(nullable: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        AtendePorConvenio = c.Boolean(nullable: false),
                        TemClinica = c.Boolean(nullable: false),
                        WebSiteBlog = c.String(maxLength: 100, unicode: false),
                        HorarioInicial = c.DateTime(nullable: false),
                        HorarioFinal = c.DateTime(nullable: false),
                        idCidade = c.Int(nullable: false),
                        idEspecialidade = c.Int(nullable: false),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidade", t => t.idCidade, cascadeDelete: true)
                .ForeignKey("dbo.Especialidade", t => t.idEspecialidade, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idCidade)
                .Index(t => t.idEspecialidade)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Especialidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256, unicode: false),
                        PasswordHash = c.String(nullable: false, maxLength: 128, unicode: false),
                        Papel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoConsulta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TempoConsulta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMedico = c.Int(nullable: false),
                        IdTipoConsulta = c.Int(nullable: false),
                        TempoMedio = c.Double(nullable: false),
                        Medico_Id = c.Int(),
                        TipoConsulta_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medico", t => t.Medico_Id)
                .ForeignKey("dbo.TipoConsulta", t => t.TipoConsulta_Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.TipoConsulta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TempoConsulta", "TipoConsulta_Id", "dbo.TipoConsulta");
            DropForeignKey("dbo.TempoConsulta", "Medico_Id", "dbo.Medico");
            DropForeignKey("dbo.Consulta", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Consulta", "TipoConsulta_Id", "dbo.TipoConsulta");
            DropForeignKey("dbo.Consulta", "Medico_Id", "dbo.Medico");
            DropForeignKey("dbo.Medico", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Medico", "idEspecialidade", "dbo.Especialidade");
            DropForeignKey("dbo.Medico", "idCidade", "dbo.Cidade");
            DropIndex("dbo.TempoConsulta", new[] { "TipoConsulta_Id" });
            DropIndex("dbo.TempoConsulta", new[] { "Medico_Id" });
            DropIndex("dbo.Medico", new[] { "idUsuario" });
            DropIndex("dbo.Medico", new[] { "idEspecialidade" });
            DropIndex("dbo.Medico", new[] { "idCidade" });
            DropIndex("dbo.Consulta", new[] { "Usuario_Id" });
            DropIndex("dbo.Consulta", new[] { "TipoConsulta_Id" });
            DropIndex("dbo.Consulta", new[] { "Medico_Id" });
            DropTable("dbo.TempoConsulta");
            DropTable("dbo.TipoConsulta");
            DropTable("dbo.Usuario");
            DropTable("dbo.Especialidade");
            DropTable("dbo.Medico");
            DropTable("dbo.Consulta");
            DropTable("dbo.Cidade");
        }
    }
}
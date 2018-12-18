namespace GestionToxicologica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denunciasContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Denuncias",
                c => new
                    {
                        Id_denuncia = c.Int(nullable: false, identity: true),
                        Comuna_Id_Comuna = c.Int(nullable: false),
                        Comuna_Nombre = c.String(),
                        Id_Comuna = c.Int(nullable: false),
                        Estado_Id_Estado = c.Int(nullable: false),
                        Estado_Nombre_Estado = c.String(),
                        Id_Estado = c.Int(nullable: false),
                        Fecha_Ingreso = c.DateTime(nullable: false),
                        Fecha_Cierre = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false),
                        CorreoUsuario = c.String(),
                    })
                .PrimaryKey(t => t.Id_denuncia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Denuncias");
        }
    }
}

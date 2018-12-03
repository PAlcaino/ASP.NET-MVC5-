namespace GestionToxicologica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isExpert", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isExpert");
        }
    }
}

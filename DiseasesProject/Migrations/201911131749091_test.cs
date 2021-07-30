namespace DiseasesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diets", "Diet1", c => c.String(nullable: false));
            AlterColumn("dbo.Diseases", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Diseases", "GeneralInfo", c => c.String(nullable: false));
            AlterColumn("dbo.Precantions", "Info", c => c.String(nullable: false));
            AlterColumn("dbo.Sports", "Info", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sports", "Info", c => c.String());
            AlterColumn("dbo.Precantions", "Info", c => c.String());
            AlterColumn("dbo.Diseases", "GeneralInfo", c => c.String());
            AlterColumn("dbo.Diseases", "Name", c => c.String());
            AlterColumn("dbo.Diets", "Diet1", c => c.String());
        }
    }
}

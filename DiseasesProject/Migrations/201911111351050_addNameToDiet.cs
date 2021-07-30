namespace DiseasesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameToDiet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diets", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diets", "Name");
        }
    }
}

namespace DiseasesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAgeTo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiseaseDiets", "AgeFrom", c => c.Int());
            AddColumn("dbo.DiseaseDiets", "AgeTo", c => c.Int());
            DropColumn("dbo.DiseaseDiets", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiseaseDiets", "Age", c => c.Int());
            DropColumn("dbo.DiseaseDiets", "AgeTo");
            DropColumn("dbo.DiseaseDiets", "AgeFrom");
        }
    }
}

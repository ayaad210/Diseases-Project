namespace DiseasesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDupAtt : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DiseaseDiets", name: "DiseaseID", newName: "Disease_ID");
            RenameIndex(table: "dbo.DiseaseDiets", name: "IX_DiseaseID", newName: "IX_Disease_ID");
            DropColumn("dbo.DiseaseDiets", "dlID");
            DropColumn("dbo.DiseaseDiets", "PreID");
            DropColumn("dbo.DiseaseDiets", "Sportsid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiseaseDiets", "Sportsid", c => c.Int());
            AddColumn("dbo.DiseaseDiets", "PreID", c => c.Int());
            AddColumn("dbo.DiseaseDiets", "dlID", c => c.Int());
            RenameIndex(table: "dbo.DiseaseDiets", name: "IX_Disease_ID", newName: "IX_DiseaseID");
            RenameColumn(table: "dbo.DiseaseDiets", name: "Disease_ID", newName: "DiseaseID");
        }
    }
}

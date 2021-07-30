namespace DiseasesProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfulldb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Diet1 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DiseaseDiets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DiseaseID = c.Int(),
                        dlID = c.Int(),
                        Age = c.Int(),
                        Gender = c.Boolean(),
                        PreID = c.Int(),
                        Sportsid = c.Int(),
                        Diet_ID = c.Int(),
                        Precantion_id = c.Int(),
                        Sport_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Diets", t => t.Diet_ID)
                .ForeignKey("dbo.Diseases", t => t.DiseaseID)
                .ForeignKey("dbo.Precantions", t => t.Precantion_id)
                .ForeignKey("dbo.Sports", t => t.Sport_id)
                .Index(t => t.DiseaseID)
                .Index(t => t.Diet_ID)
                .Index(t => t.Precantion_id)
                .Index(t => t.Sport_id);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeneralInfo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Precantions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Info = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Info = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DiseaseDiets", "Sport_id", "dbo.Sports");
            DropForeignKey("dbo.DiseaseDiets", "Precantion_id", "dbo.Precantions");
            DropForeignKey("dbo.DiseaseDiets", "DiseaseID", "dbo.Diseases");
            DropForeignKey("dbo.DiseaseDiets", "Diet_ID", "dbo.Diets");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DiseaseDiets", new[] { "Sport_id" });
            DropIndex("dbo.DiseaseDiets", new[] { "Precantion_id" });
            DropIndex("dbo.DiseaseDiets", new[] { "Diet_ID" });
            DropIndex("dbo.DiseaseDiets", new[] { "DiseaseID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sports");
            DropTable("dbo.Precantions");
            DropTable("dbo.Diseases");
            DropTable("dbo.DiseaseDiets");
            DropTable("dbo.Diets");
        }
    }
}

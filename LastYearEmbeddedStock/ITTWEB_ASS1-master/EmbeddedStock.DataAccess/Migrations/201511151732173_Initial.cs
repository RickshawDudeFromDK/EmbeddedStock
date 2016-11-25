namespace EmbeddedStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComponentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminComment = c.String(),
                        ComponentNumber = c.Int(nullable: false),
                        UserComment = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComponentTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.ComponentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        ComponentName = c.String(),
                        ComponentInfo = c.String(),
                        CategoryId = c.Int(nullable: false),
                        DataSheet = c.String(),
                        Image = c.Binary(),
                        ManufacturerLink = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComponentCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.InfoPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComponentId = c.Int(nullable: false),
                        LoanDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsEmailSent = c.Boolean(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        LoanOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.LoanOwnerId, cascadeDelete: true)
                .Index(t => t.ComponentId)
                .Index(t => t.LoanOwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelephoneNumber = c.String(),
                        Email = c.String(),
                        StudentNumber = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanInformations", "LoanOwnerId", "dbo.Users");
            DropForeignKey("dbo.LoanInformations", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Components", "TypeId", "dbo.ComponentTypes");
            DropForeignKey("dbo.ComponentTypes", "CategoryId", "dbo.ComponentCategories");
            DropIndex("dbo.LoanInformations", new[] { "LoanOwnerId" });
            DropIndex("dbo.LoanInformations", new[] { "ComponentId" });
            DropIndex("dbo.ComponentTypes", new[] { "CategoryId" });
            DropIndex("dbo.Components", new[] { "TypeId" });
            DropTable("dbo.Users");
            DropTable("dbo.LoanInformations");
            DropTable("dbo.InfoPages");
            DropTable("dbo.ComponentTypes");
            DropTable("dbo.Components");
            DropTable("dbo.ComponentCategories");
        }
    }
}

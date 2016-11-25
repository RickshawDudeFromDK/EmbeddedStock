namespace EmbeddedStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Components", "LoanerId", c => c.Int());
            CreateIndex("dbo.Components", "LoanerId");
            AddForeignKey("dbo.Components", "LoanerId", "dbo.Loaners", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "LoanerId", "dbo.Loaners");
            DropIndex("dbo.Components", new[] { "LoanerId" });
            DropColumn("dbo.Components", "LoanerId");
        }
    }
}

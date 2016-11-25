namespace EmbeddedStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedHasBeenReturnAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LoanInformations", "HasBeenReturn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanInformations", "HasBeenReturn", c => c.Boolean(nullable: false));
        }
    }
}

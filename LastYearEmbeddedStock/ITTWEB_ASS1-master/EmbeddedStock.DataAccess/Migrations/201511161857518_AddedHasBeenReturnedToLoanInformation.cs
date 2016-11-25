namespace EmbeddedStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHasBeenReturnedToLoanInformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanInformations", "HasBeenReturn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanInformations", "HasBeenReturn");
        }
    }
}

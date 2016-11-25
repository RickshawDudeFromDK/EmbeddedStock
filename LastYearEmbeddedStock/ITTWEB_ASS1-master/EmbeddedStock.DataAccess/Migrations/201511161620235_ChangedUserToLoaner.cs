namespace EmbeddedStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserToLoaner : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Loaners");
            DropColumn("dbo.Loaners", "IsAdmin");
            DropColumn("dbo.Loaners", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loaners", "Password", c => c.String());
            AddColumn("dbo.Loaners", "IsAdmin", c => c.Boolean(nullable: false));
            RenameTable(name: "dbo.Loaners", newName: "Users");
        }
    }
}

using EmbeddedStock.DataAccess.Models;
using System.Data.Entity;
namespace EmbeddedStock.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentCategory> ComponentCategories { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<Loaner> Loaners { get; set; }
        public DbSet<LoanInformation> LoanInformations { get; set; }

        public DbSet<InfoPage> InfoPages { get; set; }
    }
}

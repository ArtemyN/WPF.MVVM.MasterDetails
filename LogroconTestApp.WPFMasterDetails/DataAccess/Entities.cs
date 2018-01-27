using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DomainModel;

namespace DataAccess
{
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Cities> Sities { get; set; }
        public DbSet<Streets> Employees { get; set; }
    }
}
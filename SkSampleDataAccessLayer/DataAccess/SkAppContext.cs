using System.Data.Entity;
using SkSampleDataAccessLayer.DataAccess.Entities;

namespace SkSampleDataAccessLayer.DataAccess
{
    public class SkAppContext : DbContext
    {
        public SkAppContext(string connectName) : base(connectName)
        {
            Database.SetInitializer<SkAppContext>(null); //new CreateDatabaseIfNotExists<SkAppContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
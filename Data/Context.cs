using Data.Model;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Data Namespace
/// </summary>
namespace Data
{
    /// <summary>
    /// ProductContext
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Connection String
        /// </summary> 
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentACar;Integrated Security=True;";

        /// <summary>
        /// Cars
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Customers
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Context()
        {
            // Create the database automaticly
            Database.EnsureCreated();
        }

        /// <summary>
        /// Connection string to Microsoft SQL Server
        /// </summary> 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
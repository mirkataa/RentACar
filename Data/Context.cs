using Data.Model;
using Microsoft.EntityFrameworkCore;

///<summary>
///Пронстранство от имена на базата данни
///</summary>
namespace Data
{
    ///<summary>
    ///Публичен клас контекст, наследяващ
    ///</summary>
    public class Context : DbContext
    {
        ///<summary>
        ///Настройка за връзка към базата данни
        ///</summary> 
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentACar;Integrated Security=True;";

        ///<summary>
        ///DbContext свойство на класа от данни за колите
        ///</summary>
        public DbSet<Car> Cars { get; set; }

        ///<summary>
        ///DbContext свойство на класа от данни за клиентите
        ///</summary>
        public DbSet<Customer> Customers { get; set; }

        ///<summary>
        ///Публичен конструктор на класа
        ///</summary>
        public Context()
        {
            //Автоматично създаване на базата данни
            Database.EnsureCreated();
        }

        ///<summary>
        ///Свързване към Microsoft SQL Server
        ///</summary> 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
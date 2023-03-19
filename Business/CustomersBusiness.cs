using Data;
using Data.Model;

/// <summary>
/// ѕронстранство от имена на бинес логиката
/// </summary>
namespace Business
{
    public class CustomersBusiness
    {
        private Context context { get; set; }

        /// <summary>
        /// Get all customers from the database
        /// </summary>
        public List<Customer> GetAll()
        {
            using (context = new Context())
            {
                return context.Customers.ToList();
            }
        }

        /// <summary>
        /// Get single customer from the database by Id
        /// </summary>
        public Customer Get(int id)
        {
            using (context = new Context())
            {
                return context.Customers.Find(id);
            }
        }

        /// <summary>
        /// Add a customer to the database
        /// </summary>
        public void Add(Customer customer)
        {
            using (context = new Context())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update a single customer in the database by Id.
        /// </summary>
        public void Update(Customer customer)
        {
            using (context = new Context())
            {
                var item = context.Customers.Find(customer.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(customer);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Delete a customer from the database by Id
        /// </summary>
        public void Delete(int id)
        {
            using (context = new Context())
            {
                var customer = context.Customers.Find(id);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }
         
        

    }
}

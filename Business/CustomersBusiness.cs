using Data;
using Data.Model;

///<summary>
///Пронстранство от имена на бизнес логиката
///</summary>
namespace Business
{
    ///<summary>
    ///Публичен клас на бизнес логиката за клиенти
    ///</summary>
    public class CustomersBusiness
    {
        private Context context { get; set; }

        ///<summary>
        ///Връща всички клиенти от базата данни
        ///</summary>
        public List<Customer> GetAll()
        {
            using (context = new Context())
            {
                return context.Customers.ToList();
            }
        }

        ///<summary>
        ///Връща един клиент от базата данни по идентификационно поле
        ///</summary>
        ///<param name="id">id на клиента, който искаме</param>
        ///<returns>клиент от базата данни</returns>
        public Customer Get(int id)
        {
            using (context = new Context())
            {
                return context.Customers.Find(id);
            }
        }

        ///<summary>
        ///Добавяне на клиент към базата данни
        ///</summary>
        ///<param name="customer">клиента, който искаме да добавим</param>
        public void Add(Customer customer)
        {
            using (context = new Context())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        ///<summary>
        ///Актуализация на клиент към базата данни
        ///</summary>
        ///<param name="customer">клиената, който искаме да ъпдейтнем</param>
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

        ///<summary>
        ///Изтриване на клиент от базата данни
        ///</summary>
        ///<param name="id">id на клиента, който искаме да премахнем</param>
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

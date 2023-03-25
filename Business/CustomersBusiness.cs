using Data;
using Data.Model;

///<summary>
///������������� �� ����� �� ������ ��������
///</summary>
namespace Business
{
    ///<summary>
    ///�������� ���� �� ������ �������� �� �������
    ///</summary>
    public class CustomersBusiness
    {
        private Context context { get; set; }

        ///<summary>
        ///����� ������ ������� �� ������ �����
        ///</summary>
        public List<Customer> GetAll()
        {
            using (context = new Context())
            {
                return context.Customers.ToList();
            }
        }

        ///<summary>
        ///����� ���� ������ �� ������ ����� �� ���������������� ����
        ///</summary>
        ///<param name="id">id �� �������, ����� ������</param>
        ///<returns>������ �� ������ �����</returns>
        public Customer Get(int id)
        {
            using (context = new Context())
            {
                return context.Customers.Find(id);
            }
        }

        ///<summary>
        ///�������� �� ������ ��� ������ �����
        ///</summary>
        ///<param name="customer">�������, ����� ������ �� �������</param>
        public void Add(Customer customer)
        {
            using (context = new Context())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        ///<summary>
        ///������������ �� ������ ��� ������ �����
        ///</summary>
        ///<param name="customer">��������, ����� ������ �� ���������</param>
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
        ///��������� �� ������ �� ������ �����
        ///</summary>
        ///<param name="id">id �� �������, ����� ������ �� ���������</param>
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

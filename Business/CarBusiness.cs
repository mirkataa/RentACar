using Data;
using Data.Model;

///<summary>
///������������� �� ����� �� ������ ��������
///</summary>
namespace Business
{
    ///<summary>
    ///�������� ���� �� ������ �������� �� ����
    ///</summary>
    public class CarBusiness
    {
        private Context context { get; set; }

        ///<summary>
        ///����� ������ ���� �� ������ �����
        ///</summary>
        public List<Car> GetAll()
        {
            using (context = new Context())
            {
                return context.Cars.ToList();
            }
        }

        ///<summary>
        ///����� ���� ���� �� ������ ����� �� ���������������� ���� 
        ///</summary>
        ///<param name="id">id �� ������,����� ������</param>
        ///<returns>������������ �� ������</returns>
        public Car Get(int id)
        {
            using (context = new Context())
            {
                return context.Cars.Find(id);
            }
        }

        ///<summary>
        ///�������� �� ���� ��� ������ �����
        ///</summary>
        ///<param name="car">������, ����� �� ���� ��������</param>
        public void Add(Car car)
        {
            using (context = new Context())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        ///<summary>
        ///������������ �� ���� ��� ������ �����
        ///</summary>
        ///<param name="car">���� ����� �� ���� ����������</param>
        public void Update(Car car)
        {
            using (context = new Context())
            {
                var item = context.Cars.Find(car.Id);
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(car);
                    context.SaveChanges();
                }
            }
        }

        ///<summary>
        ///��������� �� ���� �� ������ �����
        ///</summary>
        ///<param name="id">id �� ������</param>
        public void Delete(int id)
        {
            using (context = new Context())
            {
                var car = context.Cars.Find(id);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
            }
        }

    }
}

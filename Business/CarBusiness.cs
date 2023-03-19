using Data;
using Data.Model;

/// <summary>
/// Простраснство с имена на бинес логиката
/// </summary>
namespace Business
{
    /// <summary>
    /// Публичен клас а бизнес логиката за коли
    /// </summary>
    public class CarBusiness
    {
        private Context context { get; set; }

        /// <summary>
        /// Връща вси1ки коли от базата данни
        /// </summary>
        public List<Car> GetAll()
        {
            using (context = new Context())
            {
                return context.Cars.ToList();
            }
        }

        /// <summary>
        /// Връща една кола от базата данни по идентификационно поле 
        /// </summary>
        public Car Get(int id)
        {
            using (context = new Context())
            {
                return context.Cars.Find(id);
            }
        }

        /// <summary>
        /// Добавяне на кола кум базта данни
        /// </summary>
        public void Add(Car car)
        {
            using (context = new Context())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Актуализаци на кола кум базта данни
        /// </summary>
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

        /// <summary>
        /// Изтриване на кола кум базта данни
        /// </summary>
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

using Data;
using Data.Model;

/// <summary>
/// CarBusiness Namespace
/// </summary>
namespace Business
{
    public class CarBusiness
    {
        private Context context { get; set; }

        /// <summary>
        /// Get all cars from the database
        /// </summary>
        public List<Car> GetAll()
        {
            using (context = new Context())
            {
                return context.Cars.ToList();
            }
        }

        /// <summary>
        /// Get single cars from the database by Id
        /// </summary>
        public Car Get(int id)
        {
            using (context = new Context())
            {
                return context.Cars.Find(id);
            }
        }

        /// <summary>
        /// Add a car to the database
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
        /// Update a single car in the database by Id.
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
        /// Deleate a car from the database by Id
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

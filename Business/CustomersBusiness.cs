using Data;
using Data.Model;

/// <summary>
/// Business Namespace
/// </summary>
namespace Business
{
    public class CustomersBusiness
    {
        private Context context { get; set; }

        /// <summary>
        /// Get all cars from the database
        /// </summary>
        public List<Car> GetAll()
        {
            using (carContext = new Context())
            {
                return context.Cars.ToList();
            }
        }

        /// <summary>
        /// Get single cars from the database by Id
        /// </summary>
        public Car Get(int id)
        {
            using (carContext = new CarContext())
            {
                return carContext.Cars.Find(id);
            }
        }

        /// <summary>
        /// Add a car to the database
        /// </summary>
        public void AddCar(Product car)
        {
            using (carContext = new CarContext())
            {
                carContext.Cars.Add(car);
                carContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update a single car in the database by Id.
        /// </summary>
        public void UpdateCar(Product car)
        {
            using (carContext = new CarContext())
            {
                var item = carContext.Cars.Find(car.Id);
                if (item != null)
                {
                    carContext.Entry(item).CurrentValues.SetValues(car);
                    carContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deleate a car from the database by Id
        /// </summary>
        public void DeleteCar(int id)
        {
            using (carContext = new CarContext())
            {
                var car = carContext.Cars.Find(id);
                if (car != null)
                {
                    carContext.Cars.Remove(car);
                    carContext.SaveChanges();
                }
            }
        }
         
        

    }
}

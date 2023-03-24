using Business;
using Data;
using Data.Model;
using Newtonsoft.Json;
using System;
namespace UnitTests
{
    /// <summary>
    /// NUnit тестове за методите в CarBusiness
    /// </summary>
    public class CarBusinessTests
    {
        private Context context;
        private CarBusiness carBusiness;

        /// <summary>
        /// Инициализираме контекста и car business обекта
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            context = new Context();
            carBusiness = new CarBusiness();
        }

        /// <summary>
        /// Тест проверяващ дали методът GetAll връща всички коли от базата данни
        /// </summary>
        [Test]
        public void GetAll_ReturnsAllCars()
        {
            // Arrange
            var expectedCars = JsonConvert.SerializeObject(context.Cars.OrderBy(c => c.Id));

            // Act
            var actualCars = JsonConvert.SerializeObject(carBusiness.GetAll().OrderBy(c => c.Id));

            // Assert
            CollectionAssert.AreEqual(expectedCars, actualCars);
        }

        /// <summary>
        /// Тест проверяващ дали методът Get връща правилната кола от базата данни
        /// </summary>
        [Test]
        public void Get_ReturnsCorrectCar()
        {
            // Arrange
            var testCar = new Car { Brand = "Test Brand", RgNum = "Test RgNum", Km = 1000, IsRented = false };
            context.Cars.Add(testCar);
            context.SaveChanges();
            var car = context.Cars.First();

            // Act
            var actualCar = carBusiness.Get(car.Id);
           
            // Assert
            Assert.AreEqual(car, actualCar);

            // Clean up
            context.Cars.Remove(testCar);
            context.SaveChanges();
        }

        /// <summary>
        /// Тест проверяващ дали методът Add добавя коли в базата данни
        /// </summary>
        [Test]
        public void Add_AddsNewCarToDatabase()
        {
            // Arrange
            var expectedCar = new Car { Brand = "Test Brand", RgNum = "Test RgNum", Km = 1000, IsRented = false };

            // Act
            carBusiness.Add(expectedCar);
            var actualCar = context.Cars.OrderBy(c => c.Id).Last();

            // Assert
            Assert.AreEqual(expectedCar.Brand, actualCar.Brand);
            Assert.AreEqual(expectedCar.RgNum, actualCar.RgNum);
            Assert.AreEqual(expectedCar.Km, actualCar.Km);
            Assert.AreEqual(expectedCar.IsRented, actualCar.IsRented);

            // Clean up
            context.Cars.Remove(actualCar);
            context.SaveChanges();
        }

        /// <summary>
        /// Тест проверяващ дали методът Update обновява правилно инфорамацията на дадена кола от базата данни
        /// </summary>
        [Test]
        public void Update_UpdatesCarInDatabase()
        {
            // Arrange
            var testCar = new Car { Brand = "Test Brand", RgNum = "Test RgNum", Km = 1000, IsRented = false };
            context.Cars.Add(testCar);
            context.SaveChanges();
            var car = context.Cars.OrderBy(c => c.Id).First();
            var expectedCar = new Car { Id = car.Id, Brand = "New Brand", RgNum = "New RgNum", Km = 2000, IsRented = true };

            // Act
            carBusiness.Update(expectedCar);
            context.Dispose();
            context = new Context();
            var actualCar = context.Cars.Find(car.Id);

            // Assert
            Assert.IsNotNull(actualCar);
            Assert.AreEqual(expectedCar.Id, actualCar.Id);
            Assert.AreEqual(expectedCar.Brand, actualCar.Brand);
            Assert.AreEqual(expectedCar.RgNum, actualCar.RgNum);
            Assert.AreEqual(expectedCar.Km, actualCar.Km);
            Assert.AreEqual(expectedCar.IsRented, actualCar.IsRented);

            // Clean up
            carBusiness.Update(car);
            context.Cars.Remove(testCar);
            context.SaveChanges();
        }

        /// <summary>
        /// Тест проверяващ дали методът Delete премахва дадена кола от базата данни
        /// </summary>
        [Test]
        public void Delete_DeletesCarFromDatabase()
        {
            // Arrange
            var car = new Car { Brand = "Test Brand", RgNum = "Test RgNum", Km = 1000, IsRented = false };
            context.Cars.Add(car);
            context.SaveChanges();

            // Act
            carBusiness.Delete(car.Id);
            context.Dispose();
            context = new Context();
            var actualCar = context.Cars.Find(car.Id);

            // Assert
            Assert.IsNull(actualCar);
            context.SaveChanges();
        }

        /// <summary>
        /// Почистваме базата данни
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}

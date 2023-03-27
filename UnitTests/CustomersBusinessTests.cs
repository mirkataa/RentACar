using Business;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace UnitTests
{
    ///<summary>
    ///NUnit тестове за методите в CustomersBusiness
    ///</summary>
    public class CustomersBusinessTests
    {
        private Context context;
        private CustomersBusiness customersBusiness;

        ///<summary>
        ///Инициализираме контекста и customers business обекта
        ///</summary>
        [OneTimeSetUp]
        public void Setup()
        {
            context = new Context();
            customersBusiness = new CustomersBusiness();
        }

        ///<summary>
        ///Тест проверяващ дали методът GetAll връща всички клиенти от базата данни
        ///</summary>
        [Test]
        public void GetAll_ReturnsAllCustomers()
        {
            // Arrange
            var expectedCustomers = JsonConvert.SerializeObject(context.Customers.OrderBy(c => c.Id));

            // Act
            var actualCustomers = JsonConvert.SerializeObject(customersBusiness.GetAll().OrderBy(c => c.Id));

            // Assert
            CollectionAssert.AreEqual(expectedCustomers, actualCustomers);
        }

        ///<summary>
        ///Тест проверяващ дали методът Get връща правилният клиент от базата данни
        ///</summary>
        [Test]
        public void Get_ReturnsCorrectCustomer()
        {
            // Arrange
            var testCar = new Car { Brand = "Test Car", RgNum = "123456", Km = 5000, IsRented = false };
            context.Cars.Add(testCar);
            context.SaveChanges();
            var testCustomer = new Customer
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "test@test.com",
                Phone = "123-456-7890",
                Car = testCar.Id,
                From = DateTime.Now,
                To = DateTime.Now.AddDays(1)
            };

            context.Customers.Add(testCustomer);
            context.SaveChanges();
            var customer = context.Customers.First();

            // Act
            var actualCustomer = customersBusiness.Get(customer.Id);

            // Assert
            Assert.AreEqual(customer, actualCustomer);

            context.Customers.Remove(testCustomer);
            context.SaveChanges();
            context.Cars.Remove(testCar);
            context.SaveChanges();
        }

        ///<summary>
        ///Тест проверяващ дали методът Add добавя клиент в базата данни
        ///</summary>
        [Test]
        public void Add_AddsNewCustomerToDatabase()
        {
            // Arrange
            var testCar = new Car { Brand = "Test Car", RgNum = "123456", Km = 5000, IsRented = false };
            context.Cars.Add(testCar);
            context.SaveChanges();
            var expectedCustomer = new Customer
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "test@test.com",
                Phone = "123-456-7890",
                Car = testCar.Id,
                From = DateTime.Now,
                To = DateTime.Now.AddDays(1)
            };

            // Act
            customersBusiness.Add(expectedCustomer);
            var actualCustomer = context.Customers.OrderBy(c => c.Id).Last();

            // Assert
            Assert.AreEqual(expectedCustomer.FirstName, actualCustomer.FirstName);
            Assert.AreEqual(expectedCustomer.LastName, actualCustomer.LastName);
            Assert.AreEqual(expectedCustomer.Email, actualCustomer.Email);
            Assert.AreEqual(expectedCustomer.Phone, actualCustomer.Phone);
            Assert.AreEqual(expectedCustomer.Car, actualCustomer.Car);
            Assert.AreEqual(expectedCustomer.From.ToString("MM/dd/yyyy hh:mm:ss.00"), actualCustomer.From.ToString("MM/dd/yyyy hh:mm:ss.00"));
            Assert.AreEqual(expectedCustomer.To.ToString("MM/dd/yyyy hh:mm:ss.00"), actualCustomer.To.ToString("MM/dd/yyyy hh:mm:ss.00"));


            // Clean up
            context.Customers.Remove(actualCustomer);
            context.SaveChanges();
            context.Cars.Remove(testCar);
            context.SaveChanges();
        }

        ///<summary>
        ///Тест проверяващ дали методът Update обновява правилно инфорамацията на даден клиент от базата данни
        ///</summary>
        [Test]
        public void Update_UpdatesCustomerInDatabase()
        {
            // Arrange
            var testCar = new Car { Brand = "Test Car", RgNum = "123456", Km = 5000, IsRented = false };
            context.Cars.Add(testCar);
            var testCar2 = new Car { Brand = "Test Car2", RgNum = "1234567", Km = 50000, IsRented = false };
            context.Cars.Add(testCar2);
            context.SaveChanges();
            var testCustomer = new Customer
            {
                FirstName = "Test",
                LastName = "Customer",
                Email = "test@test.com",
                Phone = "1234567890",
                Car = testCar.Id,
                From = new DateTime(2023, 3, 25, 10, 0, 0),
                To = new DateTime(2023, 3, 26, 12, 0, 0)
            };
            context.Customers.Add(testCustomer);
            context.SaveChanges();
            var customer = context.Customers.OrderBy(c => c.Id).First();
            var expectedCustomer = new Customer
            {
                Id = customer.Id,
                FirstName = "New",
                LastName = "Customer",
                Email = "new@test.com",
                Phone = "9876543210",
                Car = testCar2.Id,
                From = new DateTime(2023, 3, 25, 10, 0, 0),
                To = new DateTime(2023, 3, 26, 12, 0, 0)
            };

            // Act
            customersBusiness.Update(expectedCustomer);
            context.Dispose();
            context = new Context();
            var actualCustomer = context.Customers.AsNoTracking().SingleOrDefault(a => a.Id == customer.Id);

            // Assert
            Assert.IsNotNull(actualCustomer);
            Assert.AreEqual(expectedCustomer.Id, actualCustomer.Id);
            Assert.AreEqual(expectedCustomer.FirstName, actualCustomer.FirstName);
            Assert.AreEqual(expectedCustomer.LastName, actualCustomer.LastName);
            Assert.AreEqual(expectedCustomer.Email, actualCustomer.Email);
            Assert.AreEqual(expectedCustomer.Phone, actualCustomer.Phone);

            // Clean up
            customersBusiness.Update(customer);
            context.Customers.Remove(testCustomer);
            context.SaveChanges();
            context.Cars.Remove(testCar);
            context.Cars.Remove(testCar2);
            context.SaveChanges();
        }

        ///<summary>
        ///Тест проверяващ дали методът Delete премахва даден клиент от базата данни
        ///</summary>
        [Test]
        public void Delete_DeletesCustomerFromDatabase()
        {
            // Arrange
            var testCar = new Car { Brand = "Test Car", RgNum = "123456", Km = 5000, IsRented = false };
            context.Cars.Add(testCar);
            context.SaveChanges();
            var customer = new Customer
            {
                FirstName = "Test",
                LastName = "Customer",
                Email = "test@test.com",
                Phone = "1234567890",
                Car = testCar.Id,
                From = new DateTime(2023, 3, 25, 10, 0, 0),
                To = new DateTime(2023, 3, 26, 12, 0, 0)
            };
            context.Customers.Add(customer);
            context.SaveChanges();

            // Act
            customersBusiness.Delete(customer.Id);

            context.Dispose();
            context = new Context();
            var actualCustomer = context.Customers.Find(customer.Id);

            // Assert
            Assert.IsNull(actualCustomer);

            // Clean up
            context.Cars.Remove(testCar);
            context.SaveChanges();
        }

        ///<summary>
        ///Почистваме базата данни
        ///</summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            context.Dispose();
        }

    }
}

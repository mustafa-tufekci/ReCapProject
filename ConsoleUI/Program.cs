using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarCRUDTest();
            //UserTest();

            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName="Ahmet", LastName="Küçük", Email="ahmet.kucuk@gmail.com", Password="987654321"});

            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer {UserId=1002, CompanyName="Kücük Holding" });

            RentalManager rental = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental { CarId = 2, CustomerId = 1, RentDate = new DateTime(2022, 07, 15), ReturnDate = new DateTime(2022, 07, 22) };
            //rental.Add(rental1);

            //var result = rental.Get(1);
            //Console.WriteLine(result.Data.RentDate);
            CarCRUDTest();


        }

        //private static void UserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    //userManager.Add(new User { FirstName="Mustafa",LastName="Tüfekçi",Email="mustafa.tufekci@gmail.com", Password="qwertyklavye12345"});
        //    userManager.Add(new User { FirstName = "Ensar", LastName = "Tüfekçi", Email = "ensar.tufekci@gmail.com", Password = "123456789" });
        //    userManager.Delete(new User { Id = 1, FirstName = "Mustafa", LastName = "Tüfekçi", Email = "mustafa.tufekci@gmail.com", Password = "qwertyklavye12345" });
        //    var result = userManager.GetAll();
        //    Console.WriteLine(result.Message);
        //    foreach (var user in result.Data)
        //    {
        //        Console.WriteLine(user.FirstName + "/" + user.LastName + "/" + user.Email + "/" + user.Password);
        //    }
        //}

        private static void CarCRUDTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 2, ColorId = 2, CarName = "Mustang", ModelYear = 2015, DailyPrice = 2000000 });
            //carManager.Update(new Car { Id = 1002, BrandId = 4, ColorId = 2, CarName = "Mustang", ModelYear = 2015, DailyPrice = 2000000 });

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3} / {4}", car.ModelName, car.BrandName, car.ColorName, car.DailyPrice, car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
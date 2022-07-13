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
        }

        private static void CarCRUDTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 2, ColorId = 2, CarName = "Mustang", ModelYear = 2015, DailyPrice = 2000000 });
            carManager.Update(new Car { Id = 1002, BrandId = 4, ColorId = 2, CarName = "Mustang", ModelYear = 2015, DailyPrice = 2000000 });

            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
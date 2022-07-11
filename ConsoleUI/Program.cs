using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car { Id=6, BrandId= 2, ColorId= 1, DailyPrice = 1000000, Description="TOGG", ModelYear=2022 };
            Car car2 = new Car { Id = 5, BrandId = 4, ColorId = 2, DailyPrice = 15000, Description = "Klasik Araba", ModelYear = 2022 };
            Car car3 = new Car { Id = 4, ColorId = 5, BrandId = 2, DailyPrice = 550000, Description = "Kartal", ModelYear = 1990 };

            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Delete(car1);
            carManager.Update(new Car { Id = 5, BrandId = 4, ColorId = 2, DailyPrice = 15000, Description = "Modern Araba", ModelYear = 2022 });


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetById(5))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
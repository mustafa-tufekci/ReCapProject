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
            Car car1 = new Car { BrandId = 2, ColorId = 1, DailyPrice = 1000000, CarName = "TOGG", ModelYear = 2022 };
            Car car2 = new Car { BrandId = 4, ColorId = 2, DailyPrice = 15000, CarName = "Klasik Araba", ModelYear = 2022 };
            Car car3 = new Car { BrandId = 2, ColorId = 5, DailyPrice = 550000, CarName = "Kartal", ModelYear = 1990 };

            CarManager carManager = new CarManager(new EfCarDal());
            
            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("-----------------------------");

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.ShowAll())
            {
                Console.WriteLine(car.Description);

            }

            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine(car.Description + car.BrandId);

            }

        }
    }
}

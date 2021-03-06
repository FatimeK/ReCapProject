using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer { CompanyName = "RentCarX",UserId = 1};
            Customer customer2 = new Customer { CompanyName = "RentCarY", UserId = 2 };




            Brand newBrand = new Brand()
            {
                BrandName = "Doblo",
                BrandId = 6
                
            };
            
            //brandManager.AddNewBrandToDb(newBrand);
            //brandManager.DeleteBrandToDb(newBrand);



            Car newcar = new Car()
            {
                CarId = 6,
                CarName = "Doblo A",
                BrandId = 6,
                ColorId = 2,
                DailyPrice = 162,
                Description = "Tosbağa",
                ModelYear = 2000
            };
            //carManager.Add(newcar);

            var result = carManager.GetCarDetails();

            if(result.Success == true)
            {
                foreach (var car in result.Data)
                {

                    Console.WriteLine("Car Name: {0}\nBrand Name: {1}\n,Color Name: Black,Daily Price: {3}\n*****************",car.CarName,car.BrandName,car.DailyPrice);
                    Console.WriteLine(result.Message + "FGSAHYFLGDAUG");

                }
                


            }
            else
            {
                Console.WriteLine(result.Message);
            }




            //carManager.Add(new Car { CarName = "Renault", BrandId = 2, ColorId = 3, ModelYear = 1992, DailyPrice = 110, Description = "oldbutgold",Id = 4 });



            //DailyPrice(carManager);

        }

        private static void DailyPrice(CarManager carManager)
        {
            var result1 = carManager.GetByDailyPrice(110);
            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.DailyPrice);
                //Console.WriteLine(car.DailyPrice + "" + car.CarName + "" + car.BrandId);
            }
        }

        //private static void CarDailyPrice(CarManager carManager)
        //{
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.Id + "" + car.Description);

        //    }
        //}
    }
}

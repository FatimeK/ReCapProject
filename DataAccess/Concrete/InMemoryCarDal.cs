using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Car> _tempDelete;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                //brands 1: Audi , 2: Nissan,3: Ford,4: Alfa Romeo,5:Acura
                //colors 1:Black , 2: White,3:Gray,4:blue
                new Car{CarId = 1,BrandId = 1,ColorId = 3,DailyPrice = 100,Description = "Audi",ModelYear = 2020},
                new Car{CarId = 2,BrandId = 4,ColorId = 2,DailyPrice = 100,Description = "Alfa Romeo",ModelYear = 2020},
                new Car{CarId = 3,BrandId = 5,ColorId = 1,DailyPrice = 100,Description = "Acura",ModelYear = 2018},
                new Car{CarId = 5,BrandId = 1,ColorId = 3,DailyPrice = 100,Description = "Audi",ModelYear = 2015},
                new Car{CarId = 6,BrandId = 2,ColorId = 2,DailyPrice = 100,Description = "Nissan",ModelYear = 2008},
                new Car{CarId = 7,BrandId = 3,ColorId = 1,DailyPrice = 100,Description = "Ford",ModelYear = 2006}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);


        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filer = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(car => car.BrandId == brandId).ToList();

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}

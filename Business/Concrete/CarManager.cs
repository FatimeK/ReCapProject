
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        
        public List<Car> GetById(int brandId)
        {
            return _iCarDal.GetById(brandId);
        }

        public List<Car> ShowAll()
        {
            return _iCarDal.GetAll();
        }
    }
}

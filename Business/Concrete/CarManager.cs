
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        //public IResult Add(Car carName)
        //{
        //    if(carName.Description.Length < 2 && carName.DailyPrice < 0)
        //    {
        //        return new ErrorResult(Messages.CarNameInvalid);
        //    }
        //    _iCarDal.Add(carName);

        //    return new SuccessResult(Messages.CarAdded);
        //}

        public void Delete(Car carName)
        {
            _iCarDal.Delete(carName);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //Şartlarımız
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.CarsListed);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
           
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            
            return new SuccessDataResult<List<CarDetailDto>>( _iCarDal.GetCarDetails(),Messages.CarsListed);
        }

        [ValidationAspect(typeof(CarValidatior))]
        public IResult Update(Car carName)
        {
            return new SuccessResult("Car Updated");
            _iCarDal.Update(carName);
        }

        public IDataResult<List<Car>> GetByDailyPrice(int dailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.DailyPrice == dailyPrice));
        }

        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(CarValidatior))]
        public IResult Add(Car car)
        {
            _iCarDal.Add(car);
            return new SuccessResult("Car Added");

        }

        IResult ICarService.Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult("Car Deleted");
        }
    }
}

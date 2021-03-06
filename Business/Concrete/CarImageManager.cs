using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal carImageDal;
        

        public CarImageManager(ICarImageDal carImageDal)
        {
            this.carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImageDal.Add(carImage);

            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            carImageDal.Delete(carImage);

            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(carImageDal.Get(ci => ci.ImageId == imageId));
        }

        public IDataResult<CarImage> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<CarImage>(carImageDal.Get(c => c.CarId == carId));
        }

        public IResult Update(CarImage carImage)
        {
            carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);

        }

        private IResult CheckIfImageLimit(int carId)
        {
            var carImageCount = carImageDal.GetAll(cim => cim.CarId == carId).Count;
            if(carImageCount > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);

            }
            return new SuccessResult() ;       }

        
    }
}

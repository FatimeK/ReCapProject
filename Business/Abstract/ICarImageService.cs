﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);

        IResult Update(CarImage carImage);
        IDataResult<CarImage> GetById(int imageId);

        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> GetCarImageByCarId(int carId);
    }
}

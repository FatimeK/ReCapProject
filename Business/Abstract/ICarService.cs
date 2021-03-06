﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetAll();

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);


        IDataResult<List<Car>> GetByDailyPrice(int dailyPrice);

        //IResult Add(Car carName);



    }
}

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _ibrandDal;

        public BrandManager(IBrandDal ibrandDal)
        {
            _ibrandDal = ibrandDal;
        }

        public IResult Add(Brand brand)
        {
            _ibrandDal.Add(brand);
            return new SuccessResult("brandadded");
        }

        public IResult Delete(Brand brand)
        {
            _ibrandDal.Delete(brand);
            return new SuccessResult("branddeleted");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_ibrandDal.GetAll());
           
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_ibrandDal.GetAll(b => b.BrandId == id ));
        }

        public IResult Update(Brand brand)
        {
            _ibrandDal.Update(brand);
            return new SuccessResult("brand added");
        }

       
    }
}

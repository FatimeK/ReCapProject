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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _icustomerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _icustomerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _icustomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _icustomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_icustomerDal.GetAll());
        }

        

        public IResult Update(Customer customer)
        {
            _icustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}

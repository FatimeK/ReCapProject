﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Delete(Customer car);
        IResult Update(Customer car);
        IResult Add(Customer car);
        //IDataResult<Customer> Get(int id);
    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> ShowAll();
        List<Car> GetById(int brandId);
        
    }
}

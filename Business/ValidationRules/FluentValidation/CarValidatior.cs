using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidatior:AbstractValidator<Car>
    {
        public CarValidatior()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(50);
            RuleFor(c => c.Description).MaximumLength(5);

        }
    }
}

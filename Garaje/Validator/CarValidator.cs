using DateAccess.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.EntitiesConfiguration
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.ModelCar)
                 .NotNull() //гарантуємо, що не буде порожній
                 .NotEmpty()  //якщо це рядок, то не має бути пробілів
                 .MinimumLength(3)
                 .MaximumLength(100)
                 .WithMessage("Name car is incorect! Value is required and must be len greater 3 and more 100");
        
            RuleFor(car => car.ColorCar)
                .NotNull() //гарантуємо, що не буде порожній
                 .NotEmpty()  //якщо це рядок, то не має бути пробілів
                 .MinimumLength(3)
                 .MaximumLength(20)
                 .WithMessage("Color is incorect! Value is required and must be len greater 3 and more 20");

            RuleFor(car => car.Price) 
                .GreaterThanOrEqualTo(0)  //більше рівне нуля
                .WithMessage("Value Price is incorect!");

            RuleFor(car => car.Discription)
                .NotNull() //гарантуємо, що не буде порожній
                 .NotEmpty()  //якщо це рядок, то не має бути пробілів
                 .MinimumLength(5)
                 .MaximumLength(200)
                 .WithMessage("Name car is incorect! Value is required and must be len greater 5 and more 200");

         
        }
    }
}

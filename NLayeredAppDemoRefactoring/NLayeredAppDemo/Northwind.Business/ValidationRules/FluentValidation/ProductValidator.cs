using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        // Fluent Validation
        // Web uygulamalarında Client side validation için de rahatlıkla entegre edebiliriz.
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz!");
            Transform(from: x => x.ProductName, to: value => int.TryParse(value, out int val) ? (int?)val : null)
             .GreaterThan(10);
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);
            //categori Id 2'ye eşit ise unitprice 10'dan büyük olmalı.

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün ismi 'A , a' ile başlamalı!");
            // Kendi Kurallarımızı 'Must()' ile oluşturabiliriz.

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Business.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {

            var context = new ValidationContext<object>(entity);
            //--Bu framework 9.0 yamasıyla güncelleştiği için bu kısmı kabul etmiyor. bilginiz olsun.
            //var object = validator.Validate(entity);
            var result = validator.Validate(context);
                if (result.Errors.Count > 0)
                {
                    throw new ValidationException(result.Errors);
                }                 
        }
    }
}

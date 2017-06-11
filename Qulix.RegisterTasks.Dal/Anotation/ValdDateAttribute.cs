using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Qulix.RegisterTasks.Dal.Anotation
{
    public class ValdDateAttribute : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            var model = (Task)validationContext.ObjectInstance;
            DateTime strt_date = Convert.ToDateTime(model.Start_date);
            DateTime lst_date = Convert.ToDateTime(model.End_Date);

            if (lst_date < strt_date)
            {
                return new ValidationResult
                    (FormatErrorMessage(validationContext.DisplayName));
            }

            else
            {
                return ValidationResult.Success;
            }
        }

    }
}

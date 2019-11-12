using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using Microsoft.LightSwitch.Security;

namespace LightSwitchApplication
{
    public partial class tm_lu_employee
    {
        partial void employee_code_Validate(EntityValidationResultsBuilder results)
        {
            // results.AddPropertyError("<Error-Message>");
            if (!Regex.IsMatch(employee_code, @"\d{6}"))
            {
                results.AddPropertyError("Wrong Format");
            }
        }
    }
}
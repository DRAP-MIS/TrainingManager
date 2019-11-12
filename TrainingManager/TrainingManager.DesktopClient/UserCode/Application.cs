using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System;

namespace LightSwitchApplication
{
    
    public partial class Application
    {
        public string gEmployeeCode { get; set; }
        partial void ApplicationUsers_CanRun(ref bool result)
        {
            result = Current.User.HasPermission(Permissions.SecurityAdministration);
        }

        partial void CompletedTrainings_CanRun(ref bool result)
        {
            result = Current.User.HasPermission(Permissions.SecurityAdministration);
        }

        partial void Application_LoggedIn()
        {
            //throw new NotImplementedException();
            DataWorkspace dws = CreateDataWorkspace();

            var s = dws.ApplicationData.AppUsersSet.Where(x => x.username.ToLower() == Current.User.Name.ToLower()).FirstOrDefault();
            gEmployeeCode = s.employee_code;
        }
    }
}
using Microsoft.LightSwitch.Security.Server;
using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        #region Audit Function Calls
        partial void tm_lu_countries_Deleting(tm_lu_country entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void tm_lu_countries_Updating(tm_lu_country entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void tm_lu_divisionSections_Deleted(tm_lu_divisionSection entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void tm_lu_divisionSections_Updating(tm_lu_divisionSection entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void tm_lu_employees_Deleting(tm_lu_employee entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void tm_lu_employees_Updating(tm_lu_employee entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void tm_trainingCompleteds_Deleting(tm_trainingCompleted entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void tm_trainingCompleteds_Updating(tm_trainingCompleted entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void tm_trainingParticipants_Deleting(tm_trainingParticipant entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void tm_trainingParticipants_Updating(tm_trainingParticipant entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        partial void tm_trainings_Deleting(tm_training entity)
        {
            AuditHelper.CreateAuditTrailForDelete(entity, this);
        }

        partial void tm_trainings_Updating(tm_training entity)
        {
            AuditHelper.CreateAuditTrailForUpdate(entity, this);
        }

        #endregion

        #region Authorisations & Permissions
        partial void tm_trainings_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TDEL);
        }

        partial void tm_trainings_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TADD);
        }

        partial void tm_trainings_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TUPD);
        }

        partial void tm_trainingParticipants_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TDEL);
        }

        partial void tm_trainingParticipants_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TADD);
        }

        partial void tm_trainingParticipants_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TUPD);
        }
        partial void tm_trainingCompleteds_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TDEL);
        }
        partial void tm_trainingCompleteds_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TADD);
        }
        partial void tm_trainingCompleteds_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.TUPD);
        }
        partial void tm_lu_employees_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDDEL);
        }
        partial void tm_lu_employees_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDADD);
        }
        partial void tm_lu_employees_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDUPD);
        }
        partial void tm_lu_divisionSections_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDDEL);
        }
        partial void tm_lu_divisionSections_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDADD);
        }
        partial void tm_lu_divisionSections_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDUPD);
        }
        partial void tm_lu_countries_CanDelete(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDDEL);
        }
        partial void tm_lu_countries_CanInsert(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDADD);
        }
        partial void tm_lu_countries_CanUpdate(ref bool result)
        {
            result = Application.Current.User.HasPermission(Permissions.LDUPD);
        }
        #endregion

        partial void tm_trainingCompleteds_Inserted(tm_trainingCompleted entity)
        {
            entity.tm_training.status = "COMPLETE";
        }

        partial void EmployeeCompletedTrainings_PreprocessQuery(string pemployeeCode, ref IQueryable<tm_trainingCompleted> query)
        {
            //string empCode = 
            query = query.Where(x => x.tm_trainingParticipants.Any(z => z.tm_lu_employee.employee_code == pemployeeCode));
        }
    }
}
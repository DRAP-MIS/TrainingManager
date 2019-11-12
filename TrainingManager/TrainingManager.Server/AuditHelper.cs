using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LightSwitchApplication
{
    public static class AuditHelper
    {
        public static void CreateAuditTrailForUpdate<E>(E entity, ApplicationData app) where E : IEntityObject
        {


            foreach (var prop in entity.Details.Properties.All().OfType<IEntityStorageProperty>())
            {

                if (app.AuditExcludes.Where(Exclude => Exclude.propName == prop.Name).Count() < 1)
                {
                    if (!(Object.Equals(prop.Value, prop.OriginalValue)))
                    {
                        AuditTrail auditRecord = app.AuditTrails.AddNew();
                        auditRecord.ChangeType = "Updated";
                        auditRecord.ReferenceId = (int)entity.Details.Properties["Id"].Value;
                        auditRecord.ReferenceType = entity.Details.EntitySet.Details.Name;
                        auditRecord.Updated = DateTime.Now;
                        auditRecord.ChangedBy = Application.Current.User.Name + ";" + Application.Current.User.FullName;
                        auditRecord.ReferenceProp = prop.Name;
                        auditRecord.OriginalValues = Convert.ToString(prop.OriginalValue); //prop.OriginalValue.ToString() ?? " ";
                        auditRecord.NewValues = Convert.ToString(prop.Value);// prop.Value.ToString();
                    }
                }
            }

            foreach (var prop in entity.Details.Properties.All().OfType<IEntityReferenceProperty>())
            {
                if (app.AuditExcludes.Where(Exclude => Exclude.propName == prop.Name).Count() < 1)
                {
                    if (!(Object.Equals(prop.Value, prop.OriginalValue)))
                    {
                        AuditTrail auditRecord = app.AuditTrails.AddNew();
                        auditRecord.ChangeType = "Updated";
                        auditRecord.ReferenceId = (int)entity.Details.Properties["Id"].Value;
                        auditRecord.ReferenceType = entity.Details.EntitySet.Details.Name;
                        auditRecord.Updated = DateTime.Now;
                        auditRecord.ChangedBy = Application.Current.User.Name + ";" + Application.Current.User.FullName;
                        auditRecord.ReferenceProp = prop.Name;
                        auditRecord.OriginalValues = Convert.ToString(prop.OriginalValue); //prop.OriginalValue.ToString() ?? " ";
                        auditRecord.NewValues = Convert.ToString(prop.Value); //  prop.Value.ToString();
                    }
                }
            }
        }

        public static void CreateAuditTrailForInsert<E>(E entity, ApplicationData app) where E : IEntityObject
        {

            StringBuilder newValues = new StringBuilder("Inserted Values :" + Environment.NewLine);

            foreach (var prop in entity.Details.Properties.All().OfType<IEntityStorageProperty>())
            {
                if (app.AuditExcludes.Where(Exclude => Exclude.propName == prop.Name).Count() < 1)
                {
                    AuditTrail auditRecord = app.AuditTrails.AddNew();
                    auditRecord.ChangeType = "Inserted";
                    auditRecord.ReferenceId = (int)entity.Details.Properties["Id"].Value;
                    auditRecord.ReferenceType = entity.Details.EntitySet.Details.Name;
                    auditRecord.Updated = DateTime.Now;
                    auditRecord.ChangedBy = Application.Current.User.Name + ";" + Application.Current.User.FullName;
                    auditRecord.ReferenceProp = prop.Name;
                    auditRecord.NewValues = Convert.ToString(prop.Value);
                }
            }

            foreach (var prop in entity.Details.Properties.All().OfType<IEntityReferenceProperty>())
            {
                if (app.AuditExcludes.Where(Exclude => Exclude.propName == prop.Name).Count() < 1)
                {
                    AuditTrail auditRecord = app.AuditTrails.AddNew();
                    auditRecord.ChangeType = "Inserted";
                    auditRecord.ReferenceId = (int)entity.Details.Properties["Id"].Value;
                    auditRecord.ReferenceType = entity.Details.EntitySet.Details.Name;
                    auditRecord.Updated = DateTime.Now;
                    auditRecord.ChangedBy = Application.Current.User.Name + ";" + Application.Current.User.FullName;
                    auditRecord.ReferenceProp = prop.Name;
                    auditRecord.NewValues = Convert.ToString(prop.Value);
                }
            }
        }

        public static void CreateAuditTrailForDelete<E>(E entity, ApplicationData app) where E : IEntityObject
        {

            StringBuilder oldValues = new StringBuilder("Deleted Values :" + Environment.NewLine);

            foreach (var prop in entity.Details.Properties.All().OfType<IEntityStorageProperty>())
            {
                if (app.AuditExcludes.Where(Exclude => Exclude.propName == prop.Name).Count() < 1)
                {
                    AuditTrail auditRecord = app.AuditTrails.AddNew();
                    auditRecord.ChangeType = "Deleted";
                    auditRecord.Updated = DateTime.Now;
                    auditRecord.ChangedBy = Application.Current.User.Name + ";" + Application.Current.User.FullName;
                    auditRecord.ReferenceId = (int)entity.Details.Properties["Id"].Value;
                    auditRecord.ReferenceType = entity.Details.EntitySet.Details.Name;
                    auditRecord.ReferenceProp = prop.Name;
                    auditRecord.OriginalValues = Convert.ToString(prop.OriginalValue); //prop.OriginalValue.ToString();
                }
            }

            foreach (var prop in entity.Details.Properties.All().OfType<IEntityReferenceProperty>())
            {
                if (app.AuditExcludes.Where(Exclude => Exclude.propName == prop.Name).Count() < 1)
                {
                    AuditTrail auditRecord = app.AuditTrails.AddNew();
                    auditRecord.ChangeType = "Deleted";
                    auditRecord.Updated = DateTime.Now;
                    auditRecord.ChangedBy = Application.Current.User.Name + ";" + Application.Current.User.FullName;
                    auditRecord.ReferenceId = (int)entity.Details.Properties["Id"].Value;
                    auditRecord.ReferenceType = entity.Details.EntitySet.Details.Name;
                    auditRecord.ReferenceProp = prop.Name;
                    auditRecord.OriginalValues = Convert.ToString(prop.OriginalValue); //prop.OriginalValue.ToString();
                }
            }
        }
    }
}
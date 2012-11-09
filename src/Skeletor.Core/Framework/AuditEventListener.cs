using System;
using System.Reflection;
using System.Web;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace Skeletor.Core.Framework
{
    public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public AuditEventListener() {}

        public bool OnPreUpdate(PreUpdateEvent preUpdateEvent)
        {
            var audit = preUpdateEvent.Entity as IAuditable;
            if (audit == null)
                return false;

            var time = DateTime.UtcNow;
            var userid = CurrentUserId();

            Set(preUpdateEvent.Persister, preUpdateEvent.State, "ModifiedOnUtc", time);
            Set(preUpdateEvent.Persister, preUpdateEvent.State, "ModifiedBy", userid);

            preUpdateEvent.Entity.GetType().GetMethod("ChangeModifiedBy", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(preUpdateEvent.Entity, new object[] { userid });
            preUpdateEvent.Entity.GetType().GetMethod("ChangeModifiedOnUtc", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(preUpdateEvent.Entity, new object[] { time });

            return false;
        }

        public bool OnPreInsert(PreInsertEvent preInsertEvent)
        {
            var audit = preInsertEvent.Entity as IAuditable;
           
            if (audit == null)
                return false;

            var time = DateTime.UtcNow;
            var userid = CurrentUserId();

            Set(preInsertEvent.Persister, preInsertEvent.State, "CreatedOnUtc", time);
            Set(preInsertEvent.Persister, preInsertEvent.State, "CreatedBy", userid);

            preInsertEvent.Entity.GetType().GetMethod("ChangeCreatedBy", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(preInsertEvent.Entity, new object[] { userid });
            preInsertEvent.Entity.GetType().GetMethod("ChangeCreatedOnUtc", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(preInsertEvent.Entity, new object[] { time });

            return false;
        }


        private Guid CurrentUserId()
        {
            Guid userid = Guid.Empty;

            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                userid = Guid.Parse(HttpContext.Current.User.Identity.Name);

            return userid;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
}
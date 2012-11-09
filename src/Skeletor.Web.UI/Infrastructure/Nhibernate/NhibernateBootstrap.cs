using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using Skeletor.Core.Framework;
using Skeletor.Core.Help;

namespace Skeletor.Web.UI.Infrastructure.Nhibernate
{
    public static class NhibernateBootstrap
    {
        public static ISessionFactory Configure()
        {
            return Fluently.Configure()
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Help>())
                    .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString( ConfigurationManager.ConnectionStrings["default"].ConnectionString)
                    .ShowSql)
                    .ExposeConfiguration(cfg => cfg.SetProperty(Environment.CurrentSessionContextClass,"web"))
                    .ExposeConfiguration(cfg => cfg.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new AuditEventListener() }))
                    .ExposeConfiguration(cfg => cfg.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new AuditEventListener() }))
                 .BuildSessionFactory();
        }
    }
}
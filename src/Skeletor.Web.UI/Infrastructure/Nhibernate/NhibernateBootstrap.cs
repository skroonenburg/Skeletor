using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Skeletor.Core.Help;

namespace Skeletor.Web.UI.Infrastructure.Nhibernate
{
    public static class NhibernateBootstrap
    {
        public static ISessionFactory Configure()
        {
            // load all models from the Skeletor.Core assembly that inherit from ClassMap

            return Fluently.Configure()
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Help>())
                    .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString( ConfigurationManager.ConnectionStrings["default"].ConnectionString)
                    .ShowSql)
                 .BuildSessionFactory();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
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
                 .BuildSessionFactory();
        }

    }
}
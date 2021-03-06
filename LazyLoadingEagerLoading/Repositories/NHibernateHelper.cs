﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace LazyLoadingEagerLoading.Repositories
{
    class NHibernateHelper
    {
        private static ISessionFactory SessionFactory
        {
            get
            {
                return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(m => m.Server(@"026faca9-4c85-44a4-b2b7-a0ec00f61d56.sqlserver.sequelizer.com")
                        .Database("db026faca94c8544a4b2b7a0ec00f61d56")
                        .Username("vqgvndclkebulczm")
                        .Password("NrCdrxrn2t7QUsCTJgYVRE6NVkT6UiwLPkCpCsfAvb6mjwNfNsntoiVitWpgMtAS")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}

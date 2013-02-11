using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using LazyLoadingEagerLoading.Model;

namespace LazyLoadingEagerLoading.Tests
{
    [TestFixture]
    class GenerateScheme_Fixture
    {
        [Test]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Order).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}

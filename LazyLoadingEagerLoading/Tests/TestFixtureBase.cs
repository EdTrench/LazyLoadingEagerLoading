using LazyLoadingEagerLoading.Model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace LazyLoadingEagerLoading.Tests
{
    public class TestFixtureBase
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        //protected ISessionFactory SessionFactory
        //{
        //    get { return _sessionFactory; }
        //}

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Customer).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _sessionFactory.Close();
        }

        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            Before_each_test();
        }

        [TearDown]
        public void TearDownContext()
        {
            After_each_test();
        }

        protected virtual void Before_each_test()
        { }

        protected virtual void After_each_test()
        { }
    }
}
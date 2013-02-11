using System;
using LazyLoadingEagerLoading.Model;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NUnit.Framework;
using Order = LazyLoadingEagerLoading.Model.Order;
using LazyLoadingEagerLoading.Repositories;

namespace LazyLoadingEagerLoading.Tests
{
    [TestFixture]
    public class Order_Fixture : TestFixtureBase
    {
        private Order _order;

        protected override void Before_each_test()
        {
            base.Before_each_test();
            CreateInitialData();
        }

        private void CreateInitialData()
        {
            // create a single customer and an order with two order lines for this customer
            var customer = new Customer { CompanyName = "IBM" };
            var line1 = new OrderLine { Amount = 5, ProductName = "Laptop XYZ" };
            var line2 = new OrderLine { Amount = 2, ProductName = "Desktop PC A100" };
            _order = new Order()
            {
                OrderNumber = "o-100-001",
                OrderDate = DateTime.Today,
                Customer = customer
            };
            _order.OrderLines.Add(line1);
            _order.OrderLines.Add(line2);

            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(customer);
                session.Save(_order);
                transaction.Commit();
            }
        }

        /// <summary>
        /// The fun starts here eddie boy!
        /// </summary>
        [Test]
        public void Customer_and_OrderLines_are_not_loaded_when_loading_Order()
        {
            this.Before_each_test();

            Order fromDb;
            using (ISession session = NHibernateHelper.OpenSession())
                fromDb = session.Get<Order>(_order.Id);

            Assert.IsFalse(NHibernateUtil.IsInitialized(fromDb.Customer));
            Assert.IsFalse(NHibernateUtil.IsInitialized(fromDb.OrderLines));
        }

    }
}
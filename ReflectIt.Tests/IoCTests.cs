using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectIt.Tests
{
    [TestClass]
    public class IoCTests
    {
        [TestMethod]
        public void Can_Resolve_Types()
        {
            var ioc = new Container();
            // configure container
            ioc.For<ILogger>().Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }
        [TestMethod]
        public void Can_Resolve_Types_Without_Default_Ctor()
        {
            var ioc = new Container();
            // configure container
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();

            var repository = ioc.Resolve<IRepository<Employee>>();

            Assert.AreEqual(typeof(SqlRepository<Employee>), repository.GetType());
        }
        [TestMethod]
        public void Can_Resolve_Concrete_Type()
        {
            var ioc = new Container();
            // configure container
            ioc.For<ILogger>().Use<SqlServerLogger>();
            // we want to resolve all generic types to all similar concrete types without needing to be explicit
            //ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();
            ioc.For(typeof(IRepository<>)).Use(typeof(SqlRepository<>));

            var service = ioc.Resolve<InvoiceService>();
            Assert.IsNotNull(service);
        }
    }
}

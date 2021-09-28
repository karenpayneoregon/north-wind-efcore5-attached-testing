using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWindCoreLibrary.Classes;
using NorthWindEntityLocalData.Classes;
using NorthWindUnitTestProject.Base;

namespace NorthWindUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.Connecting)]
        public async Task A_ConnectTest()
        {
            Console.WriteLine(await CustomersOperations.TestConnection());
        }

        [TestMethod]
        [TestTraits(Trait.Warming)]
        public void A_Warmup()
        {
            CustomersOperations.Warmup();
        }

        [TestMethod]
        [TestTraits(Trait.CustomerRead)]
        public async Task GetCustomersWithProjectionTest()
        {
            var expected = 91;
            var results = await CustomersOperations.GetCustomersWithProjectionAsync();
            Assert.AreEqual(results.Count,expected);
        }
        [TestMethod]
        [TestTraits(Trait.ProductRead)]
        public async Task GetProductsWithProjectionAsyncTest()
        {
            var expected = 77;
            var results = await ProductsOperations.GetProductsWithProjectionAsync();
            Assert.AreEqual(results.Count, expected);
        }

        /// <summary>
        /// Conventional data provider read Customers
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [TestTraits(Trait.SqlClientRead)]
        public async Task SqlClientRead()
        {
            CancellationTokenSource cancellationTokenSource = new ();

            var (exception, _, dataTable) = await SqlOperations.ReadCustomersTask(cancellationTokenSource.Token);
            Assert.IsNull(exception);
            Assert.AreEqual(dataTable.Rows.Count,91);

        }

    }
}

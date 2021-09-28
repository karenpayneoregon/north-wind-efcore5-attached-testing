using System;
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
    }
}

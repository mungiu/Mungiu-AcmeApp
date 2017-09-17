using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange - test setup
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "Bilka";
            //calling the expected results
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" +
                " Available on: ";

            ////Act - executing the actual method
            //var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void SayHello_ParameterizedCtor()
        {
            //Arrange - test setup
            //we nolonger need to set the values manually as in above test
            var currentProduct = new Product("USB", 2, "USB 3.0 stick 8GB");

            //calling the expected results
            var expected = "Hello USB (2): USB 3.0 stick 8GB" +
                " Available on: ";

            ////Act - executing the actual method
            //var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            //Arrange - test setup
            var currentProduct = new Product
            {
                ProductId = 3,
                ProductName = "Bitcoin",
                Description = "Crypto currency"
            };

            var expected = "Hello Bitcoin (3): Crypto currency" +
                " Available on: ";

            ////Act - executing the method
            //var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange - test setup
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Assert
            Assert.AreEqual(expected, companyName);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            //Arrange - test setup (expected inches in 2 meters)
            var expected = 78.74;
            //Assert - asserting formula correctness
            Assert.AreEqual(expected, 2 * Product.InchesPerMeter);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //Arrange (creating instance of class as it is not static)
            var currentProduct = new Product();
            var expected = .96m;
            //Assert
            Assert.AreEqual(expected, currentProduct.MinimumPrice);
        }

        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //Arrange - initializing non static instance
            //NOTE: To instantiate an object succesfully all params must be met
            var currentProduct = new Product("Bulk Test", 3, "Test bulk descr.");
            var expected = 9.99m;
            //Assert
            Assert.AreEqual(expected, currentProduct.MinimumPrice);
        }
    }
}
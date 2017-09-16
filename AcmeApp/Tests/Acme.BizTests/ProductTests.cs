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
        /// <summary>
        /// Testing by invoking default ctor with setting properties technique
        /// </summary>
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
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            ////Act - executing the actual method
            //var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        /// <summary>
        /// Testing by initializing the prop. values with parametarized ctor
        /// </summary>
        [TestMethod()]
        public void SayHello_ParameterizedCtor()
        {
            //Arrange - test setup
            //we nolonger need to set the values manually as in above test
            var currentProduct = new Product("USB", 2, "USB 3.0 stick 8GB");

            //calling the expected results
            var expected = "Hello USB (2): USB 3.0 stick 8GB";

            ////Act - executing the actual method
            //var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        ///<summary>
        ///Testing by uzing object initializer syntax
        ///</summary>
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

            var expected = "Hello Bitcoin (3): Crypto currency";

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
    }
}
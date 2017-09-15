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
        /// Testing by invoking default ctor and manually setting values 
        /// for each property.
        /// </summary>
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange - test setup
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            //calling the expected results
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            //Act - executing the actual method
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
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

            //Act - executing the actual method
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
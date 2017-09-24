using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;
using static Acme.Biz.Vendor;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor
            {
                CompanyName = "ABC Corp"
            };
            var expected = "Message sent: Hello ABC Corp";

            // Assert
            Assert.AreEqual(expected, vendor.SendWelcomeEmail("Test Message"));
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor
            {
                CompanyName = ""
            };
            var expected = "Message sent: Hello";

            // Assert
            Assert.AreEqual(expected, vendor.SendWelcomeEmail("Test Message"));
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor
            {
                CompanyName = null
            };
            var expected = "Message sent: Hello";

            // Assert
            Assert.AreEqual(expected, vendor.SendWelcomeEmail("Test Message"));
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product("Test name", 1, "Test description");
            var expected = new OperationResult(true,
                            $"Order from Acme, Inc" +
                            $"\r\nProduct: Tools_1" +
                            $"\r\nQuantity: 1" +
                            $"\r\nDelivery instructions: Standard delivery");

            //Act
            var actual = vendor.PlaceOrder(product, 1);

            //Asserting the first "bool" param and second "string" param
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void PlaceOrderTest_3Parameters()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product("Test name", 1, "Test description");
            var expected = new OperationResult(true,
                            $"Order from Acme, Inc" +
                            $"\r\nProduct: Tools_1" +
                            $"\r\nQuantity: 1" +
                            $"\r\nDeliver by: 10/25/2017" +
                            $"\r\nDelivery instructions: Standard delivery");

            //Act
            var actual = vendor.PlaceOrder(product, 1,
                        new DateTimeOffset(2017, 10, 25, 0, 0, 0,
                        new TimeSpan(-7, 0, 0)));

            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        //test exception handling
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            //Arrange
            var vendor = new Vendor();

            //Act - mimiking null param inputs
            var actual = vendor.PlaceOrder(null, 12);
        }

        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product();

            var expected = new OperationResult(true,
                "Test With address");

            //Act
            var actual = vendor.PlaceOrder(product, 1, 
                                           IncludeAddress.yes, 
                                           SendCopy.no);

            //Assert - NOTE: We assert for every parameter
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void PlaceOrder_NoDeliveryDate()
        {
            //Arrange
            var product = new Product("Test", 1, "Test description");
            var vendor = new Vendor();
            var expected = new OperationResult(true,
                            $"Order from Acme, Inc" +
                            $"\r\nProduct: Tools_1" +
                            $"\r\nQuantity: 1" +
                            $"\r\nDelivery instructions: Deliver to suite 42");

            //Act - Using named parameters to avoid passing preceding parameters
            var actual = vendor.PlaceOrder(product, 1, 
                instructions: "Deliver to suite 42");

            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}
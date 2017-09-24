using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

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
                            $"Order from Acme, Inc \r\n" +
                            $"Product: Tools_1\r\n" +
                            $"Quantity: 1");

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
                            $"Order from Acme, Inc\r\n" +
                            $"Product: Tools_1\r\n" +
                            $"Quantity: 1\r\n" +
                            $"Deliver by: 10/25/2017");

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

            //Assert done using the above:
            //[ExpectedException(typeof(ArgumentNullException))]
        }
    }
}
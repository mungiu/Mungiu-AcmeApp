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

        //Test null company name
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
            var currentVendor = new Vendor();
            var currentProduct = new Product("Test name", 1, "Test description");

            var expected = true;

            //Assert
            Assert.AreEqual(expected, currentVendor.PlaceOrder(currentProduct, 3));
        }
    }
}
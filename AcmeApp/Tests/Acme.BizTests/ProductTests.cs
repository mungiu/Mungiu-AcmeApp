using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    //Tests are always void as they never return, only assert.
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange - test setup
            var currentProduct = new Product
            {
                ProductName = "Saw Product",
                ProductId = 1,
                Description = "15-inch steel blade hand saw"
            };

            currentProduct.ProductVendor.CompanyName = "Bilka";
            var expected = "Hello Saw Product (1): 15-inch steel blade hand saw" +
                " Available on: ";

            //Assert
            Assert.AreEqual(expected, currentProduct.SayHello());
        }

        [TestMethod()]
        public void SayHello_ParameterizedCtor()
        {
            //Arrange - test setup
            //we nolonger need to set the values manually as in above test
            var currentProduct = new Product("USB Product", 2, "USB 3.0 stick 8GB");
            var expected = "Hello USB Product (2): USB 3.0 stick 8GB" +
                " Available on: ";

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

        [TestMethod()]
        public void ProductNameFormating()
        {
            //Arrange - test setup
            var currentProduct = new Product(" Product ", 5, "Test product!");
            var expected = "Product";

            //Assert
            Assert.AreEqual(expected, currentProduct?.ProductName?.Trim());
        }

        [TestMethod()]
        public void ProductName_TooLong()
        {
            //Arrange
            //when initializing using product properties instance will not be created
            //if one of the properties does not pass validation
            var currentProduct = new Product();
            currentProduct.ProductName = "Asdfajdh akshdkahsdkahg ahksgdjakdaksj";

            //since "var" type can not be used for "null";
            string expectedProductName = null;
            string expectedValidationMessage= "Name must be > 4 & < 20";

            //Assert 1
            Assert.AreEqual(expectedProductName, currentProduct?.ProductName);
            Assert.AreEqual(expectedValidationMessage, currentProduct?.ValidationMessage);
        }

        [TestMethod()]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Asdf";

            string expectedProductName = null;
            string expectedValidationMessage = "Name must be > 4 & < 20";

            //Assert 1
            Assert.AreEqual(expectedProductName, currentProduct?.ProductName);
            Assert.AreEqual(expectedValidationMessage, currentProduct?.ValidationMessage);
        }

        [TestMethod()]
        public void ProductName_JustRight()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductName = "Asdfedfr"
            };

            string expectedProductName = "Asdfedfr";
            string expectedValidationMessage = null;

            //Assert 1
            Assert.AreEqual(expectedProductName, currentProduct?.ProductName);
            Assert.AreEqual(expectedValidationMessage, currentProduct?.ValidationMessage);
        }

        [TestMethod]
        public void Category_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expectedCategory = "Tools";
            //Assert
            Assert.AreEqual(expectedCategory, currentProduct.Category);
        }

        [TestMethod]
        public void Category_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "New Category Test";
            var expectedCategory = "New Category Test";
            //Assert
            Assert.AreEqual(expectedCategory, currentProduct.Category);
        }

        [TestMethod]
        public void Sequence_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            //note expected int # != expected string #
            var expectedSequence = 1;
            //Assert
            Assert.AreEqual(expectedSequence, currentProduct.SequenceNumber);
        }

        [TestMethod]
        public void Sequence_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 2;
            var expectedSequence = 2;
            //Assert
            Assert.AreEqual(expectedSequence, currentProduct.SequenceNumber);
        }

        [TestMethod]
        public void ProductCode_Concatination()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "This";
            currentProduct.SequenceNumber = 1;
            var expectedProductCode = "This_1";

            //Assert
            Assert.AreEqual(expectedProductCode, currentProduct.ProductCode);
        }
    }
}
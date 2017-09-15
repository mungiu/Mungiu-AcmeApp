using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common.Tests
{
    [TestClass()]
    public class LoggingServiceTests
    {
        [TestMethod()]
        public void LogAction_Success()
        {
            // Arrange
            ////can no longer be instantiated after changed to "static"
            //var loggingService = new LoggingService();
            var expected = "Action: Test Action";

            // Act
            //using class name to call LogAction method inside static class
            var actual = LoggingService.LogAction("Test Action");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
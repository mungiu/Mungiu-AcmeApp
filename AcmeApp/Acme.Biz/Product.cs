using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;

        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created.");
            ////initializing the vendor object in the default ctor
            //this.ProductVendor = new Vendor();
            this.MinimumPrice = .96m;
        }

        //using ctor to initialize product properties
        public Product(string productName, 
            int productId,
            string description) : this() 
            //setting values passed in ctor to properties
            //prop. PascalCased, param. camelCased
        {
            //"this" clarifies that we refer to the property of the current object
            this.ProductName = productName;
            this.ProductId = productId;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
                this.MinimumPrice = 9.99m;

            Console.WriteLine($"Product instance has a name: {ProductName}");
        }
        #endregion

        #region Properties
        //"?" makes it a nullable type
        private DateTime? availabilityDate;
        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        //this is a parameter
        private string productName;
        //this is a property (method)
        public string ProductName
        {
            get
            {
                var formatedValue = productName?.Trim();
                return formatedValue;
            }
            set
            {
                if (value.Length > 4 && value.Length < 20)
                    productName = value;
                else ValidationMessage = "Name must be > 4 & < 20";
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        
        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get
            {
                //check if productVendor object variable is null & initialize
                if (productVendor == null)
                    productVendor = new Vendor();

                return productVendor;
            }

            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", 
                this.ProductName,
                "sales@asd.com");

            //static classes can not be instantiated (only use for method access)
            var result = LoggingService.LogAction(confirmation);

            return $"Hello {ProductName} ({ProductId}): {Description}" +
                $" Available on: {AvailabilityDate?.ToShortDateString()}";
        }
    }
}

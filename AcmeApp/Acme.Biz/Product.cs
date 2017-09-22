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
            //initializing prop value in ctor
            this.Category = "Tools";
        }

        //ctor initializing properties
        public Product(string productName, 
            int productId,
            string description) : this() 
            //setting passed values to properties
        {
            this.ProductName = productName;
            this.ProductId = productId;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
                this.MinimumPrice = 9.99m;

            Console.WriteLine($"Product instance has a name: {ProductName}");
        }
        #endregion

        #region Properties
        //"?" = nullable type
        private DateTime? availabilityDate;
        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        //parameter
        private string productName;
        //property (NOT METHOD)
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
                //Lazy Loading - creating instance only when requested
                if (productVendor == null)
                    productVendor = new Vendor();

                return productVendor;
            }
            set { productVendor = value; }
        }

        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ProductCode => this.Category + "_" + SequenceNumber;

        //auto implemented property (backing field implicitly existent)
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

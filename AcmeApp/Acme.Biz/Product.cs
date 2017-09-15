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
        public Product()
        {
            Console.WriteLine("Product instance created.");
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
            Console.WriteLine($"Product instance has a name: {ProductName}");
        }

        //this is a parameter
        private string productName;
        //this is a property (method)
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
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

        public string SayHello()
        {
            return $"Hello {ProductName} ({ProductId}): {Description}";
        }
    }
}

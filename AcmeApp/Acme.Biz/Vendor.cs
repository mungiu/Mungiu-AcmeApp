﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends product order to the vendor.
        /// </summary>
        /// <param name="product">Ordered product</param>
        /// <param name="quantity">Ordered quantity</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            var success = false;
            var orderText = "Order from Acme, Inc \r\n" +
                            $"Product: {product.ProductCode}\r\n" +
                            $"Quantity: {quantity}";

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("Order Confirmation", 
                orderText, this.Email);
            if (confirmation.StartsWith("Message sent: "))
                success = true;

            //instantiating the class to enable 
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends product order to the vendor.
        /// </summary>
        /// <param name="product">Ordered product.</param>
        /// <param name="quantity">Ordered quantity.</param>
        /// <param name="deliverBy">Requested delivery date.</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, 
            DateTimeOffset? deliverBy)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;
            var orderText = "Order from Acme, Inc\r\n" +
                            $"Product: {product.ProductCode}\r\n" +
                            $"Quantity: {quantity}\r\n";
            if (deliverBy.HasValue)
                orderText += $"Deliver by: {deliverBy.Value.ToString("d")}";

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("Order Confirmation",
                orderText, this.Email);
            if (confirmation.StartsWith("Message sent: "))
                success = true;

            //instantiating the class to enable 
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends product order to the vendor.
        /// </summary>
        /// <param name="product">Ordered product.</param>
        /// <param name="quantity">Ordered quantity.</param>
        /// <param name="deliverBy">Requested delivery date.</param>
        /// <param name="instructions">Delivery instructions.</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity,
            DateTimeOffset? deliverBy, string instructions)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;
            var orderText = "Order from Acme, Inc\r\n" +
                            $"Product: {product.ProductCode}\r\n" +
                            $"Quantity: {quantity}\r\n";
            if (deliverBy.HasValue)
                orderText += $"Deliver by: {deliverBy.Value.ToString("d")}\r\n";
            if (instructions != null)
                orderText += $"Delivery instructions: {instructions}";

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("Order Confirmation",
                orderText, this.Email);
            if (confirmation.StartsWith("Message sent: "))
                success = true;

            //instantiating the class to enable 
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }
    }
}

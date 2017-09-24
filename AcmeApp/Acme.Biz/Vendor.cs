using Acme.Common;
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
        public enum IncludeAddress { yes, no};
        public enum SendCopy { yes, no };

        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int VendorId { get; set; }

        /// <summary>
        /// Sends product order to the vendor.
        /// </summary>
        /// <param name="product">Ordered product</param>
        /// <param name="quantity">Ordered quantity</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            //NOTE: If nulls are removed, will throw AtackOverflowException
            return PlaceOrder(product, quantity, null, null);
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
            //NOTE: If nulls are removed, will throw AtackOverflowException
            return PlaceOrder(product, quantity, deliverBy, null);
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
                                          DateTimeOffset? deliverBy, 
                                          string instructions)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;
            var orderText = "Order from Acme, Inc" +
                            $"\r\nProduct: {product.ProductCode}" +
                            $"\r\nQuantity: {quantity}";
            if (deliverBy.HasValue)
                orderText += $"\r\nDeliver by: {deliverBy.Value.ToString("d")}";
            if (instructions != null)
                orderText += $"\r\nDelivery instructions: {instructions}";

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("Order Confirmation",
                orderText, this.Email);
            if (confirmation.StartsWith("Message sent: "))
                success = true;

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends product order to the vendor.
        /// </summary>
        /// <param name="product">Ordered product.</param>
        /// <param name="quantity">Ordered quantity.</param>
        /// <param name="address">"True" to include shipping address.</param>
        /// <param name="copy">"True" to send email copy.</param>
        /// <returns>Success flag and order text.</returns>
        public OperationResult PlaceOrder(Product product, int quantity,
                                          IncludeAddress theAddress, 
                                          SendCopy theCopy)
        {
            var orderText = "Test";
            if (theAddress == IncludeAddress.yes) orderText += " With address";
            if (theCopy == SendCopy.yes) orderText += " With copy";

            var operationResult = new OperationResult(true, orderText);
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

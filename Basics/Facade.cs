using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // Multiple subsystem classes
    public class InventoryService
    {
        public bool CheckStock(string productId)
        {
            Console.WriteLine("Checking inventory...");
            return true;
        }
    }

    public class PaymentService
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment...");
        }
    }

    public class ShippingService
    {
        public void ShipProduct()
        {
            Console.WriteLine("Shipping product...");
        }
    }

    public class NotificationService
    {
        public void SendNotification()
        {
            Console.WriteLine("Sending notification...");
        }
    }

    //Main facade class
    public class OrderFacade
    {
        private readonly InventoryService _inventory;
        private readonly PaymentService _payment;
        private readonly ShippingService _shipping;
        private readonly NotificationService _notification;

        public OrderFacade()
        {
            _inventory = new InventoryService();
            _payment = new PaymentService();
            _shipping = new ShippingService();
            _notification = new NotificationService();
        }

        public void PlaceOrder(string productId)
        {
            if (!_inventory.CheckStock(productId))
            {
                Console.WriteLine("Product out of stock");
                return;
            }

            _payment.ProcessPayment();
            _shipping.ShipProduct();
            _notification.SendNotification();

            Console.WriteLine("Order placed successfully!");
        }
    }

    class Program
    {
        static void Main()
        {
            OrderFacade order = new OrderFacade();
            order.PlaceOrder("PROD-1");
        }
    } 
}

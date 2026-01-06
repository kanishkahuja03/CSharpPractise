using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate double Discount(double b);
    internal class Program
    {
        public static void Main()
        {
            Store store = new Store(10.0);
            // Subscribe to events
            store.OnDiscountApplied += price =>
            {
                Console.WriteLine($"Discount applied. Current price: {price}");
            };

            store.NegativePriceOccurred += price =>
            {
                Console.WriteLine($"Negative price detected, Discount not applied. Current price: {price}");
                return;
            };
            Console.WriteLine($"Original Price: {store.OriginalPrice}");
            Discount directDiscount = store.ApplyDirectDiscount;
            Discount percentageDiscount = store.ApplyPercentageDiscount;
            double directDiscountedPrice = directDiscount(15.0);
            double percentageDiscountedPrice = percentageDiscount(10.0);
            
        }
    }

    public class Store
    {
        public double OriginalPrice { get; set; }
        public Store(double price)
        {
            OriginalPrice = price;
        }
        public double ApplyDirectDiscount(double discountAmount)
        {
            if (OriginalPrice < discountAmount)
            {
                NegativePriceOccurred?.Invoke(OriginalPrice);
                return OriginalPrice;
            }
            OriginalPrice -= discountAmount;
            OnDiscountApplied?.Invoke(OriginalPrice);
            return OriginalPrice;
        }
        public double ApplyPercentageDiscount(double discountPercentage)
        {
            OriginalPrice = OriginalPrice*(1-(discountPercentage/100));
            OnDiscountApplied?.Invoke(OriginalPrice);
            return OriginalPrice;
        }

        public event Action<double>? NegativePriceOccurred;
        public event Action<double>? OnDiscountApplied;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public delegate void PriceChangedEventHandler(object sender, PriceChangedEventArgs args);

    public class PriceChangedEventArgs : EventArgs
    {
        public int OldPrice { get; }
        public int NewPrice { get; }

        public PriceChangedEventArgs(int oldPrice, int newPrice)
        {
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
    public class Stock
    {
        // .NET in-built event handler
        //public event EventHandler<PriceChangedEventArgs> PriceChanged;
        public event PriceChangedEventHandler PriceChanged;
        private int _price;

        public Stock(int initialPrice)
        {
            _price = initialPrice;
        }

        public void UpdatePrice(int newPrice)
        {
            if (_price == newPrice)
                return;

            int oldPrice = _price;
            _price = newPrice;

            OnPriceChanged(oldPrice, newPrice);
        }
        public virtual void OnPriceChanged(int oldPrice, int newPrice)
        {
            PriceChanged?.Invoke(this, new PriceChangedEventArgs(oldPrice, newPrice));
        }
    }

    public class MobileApp
    {
        public void Subscribe(Stock stock)
        {
            stock.PriceChanged += OnPriceChanged;
        }

        public void Unsubscribe(Stock stock)
        {
            stock.PriceChanged -= OnPriceChanged;
        }

        private void OnPriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine(
                $"[Mobile] your stocks price changed from {e.OldPrice} to {e.NewPrice}"
            );
        }
    }

    public class WebApp
    {
        public void Subscribe(Stock stock)
        {
            stock.PriceChanged += OnPriceChanged;
        }

        public void Unsubscribe(Stock stock)
        {
            stock.PriceChanged -= OnPriceChanged;
        }

        private void OnPriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine(
                $"[Web] your stocks price changed from {e.OldPrice} to {e.NewPrice}"
            );
        }
    }

    class Program
    {
        static void Main()
        {
            Stock appleStock = new Stock(150);

            MobileApp mobileApp = new MobileApp();
            WebApp webApp = new WebApp();

            mobileApp.Subscribe(appleStock);
            webApp.Subscribe(appleStock);

            appleStock.UpdatePrice(155);
            appleStock.UpdatePrice(160);

            Console.WriteLine("Unsubscribing Web App");
            webApp.Unsubscribe(appleStock);

            appleStock.UpdatePrice(165);
        }
    }
}

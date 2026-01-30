using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public interface IOrderState
    {
        void Pay(OrderContext order);
        void Ship(OrderContext order);
        void Cancel(OrderContext order);
    }

    public class OrderContext
    {
        public IOrderState CurrentState { get; private set; }

        public OrderContext()
        {
            CurrentState = new NewOrderState();
        }

        public void SetState(IOrderState state)
        {
            CurrentState = state;
        }

        public void Pay() => CurrentState.Pay(this);
        public void Ship() => CurrentState.Ship(this);
        public void Cancel() => CurrentState.Cancel(this);
    }

    public class NewOrderState : IOrderState
    {
        public void Pay(OrderContext order)
        {
            Console.WriteLine("Order paid.");
            order.SetState(new PaidOrderState());
        }

        public void Ship(OrderContext order)
        {
            Console.WriteLine("Cannot ship. Order not paid.");
        }

        public void Cancel(OrderContext order)
        {
            Console.WriteLine("Order cancelled.");
            order.SetState(new CancelledOrderState());
        }
    }

    public class PaidOrderState : IOrderState
    {
        public void Pay(OrderContext order)
        {
            Console.WriteLine("Order already paid.");
        }

        public void Ship(OrderContext order)
        {
            Console.WriteLine("Order shipped.");
            order.SetState(new ShippedOrderState());
        }

        public void Cancel(OrderContext order)
        {
            Console.WriteLine("Order cancelled and refunded.");
            order.SetState(new CancelledOrderState());
        }
    }

    public class ShippedOrderState : IOrderState
    {
        public void Pay(OrderContext order)
        {
            Console.WriteLine("Order already shipped.");
        }

        public void Ship(OrderContext order)
        {
            Console.WriteLine("Order already shipped.");
        }

        public void Cancel(OrderContext order)
        {
            Console.WriteLine("Cannot cancel. Order already shipped.");
        }
    }

    public class CancelledOrderState : IOrderState
    {
        public void Pay(OrderContext order)
        {
            Console.WriteLine("Order is cancelled.");
        }

        public void Ship(OrderContext order)
        {
            Console.WriteLine("Order is cancelled.");
        }

        public void Cancel(OrderContext order)
        {
            Console.WriteLine("Order already cancelled.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Start of code");
            OrderContext order = new OrderContext();

            order.Pay();
            order.Cancel();
            order.Ship();
            //order.Cancel();
            Console.ReadKey();
        }
    }
}

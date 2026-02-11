using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    // Client expects (Our Responsibility)
    public interface IPaymentProcessor
    {
        void Pay(decimal amount);
    }

    // Third party code
    public class LegacyPaymentGateway
    {
        public void MakePayment(int amountInRupees)
        {
            Console.WriteLine($"Not Paid Rs{amountInRupees} using legacy gateway");
        }
    }

    //Our Adapter
    public class PaymentAdapter : IPaymentProcessor
    {
        private readonly LegacyPaymentGateway _legacyGateway;

        public PaymentAdapter(LegacyPaymentGateway legacyGateway)
        {
            _legacyGateway = legacyGateway;
        }

        public void Pay(decimal amount)
        {
            _legacyGateway.MakePayment((int)amount);
        }
    }

    class Program
    {
        static void Main()
        {
            IPaymentProcessor payment =
                new PaymentAdapter(new LegacyPaymentGateway());

            payment.Pay(500);
        }
    }
}

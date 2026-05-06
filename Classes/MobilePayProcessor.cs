using Interface2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface2.Classes
{
    //public class MobilePayProcessor : IPaymentProcessor, INotifier
    public class MobilePayProcessor : IAdvancedPaymentProvider
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Behandler MobilePay-overførsel på {amount} kr... (klasse MobilePayProcessor)");
        }

        public void SendReceipt(string message)
        {
            Console.WriteLine($"Sender kvittering via MobilePay: {message}... (klasse MobilePayProcessor)");
        }
    }
}

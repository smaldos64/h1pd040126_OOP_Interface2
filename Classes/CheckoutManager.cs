using Interface2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface2.Classes
{
    public class CheckoutManager
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly INotifier? _notifier;

        // Vi "injecter" interfacene her (Constructor Dependency Injection)
        // Den fleksible Constructor tager to parametre, som begge er interfaces.
        // Det betyder, at vi kan sende enhver klasse,
        // der implementerer disse interfaces,
        // når vi opretter en instans af CheckoutManager.
        public CheckoutManager(IPaymentProcessor paymentProcessor,
                               INotifier? notifier = null)
        {
            this._paymentProcessor = paymentProcessor;
            this._notifier = notifier;
        }

        public CheckoutManager(IAdvancedPaymentProvider advancedPaymentProvider) :
            this(advancedPaymentProvider, advancedPaymentProvider)
        {
            
        }

        public void CompleteOrder(decimal total)
        {
            this._paymentProcessor.ProcessPayment(total);
            this._notifier?.SendReceipt($"Betaling på {total} kr. er gennemført.");
        }
    }
}

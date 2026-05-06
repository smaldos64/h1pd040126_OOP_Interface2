using Interface2.Classes;

namespace Interface2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCardProcessor creditCardProcessor_Object = new CreditCardProcessor();
            MobilePayProcessor mobilePayProcessor_Object = new MobilePayProcessor();
            EMailService eMailService_Object = new EMailService();

            CheckoutManager checkoutManager_Object = new CheckoutManager(creditCardProcessor_Object);
            CheckoutManager checkoutManager_Object1 = new CheckoutManager(mobilePayProcessor_Object);

            // Metoden herundeer er den metode, vi bør bruge, da den udnytter det faktum,
            // at MobilePayProcessor implementerer både IPaymentProcessor og INotifier.
            // Hermed overholder vi også Liskov Substitution Principle (L i SOLID), da vi kan erstatte IPaymentProcessor med
            // IAdvancedPaymentProvider uden at ændre på CheckoutManager's funktionalitet.
            // Desuden overholder vi S i SOLID (Single Responsibility Principle), da CheckoutManager
            // nu får 2 forskellige Interfaces, implementeret i 2 klasser,
            // der kun har én funktionalitet.
            // Interface segregation principle (I i SOLID) overholdes også,
            // da vi har opdelt funktionaliteten i flere interfaces,
            CheckoutManager checkoutManager_Object2 = new CheckoutManager(mobilePayProcessor_Object, eMailService_Object);

            // Linjen herunder giver compilr fejl, da CheckoutManager's constructor kræver en IPaymentProcessor,
            // og EMailService implementerer ikke dette interface.
            //CheckoutManager checkoutManager_Object3 = new CheckoutManager(eMailService_Object);

            Console.WriteLine();
            checkoutManager_Object.CompleteOrder(500);
            Console.WriteLine();
            checkoutManager_Object1.CompleteOrder(250);
            Console.WriteLine();
            checkoutManager_Object2.CompleteOrder(1000);

            Console.ReadKey();
        }
    }
}

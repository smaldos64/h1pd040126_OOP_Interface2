using Interface2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface2.Classes
{
    public class EMailService : INotifier
    {
        public void SendReceipt(string message)
        {
            Console.WriteLine($"Sender kvittering via E-mail: {message}... (klasse EMailService)");
        }
    }
}

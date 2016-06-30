using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mailManager = new MailManager();
            mailManager.MailArrived += (sender,  e) => {
                Console.WriteLine(
@"Title - {0}
body - {1}", e.Title, e.Body);
            };
            mailManager.SimulateMailArrived("Avi - Holon, you win 1000000$");

            Timer timer = new Timer(
            Irrelevant => { mailManager.SimulateMailArrived("Avi - Holon, you win 1000000$");}, null, 0, 1000);

            Console.ReadKey();
        }
    }
}

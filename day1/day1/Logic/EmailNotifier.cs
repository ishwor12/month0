using day1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Logic
{
    internal class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"EMAIL Sent To ...: {message}");
        }
        public class SmsNotifier : INotifier
        {
            public void Send(string message)
            {
                Console.WriteLine($"SMS: {message}");
            }
        }
    }
}

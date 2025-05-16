using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC2
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Please specify a file");
                return;
            }
            else
            {
                IView view = new View();

                Controller contr = new Controller(view, args[0]);

                contr.Start();
            }
        }
    }
}
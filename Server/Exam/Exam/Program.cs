using System;
using System.ServiceModel;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(KitchenService));

            host.Opened += (e, arg) => Console.WriteLine("Host is opened");
            host.Open();

            Console.ReadKey();
        }
    }
}

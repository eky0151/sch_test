using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Entities;
using System.Diagnostics;

namespace NHLServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(NHLService.NHLStatService)))
            {
                host.Open();
                Console.WriteLine("RUNNING : {0}", host.BaseAddresses[0].AbsoluteUri);
                Debug.Write("\n\nRUNNING : {0}", host.BaseAddresses[0].AbsoluteUri + "\n\n");
                Console.ReadLine();
            }
        }
    }
}

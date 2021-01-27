using IronSoftware.IronOcrConsoleDotNetSamples.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronSoftware.IronOcrConsoleDotNetSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(IExecuteApp);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            foreach (var app in types)
            {
                var process = ((IExecuteApp)Activator.CreateInstance(app));
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Start {app.Name}");
                var res = process.Run();
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} End {app.Name}");
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
    }
}

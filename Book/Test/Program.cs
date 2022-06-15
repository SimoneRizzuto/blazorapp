using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelAssembly = typeof(NorthwindDataContext).Assembly;
            var resourceStream =
                modelAssembly.GetManifestResourceStream("Northwind.Tutorial.NorthwindMappings.xml");
            return new NorthwindDataContext(XmlMappingSource.FromStream(resourceStream));

            Console.WriteLine("Hello World!");
        }
    }
}

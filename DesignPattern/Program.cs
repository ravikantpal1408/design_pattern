using System;
using DesignPattern.OpenClosePrincipal;

// using System.Diagnostics;
// using System.Runtime.InteropServices;

namespace DesignPattern
{
    static class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small); // creating new product 💫

            var tree = new Product("Tree", Color.Green, Size.Large);

            var house = new Product("House", Color.Blue, Size.Huge);

            Product[] products = {apple, tree, house};

            var productFilter = new ProductFilter();

            Console.WriteLine($"Green products (old): ");

            foreach (var p in productFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green.");
            }

            // now using better filter 
            var betterFilter = new BetterFilter();
            Console.WriteLine("Green products (new): ");
            foreach (var p in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green.");
            }

            Console.WriteLine("Large Blue Items : ");
            foreach (var p in betterFilter.Filter(products,
                new AddSpecification<Product>(new ColorSpecification(Color.Blue), new SizeFilter(Size.Huge))))
            {
                Console.WriteLine($" - {p.Name} is big & blue.");
            }

            Console.ReadKey();
        }
    }


    /*
     Single Responsibility principal is that a class should have only one responsibility to perform 👆😃
     
     *static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            var j = new Journal();
            // Entry to journal 
            j.AddEntry("Corona is declared as pandemic");
            j.AddEntry("I came back to her and for her !!");

            Console.WriteLine(j);


            var p = new Persistence();
            var filename = @"/Volumes/ravi128/temp/journal.txt";
            
            p.SaveToFile(j, filename, true);
            // try
            // {
            Process.Start("open", filename);
            // }
            // catch
            // {
            
            //     if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //     {
            //         // url = url.Replace("&", "^&");
            //         Process.Start(new ProcessStartInfo("cmd", $"/c start {filename}") { CreateNoWindow = true });
            //     }
            //     else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //     {
            //         Process.Start("xdg-open", filename);
            //     }
            //     else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            //     {
            //         Process.Start("open", filename);
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }


            Console.ReadKey();
        }
     * 
     */
}
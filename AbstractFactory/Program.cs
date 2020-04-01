using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using static System.Console;

namespace AbstractFactory
{
    /// <summary>
    /// Abstract Factory Method - gives abstract object instead of concrete object 
    /// </summary>
    public interface IHotDrink
    {
        void Consume();
    }

    public class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    public class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is sensational.");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Perpare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Perpare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy ! ");

            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Perpare(int amount)
        {
            WriteLine($"Grind some beans, boil water, pour {amount} ml, add");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        // public enum AvailableDrink
        // {
        //     Coffee,
        //     Tea
        // }

        // private Dictionary<AvailableDrink, IHotDrinkFactory> _factories =
        //     new Dictionary<AvailableDrink, IHotDrinkFactory>();
        //
        // public HotDrinkMachine()
        // {
        //     foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //     {
        //         var factory =
        //             (IHotDrinkFactory) Activator.CreateInstance(
        //                 Type.GetType("AbstractFactory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
        //
        //         _factories.Add(drink, factory);
        //     }
        // }
        //
        // public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        // {
        //     return _factories[drink].Perpare(amount);
        // }

        // above was violating the Open-Close principal of 👆
        // below is the solution 👇 that prevent violating of open/close principal

        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", String.Empty), (IHotDrinkFactory) Activator.CreateInstance(t)
                    ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available Drinks !!!");

            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i) && i >= 0 && i < factories.Count)
                {
                    WriteLine("Specify the amount : ");

                    s = ReadLine();

                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Perpare(amount);
                    }
                }

                WriteLine("Incorrect input input please try again ... \n ");
            }
        }
    }

    class Program
    {
        // OCP - open close principal
        static void Main(string[] args)
        {
            WriteLine("Abstract Factory Method \n");

            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            // var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drink.Consume();
            WriteLine();
        }
    }


    /*
     *    SUMMARY
     *     1- A factory method is a static method that creates object
     *     2- A factory can take care of object creation
     *     3- A factory can be external or reside inside the object as an inner class
     *     4- Hierarchies of factories can be used to create related objects
     * 
     */
}
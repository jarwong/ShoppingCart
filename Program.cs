using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingCart
{
    public class Program
    {
        private static List<string> ReadCatalogFromFile()
        {
            var reader = new StreamReader("catalog.txt");
            var line = "";
            var result = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                result.Add(line);
            }

            reader.Close();
            return result;
        }

        private static bool IsProductInCatalog(string product, List<string> catalog)
        {
            return catalog.Any(t => product == t);
        }

        public static void Main(string[] args)
        {
            var catalog = ReadCatalogFromFile();
            var cart = new List<string>();

            Console.WriteLine("Please create a cart of 5 items you'd like");

            while (cart.Count < 5)
            {
                Console.WriteLine("What is item " + (cart.Count + 1) + " you'd like to add to your shopping cart?");
                var potentialItem = Console.ReadLine();

                if (potentialItem == "quit")
                {
                    Console.WriteLine("Not filling up your cart? Okay.");
                    break;
                }
                if (IsProductInCatalog(potentialItem, catalog))
                {
                    Console.WriteLine(potentialItem + " is available\n");

                    cart.Add(potentialItem);

                    if (cart.Count == 5)
                    {
                        Console.WriteLine("Your shopping cart is full!");
                    }
                    continue;
                }

                Console.WriteLine(potentialItem + " is not available in our catalog.");
            }
           
            Console.WriteLine("\n\nHere's what you bought:");

            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        private static string[] ReadCatalogFromFile()
        {
            StreamReader myReader = new StreamReader("catalog.txt");
            string line = "";
            String[] Result = new String[1100];

            int counter = 0;

            while (line != null)
            {
                line = myReader.ReadLine();
                if (line != null)
                {
                    Result[counter] = line;
                    counter++;
                }
            }

            myReader.Close();
            return Result;
        }

        static bool IsProductInCatalog(string product, string[] catalog)
        {
            for (int i = 0; i < catalog.Length; i++)
            {
                if (product == catalog[i])
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            String[] catalog = ReadCatalogFromFile();
            String[] cart = new String[5];

            Console.WriteLine("Please create a cart of 5 items you'd like");
            int temp = 0;

            while (temp < 5)
            {
                Console.WriteLine("What is item " + (temp + 1) + " you'd like to add to your shopping cart?");
                String PotentialItem = Console.ReadLine();

                if (PotentialItem == "quit")
                {
                    Console.WriteLine("Not filling up your cart? Okay.");
                    break;
                }
                if (IsProductInCatalog(PotentialItem, catalog))
                {
                    Console.WriteLine(PotentialItem + " is available");
                    Console.WriteLine("");
                    cart[temp] = PotentialItem;
                    temp++;
                    if (temp == 5)
                        Console.WriteLine("Your shopping cart is full!");
                    continue;
                }

                Console.WriteLine(PotentialItem + " is not available in our catalog.");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Here's what you bought:");

            foreach (string item in cart)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }
    }
}

using System;
using SearchFight.Infraestructure;
using System.Linq;
namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please type a word to search ...");
            }
            Console.WriteLine("SearchFighting ...");
            var searchFight = Factory.createEngines();
            Console.WriteLine(searchFight.loadResults(args.ToList()));
        }
    }
}
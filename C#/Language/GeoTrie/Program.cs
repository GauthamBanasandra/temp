using System;
using FileHelpers;
using Gma.DataStructures.StringSearch;

namespace GeoTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileHelperEngine = new FileHelperEngine<GeoLocation>();
            var geoLocations = fileHelperEngine.ReadFile(@"C:\Users\Gautham\Downloads\IN\IN.txt");
            Console.WriteLine($"Count={geoLocations.Length}");

            var indexer = new UkkonenTrie<GeoLocation>(geoLocations.Length);
            foreach (var geoLocation in geoLocations)
            {
                indexer.Add(geoLocation.AsciiName, geoLocation);
            }
            Console.WriteLine("Finished indexing");

            var result = indexer.Retrieve("Bangalore");
            foreach (var geoLocation in result)
            {
                Console.WriteLine($"Id={geoLocation.Id} Name={geoLocation.Name}");
            }
        }
    }
}

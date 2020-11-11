using System;
using System.Collections.Generic;

namespace CustomComparerHashSet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new HashSet<Person>(new PersonComparer())
            {
                new Person() {Id = "abcd", Name = "a"},
                new Person() {Id = "efgh", Name = "b"},
                new Person() {Id = "abcd", Name = "a"}
            };

            Console.WriteLine($"People count = {people.Count}");
        }
    }
}

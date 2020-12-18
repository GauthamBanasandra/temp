using System;

namespace XMLCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boy = new Person
            {
                Id = "A123",
                Name = "a",
                PhoneNumber = 123,
                PlaceOfBirth = "Bangalore",
                DateAndTimeOfBirth = DateTime.Now,
                Gender = Gender.Male,
                SessionId = "bjf"
            };

            var girl = new Person
            {
                Id = "B456",
                Name = "b",
                PhoneNumber = 456,
                PlaceOfBirth = "Bangalore",
                DateAndTimeOfBirth = DateTime.Now,
                Gender = Gender.Female,
                SessionId = "ckvj"
            };

            Console.WriteLine(XmlCreator.Create(boy, girl));
        }
    }
}

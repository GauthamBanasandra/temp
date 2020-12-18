using System;
using System.Collections.Generic;
using System.Text;

namespace XMLCreator
{
    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string PlaceOfBirth { get; set; }

        public DateTime DateAndTimeOfBirth { get; set; }

        public Gender Gender { get; set; }

        public virtual string? SessionId { get; set; }
    }
}

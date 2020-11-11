using System;
using System.Collections.Generic;
using System.Text;

namespace CustomComparerHashSet
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null || y == null)
            {
                throw new Exception("Person object must not be null");
            }
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Person obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}

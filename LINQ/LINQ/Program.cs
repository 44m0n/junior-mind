using System;
using System.Collections.Generic;

namespace LINQ
{
    struct Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            Person[] people =
            {
                new Person { Name = "John", Age = 8 },
                new Person { Name = "Johnny", Age = 4 },
                new Person { Name = "Johannes", Age = 1 }
            };

            foreach (var el in people.OrderBy(e => e.Age, Comparer<int>.Default))
            {
                Console.WriteLine(el.Name);
            }
        }
    }
}

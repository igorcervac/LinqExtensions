using LinqApp;
using System;
using System.Linq;

namespace LinqExtensions
{
    public class DistinctBy
    {
        public static void Main()
        {
            var certifications = new[]
            {
                new 
                { 
                    Id = 1, 
                    Title = "AZ-900" 
                },
                new 
                { 
                    Id = 1, 
                    Title = "AZ-900" 
                },
                new
                {
                    Id = 2, 
                    Title = "AZ-204"
                }
            }.AsEnumerable();

            Console.WriteLine("Input:");

            foreach (var c in certifications)
            {
                Console.WriteLine($"{c.Id}, {c.Title}");
            }

            certifications = certifications.DistinctBy(x => x.Id);

            Console.WriteLine("Output:");
            foreach (var c in certifications)
            {
                Console.WriteLine($"{c.Id}, {c.Title}");
            }

            Console.ReadLine();
        }
    }
}

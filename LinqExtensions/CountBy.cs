using System;

namespace LinqExtensions
{
    internal class MinByApp
    {
        static void Main()
        {
            var ceritifications = new[]
            {
                new 
                { 
                    Title = "AZ-900", 
                    Year = 2022
                },
                new 
                { 
                    Title = "AZ-204", 
                    Year = 2023
                },
                 new
                {
                    Title = "AZ-400",
                    Year = 2023
                }
            };

            var dictionary = ceritifications.CountBy(x => x.Year);

            foreach (var keyValue in dictionary)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
            }
            Console.ReadLine();
        }
    }
}

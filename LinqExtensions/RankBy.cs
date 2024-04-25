using System;
using System.Linq;

namespace LinqApp
{
    internal class MinByApp
    {
        static void Main()
        {
            var ceritifications = new[]
            {
                new
                {
                    Title = "AZ-204",
                    Year = 2023
                },
                new
                { 
                    Title = "AZ-900", 
                    Year = 2022
                },
                 new
                {
                    Title = "AI-900",
                    Year = 2024
                }
            };

            var rankedByOldest = ceritifications.RankBy(x => x.Year);

            Console.WriteLine("Certifications:");
            Array.ForEach(ceritifications.ToArray(), x => Console.WriteLine($"{x.Title} {x.Year}"));

            Console.WriteLine("Certifications ranked by year:");
            Array.ForEach(rankedByOldest.ToArray(), x => Console.WriteLine($"{x.Key.Title} ranked {x.Value}"));

            Console.ReadLine();
        }
    }
}

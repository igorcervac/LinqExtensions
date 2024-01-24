using System;

namespace LinqApp
{
    internal class TrySelectProgram
    {
        static void Main(string[] args)
        {
            var certificates = new[]
            {
                new 
                { 
                    Title = "AZ-900", 
                    Year = 2022
                },
                new 
                { 
                    Title = "AZ-204", 
                    Year = 2024
                },
                null
            };

            foreach (var title in certificates.TrySelect(c => c.Title))
            {
                Console.WriteLine(title);
            }

            Console.ReadLine();
        }

    }
}

using System;

namespace LinqApp
{
    internal class MinByApp
    {
        static void Main()
        {
            var albums = new[]
            {
                new 
                { 
                    Title = "Album", 
                    Year = 2021
                },
                new 
                { 
                    Title = "Album2", 
                    Year = 2022
                },
                 new
                {
                    Title = "Album3",
                    Year = 2023
                }
            };
            Console.WriteLine(albums.MinBy(x => x.Year));
            Console.ReadLine();
        }
    }
}

using System;

namespace LinqApp
{
    internal class OrProgram
    {
        static void Main(string[] args)
        {
            bool[] values = { false, true, true };

            Console.WriteLine(values.LogicalAnd());
            Console.WriteLine(values.LogicalOr());

            Console.ReadLine();
        }

    }
}

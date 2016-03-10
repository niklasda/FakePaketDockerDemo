using System;
using SomeLogic.Calc;

namespace ConsoleApplication1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var l = new Logic1();
            var res = l.Add(2, 3);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

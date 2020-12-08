using CleanCodeLab3.Utilities;
using System;

namespace CleanCodeLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new PizzaFactory();
            var pizza = factory.CreateMargerita();
        }
    }
}

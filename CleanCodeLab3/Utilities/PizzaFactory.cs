using CleanCodeLab3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Utilities
{
    public class PizzaFactory
    {
        public Pizza CreateMargerita()
        {
            return new Pizza();
        }
    }
}

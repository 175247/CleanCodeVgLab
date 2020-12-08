using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Utilities
{
    public class PizzaBuilder
    {
        private string _name;
        private double _price;

        public PizzaBuilder()
        {
        }

        public PizzaBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public PizzaBuilder SetPrice(double price)
        {
            _price = price;
            return this;
        }
    }
}

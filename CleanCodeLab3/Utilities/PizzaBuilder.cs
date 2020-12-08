using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Utilities
{
    public class PizzaBuilder
    {
        public string _name { get; set; }
        private double _price;

        public PizzaBuilder(string name)
        {
            _name = name;
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

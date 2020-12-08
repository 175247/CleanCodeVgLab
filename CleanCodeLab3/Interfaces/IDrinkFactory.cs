using CleanCodeLab3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Interfaces
{
    public interface IDrinkFactory
    {
        public Drink CreateCocaCola();
        public Drink CreateFanta();
        public Drink CreateSprite();
    }
}

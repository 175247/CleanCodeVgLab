﻿using CleanCodeLab3.Models;

namespace CleanCodeLab3.Interfaces
{
    public interface IPizzaFactory
    {
        public Pizza AddToppingToPizza(Pizza pizza, Ingredient ingredient);
        public Pizza CreateMargerita();
        public Pizza CreateHawaii();
        public Pizza CreateKebabPizza();
        public Pizza CreateQuattroStagioni();
    }
}

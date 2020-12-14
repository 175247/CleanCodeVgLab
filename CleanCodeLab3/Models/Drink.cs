using CleanCodeLab3.Interfaces;

namespace CleanCodeLab3.Models
{
    public class Drink : IOrderable
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}

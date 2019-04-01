namespace TaxCalculator
{
    public class Item
    {
        public Item(decimal price, string name)
        {
            Price = price;
            Name = name;
            Display = $"1 {Name}: {Price}";
        }
        public decimal Price { get; }
        public string Name { get; }
        public string Display { get; }
    }
}

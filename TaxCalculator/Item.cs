namespace TaxCalculator
{
    public class Item
    {
        public Item(decimal price, string name, bool isTaxExempt = false)
        {
            Price = price;
            Name = name;
            Display = $"1 {Name}: {Price}";
            IsTaxExempt = isTaxExempt;
        }
        public decimal Price { get; }
        public string Name { get; }
        public string Display { get; }
        public bool IsTaxExempt { get; set; }
    }
}

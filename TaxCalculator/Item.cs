namespace TaxCalculator
{
    public class Item
    {
        public Item(decimal price, string name, bool isTaxExempt = false, bool isImported = false)
        {
            Price = price;
            Name = name;
            Display = $"1 {Name}: {Price}";
            IsTaxExempt = isTaxExempt;
            IsImported = isImported;
        }
        public decimal Price { get; }
        public string Name { get; }
        public string Display { get; }
        public bool IsTaxExempt { get; set; }
        public bool IsImported { get; set; }
    }
}

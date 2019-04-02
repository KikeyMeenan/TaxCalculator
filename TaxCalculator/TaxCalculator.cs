namespace TaxCalculator
{
    public class TaxCalculator : ITaxCalculator
    {
        const decimal BaseTax = 10;
        const decimal ImportTax = 5;

        public decimal GetSalesTax(Item item)
        {
            var totalITemTax = 0m;
            if (!item.IsTaxExempt)
            {
                totalITemTax = item.Price / BaseTax;
            }
            return totalITemTax;
        }
    }

    public interface ITaxCalculator
    {
        decimal GetSalesTax(Item item);
    }
}

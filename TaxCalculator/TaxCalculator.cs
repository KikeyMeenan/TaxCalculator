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
                totalITemTax = (BaseTax / 100) * item.Price;
            }
            if (item.IsImported)
            {
                totalITemTax += (ImportTax / 100) * item.Price;
            }
            return totalITemTax;
        }
    }

    public interface ITaxCalculator
    {
        decimal GetSalesTax(Item item);
    }
}

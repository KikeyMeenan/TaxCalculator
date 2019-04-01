namespace TaxCalculator
{
    public class TaxCalculator: ITaxCalculator
    {
        const decimal BaseTax = 10;
        const decimal ImportTax = 5;

        public decimal GetSalesTax(Item item)
        {
            return item.Price/BaseTax;
        }
    }

    public interface ITaxCalculator
    {
        decimal GetSalesTax(Item item);
    }
}

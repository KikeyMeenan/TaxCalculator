using System;

namespace TaxCalculator
{
    public class TaxCalculator : ITaxCalculator
    {
        const decimal BaseTax = 10;
        const decimal ImportTax = 5;

        public decimal GetSalesTax(Item item)
        {
            var totalItemTax = 0m;
            if (!item.IsTaxExempt)
            {
                totalItemTax = Math.Round(((BaseTax * item.Price) / 100) * 20) / 20;
            }
            if (item.IsImported)
            {
                totalItemTax += Math.Round(((ImportTax * item.Price) / 100) * 20) / 20;
            }
            return totalItemTax;
        }
    }

    public interface ITaxCalculator
    {
        decimal GetSalesTax(Item item);
    }
}

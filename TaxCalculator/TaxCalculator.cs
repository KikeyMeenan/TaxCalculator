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
                totalItemTax = BaseTax * item.Price / 100;
            }
            if (item.IsImported)
            {
                totalItemTax += ImportTax * item.Price / 100;
            }
            return Math.Ceiling(totalItemTax * 20) / 20;
        }
    }

    public interface ITaxCalculator
    {
        decimal GetSalesTax(Item item);
    }
}

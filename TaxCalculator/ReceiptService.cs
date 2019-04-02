using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public class ReceiptService
    {
        ITaxCalculator _TaxCalculator;

        public ReceiptService(ITaxCalculator TaxCalculator)
        {
            _TaxCalculator = TaxCalculator;
        }

        public string GetReceipt(IList<Item> items)
        {
            var totalPrice = items.Select(item => item.Price).Sum();
            var totalTax = items.Select(item => _TaxCalculator.GetSalesTax(item)).Sum();

            var result = string.Join(" ", items.Select(x => x.Display)).Trim();
            result += $" Sales Taxes: {totalTax}";
            result += $" Total: {totalPrice+totalTax}";

            return result;
        }
    }
}

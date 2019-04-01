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
            var result = string.Join(" ", items.Select(x => x.Display)).Trim();
            result += $" Sales Taxes: {items.Select(item => _TaxCalculator.GetSalesTax(item)).Sum()}";
            return result;
        }
    }
}

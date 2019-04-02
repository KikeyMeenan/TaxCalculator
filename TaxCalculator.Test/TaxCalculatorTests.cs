using System.Collections.Generic;
using Xunit;

namespace TaxCalculator.Test
{
    public class TaxCalculatorTests
    {
        TaxCalculator Sut;
        public TaxCalculatorTests()
        {
            Sut = new TaxCalculator();
        }

        [Fact]
        public void GivenItemAppliesOnlyBaseTax_RoundTaxUpToNearestPointZeroFive()
        {
            var result = Sut.GetSalesTax(new Item(10.3m, "some name"));
            Assert.Equal(1.05m, result);
        }

        [Fact]
        public void GivenItemAppliesOnlyImport_RoundTaxUpToNearestPointZeroFive()
        {
            var result = Sut.GetSalesTax(new Item(10.2m, "some name", true, true));
            Assert.Equal(0.55m, result);
        }
    }
}
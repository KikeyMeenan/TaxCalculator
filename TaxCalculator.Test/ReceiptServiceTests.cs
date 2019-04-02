using System.Collections.Generic;
using Xunit;

namespace TaxCalculator.Test
{
    public class ReceiptServiceTests
    {
        ReceiptService Sut;
        public ReceiptServiceTests()
        {
            Sut = new ReceiptService(new TaxCalculator());
        }

        [Fact]
        public void GivenAnItemIsProvided_WhenReceiptIsRequested_ThenReturnItemNameAndPriceInReceipt()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name") };

            Assert.Contains("1 some name: 100", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenManyItemsAreProvided_WhenReceiptIsRequested_ThenReturnAllItemsInReceipt()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name"), new Item(200m, "some other name") };

            Assert.Contains("1 some name: 100 1 some other name: 200", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenItemsAreProvided_WhenReceiptIsRequested_ThenIncludeSalesTaxInReceipt()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name") };

            Assert.Contains("Sales Taxes", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenNonTaxExemptItemIsProvided_WhenReceiptIsRequested_ThenSalesTaxIsApplied()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name") };

            Assert.Contains("Sales Taxes: 10", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenItemIsProvided_WhenReceiptIsRequested_ThenTotalIsReturned()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name") };

            Assert.Contains("Total: 110", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenTaxExemptItemProvided_WhenReceiptIsRequested_ThenSalesTaxIsNotApplied()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name", true) };

            Assert.Contains("Sales Taxes: 0", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenImportedTaxExemptItemProvided_WhenReceiptIsRequested_ThenImportTaxOnlyIsApplied()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name", true, true) };

            Assert.Contains("Sales Taxes: 5", Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void GivenImportedTaxableItemProvided_WhenReceiptIsRequested_ThenImportTaxAndBaseTaxAreApplied()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name", false, true) };

            Assert.Contains("Sales Taxes: 15", Sut.GetReceipt(requestedItem));
        }
    }
}
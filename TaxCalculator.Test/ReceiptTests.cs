using System.Collections.Generic;
using Xunit;

namespace TaxCalculator.Test
{
    public class ReceiptTests
    {
        ReceiptService Sut;
        public ReceiptTests()
        {
            Sut = new ReceiptService(new TaxCalculator());
        }

        [Fact]
        public void GivenAnItemIsProvided_WhenReceiptIsRequested_ThenReturnItemNameAndPriceInReceipt()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name")};
            
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
        public void GivenItemsAreProvided_WhenReceiptIsRequested_ThenSalesTaxIsApplied()
        {
            var requestedItem = new List<Item>() { new Item(100m, "some name") };

            Assert.Contains("Sales Taxes: 10", Sut.GetReceipt(requestedItem));
        }
    }
}
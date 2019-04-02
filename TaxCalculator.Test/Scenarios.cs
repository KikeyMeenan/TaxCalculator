using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TaxCalculator.Test
{
    public class Scenarios
    {
        ReceiptService Sut;
        public Scenarios()
        {
            Sut = new ReceiptService(new TaxCalculator());
        }

        [Fact]
        public void Scenario_1()
        {
            var requestedItem = new List<Item>() {
                new Item(12.49m, "book", true),
                new Item(14.99m, "music CD"),
                new Item(0.85m, "chocolate bar")
            };

            const string exepcted = "1 book: 12.49 1 music CD: 14.99 1 chocolate bar: 0.85 Sales Taxes: 1.50 Total: 29.83";

            Assert.Contains(exepcted, Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void Scenario_2()
        {
            var requestedItem = new List<Item>() {
                new Item(10.00m, "imported box of chocolates", true, true),
                new Item(47.50m, "imported bottle of perfume", false, true)
            };

            const string exepcted = "1 imported box of chocolates: 10.00 1 imported bottle of perfume: 47.50 Sales Taxes: 7.65 Total: 65.15";

            Assert.Contains(exepcted, Sut.GetReceipt(requestedItem));
        }

        [Fact]
        public void Scenario_3()
        {
            var requestedItem = new List<Item>() {
                new Item(27.99m, "imported bottle of perfume", false, true),
                new Item(18.99m, "bottle of perfume"),
                new Item(9.75m, "packet of paracetemol", true),
                new Item(11.25m, "box of imported chocolates", true, true)
            };

            const string exepcted = "1 imported bottle of perfume: 27.99 1 bottle of perfume: 18.99 1 packet of paracetemol: 9.75 1 box of imported chocolates: 11.25 Sales Taxes: 6.7 Total: 74.68";

            Assert.Contains(exepcted, Sut.GetReceipt(requestedItem));
        }
    }
}

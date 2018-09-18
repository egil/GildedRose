using GildedRose.Console;
using GildedRose.Console.Inventory;
using Xunit;

namespace GildedRose.Tests
{
    public class InventoryUpdaterTests
    {
        private static Item CreateSulfurasItem(int quality = 80)
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = quality };
        }

        private static Item CreateAgedBrie(int sellIn = 2, int quality = 0)
        {
            return new Item() { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        }

        private static Item CreateBackstagePass(int sellIn = 15, int quality = 10)
        {
            return new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };
        }

        [Fact(DisplayName = "At the end of each day our system lowers both values for every item")]
        public void SellInAndQualityIsLoweredEachDay()
        {
            var item = new Item { Quality = 1, SellIn = 1 };

            InventoryUpdater.Update(item);

            Assert.Equal(0, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact(DisplayName = "The Quality of an item is never negative")]
        public void QuantityNeverNegative()
        {
            var item = new Item { SellIn = 0, Quality = 0 };

            InventoryUpdater.Update(item);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact(DisplayName = "Once the sell by date has passed, Quality degrades twice as fast")]
        public void QualityDegradsTwiceAsFastOnceSellByHasPassed()
        {
            var item = new Item { SellIn = 0, Quality = 4 };

            InventoryUpdater.Update(item);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(2, item.Quality);
        }

        [Fact(DisplayName = "Sulfuras never has to be sold or decreases in Quality")]
        public void SulFurasNeverDecreasesInQuality()
        {
            var item = CreateSulfurasItem();

            InventoryUpdater.Update(item);

            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact(DisplayName = "Aged Brie increases in quality the older it gets ")]
        public void AgedBrieIncreaseInQualityWhenOlder()
        {
            var item = CreateAgedBrie(sellIn: 1, quality: 0);

            InventoryUpdater.Update(item);

            Assert.Equal(1, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact(DisplayName = "Aged Brie increases in quality by 2 after its sell date")]
        public void AgedBrieIncreaseInQualityBy2AfterSellDate()
        {
            var item = CreateAgedBrie(sellIn: 0, quality: 0);

            InventoryUpdater.Update(item);

            Assert.Equal(2, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact(DisplayName = "The quality of an item is never more than 50")]
        public void QualityOfItemNeverRaisedAbove50()
        {
            var item = CreateAgedBrie(quality: 50, sellIn: 2);

            InventoryUpdater.Update(item);

            Assert.Equal(50, item.Quality);
            Assert.Equal(1, item.SellIn);
        }

        [Theory(DisplayName = "Backstage passes, increases in Quality as it's SellIn value approaches; " +
                              "Quality increases by 2 when there are 10 days or less and by 3 when there " +
                              "are 5 days or less but Quality drops to 0 after the concert")]
        [InlineData(11, 0, 10, 1)]
        [InlineData(10, 0, 9, 2)]
        [InlineData(5, 0, 4, 3)]
        [InlineData(0, 20, -1, 0)]
        public void BackstagePassesQualityIncreaseTest(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = CreateBackstagePass(sellIn: sellIn, quality: quality);

            InventoryUpdater.Update(item);

            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact(DisplayName = "Conjured items degrade in Quality twice as fast as normal items")]
        public void ConjuredItemsDegradeTwiceAsFastAsNormalItems()
        {
            var item = new Item { Name = "Conjured", SellIn = 1, Quality = 2 };

            InventoryUpdater.Update(item);

            Assert.Equal(0, item.Quality);
            Assert.Equal(0, item.SellIn);
        }
    }
}

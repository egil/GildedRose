namespace GildedRose.Console.Inventory
{
    class BackstagePassesItemUpdater : ItemUpdater
    {
        public BackstagePassesItemUpdater(string itemName = "Backstage passes to a TAFKAL80ETC concert") : base(itemName)
        {
        }

        public override void Update(Item item)
        {
            DecreaseSellIn(item);
            IncreaseQuality(item);

            if (item.SellIn < 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 5)
            {
                IncreaseQuality(item);
            }

            if (HasSellingDatePassed(item))
            {
                item.Quality = 0;
            }
        }
    }
}
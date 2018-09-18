namespace GildedRose.Console.Inventory
{
    class AgedBrieItemUpdater : ItemUpdater
    {
        public AgedBrieItemUpdater(string itemName = "Aged Brie") : base(itemName)
        {
        }

        public override void Update(Item item)
        {
            DecreaseSellIn(item);
            IncreaseQuality(item);

            if (HasSellingDatePassed(item))
            {
                IncreaseQuality(item);
            }
        }
    }
}
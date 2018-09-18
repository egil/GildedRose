namespace GildedRose.Console.Inventory
{
    class GeneralItemUpdater : ItemUpdater
    {
        public GeneralItemUpdater() : base(string.Empty)
        {
        }

        public override void Update(Item item)
        {
            DecreaseSellIn(item);
            DecreaseQuantity(item);

            if (HasSellingDatePassed(item))
            {
                DecreaseQuantity(item);
            }
        }
    }
}
namespace GildedRose.Console.Inventory
{
    class ConjuredItemUpdater : ItemUpdater
    {
        public ConjuredItemUpdater(string itemName = "Conjured") : base(itemName)
        {
        }

        public override void Update(Item item)
        {
            DecreaseSellIn(item);
            DecreaseQuantity(item);
            DecreaseQuantity(item);
        }
    }
}
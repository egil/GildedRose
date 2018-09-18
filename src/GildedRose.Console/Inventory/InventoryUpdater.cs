using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Inventory
{
    public static class InventoryUpdater
    {
        private static readonly IList<ItemUpdater> SpecialItemUpdaters = new List<ItemUpdater>
        {
            new AgedBrieItemUpdater(),
            new BackstagePassesItemUpdater(),
            new ConjuredItemUpdater(),
            new SulfurasItemUpdater()
        };

        private static readonly ItemUpdater GeneralItemUpdater = new GeneralItemUpdater();

        public static void Update(Item item)
        {
            var updater = SpecialItemUpdaters.FirstOrDefault(x => x.Matches(item)) ?? GeneralItemUpdater;
            updater.Update(item);
        }
    }
}

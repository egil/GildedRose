using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Inventory
{
    abstract class ItemUpdater
    {
        private readonly string _itemName;

        protected ItemUpdater(string itemName)
        {
            _itemName = itemName;
        }

        public bool Matches(Item item) => item.Name?.Equals(_itemName, StringComparison.Ordinal) ?? false;

        public abstract void Update(Item item);

        protected void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        protected void DecreaseQuantity(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        protected void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        protected bool HasSellingDatePassed(Item item)
        {
            return item.SellIn < 0;
        }
    }
}

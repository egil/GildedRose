# My solution to the Gilded Rose Refactoring Kata
This fork of [https://github.com/NotMyself/GildedRose](https://github.com/NotMyself/GildedRose) contains
my solution the Gilded Rose Refactoring Kata.

This was my approach:

1. Moved the `UpdateQuantity` method to a dedicated class named `InventoryUpdater`
2. Write unittests to cover the existing features, based on the specification.
3. Refactor to use the a variant of the [Chain of Responsibility pattern](https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern).
4. Add the new "Conjoured" requirement as an `ItemUpdater`.

All credit for an excellent kata goes to [@TerryHughes](https://twitter.com/TerryHughes) and [@NotMyself](https://twitter.com/NotMyself).
The original repository can be found at [https://github.com/NotMyself/GildedRose](https://github.com/NotMyself/GildedRose).

## License
MIT

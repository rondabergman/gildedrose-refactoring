using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests_ItemSellIn
{
    [Fact]
    public void VestDecreasesSellIn()
    {
        IList<Item> Items = new List<Item> { 
            new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(9, Items[0].SellIn);
    }

    [Fact]
    public void AgedBrieDecreasesSellIn()
    {
        IList<Item> Items = new List<Item> { 
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
    }

    [Fact]
    public void SulfurasSellInDoesNotChange()
    {
        IList<Item> Items = new List<Item> {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(5, Items[0].SellIn);
    }
}
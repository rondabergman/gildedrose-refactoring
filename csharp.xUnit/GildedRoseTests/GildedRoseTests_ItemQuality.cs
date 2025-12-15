using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests_ItemQuality
{
    [Fact]
    public void VestDecreasesInQuality()
    {
        IList<Item> Items = new List<Item> { 
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(19, Items[0].Quality);
    }

    [Fact]
    public void AgedBrieIncreasesInQuality()
    {
        IList<Item> Items = new List<Item> { 
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].Quality);
    }

    [Fact]
    public void ElixerDecreasesInQuality()
    {
        IList<Item> Items = new List<Item> {
            new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(19, Items[0].Quality);
    }

    [Fact]
    public void SulfurasQualityDoesNotChange()
    {
        IList<Item> Items = new List<Item> { 
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(80, Items[0].Quality);
    }

    [Fact]
    public void BackstagePassesQualityDoesNotChange()
    {
        IList<Item> Items = new List<Item> {
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(80, Items[0].Quality);
    }
}
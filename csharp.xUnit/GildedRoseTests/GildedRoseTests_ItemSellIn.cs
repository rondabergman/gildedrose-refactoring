using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests_ItemSellIn
{
    [Fact]
    public void VestDecreasesSellIn()
    {
        IList<Item> Items = new List<Item>();
        Item standard = new ItemBuilder()
            .WithName("Normal Item")
            .WithSellIn(10)
            .WithQuality(20)
            .Build();

        Items.Add(standard);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(9, Items[0].SellIn);
    }

    [Fact]
    public void AgedBrieDecreasesSellIn()
    {
        IList<Item> Items = new List<Item>();
        Item brie = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(2)
            .WithQuality(0)
            .Build();

        Items.Add(brie);
        
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
    }

    [Fact]
    public void SulfurasSellInDoesNotChange()
    {
        IList<Item> Items = new List<Item>();
        Item sulfuras = new ItemBuilder()
            .WithName("Sulfuras, Hand of Ragnaros")
            .WithSellIn(5)
            .WithQuality(80)
            .Build();

        Items.Add(sulfuras);
        
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(5, Items[0].SellIn);
    }
}
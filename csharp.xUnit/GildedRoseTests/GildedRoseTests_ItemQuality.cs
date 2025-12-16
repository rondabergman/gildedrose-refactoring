using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests_ItemQuality
{
    [Fact]
    public void VestDecreasesInQuality()
    {
        IList<Item> Items = new List<Item>();
        Item vest = new ItemBuilder()
            .WithName("+5 Dexterity Vest")
            .WithSellIn(10)
            .WithQuality(20)
            .Build();

        Items.Add(vest);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(19, Items[0].Quality);
    }

    [Fact]
    public void StandardItemQualityChangesByNeg2_WithSellInLessThan1()
    {
        IList<Item> Items = new List<Item>();
        Item vest = new ItemBuilder()
            .WithName("+5 Dexterity Vest")
            .WithSellIn(0)
            .WithQuality(80)
            .Build();

        Items.Add(vest);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(78, Items[0].Quality);
    }

    [Fact]
    public void StandardItemQualityDoesNotGoBelow0()
    {
        IList<Item> Items = new List<Item>();
        Item vest = new ItemBuilder()
            .WithName("+5 Dexterity Vest")
            .WithSellIn(1)
            .WithQuality(0)
            .Build();

        Items.Add(vest);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void AgedBrieIncreasesInQuality()
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
        Assert.Equal(1, Items[0].Quality);
    }

    [Fact]
    public void AgedBrieIncreasesInQualityBy2_WithSellInLessThan1()
    {
        IList<Item> Items = new List<Item>();
        Item brie = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(0)
            .WithQuality(0)
            .Build();

        Items.Add(brie);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(2, Items[0].Quality);
    }

    [Fact]
    public void AgedBrieDoesNotIncreasesInQualityAfter50()
    {
        IList<Item> Items = new List<Item>();
        Item brie = new ItemBuilder()
            .WithName("Aged Brie")
            .WithSellIn(0)
            .WithQuality(50)
            .Build();

        Items.Add(brie);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void ElixerDecreasesInQuality()
    {
        IList<Item> Items = new List<Item>();
        Item elixir = new ItemBuilder()
            .WithName("Elixir of the Mongoose")
            .WithSellIn(10)
            .WithQuality(20)
            .Build();

        Items.Add(elixir);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(19, Items[0].Quality);
    }

    [Fact]
    public void SulfurasQualityDoesNotChange_WithSellInGreaterThan0()
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
        Assert.Equal(80, Items[0].Quality);
    }

    [Fact]
    public void SulfurasQualityDoesNotChange_WithSellInLessThan1()
    {
        IList<Item> Items = new List<Item>();
        Item sulfuras = new ItemBuilder()
            .WithName("Sulfuras, Hand of Ragnaros")
            .WithSellIn(0)
            .WithQuality(80)
            .Build();

        Items.Add(sulfuras);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(80, Items[0].Quality);
    }

    [Fact]
    public void BackstagePassesQualityDoesNotChangeWithQualityGreaterThan50()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Backstage passes to a TAFKAL80ETC concert")
            .WithSellIn(2)
            .WithQuality(51)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(51, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityChangeBy1_WithQualityLessThan50_SellInGreaterThan10()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Backstage passes to a TAFKAL80ETC concert")
            .WithSellIn(11)
            .WithQuality(30)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(31, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityChangeBy2_WithQualityLessThan50_SellInLessThan11()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Backstage passes to a TAFKAL80ETC concert")
            .WithSellIn(10)
            .WithQuality(30)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(32, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityChangeBy3_WithQualityLessThan50_SellInLessThan6()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Backstage passes to a TAFKAL80ETC concert")
            .WithSellIn(5)
            .WithQuality(30)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(33, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_Quality0_WithSellInLessThan1()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Backstage passes to a TAFKAL80ETC concert")
            .WithSellIn(0)
            .WithQuality(30)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void ConjuredItems_DegradeTwiceAsFast()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Conjured Mana Cake")
            .WithSellIn(10)
            .WithQuality(30)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(28, Items[0].Quality);
    }

    [Fact]
    public void ConjuredItems_DegradeTwiceAsFastButDoesNotGoBelow0()
    {
        IList<Item> Items = new List<Item>();
        Item passes = new ItemBuilder()
            .WithName("Conjured Mana Cake")
            .WithSellIn(10)
            .WithQuality(1)
            .Build();

        Items.Add(passes);

        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }
}
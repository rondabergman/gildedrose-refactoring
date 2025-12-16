using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");



        IList<Item> items = new List<Item>()
        {
            {
                new ItemBuilder()
                .WithName("+5 Dexterity Vest")
                .WithSellIn(10)
                .WithQuality(20)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Aged Brie")
                .WithSellIn(2)
                .WithQuality(0)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Elixir of the Mongoose")
                .WithSellIn(5)
                .WithQuality(7)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Sulfuras, Hand of Ragnaros")
                .WithSellIn(0)
                .WithQuality(80)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Sulfuras, Hand of Ragnaros")
                .WithSellIn(-1)
                .WithQuality(80)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Backstage passes to a TAFKAL80ETC concert")
                .WithSellIn(15)
                .WithQuality(20)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Backstage passes to a TAFKAL80ETC concert")
                .WithSellIn(10)
                .WithQuality(49)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Backstage passes to a TAFKAL80ETC concert")
                .WithSellIn(5)
                .WithQuality(49)
                .Build()
            },
            {
                new ItemBuilder()
                .WithName("Conjured Mana Cake")
                .WithSellIn(3)
                .WithQuality(6)
                .Build()
            }
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name , sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}
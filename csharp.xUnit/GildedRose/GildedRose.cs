using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                continue;

            if (Items[i].Quality == 0 && Items[0].Name != "Aged Brie")
            {
                if (Items[i].SellIn > 0)
                {
                    Items[i].SellIn -= 1;
                }
                continue;
            }
            switch (Items[i].Name)
            {
                case "Aged Brie":
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality += 1;
                    }

                    if (Items[i].SellIn < 1 && Items[i].Quality < 50)
                    {
                        Items[i].Quality += 1;
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (Items[i].SellIn < 1)
                    {
                        Items[i].Quality = 0;
                    }
                    else if (Items[i].Quality < 50)
                    {
                        Items[i].Quality += 1;

                        if (Items[i].SellIn < 11)
                        {
                            Items[i].Quality += 1;

                            if (Items[i].SellIn < 6)
                            {
                                Items[i].Quality += 1;
                            }

                        }
                    }
                    break;
                case string name when name.Contains("Conjured"):
                    if (Items[i].Quality > 1)
                    {
                        Items[i].Quality -= 2;
                    }
                    else
                        Items[i].Quality--;
                        break;
                default:
                    Items[i].Quality -= 1;

                    if (Items[i].SellIn < 1 && Items[i].Quality > 0)
                    {
                        Items[i].Quality -= 1;
                    }
                    break;
            }
            if (Items[i].SellIn > 0)
            {
                Items[i].SellIn -= 1;
            }
        }
    }
}
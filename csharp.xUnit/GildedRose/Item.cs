namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
}

public class ItemBuilder
{
    private string _name = "";
    private int _sellIn = 0;
    private int _quality = 0;

    public ItemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ItemBuilder WithSellIn(int sellIn)
    {
        _sellIn = sellIn;
        return this;
    }

    public ItemBuilder WithQuality(int quality)
    {
        _quality = quality;
        return this;
    }

    public Item Build()
    {
        return new Item
        {
            Name = _name,
            SellIn = _sellIn,
            Quality = _quality
        };
    }
}
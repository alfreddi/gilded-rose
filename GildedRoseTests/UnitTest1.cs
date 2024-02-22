using csharp;

namespace GildedRoseTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestName()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual("foo", Items[0].Name);
    }

    [TestMethod]
    public void TestDegradingQualityAfterSellIn()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 5 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(3, Items[0].Quality);
    }

    [TestMethod]
    public void TestQualityAfterSellInNotEqual()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreNotEqual(-1, Items[0].Quality);
    }

    [TestMethod]
    public void TestBrieQualityIncrease()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 4, Quality = 5 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(6, Items[0].Quality);
    }

    [TestMethod]
    public void TestQualityNotOver50()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 4, Quality = 50 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(50, Items[0].Quality);
    }

    [TestMethod]
    public void TestSulfuraQualityIncrease()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(80, Items[0].Quality);
    }

    [TestMethod]
    public void TestBackstageQualityAt10Days()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(32, Items[0].Quality);
    }

    [TestMethod]
    public void TestBackstageQualityAt5Days()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(33, Items[0].Quality);
    }

    [TestMethod]
    public void TestBackstageQualityAt0Days()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 30 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.AreEqual(0, Items[0].Quality);
    }
}
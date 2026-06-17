namespace ArgentRose.Tests;

using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ArgentRoseTest
{
    private const int MinQuality = 0;
    private const int MaxQuality = 50;

    [Test]
    [Description(
        "Updating a non expired regular product decreases its quality by 2 and decreases its sell-in by 1")]
    public void NotExpiredRegularProductUpdate()
    {
        var store = ArgentRoseStoreWith(RegularProduct(30, 5));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(RegularProduct(29, 3))));
    }

    [Test]
    [Description("Non expired regular product's updated quality can not be negative")]
    public void NotExpiredRegularProductUpdatedQualityCanNotBeNegative()
    {
        var store = ArgentRoseStoreWith(RegularProduct(30, 1));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(RegularProduct(29, MinQuality))));
    }

    [Test]
    [Description("Already expired regular product decreases quality twice as fast")]
    public void AlreadyExpiredRegularProductUpdate()
    {
        var store = ArgentRoseStoreWith(RegularProduct(0, 5));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(RegularProduct(-1, 1))));
    }

    [Test]
    [Description("Already expired regular product's updated quality can not be negative")]
    public void AlreadyExpiredRegularProductUpdatedQualityCanNotBeNegative()
    {
        var store = ArgentRoseStoreWith(RegularProduct(-1, 2));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(RegularProduct(-2, MinQuality))));
    }

    [Test]
    [Description("Theatre Passes increases quality by 1 when sell-in is greater than 6 days")]
    public void TheatrePassesQualityIncreasesBy1WhenSellInGreaterThan6()
    {
        var store = ArgentRoseStoreWith(TheatrePasses(30, 5));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(TheatrePasses(29, 6))));
    }

    [Test]
    [Description("Theatre Passes's quality can't grow over 50 when sell-in is greater than 6 days")]
    public void TheatrePassesQualityCantGrowOver50WhenSellInIsGreaterThan6()
    {
        var store = ArgentRoseStoreWith(TheatrePasses(20, MaxQuality));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(TheatrePasses(19, MaxQuality))));
    }

    [Test]
    [Description("Theatre Passes increases quality by 3 when sell-in is between 1 and 6 days")]
    public void TheatrePassesQualityIncreasesBy3WhenSellInBetween1And6()
    {
        var store = ArgentRoseStoreWith(TheatrePasses(6, 46));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(TheatrePasses(5, 49))));
    }

    [Test]
    [Description("Theatre Passes quality can't grow over 50 when sell-in is between 1 and 6 days")]
    public void TheatrePassesQualityCantExceed50WhenSellInBetween1And6()
    {
        var store = ArgentRoseStoreWith(TheatrePasses(4, 48));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(TheatrePasses(3, MaxQuality))));
    }

    [Test]
    [Description("Theatre Passes quality drops to 0 when expired")]
    public void TheatrePassesQualityDropsTo0Expired()
    {
        var store = ArgentRoseStoreWith(TheatrePasses(-1, 38));

        store.Update();

        Assert.That(store, Is.EqualTo(ArgentRoseStoreWith(TheatrePasses(-2, MinQuality))));
    }
        
    private static Product TheatrePasses(int sellIn, int quality)
    {
        return new Product("Theatre Passes", sellIn, quality);
    }

    private static Product RegularProduct(int sellIn, int quality)
    {
        return new Product("any not special product", sellIn, quality);
    }

    private static ArgentRoseStore ArgentRoseStoreWith(params Product[] products)
    {
        return new ArgentRoseStore(new List<Product>(products));
    }
}
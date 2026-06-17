using System;

namespace ArgentRose;

public class Product {
    private const int MinQuality = 0;
    private const int MaxQuality = 50;
    private readonly string _description;
    private int _sellIn;
    private int _quality;

    public Product(string description, int sellIn, int quality) {
        _description = description;
        _sellIn = sellIn;
        _quality = quality;
    }

    public int GetSellIn() {
        return _sellIn;
    }

    public void DecreaseSellIn() {
        _sellIn = _sellIn - 1;
    }

    public void IncreaseQuality(int delta) {
        UpdateQuality(_quality + delta);
    }

    public void DecreaseQuality(int delta) {
        UpdateQuality(_quality - delta);
    }

    public bool IsTheatrePasses()
    {
        return "Theatre Passes".Equals(_description, StringComparison.OrdinalIgnoreCase);
    }

    public void DropQualityToZero() {
        UpdateQuality(MinQuality);
    }

    private static int EnforceQualityInvariant(int newQuality) {
        return Math.Max(MinQuality, Math.Min(MaxQuality, newQuality));
    }

    private void UpdateQuality(int newQuality) {
        _quality = EnforceQualityInvariant(newQuality);
    }

    protected bool Equals(Product other)
    {
        return _description == other._description && _sellIn == other._sellIn && _quality == other._quality;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_description, _sellIn, _quality);
    }

    public override string ToString()
    {
        return $"{nameof(_description)}: {_description}, {nameof(_sellIn)}: {_sellIn}, {nameof(_quality)}: {_quality}";
    }
}

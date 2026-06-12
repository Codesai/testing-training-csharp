using System.Collections.Generic;
using System.Linq;

namespace ArgentRose;

public class ArgentRoseStore {

    private readonly List<Product> _inventory;

    public ArgentRoseStore(List<Product> inventory) {
        _inventory = new List<Product>(inventory);
    }

    public void Update() {
        foreach (Product product in _inventory) {
            product.DecreaseSellIn();

            if (product.IsTheatrePasses()) {
                UpdateTheatrePasses(product, product.GetSellIn());
            } else {
                UpdateRegularProduct(product, product.GetSellIn());
            }
        }
    }

    private void UpdateTheatrePasses(Product product, int newSellIn) {
        if (newSellIn <= 0) {
            product.DropQualityToZero();
        } else if (newSellIn < 5) {
            product.IncreaseQuality(3);
        } else {
            product.IncreaseQuality(1);
        }
    }

    private void UpdateRegularProduct(Product product, int newSellIn) {
        int changeBeforeExpiry = 2;
        int decrease = (newSellIn < -1) ? changeBeforeExpiry * 2 : changeBeforeExpiry;
        product.DecreaseQuality(decrease);
    }

    protected bool Equals(ArgentRoseStore other)
    {
        return _inventory.SequenceEqual(other._inventory);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ArgentRoseStore)obj);
    }

    public override int GetHashCode()
    {
        return _inventory.GetHashCode();
    }

    public override string ToString()
    {
        return $"{nameof(_inventory)}: [{string.Join(", ", _inventory)}]";
    }
}

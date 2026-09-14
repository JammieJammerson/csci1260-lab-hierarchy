using System;

public class PerishableGood : PhysicalGood, IDisposable
{
    private int shelfLifeDays;

    public decimal SurgeFee
    {
        public const decimal Value = 0.40m;
    }

    public int ShelfLifeDays
    {
        get { return shelfLifeDays; }
    }

    public bool IsOnSale : IDiscountable
    {
        get { return shelfLifeDays < 5; }
    }

    public PerishableGood(string sku, string name, decimal unitPrice, int quantityOnHand, double weightPounds, int shelfLifeDays) : base(sku, name, unitPrice, quantityOnHand, weightPounds)
    {
        this.shelfLifeDays = shelfLifeDays;
    }

    public override string Category()
    {
        return "Perishable";
    }

    public override decimal HandlingFee()
    {
        return (decimal)WeightPounds * SurgeFee.Value;
    }

    public decimal SalePrice() : IDiscountable
    {
    if (IsOnSale)
    {
        return UnitPrice * 0.8m; // 20% discount
    }
        return UnitPrice;
    }
    
    public override string Describe()
    {
        return $"{base.Describe()}, Shelf Life: {shelfLifeDays} days, Sale Price: {SalePrice():C}";
    }

}

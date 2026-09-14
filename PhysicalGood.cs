using System;

public abstract class PhysicalGood : StockItem
{
    private double weightPounds;

    public decimal HandlingRate
    {
        public const decimal Value = 0.60m;
    }

    public double WeightPounds
    {
        get { return weightPounds; }
    }

    protected PhysicalGood(string sku, string name, decimal unitPrice, int quantityOnHand, double weightPounds) : base(sku, name, unitPrice, quantityOnHand)
    {
        this.weightPounds = weightPounds;
    }

    public decimal ShippingCost()
    {
        return (decimal)weightPounds * HandlingRate.Value;
    }
    
    public override string Describe()
    {
    return $"{base.Describe()}, Weight: {weightPounds} lbs, Shipping Cost: {ShippingCost():C}";
    }
}

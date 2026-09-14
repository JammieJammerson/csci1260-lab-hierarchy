using System;

public class DurableGood : PhysicalGood
{
    private int warrantyMonths;

    public int WarrantyMonths
    {
        get { return warrantyMonths; }
    }

    public DurableGood(string sku, string name, decimal unitPrice, int quantityOnHand, double weightPounds, int warrantyMonths) : base(sku, name, unitPrice, quantityOnHand, weightPounds)
    {
        this.warrantyMonths = warrantyMonths;
    }

    public override string Category()
    {
        return "Durable";
    }

    public override decimal HandlingFee()
    {
        return 0.0m;
    }

    public override string Describe()
    {
        return $"{base.Describe()}, Warranty: {warrantyMonths} months";
    }
}

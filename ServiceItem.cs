using System;

public class ServiceItem : StockItem, IDiscountable
{
    private double laborHours;

    public double LaborHours { get; }

    public bool IsOnSale : IDiscountable { get; }

    public ServiceItem(string sku, string name, decimal unitPrice, int quantityOnHand, double laborHours) : base(sku, name, unitPrice, quantityOnHand)
    {
        this.laborHours = laborHours;
    }

    public override string Category()
    {
        return "Service";
    }

    public override decimal HandlingFee()
    {
        return 0.00m;
    }

    public decimal SalePrice() : IDiscountable
    {
        return 0.10m;
    }

    public override string Describe()
    {
        return $"{base.Describe()}, Labor Hours: {laborHours}, Sale Price: {SalePrice():C}";
    }
}

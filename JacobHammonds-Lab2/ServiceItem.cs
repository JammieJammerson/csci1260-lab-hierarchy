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
        if (laborHours > 2)
        {
            IsOnSale = true;
        }
    }

    public decimal SalePrice() : IDiscountable
    {
        if (IsOnSale)
        {
            return UnitPrice * 0.85m;
        }
        else
        {
            return UnitPrice;
        }
    }

    public override string Describe()
    {
        return $"{base.Describe()}, Labor Hours: {laborHours}";
    }
}

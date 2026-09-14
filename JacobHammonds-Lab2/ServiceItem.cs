using System;

public class ServiceItem : StockItem, IDiscountable
{
    private double laborHours;

    public double LaborHours { get { return laborHours; } }

    public bool IsOnSale { get; private set; }

    public ServiceItem(string sku, string name, decimal unitPrice, int quantityOnHand, double laborHours)
        : base(sku, name, unitPrice, quantityOnHand)
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
        return 0m;
    }

    public decimal SalePrice()
    {
        // Use base.UnitPrice (or UnitPrice) depending on how StockItem exposes it.
        decimal price = base.UnitPrice;
        if (IsOnSale)
        {
            return price * 0.85m;
        }
        else
        {
            return price;
            }
    }

    public override string Describe()
    {
        return $"{base.Describe()}, Labor Hours: {laborHours}";
    }
}

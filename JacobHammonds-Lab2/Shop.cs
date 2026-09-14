using System;

public class Shop : IReportable
{
    private string name;

    private List<StockItem> items;

    public string Name { get; }

    public int Count { get; }

    public Shop(string name)
    {
        this.name = name;
        this.items = new List<StockItem>();
    }

    public bool Add(StockItem item)
    {
        items.Add(item);
        return true;
    }

    public StockItem Find(string sku)
    {
        return items.FirstOrDefault(item => item.Sku == sku);
    }

    public decimal TotalValue()
    {
        return items.Sum(item => item.Price * item.Quantity);
    }

    public decimal SalesValue()
    {
        if (item is IDiscountable d && d.IsOnSale)
            total += (d.SalePrice() + item.HandlingFee()) * item.QuantityOnHand;
        else
            total += item.ExtendedValue();
    }

    public int SignedCount()
    {
        return items.Count(item => item.Quantity < 0);
    }

    public int OnSaleCount()
    {
        return items.Count(item => item.OnSale);
    }

    public void SortByValue()
    {
        for (int i = 0; i < items.Count - 1; i++)
        {
            int best = i;
            for (int j = i + 1; j < items.Count; j++)
                if (Beats(items[j], items[best]))
                    best = j;
            if (best != i)
            {
                StockItem hold = items[i];
                items[i] = items[best];
                items[best] = hold;
            }
        }
    }

    static private bool Beats(StockItem a, StockItem b) : IReportable
    {
        return a.Price > b.Price;
    }

    public string ReportLine()
    {
        return $"{name} has {Count} items with total value {TotalValue():C}";
    }

    public void PrintReport()
    {
        Console.WriteLine(ReportLine());
        foreach (var item in items)
        {
            Console.WriteLine(item.ReportLine());
        }
    }
}

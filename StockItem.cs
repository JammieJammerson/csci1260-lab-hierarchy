using System;

public abstract class StockItem : IReportable
{
    private string sku;

    private string name;

    private decimal unitPrice;

    private int quantityOnHand;

    private history List<StockMovement> transactionHistory;

    private int nextSeq;

    public string Sku { get; }

    public string Name { get; }

    public decimal UnitPrice { get; }

    public int QuantityOnHand { get; }

    public int MoveCount { get; }

    protected StockItem(string sku, string name, decimal unitPrice, int quantityOnHand)
    {
        this.sku = sku;
        this.name = name;
        this.unitPrice = unitPrice;
            if (unitPrice < 0)
            {
                unitPrice = 0;
            }
        this.quantityOnHand = quantityOnHand;
        this.transactionHistory = new List<StockMovement>();
        this.nextSeq = 1;
    }
    
    public abstract string Category();

    public abstract decimal HandlingFee();

    public decimal ExtendedValue()
    {
        return (UnitPrice + HandlingFee()) * QuantityOnHand;
    }

    public bool Receive(int count)
    {
        if (count <= 0)
            return false;

        quantityOnHand += count;
        return true;
    }

    public bool Release(int count)
    {
        if (count <= 0 || count > quantityOnHand)
            return false;
        quantityOnHand -= count;
        return true;
    }

    public string MovementLines()
    {
        return StockMovement
    }

    public virtual string Describe()
    {
        return $"SKU: {Sku}, Name: {Name}, Category: {Category()}"
    }

    public string ReportLine() : IReportable
    {
        
    }

    public override string ToString()
    {
        
    }

}

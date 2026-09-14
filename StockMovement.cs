using System;

public class StockMovement
{
    private int seq;

    private string kind;

    private int count;

    public int Seq { get; }

    public string Count { get; }

    public StockMovement(int seq, string kind, int count)
    {
        this.seq = seq;
        this.kind = kind;
        this.count = count;
    }

    public string Describe()
    {
        return $"Seq: {seq}, Kind: {kind}, Count: {count}";
    }
}

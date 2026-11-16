namespace Task5.ApiAudit;

public class OrderProcessor
{
    private const decimal TaxRate = 0.20m;
    private readonly List<decimal> _itemPrices = new();

    public string OrderId { get; }
    public bool IsFinalized { get; private set; }

    public OrderProcessor(string orderId)
    {
        OrderId = orderId;
    }

    public void AddItem(decimal price)
    {
        if (IsFinalized) throw new InvalidOperationException("Замовлення вже закрите.");
        if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
        _itemPrices.Add(price);
    }

    public decimal CalculateTotal()
    {
        decimal subtotal = _itemPrices.Sum();
        return subtotal + CalculateTax(subtotal);
    }

    protected virtual decimal CalculateTax(decimal subtotal) => subtotal * TaxRate;

    internal void ForceResetForAudit()
    {
        _itemPrices.Clear();
        IsFinalized = false;
    }

    private sealed class AuditLogEntry
    {
        public DateTime Timestamp { get; init; }
    }
}
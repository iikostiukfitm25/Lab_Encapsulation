namespace Task2.Inventory;

public class WarehouseItem
{
    private string _name = string.Empty;
    private decimal _unitPrice;
    private int _quantity;

    public string Sku { get; }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2 || value.Trim().Length > 100)
                throw new ArgumentException("Назва товару має містити від 2 до 100 символів.", nameof(value));
            _name = value.Trim();
        }
    }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Ціна має бути більшою за 0.");
            _unitPrice = value;
        }
    }

    public int Quantity => _quantity;
    public decimal TotalValue => _unitPrice * _quantity;

    public WarehouseItem(string sku, string name, decimal unitPrice, int initialQuantity = 0)
    {
        if (string.IsNullOrWhiteSpace(sku) || sku.Trim().Length != 8)
            throw new ArgumentException("SKU має містити рівно 8 символів.", nameof(sku));
        if (initialQuantity < 0)
            throw new ArgumentOutOfRangeException(nameof(initialQuantity), "Початковий залишок не може бути від'ємним.");

        Sku = sku.Trim().ToUpperInvariant();
        Name = name;
        UnitPrice = unitPrice;
        _quantity = initialQuantity;
    }

    public void Restock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Кількість поповнення має бути додатною.");
        _quantity += amount;
    }

    public bool TryShip(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Кількість відвантаження має бути додатною.");
        if (amount > _quantity)
            return false;

        _quantity -= amount;
        return true;
    }
}
namespace Task4.Comparison;

// Версія А: відкриті поля без перевірок
public class DepositAccountPublic
{
    public string Owner = string.Empty;
    public decimal Balance;
    public double InterestRate;

    public decimal CalculateAnnualProfit() => Balance * (decimal)(InterestRate / 100.0);
}

// Версія Б: інкапсульований стан із валідацією
public class DepositAccountEncapsulated
{
    private string _owner = string.Empty;
    private decimal _balance;
    private double _interestRate;

    public string Owner
    {
        get => _owner;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ім'я власника не може бути порожнім.");
            _owner = value.Trim();
        }
    }

    public decimal Balance => _balance;

    public double InterestRate
    {
        get => _interestRate;
        set
        {
            if (value < 0 || value > 50)
                throw new ArgumentOutOfRangeException(nameof(value), "Ставка має бути в межах 0–50%.");
            _interestRate = value;
        }
    }

    public DepositAccountEncapsulated(string owner, decimal initialDeposit, double interestRate)
    {
        if (initialDeposit < 0)
            throw new ArgumentOutOfRangeException(nameof(initialDeposit), "Депозит не може бути від'ємним.");
        Owner = owner;
        _balance = initialDeposit;
        InterestRate = interestRate;
    }

    public decimal CalculateAnnualProfit() => _balance * (decimal)(_interestRate / 100.0);
}
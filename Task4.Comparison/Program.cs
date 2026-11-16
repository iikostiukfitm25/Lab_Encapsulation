using Task4.Comparison;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== ВЕРСІЯ А (Публічні поля) ===");
var accA = new DepositAccountPublic { Owner = "Костюк І.І.", Balance = -5000m, InterestRate = -10 };
Console.WriteLine($"Баланс: {accA.Balance}, Ставка: {accA.InterestRate}%");
Console.WriteLine($"Хибний розрахований прибуток: {accA.CalculateAnnualProfit()} грн (мінус на мінус дав плюс!)");

Console.WriteLine("\n=== ВЕРСІЯ Б (Інкапсуляція) ===");
try
{
    var accB = new DepositAccountEncapsulated("Костюк І.І.", -5000m, -10);
}
catch (Exception ex)
{
    Console.WriteLine($"Заблоковано створення некоректного рахунку: {ex.Message}");
}
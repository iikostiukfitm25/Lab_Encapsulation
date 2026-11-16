using Task2.Inventory;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// 1. Коректне створення
var item = new WarehouseItem("SKU-1024", "Механічна клавіатура", 450.00m, 20);
Console.WriteLine($"[OK] Створено: {item.Sku} | {item.Name} | Залишок: {item.Quantity} | Сума: {item.TotalValue} грн");

// 2. Коректні операції
item.Restock(10);
bool shipped = item.TryShip(15);
Console.WriteLine($"[OK] Після поповнення (+10) і відвантаження (-15): Успіх={shipped}, Залишок={item.Quantity}");

// 3. Спроба відвантажити більше, ніж є
bool failedShip = item.TryShip(50);
Console.WriteLine($"[EXPECTED FAIL] Спроба відвантажити 50 шт: Успіх={failedShip}, Залишок не змінився={item.Quantity}");

// 4. Некоректні аргументи (перехоплення винятків)
try
{
    var badItem = new WarehouseItem("123", "   ", -50m);
}
catch (Exception ex)
{
    Console.WriteLine($"[CAUGHT] Перехоплено помилку валідації: {ex.GetType().Name} -> {ex.Message}");
}
using Task5.ApiAudit;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var order = new OrderProcessor("ORD-2026-01");
order.AddItem(1000m);
Console.WriteLine($"Замовлення {order.OrderId}, сума з ПДВ: {order.CalculateTotal()} грн");

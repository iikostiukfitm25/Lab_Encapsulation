using Task3.Properties;

var server = new ServerNode("srv-kyiv-01") { MaxConnections = 500 };
server.EnvironmentTag = "Production";
server.Activate();

Console.WriteLine(server.ConnectionEndpoint);

// Порушення обмежень:
// server.Status = "Offline";        // CS0272
// server.Hostname = "srv-lviv-02";     // ПОМИЛКА CS8852 (init-only)
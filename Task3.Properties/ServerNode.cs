namespace Task3.Properties;

public class ServerNode
{
    public string EnvironmentTag { get; set; } = "Staging";
    public string Status { get; private set; }
    public string Hostname { get; init; }
    public int MaxConnections { get; init; }

    public string ConnectionEndpoint => $"{Hostname}:{MaxConnections} [{EnvironmentTag} - {Status}]";

    public ServerNode(string hostname)
    {
        Hostname = hostname;
        Status = "Initialized";
    }

    public void Activate() => Status = "Online";
}
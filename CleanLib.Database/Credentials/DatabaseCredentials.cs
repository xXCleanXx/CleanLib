namespace CleanLib.Database.Credentials;

public class DatabaseCredentials {
    public string Username { get; }
    public string Password { get; }
    public string Server { get; }
    public uint Port { get; }

    public DatabaseCredentials(string username, string password, string server, uint port) {
        this.Username = username;
        this.Password = password;
        this.Server = server;
        this.Port = port;
    }
}
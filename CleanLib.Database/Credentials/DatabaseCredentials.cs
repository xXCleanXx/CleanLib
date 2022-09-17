using CleanLib.Database.Credentials.Interfaces;
using System.Net;
using System.Security;

namespace CleanLib.Database.Credentials;

public class DatabaseCredentials : NetworkCredential, IDatabaseCredentials {
    public uint Port { get; set; }
    public string ConnectionString { get; set; }

    public DatabaseCredentials(string userName, string password, string server, uint port) : base(userName, password, server) {
        this.Port = port;
    }

    public DatabaseCredentials(string userName, SecureString password, string server, uint port) : base(userName, password, server) {
        this.Port = port;
    }

    public DatabaseCredentials(string connectionString) {
        this.ConnectionString = connectionString;
    }
}
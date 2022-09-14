#pragma warning disable S101 // Types should be named in PascalCase

using CleanLib.Database.Credentials;
using MySql.Data.MySqlClient;

namespace CleanLib.Database.MySQL.Credentials;

public class MySQLDatabaseCredentials : DatabaseCredentials {
    public string ConnectionString { get; set; }

    public MySQLDatabaseCredentials(string username, string password, string server, uint port) : base(username, password, server, port) {
        this.ConnectionString = new MySqlConnectionStringBuilder() {
            UserID = base.Username,
            Password = base.Password,
            Server = base.Server,
            Port = base.Port,
        }.ConnectionString;
    }
}
#pragma warning disable S101 // Types should be named in PascalCase

using CleanLib.Database.Credentials;
using MySql.Data.MySqlClient;

namespace CleanLib.Database.MySQL.Credentials;

public class MySQLDatabaseCredentials : DatabaseCredentials {
    public MySQLDatabaseCredentials(string userName, string password, string server, uint port) : base(userName, password, server, port) {
        base.ConnectionString = new MySqlConnectionStringBuilder() {
            UserID = base.UserName,
            Password = base.Password,
            Server = base.Domain,
            Port = base.Port,
        }.ConnectionString;
    }

    public MySQLDatabaseCredentials(string connectionString) : base(connectionString) {
        base.ConnectionString = new MySqlConnectionStringBuilder(connectionString).ConnectionString;
    }
}
using CleanLib.Database.Connections.Interfaces;
using CleanLib.Database.Methods.Interfaces;
using CleanLib.Database.MySQL.Methods;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CleanLib.Database.MySQL.Connections;

public class ConnectionMethods : IConnectionMethods<MySqlConnection, MySqlParameter> {
    public MySqlConnection Connection { get; private set; }

    internal ConnectionMethods() { }

    public IDatabaseMethods<MySqlParameter> WithCredentials(string username, string password, string server, uint port) {
        MySqlConnectionStringBuilder sb = new() {
            UserID = username,
            Password = password,
            Server = server,
            Port = port
        };

        this.Connection = new(sb.ConnectionString);
        this.Connection.Open();

        return new DatabaseMethods(this.Connection);
    }

    public IDatabaseMethods<MySqlParameter> WithConnection(MySqlConnection connection) {
        if (connection is null) throw new ArgumentNullException(nameof(connection), "Connection cannot be null!");
        this.Connection = connection;

        if (this.Connection.State is not ConnectionState.Open) {
            this.Connection.Open();
        }

        return new DatabaseMethods(this.Connection);
    }
}
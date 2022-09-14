using CleanLib.Database.Connections.Interfaces;
using CleanLib.Database.Methods.Interfaces;
using CleanLib.Database.MySQL.Credentials;
using CleanLib.Database.MySQL.Methods;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CleanLib.Database.MySQL.Connections;

public class ConnectionMethods : IConnectionMethods<MySqlConnection, MySqlParameter> {
    private bool _disposedValue;

    public MySqlConnection Connection { get; private set; }

    public IDatabaseMethods<MySqlParameter> WithCredentials(MySQLDatabaseCredentials databaseCredentials) {
        if (databaseCredentials is null) throw new ArgumentNullException(nameof(databaseCredentials), "Database credentials cannot be null!");
        if (string.IsNullOrWhiteSpace(databaseCredentials.ConnectionString)) throw new ArgumentException("Connection string cannot be null, empty or consists of white-spaces!", nameof(databaseCredentials));

        this.Connection = new(databaseCredentials.ConnectionString);
        this.Connection.Open();

        return new DatabaseMethods(this.Connection);
    }

    public IDatabaseMethods<MySqlParameter> WithCredentials(string username, string password, string server, uint port) {
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Username cannot be null, empty or consists of white-spaces!", nameof(username));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be null, empty or consists of white-spaces!", nameof(password));
        if (string.IsNullOrWhiteSpace(server)) throw new ArgumentException("Server cannot be null, empty or consists of white-spaces!", nameof(server));

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

        if (this.Connection.State is not ConnectionState.Open) this.Connection.Open();

        return new DatabaseMethods(this.Connection);
    }

    protected virtual void Dispose(bool disposing) {
        if (!this._disposedValue) {
            if (disposing)
                this.Connection.Dispose();

            this._disposedValue = true;
        }
    }

    public void Dispose() {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}
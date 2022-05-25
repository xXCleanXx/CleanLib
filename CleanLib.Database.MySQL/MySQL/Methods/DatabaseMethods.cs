using CleanLib.Database.Methods.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CleanLib.Database.MySQL.Methods;

public class DatabaseMethods : IDatabaseMethods<MySqlParameter>, IDisposable {
    private bool _disposedValue;

    internal DatabaseMethods(MySqlConnection connection) {
        if (connection is null) throw new ArgumentNullException(nameof(connection), "Connection cannot be null!");
        if (connection.State is not ConnectionState.Open) throw new InvalidOperationException("Connection cannot is not open!");

        this.Connection = connection;
    }

    public MySqlConnection Connection { get; private set; }

    public int ExecuteNonQuery(string command, IEnumerable<MySqlParameter> parameters = null) {
        if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

        using MySqlCommand cmd = new(command, this.Connection);

        if (parameters is not null && parameters.Any()) {
            cmd.Parameters.AddRange(parameters.ToArray());
        }

        return cmd.ExecuteNonQuery();
    }

    public IDatabaseMethods<MySqlParameter> ExecuteNonQuery(string command, out int affectedRows, IEnumerable<MySqlParameter> parameters = null) {
        affectedRows = this.ExecuteNonQuery(command, parameters);

        return this;
    }

    public IDatabaseMethods<MySqlParameter> FillDataTable(string command, DataTable dataTable, IEnumerable<MySqlParameter> parameters = null) {
        if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));
        if (dataTable is null) throw new ArgumentNullException(nameof(dataTable), "DataTable cannot be null!");

        using MySqlCommand cmd = new(command, this.Connection);

        if (parameters is not null && parameters.Any()) {
            cmd.Parameters.AddRange(parameters.ToArray());
        }

        using MySqlDataAdapter da = new(cmd);
        da.Fill(dataTable);

        return this;
    }

    public DataTable GetFilledDataTable(string command, IEnumerable<MySqlParameter> parameters = null) {
        DataTable dataTable = new();

        _ = this.FillDataTable(command, dataTable, parameters);

        return dataTable;
    }

    public IDatabaseMethods<MySqlParameter> GetFilledDataTable(string command, out DataTable dataTable, IEnumerable<MySqlParameter> parameters = null) {
        dataTable = this.GetFilledDataTable(command, parameters);

        return this;
    }

    protected virtual void Dispose(bool disposing) {
        if (!this._disposedValue) {
            if (disposing) {
                this.Connection.Dispose();
            }

            this._disposedValue = true;
        }
    }

    public void Dispose() {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}
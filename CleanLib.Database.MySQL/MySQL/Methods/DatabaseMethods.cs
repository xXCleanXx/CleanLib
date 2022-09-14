using CleanLib.Database.Methods.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CleanLib.Database.MySQL.Methods;

public class DatabaseMethods : IDatabaseMethods<MySqlParameter> {
    private bool _disposedValue;

    internal DatabaseMethods(MySqlConnection connection) {
        if (connection is null) throw new ArgumentNullException(nameof(connection), "Connection cannot be null!");
        if (connection.State is not ConnectionState.Open) throw new InvalidOperationException("Connection cannot is not open!");

        this.Connection = connection;
    }

    public MySqlConnection Connection { get; }

    public IDatabaseMethods<MySqlParameter> ExecuteScalar<T>(string command, out T returnValue, IEnumerable<MySqlParameter> parameters = null) {
        returnValue = (T)Convert.ChangeType(this.ExecuteScalar(command, parameters), typeof(T));

        return this;
    }


    public T ExecuteScalar<T>(string command, IEnumerable<MySqlParameter> parameters = null) {
        _ = this.ExecuteScalar<T>(command, out T returnValue, parameters);

        return returnValue;
    }

    public IDatabaseMethods<MySqlParameter> ExecuteScalar(string command, out object returnValue, IEnumerable<MySqlParameter> parameters = null) {
        returnValue = this.ExecuteScalar(command, parameters);

        return this;
    }

    public object ExecuteScalar(string command, IEnumerable<MySqlParameter> parameters = null) {
        if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

        using MySqlCommand cmd = new(command, this.Connection);

        if (parameters is not null && parameters.Any())
            cmd.Parameters.AddRange(parameters.ToArray());

        return cmd.ExecuteScalar();
    }

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

        if (parameters is not null && parameters.Any())
            cmd.Parameters.AddRange(parameters.ToArray());

        using MySqlDataAdapter da = new(cmd);
        da.Fill(dataTable);

        return this;
    }

    public DataTable GetFilledDataTable(string command, IEnumerable<MySqlParameter> parameters = null) {
        DataTable dataTable = new();

        _ = this.FillDataTable(command, dataTable, parameters);

        return dataTable;
    }

    public IDatabaseMethods<MySqlParameter> GetFilledDataTable(string command, out DataTable dataTable, IEnumerable<MySqlParameter> parameters = null, string sourceTable) {
        dataTable = this.GetFilledDataTable(command, parameters);

        return this;
    }

    public IDatabaseMethods<MySqlParameter> FillDataSet(string command, DataSet dataSet, string sourceTable = null, IEnumerable<MySqlParameter> parameters = null) {
        using MySqlCommand cmd = new(command, this.Connection);

        if (parameters is not null && parameters.Any())
            cmd.Parameters.AddRange(parameters.ToArray());

        using MySqlDataAdapter da = new(cmd);

        da.Fill(dataSet, sourceTable);

        return this;
    }

    public IDatabaseMethods<MySqlParameter> GetFilledDataSet(string command, out DataSet dataSet, string sourceTable = null, IEnumerable<MySqlParameter> parameters = null) {
        dataSet = new();

        this.FillDataSet(command, dataSet, sourceTable, parameters);
    }

    public DataSet GetFilledDataSet(string command, string sourceTable = null, IEnumerable<MySqlParameter> parameters = null) {
        DataSet dataSet = new();

        _ = this.FillDataSet(command, dataSet, sourceTable, parameters);

        return dataSet;
    }

    protected virtual void Dispose(bool disposing) {
        if (!this._disposedValue) {
            if (disposing) this.Connection.Dispose();

            this._disposedValue = true;
        }
    }

    public void Dispose() {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

}
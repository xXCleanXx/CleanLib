#pragma warning disable S101 // Types should be named in PascalCase

using CleanLib.Database.Methods.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CleanLib.Database.MySQL.Methods.Lazy;

public static class MySQLMethodsLazy {
    public static IDatabaseMethods<MySqlParameter> DatabaseMethods { get; set; }
    
    public static T ExecuteScalar<T>(string command, IEnumerable<MySqlParameter> parameters = null) {
        DatabaseMethods.ExecuteScalar(command, out T returnValue, parameters).Dispose();

        return returnValue;
    }

    public static object ExecuteScalar(string command, IEnumerable<MySqlParameter> parameters = null) {
        DatabaseMethods.ExecuteScalar(command, out object returnValue, parameters).Dispose();

        return returnValue;
    }

    public static int ExecuteNonQuery(string command, IEnumerable<MySqlParameter> parameters = null) {
        DatabaseMethods.ExecuteScalar(command, out int affectedRows, parameters).Dispose();

        return affectedRows;
    }

    public static DataTable GetFilledDataTable(string command, IEnumerable<MySqlParameter> parameters = null) {
        DatabaseMethods.GetFilledDataTable(command, out DataTable dataTable, parameters).Dispose();

        return dataTable;
    }

    public static void FillDataTable(string command, DataTable dataTable, IEnumerable<MySqlParameter> parameters = null)
        => DatabaseMethods.FillDataTable(command, dataTable, parameters).Dispose();

    public static DataSet GetFilledDataSet(string command, string sourceTable = null, IEnumerable<MySqlParameter> parameters = null) {
        DatabaseMethods.GetFilledDataSet(command, out DataSet dataSet, sourceTable, parameters).Dispose();

        return dataSet;
    }

    public static void GetFilledDataSet(string command, out DataSet dataSet, string sourceTable = null, IEnumerable<MySqlParameter> parameters = null)
        => DatabaseMethods.GetFilledDataSet(command, out dataSet, sourceTable, parameters).Dispose();

    public static void FillDataSet(string command, DataSet dataSet, string sourceTable = null, IEnumerable<MySqlParameter> parameters = null)
        => DatabaseMethods.FillDataSet(command, dataSet, sourceTable, parameters).Dispose();
}
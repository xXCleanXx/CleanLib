using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CleanLib.Database.Methods.Interfaces;

public interface IDatabaseMethods<DerivedParameter> : IDisposable where DerivedParameter : DbParameter {
    IDatabaseMethods<DerivedParameter> ExecuteScalar<T>(string command, out T returnValue, IEnumerable<DerivedParameter> parameters = null);

    T ExecuteScalar<T>(string command, IEnumerable<DerivedParameter> parameters = null);

    IDatabaseMethods<DerivedParameter> ExecuteScalar(string command, out object returnValue, IEnumerable<DerivedParameter> parameters = null);

    object ExecuteScalar(string command, IEnumerable<DerivedParameter> parameters = null);

    int ExecuteNonQuery(string command, IEnumerable<DerivedParameter> parameters = null);

    IDatabaseMethods<DerivedParameter> ExecuteNonQuery(string command, out int affectedRows, IEnumerable<DerivedParameter> parameters = null);

    IDatabaseMethods<DerivedParameter> FillDataTable(string command, DataTable dataTable, IEnumerable<DerivedParameter> parameters = null);

    DataTable GetFilledDataTable(string command, IEnumerable<DerivedParameter> parameters = null);

    IDatabaseMethods<DerivedParameter> GetFilledDataTable(string command, out DataTable dataTable, IEnumerable<DerivedParameter> parameters = null);

    IDatabaseMethods<DerivedParameter> FillDataSet(string command, DataSet dataSet, IEnumerable<DerivedParameter> parameters = null);

    IDatabaseMethods<DerivedParameter> GetFilledDataSet(string command, out DataSet dataSet, IEnumerable<DerivedParameter> parameters = null);

    DataSet GetFilledDataSet(string command, IEnumerable<DerivedParameter> parameters = null);
}
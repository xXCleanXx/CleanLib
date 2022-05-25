using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CleanLib.Database.Methods.Interfaces;

public interface IDatabaseMethods<DerivedParameter> where DerivedParameter : DbParameter {
    public int ExecuteNonQuery(string command, IEnumerable<DerivedParameter> parameters = null);

    public IDatabaseMethods<DerivedParameter> ExecuteNonQuery(string command, out int affectedRows, IEnumerable<DerivedParameter> parameters = null);

    public IDatabaseMethods<DerivedParameter> FillDataTable(string command, DataTable dataTable, IEnumerable<DerivedParameter> parameters = null);

    public DataTable GetFilledDataTable(string command, IEnumerable<DerivedParameter> parameters = null);

    public IDatabaseMethods<DerivedParameter> GetFilledDataTable(string command, out DataTable dataTable, IEnumerable<DerivedParameter> parameters = null);
}
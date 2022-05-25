#pragma warning disable S101 // Types should be named in PascalCase

using CleanLib.Database.Connections.Interfaces;
using CleanLib.Database.MySQL.Connections;
using MySql.Data.MySqlClient;

namespace CleanLib.Database.MySQL;

public class MySQL {
    public IConnectionMethods<MySqlConnection, MySqlParameter> Connect() => new ConnectionMethods();
}
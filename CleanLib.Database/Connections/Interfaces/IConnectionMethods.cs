﻿using CleanLib.Database.Methods.Interfaces;
using System.Data.Common;

namespace CleanLib.Database.Connections.Interfaces;

public interface IConnectionMethods<DerivedConnection, DerivedParameter> where DerivedConnection : DbConnection where DerivedParameter : DbParameter {
    public IDatabaseMethods<DerivedParameter> WithCredentials(string username, string password, string server, uint port);
    public IDatabaseMethods<DerivedParameter> WithConnection(DerivedConnection connection);
}
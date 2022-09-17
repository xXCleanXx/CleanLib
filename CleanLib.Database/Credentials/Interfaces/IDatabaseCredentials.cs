namespace CleanLib.Database.Credentials.Interfaces;

public interface IDatabaseCredentials {
    string ConnectionString { get; set; }
    uint Port { get; set; }
}
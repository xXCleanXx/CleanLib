using Renci.SshNet;

namespace CleanLib.Common.SSH {
    public class Ssh {
        public SshClient SshClient { get; private set; }
        public ConnectionInfo ConnectionInfo { get; private set; }

        public Ssh() { }

        public SshConnectionMethods Credentials(ConnectionInfo connectionInfo) {
            this.SshClient = new SshClient(connectionInfo);

            return new SshConnectionMethods(this.SshClient);
        }

        public SshConnectionMethods Credentials(string host, uint port, string username, PrivateKeyFile privateKeyFile) {
            this.SshClient = new SshClient(host, (int)port, username, privateKeyFile);

            return new SshConnectionMethods(this.SshClient);
        }

        public SshConnectionMethods Credentials(string host, string username, PrivateKeyFile privateKeyFile) {
            return this.Credentials(host, 22, username, privateKeyFile);
        }

        public SshConnectionMethods Credentials(string host, uint port, string username, string password) {
            this.SshClient = new SshClient(host, (int)port, username, password);
            
            return new SshConnectionMethods(this.SshClient);
        }

        public SshConnectionMethods Credentials(string host, string username, string password) {
            return this.Credentials(host, 22, username, password);
        }
    }
}
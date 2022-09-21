using Renci.SshNet;
using System;
using System.Text;

namespace CleanLib.SSH {
    public class SshMethods : IDisposable {
        private bool _disposedValue;

        public SshClient SshClient { get; private set; }

        public bool IsConnected => this.SshClient is not null && this.SshClient.IsConnected;

        public SshMethods(SshClient client) => this.SshClient = client;

        public string RunCommand(string command) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

            using SshCommand cmd = this.SshClient.RunCommand(command);
            
            return cmd.Result;
        }

        public SshMethods RunCommand(string command, out string result) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

            result = this.RunCommand(command);

            return this;
        }

        public SshCommandResult GetCommandOutput(string command) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

            using SshCommand cmd = this.SshClient.RunCommand(command);

            return new SshCommandResult(command, cmd.Result, cmd.ExitStatus, !string.IsNullOrWhiteSpace(cmd.Error), cmd.Error);
        }

        public SshMethods GetCommandOutput(string command, out SshCommandResult result) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

            result = this.GetCommandOutput(command);

            return this;
        }

        public SshCommand CreateCommand(string command) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

            return this.SshClient.CreateCommand(command);
        }

        public SshCommand CreateCommand(string command, Encoding encoding) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));
            if (encoding is null) throw new ArgumentNullException(nameof(encoding), "Encoding cannot be null!");

            return this.SshClient.CreateCommand(command, encoding);
        }

        public SshMethods CreateCommand(string command, out SshCommand sshCommand) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));

            sshCommand = this.CreateCommand(command);

            return this;
        }

        public SshMethods CreateCommand(string command, Encoding encoding, out SshCommand sshCommand) {
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentException("Command cannot be null, empty or consists of white-spaces!", nameof(command));
            if (encoding is null) throw new ArgumentNullException(nameof(encoding), "Encoding cannot be null!");

            sshCommand = this.CreateCommand(command, encoding);

            return this;
        }

        protected virtual void Dispose(bool disposing) {
            if (!this._disposedValue) {
                if (disposing) {
                    if (this.IsConnected) this.SshClient.Disconnect();

                    this.SshClient.Dispose();
                }

                this._disposedValue = true;
            }
        }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
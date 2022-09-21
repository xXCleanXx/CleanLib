using Renci.SshNet;
using System;

namespace CleanLib.SSH {
    public class SshConnectionMethods : IDisposable {
        private bool _disposedValue;

        public SshClient SshClient { get; private set; }
        public bool IsConnected => this.SshClient is not null && this.SshClient.IsConnected;

        public SshConnectionMethods(SshClient client) => this.SshClient = client;

        public SshMethods Connect() {
            if (!this.IsConnected) this.SshClient.Connect();

            return new(this.SshClient);
        }

        public void Disconnect() {
            if (this.IsConnected) this.SshClient.Disconnect();
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
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
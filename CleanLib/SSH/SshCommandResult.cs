namespace CleanLib.Common.SSH {
    public class SshCommandResult {
        public string Command { get; private set; }
        public string Result { get; private set; }
        public int ExitCode { get; private set; }
        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public SshCommandResult(string command, string result, int exitCode, bool hasError, string errorMessage) {
            this.Command = command;
            this.Result = result;
            this.ExitCode = exitCode;
            this.HasError = hasError;
            this.ErrorMessage = errorMessage;
        }
    }
}
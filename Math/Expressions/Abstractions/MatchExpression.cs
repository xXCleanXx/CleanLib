using CleanLib.Math.Tokens.Abstractions;

namespace CleanLib.Math.Expressions.Abstractions {
    public abstract class ExpressionBase {
        public string Match { get; }
        public string Regex { get; }
        public string Input { get; }
        public bool HasMatch => this.Match != null;

        protected ExpressionBase(string input, string regex) {
            this.Input = input;
            this.Regex = regex;
        }

        public abstract TokenBase GetToken();
    }
}
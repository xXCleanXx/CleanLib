using CleanLib.Math.Enums;
using CleanLib.Math.Tokens.Abstractions;

namespace CleanLib.Math.Tokens;

public class Identifier : TokenBase {
    public string Value { get; }

    public Identifier(string value, uint line, uint column) : base(TokenKind.Identifier, line, column) {
        this.Value = value;
    }
}
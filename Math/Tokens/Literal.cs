using CleanLib.Math.Enums;
using CleanLib.Math.Tokens.Abstractions;

namespace CleanLib.Math.Tokens;

public class Literal : TokenBase {
    public string Value { get; }
    public LiteralKind LiteralKind { get; }

    public Literal(string value, uint line, uint column) : base(TokenKind.Literal, line, column) {
        this.Value = value;
    }
}
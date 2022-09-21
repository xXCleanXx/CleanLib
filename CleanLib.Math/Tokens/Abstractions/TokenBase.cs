using CleanLib.Math.Enums;

namespace CleanLib.Math.Tokens.Abstractions;

public abstract class TokenBase {
    public TokenKind TokenKind { get; }
    public uint Line { get; }
    public uint Column { get; }

    protected TokenBase(TokenKind tokenKind, uint line, uint column) {
        this.TokenKind = tokenKind;
        this.Line = line;
        this.Column = column;
    }
}
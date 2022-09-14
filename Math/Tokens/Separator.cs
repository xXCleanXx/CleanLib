using CleanLib.Math.Enums;
using CleanLib.Math.Tokens.Abstractions;

namespace CleanLib.Math.Tokens;

public class Separator : TokenBase {
    public SeparatorKind SeparatorKind { get; }

    public Separator(SeparatorKind separatorKind, uint line, uint column) : base(TokenKind.Separator, line, column) {
        this.SeparatorKind = separatorKind;
    }
}
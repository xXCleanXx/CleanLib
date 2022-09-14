using CleanLib.Math.Enums;
using CleanLib.Math.Tokens.Abstractions;

namespace CleanLib.Math.Tokens;

public class Operator : TokenBase {
    public OperatorKind OperatorKind { get; }

    public Operator(OperatorKind operatorKind, uint line, uint column) : base(TokenKind.Operator, line, column) {
        this.OperatorKind = operatorKind;
    }
}
using CleanLib.Math.Expressions.Abstractions;
using CleanLib.Math.Tokens.Abstractions;
using System;

namespace CleanLib.Math.Expressions {
    public class LiteralExpression : ExpressionBase {
        public LiteralExpression() : base("", "") {
            
        }

        public override TokenBase GetToken() => throw new NotImplementedException();
    }
}

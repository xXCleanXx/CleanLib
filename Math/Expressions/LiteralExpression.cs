using CleanLib.Math.Expressions.Abstractions;
using CleanLib.Math.Tokens.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanLib.Math.Expressions {
    public class LiteralExpression : ExpressionBase {
        public LiteralExpression() : base("") {
            
        }

        public override TokenBase GetToken() => throw new NotImplementedException();
    }
}

using CleanLib.Math.Expressions.Abstractions;
using CleanLib.Math.Tokens.Abstractions;
using System.Text.RegularExpressions;

namespace CleanLib.Math.Expressions {
 
    public class KeywordExpression : ExpressionBase {
        public KeywordExpression(string input, string keyword) : base(input, $"${keyword}^") {

        }

        public override TokenBase GetToken() {
            //Regex regex = new(base.Regex);
            //regex.Match(base.Input, )
            return null;
        }
    }
}
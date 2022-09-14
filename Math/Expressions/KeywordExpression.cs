using CleanLib.Math.Expressions.Abstractions;
using CleanLib.Math.Tokens.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace CleanLib.Math.Expressions {
 
    public class KeywordExpression : ExpressionBase {
        public KeywordExpression(string input, string keyword) : base(input, $"${keyword}^") {

        }

        public TokenBase GetToken() {
            Regex regex = new(base.Regex);
            regex.Match(base.Input, )
        }
    }
}
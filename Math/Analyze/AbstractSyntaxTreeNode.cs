using CleanLib.Math.Tokens.Abstractions;

namespace CleanLib.Math.Analyze;

public class AbstractSyntaxTreeNode {
    public TokenBase PreviousToken { get; set; }
    public TokenBase NextToken { get; set; }
    public TokenBase Token { get; }

    public AbstractSyntaxTreeNode(TokenBase previousToken, TokenBase token, TokenBase nextToken) {
        this.PreviousToken = previousToken;
        this.Token = token;
        this.NextToken = nextToken;
    }
}
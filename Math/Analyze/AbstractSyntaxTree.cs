using CleanLib.Math.Tokens.Abstractions;
using System;
using System.Collections.Generic;

namespace CleanLib.Math.Analyze;

public class AbstractSyntaxTree {
    private AbstractSyntaxTreeNode Node { get; set; }

    public AbstractSyntaxTree() {
    }

    public void AddNode(TokenBase token) {
        if (token is null) throw new ArgumentNullException(nameof(token), "Token cannot be null!");

        if (this.Node is null) {
            this.Node = new(null, token, null);

            return;
        }

        this.Node.NextToken = token;
    }
}
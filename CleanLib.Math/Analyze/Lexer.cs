using CleanLib.Math.Tokens.Abstractions;
using System.Collections.Generic;
using System.Text;

namespace CleanLib.Math.Analyze;

// a = 1 + 1
// a : identifier
// = : operator
// 1 : literal
// + : operator
// 1 : literal

public class Lexer {
    public List<TokenBase> Tokens { get; } = new();
    //public AbstractSyntaxTree AST { get; } = new();
    public string Source { get; }
    public uint Line { get; private set; }
    public uint Column { get; private set; }

    public Lexer(string source) {
        this.Source = source;
    }

    public Lexer Match() {
        StringBuilder temp = new();

        for (int i = 0; i < this.Source.Length; i++) {
            this.Line = (uint)i; // No Nextline!!!

            if (char.IsWhiteSpace(this.Source[i])) {
                
            } else {
                temp.Append(this.Source[i]);
            }
        }

        return this;
    }

    public Lexer MatchKeyword() {

        return this;
    }

    public Lexer MatchLiteral() {

        return this;
    }

    public Lexer MatchIdentifier() {

        return this;
    }

    public Lexer MatchSeparator() {


        return this;
    }

    public Lexer MatchOperator() {
        

        return this;
    }
}
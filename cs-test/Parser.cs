using Nodes;
using System;
using System.Collections.Generic;

public class Parser
{
    private List<Tokenizer.Token> tokens = new List<Tokenizer.Token>();
    private int tokenIndex;

    bool endOfFile => tokens[0].type != Tokenizer.TokenType.EndOfFile;

    public Nodes.Program CreateAST(string sourceCode)
    {
        tokenIndex = 0;
        tokens = new Tokenizer().Tokenize(sourceCode);

        var progNode = new Nodes.Program();

        //parse until EoF
        while (!endOfFile)
        {
            var st = ParseStatement();
            if (st != null)
                progNode.body.Add(st);
        }
        return progNode;
    }

    public Tokenizer.Token NextToken()
    {
        var tk = tokens[tokenIndex];
        tokenIndex++;
        return tk;
    }

    Statement ParseStatement()
    {
        //skip to parseExpr
        return ParseExpression();
    }
    Expression ParseExpression()
    {
        return ParsePrimaryExpression();
    }

    Expression ParsePrimaryExpression()
    {
        var tk = NextToken();

        switch (tk.type)
        {
            case Tokenizer.TokenType.identifier:
                return new Identifier(tk.value);
            case Tokenizer.TokenType.number:
                return new NumericLiteral(tk.value);
            case Tokenizer.TokenType.EndOfFile:
                break;
            case Tokenizer.TokenType.binaryOperator:
                break;
            case Tokenizer.TokenType.equals:
                break;
            case Tokenizer.TokenType.openParen:
                break;
            case Tokenizer.TokenType.closeParen:
                break;
            case Tokenizer.TokenType.let:
                break;
        }
        Console.WriteLine($"Unexpected token found:{tk}");
        return null;
    }
}

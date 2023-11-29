using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

public class Tokenizer
{
    public enum TokenType
    {
        //none = -1,
        EndOfFile,
        number,


        binaryOperator,

        equals,
        openParen, closeParen,

        identifier,

        //Keywords
        let,
    }
    public struct Token
    {
        public TokenType type;
        public string value;

        public Token(TokenType type, string value)
        {
            this.type = type;
            this.value = value;
        }
        public override string ToString()
        {
            return $"Type: {type.ToString()},\tValue: '{value}'";
        }
    }

    public static readonly Dictionary<string, TokenType> KEYWORDS = new Dictionary<string, TokenType>()
        {
            { "let", TokenType.let },
        };

    public List<Token> Tokenize(string sourceCode)
    {
        var tokens = new List<Token>();

        foreach (var line in sourceCode.Split("\n"))
            tokens.AddRange(ProcessLine(line));

        return tokens;
    }

    private List<Token> ProcessLine(string line)
    {
        var tokens = new List<Token>();

        if (line.Length == 0)
            return tokens;

        for (int i = 0; i < line.Length; i++)
        {
            var token = DetermineToken(line, ref i);
            if (token != null)
                tokens.Add(token.Value);
        }

        tokens.Add(new Token(TokenType.EndOfFile, ""));

        return tokens;
    }

    public static Token? DetermineToken(string line, ref int index)
    {
        switch (line[index])
        {
            case '(':
                return new Token(TokenType.openParen, "(");
            case ')':
                return new Token(TokenType.closeParen, ")");
            case '+':
                //TODO: add ++ += (and token type)
                return new Token(TokenType.binaryOperator, "+");
            case '-':
                //TODO: add -- -=
                return new Token(TokenType.binaryOperator, "-");
            case '*':
                //TODO: add -- -=
                return new Token(TokenType.binaryOperator, "*");
            case '/':
                //TODO: add -- -=
                return new Token(TokenType.binaryOperator, "/");
            case '=':
                return new Token(TokenType.equals, "=");
            default:
                break;
        }

        //Multichar token

        if (isSkippable(line[index]))
            return null;
        if (isNumeric(line[index]))
        {
            var num = "";
            while (index < line.Length && isNumeric(line[index]))
            {
                num += line[index];
                index++;
            }
            index--;
            return new Token(TokenType.number, num);
        }

        if (isAlphabetic(line[index]))
        {
            var ident = "";
            while (index < line.Length && isAlphabetic(line[index]))
            {
                ident += line[index];
                index++;
            }
            index--;

            if (KEYWORDS.ContainsKey(ident))
                return new Token(KEYWORDS[ident], ident);
            else
                return new Token(TokenType.identifier, ident);
        }

        throw new Exception($"Unrecogonized character: '{line[index]}' at char {index}");
    }

    private static bool isAlphabetic(char c) => isAlphabetic(c.ToString());
    private static bool isAlphabetic(string s) => Regex.IsMatch(s, "^[A-Za-z]");

    private static bool isNumeric(char c) => isNumeric(c.ToString());
    private static bool isNumeric(string s) => Regex.IsMatch(s, "^[0-9]");

    private static bool isSkippable(char c) => isSkippable(c.ToString());
    private static bool isSkippable(string s) => Regex.IsMatch(s, "[\\s]");
}
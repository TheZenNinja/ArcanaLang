using System;
using System.Collections.Generic;

namespace Nodes
{
    public enum NodeType
    {
        program,
        numericLiteral,
        identifier,

        binaryExpression,
        callExpr,
        unaryExpr,

        functionDecl,
    }

    public interface Statement
    {
        public NodeType type { get; }
    }

    public struct Program : Statement
    {
        public NodeType type => NodeType.program;
        public List<Statement> body;
    }

    public interface Expression : Statement { }
    public struct BinaryExpression : Expression
    {
        public NodeType type => NodeType.binaryExpression;

        public Expression left;
        public Expression right;

        public string operatorChar;
    }

    public struct Identifier : Expression
    {
        public NodeType type => NodeType.identifier;
        public string symbol;

        public Identifier(string symbol)
        {
            this.symbol = symbol;
        }
    }

    #region Literals
    public struct NumericLiteral : Expression
    {
        public NodeType type => NodeType.numericLiteral;
        public string value;

        public NumericLiteral(string value)
        {
            this.value = value;
        }
    }
    #endregion
}
using System.Linq;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Utilities
{
    public static class ExpressionChildGenerator
    {
        public static IExpressionChild ParseExpression(ITokenizer tokenizer) => ParseAssignmentOperator(tokenizer);

        private static IExpressionChild ParseAssignmentOperator(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseLogicalOr(tokenizer);
            while (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.Assign, TokenType.AssignOp))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseAssignmentOperator(tokenizer);
                right = token.TokenType.GetHashCode() == (int) TokenType.Assign
                    ? (IExpressionChild)new BinaryAssignNode(left, right)
                    : new BinaryAssignOperatorNode(left, right, token.Value.Replace("=",""));
                return right;
            }
            return left;
        }

        private static IExpressionChild ParseLogicalOr(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseLogicalAnd(tokenizer);
            while (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.Or))
            {
                tokenizer.Pop(); 
                IExpressionChild right = ParseLogicalAnd(tokenizer);
                left = new BinaryOrOperatorNode(left, right);
            }
            return left;
        }

        private static IExpressionChild ParseLogicalAnd(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseOr(tokenizer);
            while (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.And))
            {
                tokenizer.Pop(); 
                IExpressionChild right = ParseBitwiseOr(tokenizer);
                left = new BinaryAndOperatorNode(left, right);
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseOr(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseXor(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "|"))
            {
                tokenizer.Pop(); 
                IExpressionChild right = ParseBitwiseXor(tokenizer);
                left = new BinaryOperatorNode(left, right, "|");
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseXor(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseBitwiseAnd(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "^"))
            {
                tokenizer.Pop();
                IExpressionChild right = ParseBitwiseAnd(tokenizer);
                left = new BinaryOperatorNode(left, right, "^");
            }
            return left;
        }

        private static IExpressionChild ParseBitwiseAnd(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseRelationalEquals(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "&"))
            {
                tokenizer.Pop();
                IExpressionChild right = ParseRelationalEquals(tokenizer);
                left = new BinaryOperatorNode(left, right, "&");
            }
            return left;
        }

        private static IExpressionChild ParseRelationalEquals(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseRelationalOperator(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "!=", "=="))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseRelationalOperator(tokenizer);
                left = new BinaryRelationalOperatorNode(left, right, token.Value);
            }
            return left;
        }

        private static IExpressionChild ParseRelationalOperator(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseShift(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "<", "<=", ">", ">="))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseShift(tokenizer);
                left = new BinaryRelationalOperatorNode(left, right, token.Value);
            }
            return left;
        }

        private static IExpressionChild ParseShift(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseTerm(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "<<", ">>"))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseTerm(tokenizer);
                left = new BinaryOperatorNode(left, right, token.Value);
            }
            return left;
        }

        private static IExpressionChild ParseTerm(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseFactor(tokenizer);
            while (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.PlusMinus))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseFactor(tokenizer);
                left = new BinaryOperatorNode(left, right, token.Value);
            }
            return left;
        }

        private static IExpressionChild ParseFactor(ITokenizer tokenizer)
        {
            IExpressionChild left = ParseUnary(tokenizer);
            while (DoesValueMatchAccepted(tokenizer.PeekValue(), "*", "/", "%"))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseUnary(tokenizer);
                left = new BinaryOperatorNode(left, right, token.Value);
            }
            return left;
        }

        private static IExpressionChild ParseUnary(ITokenizer tokenizer)
        {
            if (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.PlusMinus, TokenType.PrePost, TokenType.Negation, TokenType.Not))
            {
                SimpleCToken token = tokenizer.Pop();
                IExpressionChild right = ParseUnary(tokenizer);
                if (DoesTypeMatchAccepted(token.TokenType, TokenType.PlusMinus, TokenType.Negation)) return new UnaryOperatorNode(right, token.Value);
                if (DoesTypeMatchAccepted(token.TokenType, TokenType.Not)) return new UnaryNotOperatorNode(right);
                return new UnaryPreOperatorNode(right, token.Value[0].ToString());
            }
            return ParsePrimary(tokenizer);
        }

        private static IExpressionChild ParsePrimary(ITokenizer tokenizer)
        {
            if (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.Float, TokenType.Integer)) return ParseConstant(tokenizer);
            if (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.Identifier)) return ParseIdentifier(tokenizer);
            return ParseInnerExpression(tokenizer);
        }

        private static IExpressionChild ParseConstant(ITokenizer tokenizer)
        {
            SimpleCToken token = tokenizer.Pop();
            return new ConstantNode(token.Value, token.TokenType.GetHashCode() == (int) TokenType.Integer);
        }

        private static IExpressionChild ParseIdentifier(ITokenizer tokenizer)
        {
            SimpleCToken token = tokenizer.Pop();
            IExpressionChild result = new VariableExpressionNode(token.Value);
            if (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.LBracket))
            {
                tokenizer.Pop();
                IExpressionChild inside = ParseExpression(tokenizer);
                TokenConsumer.Consume(tokenizer.Pop(), TokenType.RBracket);
                result = new BinaryArrayOperatorNode((IVariableExpressionNode) result, inside);
            }
            if (DoesTypeMatchAccepted(tokenizer.PeekTokenType(), TokenType.PrePost))
            {
                token = tokenizer.Pop();
                result = new UnaryPostOperatorNode(result, token.Value[0].ToString());
            }
            return result;
        }

        private static IExpressionChild ParseInnerExpression(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LParent);
            IExpressionChild result = ParseExpression(tokenizer);
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RParent);
            return result;
        }

        private static bool DoesTypeMatchAccepted(ITokenType actual, params TokenType [] accepted)
        {
            int actualHash = actual.GetHashCode();
            return accepted.Any(type => (int) type == actualHash);
        }

        private static bool DoesValueMatchAccepted(string actual, params string[] accepted)
        {
            return accepted.Any(s => s.Equals(actual));
        }
    }
}

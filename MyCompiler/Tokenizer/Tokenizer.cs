
using System.Collections.Generic;

namespace MyCompiler.Tokenizer
{
    public class Tokenizer
    {
        private static IList<TokenDefinition> definitions;

        static Tokenizer(){
            definitions = new List<TokenDefinition>();
            //side effect operators
            definitions.Add(new TokenDefinition(TokenType.MinusMinus, "^--"));
            definitions.Add(new TokenDefinition(TokenType.PlusPlus, "^\\+\\+"));
            //numeric operators
            definitions.Add(new TokenDefinition(TokenType.Divide, "^/"));
            definitions.Add(new TokenDefinition(TokenType.LeftShift, "^<<"));
            definitions.Add(new TokenDefinition(TokenType.Minus, "^-"));
            definitions.Add(new TokenDefinition(TokenType.Modulus, "^%"));
            definitions.Add(new TokenDefinition(TokenType.Multiply, "^\\*"));
            definitions.Add(new TokenDefinition(TokenType.Plus, "^\\+"));
            definitions.Add(new TokenDefinition(TokenType.RightShift, "^>>"));
            //Boolean Operators
            definitions.Add(new TokenDefinition(TokenType.And, "^&&"));
            definitions.Add(new TokenDefinition(TokenType.BitwiseAnd, "^&"));
            definitions.Add(new TokenDefinition(TokenType.BitwiseNegation, "^~"));
            definitions.Add(new TokenDefinition(TokenType.BitwiseOr, "^\\|"));
            definitions.Add(new TokenDefinition(TokenType.Equals, "^=="));
            definitions.Add(new TokenDefinition(TokenType.GreaterThan, "^>"));
            definitions.Add(new TokenDefinition(TokenType.GreaterThanOrEquals, "^>="));
            definitions.Add(new TokenDefinition(TokenType.LessThan, "^<"));
            definitions.Add(new TokenDefinition(TokenType.LessThanOrEquals, "^<="));
            definitions.Add(new TokenDefinition(TokenType.Negation, "^!"));
            definitions.Add(new TokenDefinition(TokenType.NotEqualTo, "^!="));
            definitions.Add(new TokenDefinition(TokenType.Or, "^\\|\\|"));
            //Assignment Operators
            definitions.Add(new TokenDefinition(TokenType.AndAssign, "^&="));
            definitions.Add(new TokenDefinition(TokenType.Assign, "^="));
            definitions.Add(new TokenDefinition(TokenType.DivideAssign, "^/="));
            definitions.Add(new TokenDefinition(TokenType.LeftShiftAssign, "^<<="));
            definitions.Add(new TokenDefinition(TokenType.MinusAssign, "^-="));
            definitions.Add(new TokenDefinition(TokenType.ModulusAssign, "^%="));
            definitions.Add(new TokenDefinition(TokenType.MultiplyAssign, "^\\*="));
            definitions.Add(new TokenDefinition(TokenType.OrAssign, "^\\|="));
            definitions.Add(new TokenDefinition(TokenType.PlusAssign, "^\\+="));
            definitions.Add(new TokenDefinition(TokenType.RightShiftAssign, "^>>="));
            definitions.Add(new TokenDefinition(TokenType.XorAssign, "^\\^="));
            definitions.Add(new TokenDefinition(TokenType.IntegerConstant, "(+|-)?([1-9][\\d]*|0[0-7]*|(0x|0X)([\\da-fA-F]*))((u|U)(l|L)?|(l|L)(u|U)?)?"));
            definitions.Add(new TokenDefinition(TokenType.FloatingPointConstant, "\\d*.\\d+ | \\d+.(e|E)(+|-)?\\d* | \\d+.(e|E)(+|-)?\\d+(f|F)? | (0x|0X)[\\da-fA-F]*.[\\da-fA-F]* | [\\da-fA-F]+ . (p|P) (+|-)? \\d+ (f|F)?"));
        }

        public Tokenizer()
        {
        }
    }
}

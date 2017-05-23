using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.VariablesAndConstants
{
    public class IntegerConstantTokenType : BaseTokenType
    {
        public IntegerConstantTokenType()
        {
            Pattern = new Regex("([1-9][\\d]*|0[0-7]*|(0x|0X)([\\da-fA-F]*))((u|U)(l|L)?|(l|L)(u|U)?)?");
        }
    }
}

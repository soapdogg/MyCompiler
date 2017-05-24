﻿using System.Text.RegularExpressions;

namespace MyCompiler.Tokenizer.Tokens.VariablesAndConstants
{
    public class IntegerConstantTokenType : BaseTokenType
    {
        public IntegerConstantTokenType()
        {
            Pattern = new Regex("^([1-9]\\d*|0)");
        }
    }
}

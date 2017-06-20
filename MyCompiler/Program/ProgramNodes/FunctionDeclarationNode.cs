using System.Text;
using MyCompiler.Tokenizer;

namespace MyCompiler.Program.ProgramNodes
{
    public class FunctionDeclarationNode : Interfaces.IFunctionDeclarationNode
    {
        private string functionName;
        private Interfaces.ITypeNode type;
        private Interfaces.IBasicBlockNode basicBlock;

        public string Address => string.Empty; 

        public void Parse(ITokenizer tokenizer)
        {
            type = new TypeNode();
            type.Parse(tokenizer);
            functionName = tokenizer.Pop().Value;
            tokenizer.Pop(); //left parentheses
            tokenizer.Pop(); //right parenttheses
            basicBlock = new BasicBlockNode();
            basicBlock.Parse(tokenizer);
        }

        public string Translate() => basicBlock.Translate();

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(type.PrettyPrint());
            sb.Append(functionName);
            sb.Append("(){");
            sb.Append(Utilities.PrettyPrintingUtilities.GetPrettyPrintTempDeclarations());
            sb.Append(basicBlock.PrettyPrint());
            sb.Append("\n}\n");
            return sb.ToString();
        }

    }
}

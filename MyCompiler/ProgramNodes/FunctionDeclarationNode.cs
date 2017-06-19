using System.Text;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;

namespace MyCompiler.ProgramNodes
{
    public class FunctionDeclarationNode : IFunctionDeclarationNode
    {
        private string functionName;
        private ITypeNode type;
        private IBasicBlockNode basicBlock;

        public string Address { get; }

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
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintTempDeclarations());
            sb.Append(basicBlock.PrettyPrint());
            sb.Append("\n}\n");
            return sb.ToString();
        }

        public IDeclarationChild NewDeclarationChildInstance => new FunctionDeclarationNode();
    }
}

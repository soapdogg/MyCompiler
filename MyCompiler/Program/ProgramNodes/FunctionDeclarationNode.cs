using System.Text;
using MyCompiler.Program.ProgramNodes.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;
using MyCompiler.Tokenizer;
using MyCompiler.Tokenizer.Tokens.Interfaces;

namespace MyCompiler.Program.ProgramNodes
{
    public class FunctionDeclarationNode : IFunctionDeclarationNode
    {
        private readonly string functionName;
        private readonly ITypeNode type;
        private IBasicBlockNode basicBlock;

        public FunctionDeclarationNode(string typeString, string functionName)
        {
            type = new TypeNode(typeString);
            this.functionName = functionName;
        }

        public void Parse(ITokenizer tokenizer)
        {
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.LParent); 
            TokenConsumer.Consume(tokenizer.Pop(), TokenType.RParent); 
            basicBlock = new BasicBlockNode();
            basicBlock.Parse(tokenizer);
        }

        public void Translate() => basicBlock.Translate();

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(type.PrettyPrint());
            sb.Append(' ');
            sb.Append(functionName);
            sb.Append("(){");
            sb.Append(PrettyPrintingUtilities.GetPrettyPrintTempDeclarations());
            sb.Append(basicBlock.PrettyPrint());
            sb.Append("\n}\n");
            return sb.ToString();
        }

    }
}

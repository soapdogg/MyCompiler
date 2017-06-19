using System.Text;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class ArrayTypeNode : IArrayTypeNode
    {
        private bool hasIndex;
        private IExpressionNode expression;

        public string PrettyPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (hasIndex) sb.Append(expression.PrettyPrint());
            sb.Append("]");
            return sb.ToString();
        }
    }
}

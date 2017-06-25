using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IBinaryArrayOperatorNode : IExpressionChild, ILeftHandValue, ITypeNode, ITypable
    {
        string TranslatedInnerExpression { get; }
    }
}

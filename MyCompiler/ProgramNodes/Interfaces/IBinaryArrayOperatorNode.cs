namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IBinaryArrayOperatorNode : IExpressionChild, ILeftHandValue
    {
        string TranslatedInnerExpression { get; }
    }
}

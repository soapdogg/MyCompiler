namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IVariableExpressionNode : ILeftHandValue, IExpressionChild
    {
        string VariableType { get; }
    }
}

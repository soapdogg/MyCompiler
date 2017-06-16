namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IExpressionNode : ITranslatable, IPrettyPrintable
    {
        IExpressionChild Child { get; }
    }
}

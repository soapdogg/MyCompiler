namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IExpressionNode : ITranslatable, IPrettyPrintable, IParsable
    {
        IExpressionChild Child { get; }
    }
}

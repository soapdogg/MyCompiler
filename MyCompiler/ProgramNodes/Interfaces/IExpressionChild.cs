namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IExpressionChild : ITranslatable, IPrettyPrintable
    {
        IExpressionChild NewExpressionChildInstance();
    }
}

namespace MyCompiler.ProgramNodes.Interfaces
{
    public interface IBooleanExpressionChild : ITranslatable, ILabelable, IPrettyPrintable
    {
        IBooleanExpressionChild NewBooleanExpressionChildInstance { get; }
    }
}

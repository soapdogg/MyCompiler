using MyCompiler.Program.Interfaces;

namespace MyCompiler.Program.ProgramNodes.Interfaces
{
    public interface IVariableExpressionNode : ILeftHandValue, IExpressionChild, ITypable
    {
    }
}

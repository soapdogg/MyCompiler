using MyCompiler.ProgramNodes.Components;
using MyCompiler.ProgramNodes.Interfaces;

namespace MyCompiler.ProgramNodes
{
    public class StatementNode : IStatementNode
    {
        private readonly Translatable translatable;

        public StatementNode()
        {
            translatable = new Translatable();
        }

        public IStatementChild Child { get; }
        public string Address => translatable.Address;
        
        public string Translate() => Child.Translate();

        public string PrettyPrint() => Child.PrettyPrint();
    }
}

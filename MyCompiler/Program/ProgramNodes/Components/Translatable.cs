using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes.Components
{
    public class Translatable : ITranslatable
    {
        public bool IsTranslated { get; private set; }
        public string Address { get; set; }
        public string VariableType { get; protected set; }
        
        public void MarkAsTranslated()
        {
            IsTranslated = true;
        }

        public string Translate()
        {
            MarkAsTranslated();
            string tempId = CounterUtilities.GetNextTempAvailable;
            Address =  tempId;
            PrettyPrintingUtilities.AddToTypeTempIdDictionary(VariableType, tempId);
            return tempId;
        }
    }
}

using MyCompiler.Program.Interfaces;
using MyCompiler.Program.ProgramNodes.Utilities;

namespace MyCompiler.Program.ProgramNodes.Components
{
    public class Typable : ITypable
    {
        public string Type { get; set; }
        public string Address { get; set; }

        public string GenerateNewAddress()
        {
            string tempId = CounterUtilities.GetNextTempAvailable;
            Address =  tempId;
            PrettyPrintingUtilities.AddToTypeTempIdDictionary(Type, tempId);
            return tempId;
        }
    }
}


using System.Collections.Generic;

namespace MyCompiler.Program.ProgramNodes.Utilities
{
    public static class PrettyPrintingUtilities
    {
        private static IDictionary<string, string> typeTempIdDictionary;

        static PrettyPrintingUtilities()
        {
            typeTempIdDictionary = new Dictionary<string, string>();
        }

        public static void AddToTypeTempIdDictionary(string variableType, string tempId)
        {
            typeTempIdDictionary[variableType] = tempId;
        }

        public static string GetTabbedNewLine() => "\n\t";

        public static string GetVariableAssignment(string left, string right) => left + " = " + right + ";";

        public static string GetTabbedNewLineAndVariableAssignment(string left, string right) 
            => GetTabbedNewLine() + GetVariableAssignment(left, right);

        public static string GetPrettyPrintedLabel(string label) => "\n\t" + label + ": ;";

        public static string GetPrettyPrintedGoto(string label) => "goto " + label + ";";

        public static string GetPrettyPrintTempDeclarations() => "TEMP DECLARATIONS\n";
    }
}

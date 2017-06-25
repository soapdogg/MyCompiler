
using System.Collections.Generic;
using System.Text;

namespace MyCompiler.Program.ProgramNodes.Utilities
{
    public static class PrettyPrintingUtilities
    {
        private static IDictionary<string, List<string>> typeTempIdDictionary;

        static PrettyPrintingUtilities()
        {
            typeTempIdDictionary = new Dictionary<string, List<string>>();
        }

        public static void AddToTypeTempIdDictionary(string variableType, string tempId)
        {
            if(!typeTempIdDictionary.ContainsKey(variableType)) typeTempIdDictionary[variableType] = new List<string>();
            typeTempIdDictionary[variableType].Add(tempId);
        }

        public static string GetTabbedNewLine() => "\n\t";

        public static string GetVariableAssignment(string left, string right) => left + " = " + right + ";";

        public static string GetTabbedNewLineAndVariableAssignment(string left, string right) 
            => GetTabbedNewLine() + GetVariableAssignment(left, right);

        public static string GetPrettyPrintedLabel(string label) => "\n\t" + label + ": ;";

        public static string GetPrettyPrintedGoto(string label) => "goto " + label + ";";

        public static string GetPrettyPrintTempDeclarations()
        {
            int tempsPerLine = 5;
            StringBuilder sb = new StringBuilder();
            foreach (var l in typeTempIdDictionary)
            {
                int counter = 0;
                for (var index = 0; index < l.Value.Count; index++)
                {
                    if (counter++ % tempsPerLine == 0)
                    {
                        sb.Append(GetTabbedNewLine());
                        sb.Append(l.Key);
                        sb.Append(' ');
                    }
                    var id = l.Value[index];
                    sb.Append(id);
                    if (index != l.Value.Count - 1 && counter % tempsPerLine != 0) sb.Append(", ");
                    else sb.Append(';');
                }
            }
            return sb.ToString();
        }
    }
}

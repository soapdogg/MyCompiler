using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompiler.ProgramNodes.Interfaces;
using MyCompiler.ProgramNodes.Utilities;

namespace MyCompiler.ProgramNodes
{
    public class Translatable : ITranslatable
    {
        public bool IsTranslated { get; private set; }
        public string Address { get; set; }
        public string VariableType { get; protected set; }
        private static IDictionary<string, string> typeTempIdDictionary;

        static Translatable()
        {
            typeTempIdDictionary = new Dictionary<string, string>();
        }

        public void MarkAsTranslated()
        {
            IsTranslated = true;
        }

        public string Translate()
        {
            MarkAsTranslated();
            string tempId = CounterUtilities.GetNextTempAvailable;
            Address =  tempId;
            AddToTypeTempIdDictionary(VariableType, tempId);
            return tempId;
        }

        private static void AddToTypeTempIdDictionary(string variableType, string tempId)
        {
            typeTempIdDictionary[variableType] = tempId;
        }
    }
}

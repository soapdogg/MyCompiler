using System.Collections.Generic;

namespace MyCompiler.Program.ProgramNodes.Utilities
{
    public static class TypeTracker
    {
        private static readonly IDictionary<string, string> declaredTypeDictionary;

        static TypeTracker()
        {
            declaredTypeDictionary = new Dictionary<string, string>();   
        }

        public static void AddType(string id, string type)
        {
            declaredTypeDictionary[id] = type;
        }

        public static string GetType(string id)
        {
            return declaredTypeDictionary[id];
        }
    }
}

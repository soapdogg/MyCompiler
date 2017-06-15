namespace MyCompiler.ProgramNodes.Utilities
{
    public static class CounterUtilities
    {
        private static int tempCounter;

        private static int labelCounter;

        public static string GetNextTempAvailable => "_t" + ++tempCounter;

        public static string GetNextLabelAvailable => "_l" + ++labelCounter;
    }
}

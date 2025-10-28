using System;
using System.Collections.Generic;

namespace TestCaseGenerator
{
    public class TestCase(string name)
    {
        public readonly string Name = name;
        public readonly List<string> Statements = [];
        public readonly HashSet<int> StatementsToTraceIndexes = new HashSet<int>();
        public bool UseConstraints = false;

        public void AddStatement(string statement, bool trace = false)
        {
            if (trace)
            {
                Console.WriteLine($"#trace was selected for \"{statement}\" [{Statements.Count}]");
                StatementsToTraceIndexes.Add(Statements.Count);
            }
            Statements.Add(statement);
        }
     }
}


using System;
using System.Collections.Generic;

namespace TestCaseGenerator
{
    public class TestCase(string name)
    {
        public readonly string Name = name;
        public readonly List<string> Statements = [];
        public bool UseConstraints = false;
     }
}


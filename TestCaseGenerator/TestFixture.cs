using System;
using System.Collections.Generic;

namespace TestCaseGenerator
{
    public class TestFixture
    {
        public string Name;
        public readonly List<TestCase> TestCases = [];
        public readonly List<string> Epilogue = [];
    }
}


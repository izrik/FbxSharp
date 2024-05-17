using System.Collections.Generic;

namespace TestCaseGenerator;

public class TestFile
{
    public readonly List<string> Prologue = [];
    public readonly List<TestFixture> TestFixtures = [];
}

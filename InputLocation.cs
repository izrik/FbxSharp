using System;

namespace FbxSharp
{
    public struct InputLocation
    {
        public InputLocation(int line, int column, int index)
        {
            Line = line;
            Column = column;
            Index = index;
        }

        public readonly int Line;
        public readonly int Column;
        public readonly int Index;
    }
}


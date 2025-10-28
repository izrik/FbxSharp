using System;

namespace FbxSharp
{
    public struct InputLocation
    {
        public InputLocation(int line, int column, int index, string filename)
        {
            Line = line;
            Column = column;
            Index = index;
            Filename = filename;
        }

        public readonly int Line;
        public readonly int Column;
        public readonly int Index;
        public readonly string Filename;

        public override string ToString()
        {
            if (Index > 0)
                return string.Format("{0}[{1} 0x{1:x}]", Filename, Index);
            return string.Format("{0}:{1},{2}", Filename, Line, Column);
        }
    }
}

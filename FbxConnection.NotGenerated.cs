using System;

namespace FbxSharp
{
    public static partial class FbxConnection
    {
        public enum EType
        {
            None,
            System,
            User,
            SystemOrUser,
            Reference,
            Contains,
            Data,
            LinkType,
            Default,
            Unidirectional,
        }
    }
}


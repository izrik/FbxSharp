using System;

namespace FbxSharp
{
    public static class Connection
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


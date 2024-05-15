using System;

namespace FbxSharp;

/// <summary>
/// An attribute that indicates that a certain class, struct, method, or
/// property is not found in the FBX SDK, and is included for convenience. 
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class NotSdkAttribute : Attribute
{
}

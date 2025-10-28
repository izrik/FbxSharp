using System;

namespace FbxSharp;

/// <summary>
/// An attribute that indicates that a certain class, struct, method, or
/// property is not found in the FBX SDK, and is included for convenience. 
/// </summary>
[AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Delegate |
    AttributeTargets.Enum |
    AttributeTargets.Event | // Note: There are no events in C++
    AttributeTargets.Field |
    AttributeTargets.GenericParameter |
    AttributeTargets.Interface |
    AttributeTargets.Method |
    AttributeTargets.Parameter |
    AttributeTargets.Property |
    AttributeTargets.Struct)]
public class NotSdkAttribute : Attribute;

using System;

namespace FbxSharp;

/// <summary>
/// Indicates that an item is meant to be as close as possible to an item in
/// the SDK, but cannot due to a fundamental difference between C++ and C#.
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class DeviationFromSdkAttribute(
    string appliesTo = null,
    string notes = null) : Attribute
{
    public string AppliesTo { get; } = appliesTo;
    public string Notes { get; } = notes;
}

using System;
using System.Collections.Generic;

namespace FbxSharp;

/// <summary>
/// A kind of specialization of FbxProperty for root properties 
/// </summary>
[NotSdk]
public class FbxPropertyRoot(FbxObject parent)
    : FbxProperty("", EFbxType.eFbxUndefined)
{
    public override Type GetDotnetType() => typeof(void);

    public override bool IsRoot() => true;

    public override FbxObject GetFbxObject() => parent;
}
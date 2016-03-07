using System;

namespace TestCaseGenerator
{
    public static class FbxTypes
    {
        public static FbxType FbxObject = new FbxType {
            Name = "FbxObject",
            Methods = new [] {
                new FbxMethod {
                    Name = "FindProperty",
                    ReturnType = FbxTypes.FbxProperty,
                    Parameters = new [] {
                        new FbxParameter {
                            Name = "pName",
                            ParameterType = FbxTypes.String,
                        },
                        new FbxParameter {
                            Name = "pCaseSensitive",
                            ParameterType = FbxTypes.Bool,
                            DefaultValue = true,
                        }
                    }
                },
                new FbxMethod {
                    Name = "GetSrcPropertyCount",
                    ReturnType = FbxTypes.Int,
                },
                new FbxMethod {
                    Name = "GetDstPropertyCount",
                    ReturnType = FbxTypes.Int,
                }
            },
        };

        public static FbxType FbxProperty = new FbxType {
            Name = "FbxProperty",
            Methods = new [] {
                new FbxMethod {
                    Name = "IsValid",
                    ReturnType = FbxTypes.Bool,
                },
                new FbxMethod {
                    Name = "GetName",
                    ReturnType = FbxTypes.String,
                },
            }
        };

        public static FbxType FbxMesh = new FbxType {
            Name = "FbxMesh",
            BaseType = FbxTypes.FbxGeometry,
        };

        public static FbxType FbxGeometry = new FbxType {
            Name = "FbxGeometry",
            BaseType = FbxTypes.FbxGeometryBase,
        };

        public static FbxType FbxGeometryBase = new FbxType {
            Name = "FbxGeometryBase",
            BaseType = FbxTypes.FbxLayerContainer,
        };

        public static FbxType FbxLayerContainer = new FbxType {
            Name = "FbxLayerContainer",
            BaseType = FbxTypes.FbxNodeAttribute,
        };

        public static FbxType FbxNodeAttribute = new FbxType {
            Name = "FbxNodeAttribute",
            BaseType = FbxTypes.FbxObject,
        };


        public static FbxType FbxAnimCurveKey = new FbxType {
            Name = "FbxAnimCurveKey",
            BaseType = FbxTypes.FbxAnimCurveKeyBase,
            Methods = new [] {
                new FbxMethod {
                    Name="GetTime",
                    ReturnType=FbxTypes.FbxTime,
                },
                new FbxMethod {
                    Name="GetValue",
                    ReturnType=FbxTypes.Float,
                },
                new FbxMethod {
                    Name = "GetTangentMode",
                    ReturnType = FbxTypes.FbxAnimCurveDef_ETangentMode,
                    Parameters = new [] {
                        new FbxParameter {
                            Name = "pIncludeOverrides",
                            ParameterType=FbxTypes.Bool,
                            DefaultValue=false,
                        }
                    }
                },
                new FbxMethod {
                    Name = "GetInterpolation",
                    ReturnType = FbxTypes.FbxAnimCurveDef_EInterpolationType,
                },
                new FbxMethod {
                    Name = "GetTangentWeightMode",
                    ReturnType = FbxTypes.FbxAnimCurveDef_EWeightedMode,
                },
                new FbxMethod {
                    Name = "SetTangentWeightMode",
                    Parameters = new [] {
                        new FbxParameter {
                            Name="pTangentWeightMode",
                            ParameterType=FbxTypes.FbxAnimCurveDef_EWeightedMode,
                        },
                        new FbxParameter {
                            Name="pMask",
                            ParameterType=FbxTypes.FbxAnimCurveDef_EWeightedMode,
                            DefaultValue="FbxAnimCurveDef::eWeightedAll"
                        },
                    }
                },
                new FbxMethod {
                    Name = "GetConstantMode",
                    ReturnType = FbxTypes.FbxAnimCurveDef_EConstantMode,
                },
                new FbxMethod {
                    Name = "GetTangentVelocityMode",
                    ReturnType = FbxTypes.FbxAnimCurveDef_EVelocityMode,
                },
                new FbxMethod {
                    Name = "GetTangentVisibility",
                    ReturnType = FbxTypes.FbxAnimCurveDef_ETangentVisibility,
                },
                new FbxMethod {
                    Name = "GetBreak",
                    ReturnType = FbxTypes.Bool,
                },
                new FbxMethod {
                    Name="GetDataFloat",
                    ReturnType=FbxTypes.Float,
                    Parameters=new [] {
                        new FbxParameter {
                            Name="pIndex",
                            ParameterType=FbxTypes.FbxAnimCurveDef_EDataIndex,
                        },
                    }
                },
                new FbxMethod {
                    Name="SetTangentWeightAndAdjustTangent",
                    Parameters = new [] {
                        new FbxParameter {
                            Name="pIndex",
                            ParameterType=FbxTypes.FbxAnimCurveDef_EDataIndex,
                        },
                        new FbxParameter {
                            Name="pWeight",
                            ParameterType=FbxTypes.Double,
                        },
                    }
                }
            }
        };

        public static FbxType FbxAnimCurveKeyBase = new FbxType {
            Name = "FbxAnimCurveKeyBase",
        };

        public static FbxType FbxTime = new FbxType {
            Name = "FbxTime",
            Methods = new [] {
                new FbxMethod {
                    Name = "Get",
                    ReturnType = FbxTypes.FbxLongLong,
                }
            }
        };

        public static FbxType FbxAnimCurveDef_ETangentMode = new FbxType {
            Name = "ETangentMode"
        };
        public static FbxType FbxAnimCurveDef_EInterpolationType = new FbxType {
            Name = "EInterpolationType"
        };
        public static FbxType FbxAnimCurveDef_EWeightedMode = new FbxType {
            Name = "EWeightedMode"
        };
        public static FbxType FbxAnimCurveDef_EConstantMode = new FbxType {
            Name = "EConstantMode"
        };
        public static FbxType FbxAnimCurveDef_EVelocityMode = new FbxType {
            Name = "EVelocityMode"
        };
        public static FbxType FbxAnimCurveDef_ETangentVisibility = new FbxType {
            Name = "ETangentVisibility"
        };
        public static FbxType FbxAnimCurveDef_EDataIndex = new FbxType {
            Name = "EDataIndex"
        };


        public static FbxType Void = new FbxType { Name = "void" };
        public static FbxType Bool = new FbxType { Name = "bool" };
        public static FbxType String = new FbxType { Name = "string" };
        public static FbxType Int = new FbxType { Name = "int" };
        public static FbxType Float = new FbxType { Name = "float" };
        public static FbxType Double = new FbxType { Name = "double" };

        public static FbxType FbxLongLong = new FbxType { Name = "FbxLongLong" };
    }
}


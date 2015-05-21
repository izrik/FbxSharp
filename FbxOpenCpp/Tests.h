
#ifndef __FBXOPENCPP_TESTS_H
#define __FBXOPENCPP_TESTS_H

#include "common.h"
#include "Assertions.h"

void RunTests();

typedef void (*TestFunction)();

class TestFixture;

struct TestCase
{
    TestCase(const char* name, TestFunction function, TestFixture* parentFixture)
        : Name(name), Function(function), ParentFixture(parentFixture)
    {
    }

    const char* Name;
    TestFunction Function;
    TestFixture* ParentFixture;
};

class TestFixture
{
public:
    TestFixture(const char* name);

    virtual void RegisterTestCases();

    virtual void SetupFixture();
    virtual void Setup();
    virtual void TearDown();
    virtual void TearDownFixture();

    const char* Name;

    std::vector<TestCase> TestCases;
};


#define AddTestCase(name) TestCases.push_back(TestCase(#name, &name, this))

#define TestClass(name) class name : public virtual TestFixture {\
    public: name() : TestFixture(#name) { RegisterTestCases(); }\
    virtual void RegisterTestCases(); };

TestClass(NodeTest);
TestClass(SceneTest);
TestClass(LayerContainerTest);
TestClass(GeometryBaseTest);
TestClass(GeometryTest);
TestClass(MeshTest);
TestClass(FbxObjectTest);
TestClass(SurfacePhongTest);
TestClass(PropertyTest);
TestClass(DeformerTest);
TestClass(SubDeformerTest);
TestClass(SkinTest);
TestClass(ClusterTest);
TestClass(FbxTimeTest);
TestClass(AnimCurveNodeTest);
TestClass(AnimCurveTest);
TestClass(AnimLayerTest);
TestClass(AnimStackTest);
TestClass(NodeTransformsTest);
TestClass(MatrixTest);
TestClass(AnimCurveKeyTest);
TestClass(LightTest);
TestClass(CameraTest);

#endif // __FBXOPENCPP_TESTS_H

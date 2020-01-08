
#include "Tests.h"
#include <vector>

using namespace std;

class ScopedTestRun
{
public:
    ScopedTestRun(TestFixture* _test, TestCase* _testCase, std::string** _exception)
        : test(_test), testCase(_testCase), exception(_exception)
    {
        if (exception != NULL)
        {
            *exception = NULL;
        }
    }

    TestFixture* test;
    TestCase* testCase;
    std::string** exception;

    ~ScopedTestRun()
    {
        try
        {
            test->TearDown();
        }
        catch (std::string* e)
        {
            cout << "Error in tear down: " << *e << endl;
            if (exception != NULL)
            {
                *exception = e;
            }
            else
            {
                delete e;
            }
        }
        catch (char* e)
        {
            cout << "Error in tear down: " << e << endl;
            if (exception != NULL)
            {
                *exception = new string(e);
            }
        }
    }

    void RunTest()
    {
        cout << "    Running test " << testCase->Name << "... ";

        try
        {
            test->Setup();
        }
        catch (std::string* e)
        {
            cout << "Error in setup: " << *e << endl;
            if (exception != NULL)
            {
                *exception = e;
            }
            else
            {
                delete e;
            }
            return;
        }
        catch (char* e)
        {
            cout << "Error in setup: " << e << endl;
            if (exception != NULL)
            {
                *exception = new string(e);
            }
        }

        try
        {
            testCase->Function();
        }
        catch (std::string* e)
        {
            cout << *e << endl;
            if (exception != NULL)
            {
                *exception = e;
            }
            else
            {
                delete e;
            }
        }
        catch (char* e)
        {
            cout << e << endl;
            if (exception != NULL)
            {
                *exception = new string(e);
            }
        }
    }
};

void RunTests()
{
    vector<TestFixture*> tests;

    tests.push_back(new NodeTest());
    tests.push_back(new SceneTest());
    tests.push_back(new LayerContainerTest());
    tests.push_back(new GeometryBaseTest());
    tests.push_back(new GeometryTest());
    tests.push_back(new MeshTest());
    tests.push_back(new FbxObjectTest());
    tests.push_back(new SurfacePhongTest());
    tests.push_back(new PropertyTest());
    tests.push_back(new DeformerTest());
    tests.push_back(new SubDeformerTest());
    tests.push_back(new SkinTest());
    tests.push_back(new ClusterTest());
    tests.push_back(new FbxTimeTest());
    tests.push_back(new AnimCurveNodeTest());
    tests.push_back(new AnimCurveTest());
    tests.push_back(new AnimLayerTest());
    tests.push_back(new AnimStackTest());
    tests.push_back(new NodeTransformsTest());
    tests.push_back(new MatrixTest());
    tests.push_back(new AnimCurveKeyTest());
    tests.push_back(new LightTest());
    tests.push_back(new CameraTest());

    cout << "Running tests..." << endl;

    vector<TestCase*> failures;

    int i;
    for (i = 0; i < tests.size(); i++)
    {
        TestFixture* test = tests[i];

        cout << "  Running test class " << test->Name << endl;

        test->SetupFixture();

        int j;
        for (j = 0; j < test->TestCases.size(); j++)
        {
            TestCase* testCase = &test->TestCases[j];
            string* exception;

            { // ScopedTestRun
                ScopedTestRun testRun(test, testCase, &exception);
                testRun.RunTest();
            }

            if (exception == NULL)
            {
                cout << "pass" << endl;
            }
            else
            {
                failures.push_back(testCase);
            }
        }

        test->TearDownFixture();
    }

    cout << endl;
    if (failures.size() < 1)
    {
        cout << "All tests passed." << endl;
    }
    else
    {
        if (failures.size() == 1)
        {
            cout << "There was " << failures.size() << " failure:" << endl;
        }
        else
        {
            cout << "There were " << failures.size() << " failures:" << endl;
        }

        for (i = 0; i < failures.size(); i++)
        {
            TestCase* tc = failures[i];
            cout << "  " << tc->ParentFixture->Name << "." << tc->Name << endl;
        }
    }
}

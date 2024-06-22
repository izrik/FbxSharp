
#include "Tests.h"
#include <vector>
#include <iostream>
#include <algorithm>

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

bool CompareTestFixturesByName(TestFixture* a, TestFixture* b)
{
    int alen = a->Name.size();
    int blen = b->Name.size();
    int result = a->Name.compare(b->Name);
    if (result < 0)
        return true;
    if (result == 0)
        return alen < blen;
    return false;
}

void RunTests()
{
    vector<string> args;
    RunTestsWithArgs(args);
}
void RunTestsWithArgs(vector<string>& args)
{
    if (args.size() > 0)
    {
        cout << "Args:" << endl;
        for (auto iter = args.begin(); iter != args.end(); iter++)
            cout << "  " << *iter << endl;
        cout << endl;
    }

    vector<TestFixture*> all_tests;

    all_tests.push_back(new NodeTest());
    all_tests.push_back(new SceneTest());
    all_tests.push_back(new LayerContainerTest());
    all_tests.push_back(new GeometryBaseTest());
    all_tests.push_back(new GeometryTest());
    all_tests.push_back(new MeshTest());
    all_tests.push_back(new FbxObjectTest());
    all_tests.push_back(new SurfacePhongTest());
    all_tests.push_back(new PropertyTest());
    all_tests.push_back(new DeformerTest());
    all_tests.push_back(new SubDeformerTest());
    all_tests.push_back(new SkinTest());
    all_tests.push_back(new ClusterTest());
    all_tests.push_back(new FbxTimeTest());
    all_tests.push_back(new AnimCurveNodeTest());
    all_tests.push_back(new AnimCurveTest());
    all_tests.push_back(new AnimLayerTest());
    all_tests.push_back(new AnimStackTest());
    all_tests.push_back(new NodeTransformsTest());
    all_tests.push_back(new MatrixTest());
    all_tests.push_back(new AnimCurveKeyTest());
    all_tests.push_back(new LightTest());
    all_tests.push_back(new CameraTest());
    all_tests.push_back(new LayerTest());
    all_tests.push_back(new FbxImporterTest());
    all_tests.push_back(new EFbxTypeTest());
    all_tests.push_back(new FbxPropertyFlagsTest());
    all_tests.push_back(new FbxDataTypeTest());
    all_tests.push_back(new FbxPropertyTest());
    all_tests.push_back(new FbxIOSettingsTest());
    all_tests.push_back(new FbxDocumentInfoTest());

    vector<TestFixture*> tests;

    if (args.size() > 0)
    {
        for (auto iter = all_tests.begin(); iter != all_tests.end(); iter++)
        {
            auto it = std::find(args.begin(), args.end(), (*iter)->Name);
            if (it != std::end(args))
                tests.push_back(*iter);
        }
        // TODO: Warn when an arg is not found among the tests
        // TODO: Warn when no tests were selected
    }
    else
    {
        tests.insert(tests.end(), all_tests.begin(), all_tests.end());
    }

    sort(tests.begin(), tests.end(), CompareTestFixturesByName);

    // Some classes need the SDK library to be initialized before we can use
    // them. For example, the AnimCurveKey constructors will segfault without
    // the following:
    FbxManager* manager = FbxManager::Create();

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
            TestCase* testCase = test->TestCases[j];
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

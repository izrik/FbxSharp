
#include "common.h"

using namespace std;

void _AssertEqual(int expected, int actual, const char* filename, int line)
{
    if (expected != actual)
    {
        stringstream ss;
        ss << "Expected " << expected << " but got " << actual << ", at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertEqual(void* expected, void* actual, const char* filename, int line)
{
    if (expected != actual)
    {
        stringstream ss;
        ss << "Expected " << expected << " but got " << actual << ", at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertEqual(const char* expected, const char* actual, const char* filename, int line)
{
    if (strcmp(expected, actual) != 0)
    {
        stringstream ss;
        ss << "Expected \"" << expected << "\" but got \"" << actual << "\", at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertEqual(const char* expected, FbxString& actual, const char* filename, int line)
{
    _AssertEqual(expected, actual.Buffer(), filename, line);
}

void _AssertEqual(FbxVector4 expected, FbxVector4 actual, const char* filename, int line)
{
    if (expected != actual)
    {
        stringstream ss;
        ss << "Expected " << expected << " but got " << actual << ", at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertNotEqual(void* expected, void* actual, const char* filename, int line)
{
    if (expected == actual)
    {
        stringstream ss;
        ss << "Expected not(" << expected << ") but got " << actual << ", at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertNull(void* actual, const char* filename, int line)
{
    _AssertEqual(NULL, actual, filename, line);
}

void _AssertNotNull(void* actual, const char* filename, int line)
{
    _AssertNotEqual(NULL, actual, filename, line);
}

void _AssertTrue(bool condition, const char* filename, int line)
{
    if (!condition)
    {
        stringstream ss;
        ss << "Assertion failed at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

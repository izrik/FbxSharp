
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

void _AssertEqual(double expected, double actual, const char* filename, int line, double epsilon)
{
    double difference = abs(expected - actual);
    if (difference > epsilon)
    {
        stringstream ss;
        ss << "Expected " << expected << " but got " << actual << " (difference="<< difference << ", epsilon=" << epsilon << "), at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertEqual(FbxAMatrix expected, FbxAMatrix actual, const char* filename, int line, double epsilon)
{
    double d00 = abs(expected.Get(0, 0) - actual.Get(0, 0));
    double d01 = abs(expected.Get(0, 1) - actual.Get(0, 1));
    double d02 = abs(expected.Get(0, 2) - actual.Get(0, 2));
    double d03 = abs(expected.Get(0, 3) - actual.Get(0, 3));
    double d10 = abs(expected.Get(1, 0) - actual.Get(1, 0));
    double d11 = abs(expected.Get(1, 1) - actual.Get(1, 1));
    double d12 = abs(expected.Get(1, 2) - actual.Get(1, 2));
    double d13 = abs(expected.Get(1, 3) - actual.Get(1, 3));
    double d20 = abs(expected.Get(2, 0) - actual.Get(2, 0));
    double d21 = abs(expected.Get(2, 1) - actual.Get(2, 1));
    double d22 = abs(expected.Get(2, 2) - actual.Get(2, 2));
    double d23 = abs(expected.Get(2, 3) - actual.Get(2, 3));
    double d30 = abs(expected.Get(3, 0) - actual.Get(3, 0));
    double d31 = abs(expected.Get(3, 1) - actual.Get(3, 1));
    double d32 = abs(expected.Get(3, 2) - actual.Get(3, 2));
    double d33 = abs(expected.Get(3, 3) - actual.Get(3, 3));
    if (d00 > epsilon ||
        d01 > epsilon ||
        d02 > epsilon ||
        d03 > epsilon ||
        d10 > epsilon ||
        d11 > epsilon ||
        d12 > epsilon ||
        d13 > epsilon ||
        d20 > epsilon ||
        d21 > epsilon ||
        d22 > epsilon ||
        d23 > epsilon ||
        d30 > epsilon ||
        d31 > epsilon ||
        d32 > epsilon ||
        d33 > epsilon)
    {
        stringstream ss;
        ss << "Expected " << expected << " but got " << actual << " (epsilon=" << epsilon << "), at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertEqual(FbxMatrix expected, FbxMatrix actual, const char* filename, int line, double epsilon)
{
    double d00 = abs(expected.Get(0, 0) - actual.Get(0, 0));
    double d01 = abs(expected.Get(0, 1) - actual.Get(0, 1));
    double d02 = abs(expected.Get(0, 2) - actual.Get(0, 2));
    double d03 = abs(expected.Get(0, 3) - actual.Get(0, 3));
    double d10 = abs(expected.Get(1, 0) - actual.Get(1, 0));
    double d11 = abs(expected.Get(1, 1) - actual.Get(1, 1));
    double d12 = abs(expected.Get(1, 2) - actual.Get(1, 2));
    double d13 = abs(expected.Get(1, 3) - actual.Get(1, 3));
    double d20 = abs(expected.Get(2, 0) - actual.Get(2, 0));
    double d21 = abs(expected.Get(2, 1) - actual.Get(2, 1));
    double d22 = abs(expected.Get(2, 2) - actual.Get(2, 2));
    double d23 = abs(expected.Get(2, 3) - actual.Get(2, 3));
    double d30 = abs(expected.Get(3, 0) - actual.Get(3, 0));
    double d31 = abs(expected.Get(3, 1) - actual.Get(3, 1));
    double d32 = abs(expected.Get(3, 2) - actual.Get(3, 2));
    double d33 = abs(expected.Get(3, 3) - actual.Get(3, 3));
    if (d00 > epsilon ||
        d01 > epsilon ||
        d02 > epsilon ||
        d03 > epsilon ||
        d10 > epsilon ||
        d11 > epsilon ||
        d12 > epsilon ||
        d13 > epsilon ||
        d20 > epsilon ||
        d21 > epsilon ||
        d22 > epsilon ||
        d23 > epsilon ||
        d30 > epsilon ||
        d31 > epsilon ||
        d32 > epsilon ||
        d33 > epsilon)
    {
        stringstream ss;
        ss << "Expected " << expected << " but got " << actual << " (epsilon=" << epsilon << "), at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

void _AssertEqual(FbxLongLong expected, FbxLongLong actual, const char* filename, int line)
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

void _AssertFalse(bool condition, const char* filename, int line)
{
    _AssertTrue(!condition, filename, line);
}

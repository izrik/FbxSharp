
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

void _AssertNotEqual(void* expected, void* actual, const char* filename, int line)
{
    if (expected == actual)
    {
        stringstream ss;
        ss << "Expected not(" << expected << ") but got " << actual << ", at " << filename << ":" << line;
        throw new string(ss.str());
    }
}

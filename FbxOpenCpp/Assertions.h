
#ifndef __FBXOPENCPP_ASSERTIONS_H
#define __FBXOPENCPP_ASSERTIONS_H

#include <fbxsdk.h>

void _AssertEqual(int expected, int actual, const char* filename, int line);
void _AssertEqual(void* expected, void* actual, const char* filename, int line);
void _AssertEqual(const char* expected, const char* actual, const char* filename, int line);
void _AssertEqual(const char* expected, FbxString& actual, const char* filename, int line);
void _AssertEqual(FbxVector4 expected, FbxVector4 actual, const char* filename, int line);
void _AssertEqual(double expected, double actual, const char* filename, int line, double epsilon=0);
void _AssertEqual(FbxMatrix expected, FbxMatrix actual, const char* filename, int line, double epsilon=0);
void _AssertEqual(FbxAMatrix expected, FbxAMatrix actual, const char* filename, int line, double epsilon=0);
void _AssertEqual(FbxLongLong expected, FbxLongLong actual, const char* filename, int line);
void _AssertNotEqual(void* expected, void* actual, const char* filename, int line);
void _AssertNull(void* actual, const char* filename, int line);
void _AssertNotNull(void* actual, const char* filename, int line);
void _AssertTrue(bool condition, const char* filename, int line);
void _AssertFalse(bool condition, const char* filename, int line);

#define AssertEqual(expected, actual, ...) _AssertEqual((expected), (actual), __FILE__, __LINE__ , ## __VA_ARGS__)
#define AssertNotEqual(expected, actual) _AssertNotEqual((expected), (actual), __FILE__, __LINE__)
#define AssertNull(actual) _AssertNull((actual), __FILE__, __LINE__)
#define AssertNotNull(actual) _AssertNotNull((actual), __FILE__, __LINE__)
#define AssertTrue(condition) _AssertTrue((condition), __FILE__, __LINE__)
#define AssertFalse(condition) _AssertFalse((condition), __FILE__, __LINE__)

#endif // __FBXOPENCPP_ASSERTIONS_H

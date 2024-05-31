
#include <iostream>
#include <fbxsdk.h>
#include <iomanip>
#include <stdio.h>  /* defines FILENAME_MAX */
#include <vector>
#include <string>
#ifdef WIN32
    #include <direct.h>
    #define __getcwd _getcwd
#else
    #include <unistd.h>
    #define __getcwd getcwd
#endif

#include "OutputDebugStringBuf.h"
#include "Tests.h"

int main (int argc, char *argv[])
{
     #ifndef NDEBUG
        #ifdef _WIN32
            static OutputDebugStringBuf<char> charDebugOutput;
            std::cout.rdbuf(&charDebugOutput);
            std::cerr.rdbuf(&charDebugOutput);
            std::clog.rdbuf(&charDebugOutput);

            static OutputDebugStringBuf<wchar_t> wcharDebugOutput;
            std::wcout.rdbuf(&wcharDebugOutput);
            std::wcerr.rdbuf(&wcharDebugOutput);
            std::wclog.rdbuf(&wcharDebugOutput);
        #endif
    #endif

    std::vector<std::string> args;
    for (int i = 1; i < argc; i++)
        args.push_back(std::string(argv[i]));

    RunTestsWithArgs(args);

    return 0;
}


#include <iostream>

//#include "assimp/Importer.hpp"
//#include "assimp/postprocess.h"
//#include "assimp/scene.h"
//#include "assimp/cimport.h"

#include <fbxsdk.h>
#include <iomanip>

#include <stdio.h>  /* defines FILENAME_MAX */
#ifdef WIN32
    #include <direct.h>
    #define __getcwd _getcwd
#else
    #include <unistd.h>
    #define __getcwd getcwd
#endif

#include "OutputDebugStringBuf.h"

using namespace std;

#include "common.h"
#include "Tests.h"

void LoadAndPrint(const char* filename);

template <typename T, size_t N>
size_t len(T(&arr)[N]) { return N; }

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

    if (argc > 1)
    {
        LoadAndPrint(argv[1]);
    }
    else
    {
        RunTests();
    }

    return 0;
}

void LoadAndPrint(const char* filename)
{
    FbxScene* scene = Load(filename);

    PrintObjectGraph(scene);
}

void Save(const char* filename, FbxScene* scene)
{
    FbxManager* manager = scene->GetFbxManager();

    FbxIOSettings* ios = FbxIOSettings::Create(manager, IOSROOT);
    ios->SetEnumProp(EXP_ASCIIFBX, 1);

    FbxExporter * ex = FbxExporter::Create(manager, "");

    ex->Initialize(filename, -1, ios);
    ex->Export(scene);
}

FbxScene* Load(const char* filename, FbxManager* manager)
{
    if (manager == NULL)
    {
        manager = FbxManager::Create();
    }

    char cwd[1024];
    __getcwd(cwd, 1024);
    cout << "Loading file " << quote(filename) << " from cwd " << quote(cwd) << "." << endl;

    FbxScene* pScene = FbxScene::Create(manager, "My Scene");

    int lFileMajor, lFileMinor, lFileRevision;
    int lSDKMajor,  lSDKMinor,  lSDKRevision;
    //int lFileFormat = -1;
    int i, lAnimStackCount;
    bool lStatus;
    char lPassword[1024];

    // Get the file version number generate by the FBX SDK.
    FbxManager::GetFileFormatVersion(lSDKMajor, lSDKMinor, lSDKRevision);

    // Create an importer.
    FbxImporter* lImporter = FbxImporter::Create(manager,"");

    // Initialize the importer by providing a filename.
    const bool lImportStatus = lImporter->Initialize(filename, -1, manager->GetIOSettings());
    lImporter->GetFileVersion(lFileMajor, lFileMinor, lFileRevision);

    if( !lImportStatus )
    {
        FBXSDK_printf("Call to FbxImporter::Initialize() failed.\n");
        FBXSDK_printf("Error returned: %s\n\n", lImporter->GetStatus().GetErrorString());

//        if (lImporter->GetLastErrorID() == FbxIOBase::eFileVersionNotSupportedYet ||
//            lImporter->GetLastErrorID() == FbxIOBase::eFileVersionNotSupportedAnymore)
//        {
            FBXSDK_printf("FBX file format version for this FBX SDK is %d.%d.%d\n", lSDKMajor, lSDKMinor, lSDKRevision);
            FBXSDK_printf("FBX file format version for file '%s' is %d.%d.%d\n\n", filename, lFileMajor, lFileMinor, lFileRevision);
//        }

        exit(-1);
    }

    lImporter->Import(pScene);

//    printf("file version info: %i.%i.%i\n", lFileMajor, lFileMinor, lFileRevision);

    return pScene;
}

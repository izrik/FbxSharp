
#include <iostream>

//#include "assimp/Importer.hpp"
//#include "assimp/postprocess.h"
//#include "assimp/scene.h"
//#include "assimp/cimport.h"

#include <fbxsdk.h>

using namespace std;

#include "common.h"

int main (int argc, char *argv[])
{
//    aiLogStream ailog;
//    ailog = aiGetPredefinedLogStream(aiDefaultLogStream_STDOUT,NULL);
//    aiAttachLogStream(&ailog);

//    Assimp::Importer importer;
//
    const char* filename = "model.fbx";
//    char dirname[1024];
//    getcwd(dirname, 1024);
//    cout << "current directory: " << dirname << endl;
//    cout << "Loading file with assimp" << endl;
//    const aiScene* scene = importer.ReadFile(
//        filename,
//        aiProcess_Triangulate | aiProcess_JoinIdenticalVertices);
//
//    cout << "file loaded" << endl;
//    bool hasAnimations = scene->HasAnimations();
//    cout << "..." << endl;
//    int numAnimations = scene->mNumAnimations;
//    cout << "..." << endl;
//    cout << numAnimations << " animations" << endl;









    cout << endl;

    cout << "Loading file with fbxsdk" << endl;
    




    FbxManager* pManager = FbxManager::Create();
    FbxScene* pScene = FbxScene::Create(pManager, "My Scene");

    int lFileMajor, lFileMinor, lFileRevision;
    int lSDKMajor,  lSDKMinor,  lSDKRevision;
    //int lFileFormat = -1;
    int i, lAnimStackCount;
    bool lStatus;
    char lPassword[1024];

    // Get the file version number generate by the FBX SDK.
    FbxManager::GetFileFormatVersion(lSDKMajor, lSDKMinor, lSDKRevision);

    // Create an importer.
    FbxImporter* lImporter = FbxImporter::Create(pManager,"");

    // Initialize the importer by providing a filename.
    const bool lImportStatus = lImporter->Initialize(filename, -1, pManager->GetIOSettings());
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

        return false;
    }

    lImporter->Import(pScene);

    printf("file version info: %i.%i.%i\n", lFileMajor, lFileMinor, lFileRevision);
    PrintObject(pScene);

//    // get the number of animation stacks
//    int numStacks = pScene->GetSrcObjectCount(FBX_TYPE(FbxAnimStack));
//    cout << "num stacks: " << numStacks << endl;
//    int n = 0;
//    // get the nth animation stack
//    FbxAnimStack* pAnimStack = FbxCast<FbxAnimStack>(pScene->GetSrcObject(FBX_TYPE(FbxAnimStack), n));
//    // get the number of animation layers
//    int numAnimLayers = pAnimStack->GetMemberCount(FBX_TYPE(FbxAnimLayer));
//    cout << "num layers: " << numAnimLayers << endl;
//    // get the nth animation layer
//    FbxAnimLayer* lAnimLayer = pAnimStack->GetMember(FBX_TYPE(FbxAnimLayer), n);

    return 0;
}


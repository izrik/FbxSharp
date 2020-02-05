
#include <iostream>
#include <string>
#include <fileio.h>
#include <print.h>

#include "explore.h"

void PrintUsage()
{
    std::cout << "fbxcppcli [COMMAND]" << std::endl <<
                 std::endl <<
                 "Available Commands" << std::endl <<
                 "    help                       Display this help text." << std::endl <<
                 "    info [FILENAME]            Display file info about FILENAME." << std::endl <<
                 "    print [FILENAME]           Display the contents of FILENAME." << std::endl <<
                 "    convert [SOURCE] [DEST]    Open the SOURCE file and then save it as ascii at DEST." << std::endl <<
                 "    unconvert [SOURCE] [DEST]  Open the SOURCE file and then save it as binary at DEST." << std::endl <<
                 "    explore [FILENAME]         Navigate a scene graph using a shell-like command interface." << std::endl <<
                 std::endl;
}

int main (int argc, const char *argv[])
{
    if (argc <= 1)
    {
        PrintUsage();
        return 0;
    }

    std::string command = argv[1];
    if (command == "help")
    {
        PrintUsage();
        return 0;
    }

    if (command == "info")
    {
        if (argc <= 2)
        {
            std::cout << "info: No filename provided." << std::endl;
            PrintUsage();
            return 2;
        }

        // Get the file version number generate by the FBX SDK.
        int lSDKMajor,  lSDKMinor,  lSDKRevision;
        FbxManager::GetFileFormatVersion(lSDKMajor, lSDKMinor, lSDKRevision);
        FBXSDK_printf("FBX file format version for this FBX SDK is %d.%d.%d\n", lSDKMajor, lSDKMinor, lSDKRevision);

        // Create an importer.
        FbxManager* manager = FbxManager::Create();
        FbxImporter* lImporter = FbxImporter::Create(manager, "");

        // Initialize the importer by providing a filename.
        std::string filename = argv[2];
        lImporter->Initialize(filename.c_str(), -1, manager->GetIOSettings());
        int lFileMajor, lFileMinor, lFileRevision;
        lImporter->GetFileVersion(lFileMajor, lFileMinor, lFileRevision);
        FBXSDK_printf("FBX file format version for file '%s' is %d.%d.%d\n", filename.c_str(), lFileMajor, lFileMinor, lFileRevision);
        FbxIOFileHeaderInfo* header = lImporter->GetFileHeaderInfo();
        FBXSDK_printf("mFileVersion -              %d\n", header->mFileVersion);
        FBXSDK_printf("mCreationTimeStampPresent - %d\n", header->mCreationTimeStampPresent);
        FBXSDK_printf("mCreationTimeStamp -        %s\n", ToString(header->mCreationTimeStamp).c_str());
        FBXSDK_printf("mCreator -                  %s\n", header->mCreator.Buffer());
        FBXSDK_printf("mIOPlugin -                 %d\n", header->mIOPlugin);
        FBXSDK_printf("mPLE -                      %d\n", header->mPLE);
        return 0;
    }

    if (command == "print")
    {
        if (argc <= 2)
        {
            std::cout << "print: No filename provided." << std::endl;
            PrintUsage();
            return 2;
        }

        std::string filename = argv[2];
        FbxScene* scene = Load(filename.c_str());
        PrintObjectGraph(scene);
        return 0;
    }

    if (command == "convert")
    {
        if (argc <= 2)
        {
            std::cout << "convert: No source filename provided." << std::endl;
            PrintUsage();
            return 2;
        }
        if (argc <= 3)
        {
            std::cout << "convert: No destination filename provided." << std::endl;
            PrintUsage();
            return 2;
        }

        std::string source = argv[2];
        FbxScene* scene = Load(source.c_str());
        std::string dest = argv[3];
        Save(dest.c_str(), scene, true);
        return 0;
    }

    if (command == "unconvert")
    {
        if (argc <= 2)
        {
            std::cout << "convert: No source filename provided." << std::endl;
            PrintUsage();
            return 2;
        }
        if (argc <= 3)
        {
            std::cout << "convert: No destination filename provided." << std::endl;
            PrintUsage();
            return 2;
        }

        std::string source = argv[2];
        FbxScene* scene = Load(source.c_str());
        std::string dest = argv[3];
        Save(dest.c_str(), scene, false);
        return 0;
    }

    if (command == "explore")
    {
        if (argc <= 2)
        {
            std::cout << "explore: No source filename provided." << std::endl;
            PrintUsage();
            return 2;
        }

        std::string filename = argv[2];
        FbxScene* scene = Load(filename.c_str());
        Explore(scene);
        return 0;
    }

    std::cout << "Unknown command \"" << command << "\"" << std::endl;
    PrintUsage();
    return 1;
}

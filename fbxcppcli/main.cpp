
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
                 "    convert [SOURCE] [DEST] [FORMAT] [VERSION]" <<
                 "                               Open the SOURCE file and then save it as the given FORMAT and VERSION." << std::endl <<
                 "        FORMAT                 One of \"6a\", \"6b\", \"7a\", \"7b\", that is, 6 or 7+, ascii or binary" << std::endl <<
                 "        VERSION                One of FBX200508_MB70, 2005, FBX200602_MB75, 2006.02, FBX200608, 2006.08," << std::endl <<
                 "                               FBX200611, 2006.11, FBX200900, 2009, FBX200900v7, 2009-v7, FBX201000, 2010, " << std::endl <<
                 "                               FBX201100, 2011, FBX201200, 2012, FBX201300, 2013, FBX201400, 2014," << std::endl <<
                 "                               FBX201600, 2016, FBX201800, 2018, FBX201900, 2019, FBX202000, 2020," << std::endl <<
                 "                               FBX53_MB55, 5.3, FBX60_MB60, 6.0" << std::endl <<
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
        if (argc <= 4)
        {
            std::cout << "convert: No format provided." << std::endl;
            PrintUsage();
            return 2;
        }
        if (argc <= 3)
        {
            std::cout << "convert: No format version provided." << std::endl;
            PrintUsage();
            return 2;
        }

        std::string source = argv[2];
        FbxScene* scene = Load(source.c_str());
        std::string dest = argv[3];

        std::string format = argv[4];

        if (format == "6a") {
            format = "FBX 6.0 ascii (*.fbx)";
        } else if (format == "6b") {
            format = "FBX 6.0 binary (*.fbx)";
        } else if (format == "7a") {
            format = "FBX ascii (*.fbx)";
        } else if (format == "7b") {
            format = "FBX binary (*.fbx)";
        } else {
            std::cout << "convert: Unknown FBX file format \"" << format << "\"" << std::endl;
            PrintUsage();
            return 2;
        }

        std::string version = argv[5];
        if (version == "FBX200508_MB70" || version == "2005") {
            version = "FBX200508_MB70";
        } else if (version == "FBX200602_MB75" || version == "2006.02") {
            version = "FBX200602_MB75";
        } else if (version == "FBX200608" || version == "2006.08") {
            version = "FBX200608";
        } else if (version == "FBX200611" || version == "2006.11") {
            version = "FBX200611";
        } else if (version == "FBX200900" || version == "2009") {
            version = "FBX200900";
        } else if (version == "FBX200900v7" || version == "2009-v7") {
            version = "FBX200900v7";
        } else if (version == "FBX201000" || version == "2010") {
            version = "FBX201000";
        } else if (version == "FBX201100" || version == "2011") {
            version = "FBX201100";
        } else if (version == "FBX201200" || version == "2012") {
            version = "FBX201200";
        } else if (version == "FBX201300" || version == "2013") {
            version = "FBX201300";
        } else if (version == "FBX201400" || version == "2014") {
            version = "FBX201400";
        } else if (version == "FBX201600" || version == "2016") {
            version = "FBX201600";
        } else if (version == "FBX201800" || version == "2018") {
            version = "FBX201800";
        } else if (version == "FBX201900" || version == "2019") {
            version = "FBX201900";
        } else if (version == "FBX202000" || version == "2020") {
            version = "FBX202000";
        } else if (version == "FBX53_MB55" || version == "5.3") {
            version = "FBX53_MB55";
        } else if (version == "FBX60_MB60" || version == "6.0") {
            version = "FBX60_MB60";
        } else {
            std::cout << "convert: Unknown FBX file format version \"" << version << "\"" << std::endl;
            PrintUsage();
            return 2;
        }

        Save(dest.c_str(), scene, format.c_str(), version.c_str());
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

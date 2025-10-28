#include <filesystem>
#include <iostream>
#include "Utils.h"

using namespace std;
namespace fs = std::filesystem;

std::string GetSample(const char* filename)
{
    fs::path file = __FILE__;
    fs::path current_folder = fs::current_path();
    int i;
    fs::path samples_folder;
    for (i = 0; i < 100; i++)
    {
        if (current_folder.filename() == "FbxSharp")
            break;
        current_folder = current_folder.parent_path();
        samples_folder = current_folder / "samples";
        if (fs::exists(samples_folder))
            break;
        if (current_folder == current_folder.root_path())
            return "";
    }
    fs::path desired_path = samples_folder.append(filename);
    return desired_path;
}

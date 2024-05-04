
#include "explore.h"
#include <string>
#include <iostream>
#include <vector>
#include <sstream>
#include <objects.h>
#include <print.h>

void Explore(FbxScene* scene)
{
    std::string prompt = ">>> ";

    FbxObject* obj = scene;
    while (true)
    {
        std::string s;
        std::cout << prompt;
        std::getline(std::cin, s);
        if (std::cin.eof())
        {
            std::cout << std::endl;
            break;
        }

        std::istringstream ss(s);
        std::vector<std::string> tokens;
        std::copy(std::istream_iterator<std::string>(ss),
                  std::istream_iterator<std::string>(),
                  std::back_inserter(tokens));

        if (tokens.size() < 1) continue;

        std::string command = tokens[0];
        if (command == "quit" || command == "exit") break;

        if (command == "help")
        {
        }
        else if (command == ".")
        {
            std::cout << "$"; PrintObjectID(obj); std::cout << std::endl;
        }
        else if (command == "print")
        {
            PrintObjectGraph(obj);
        }
        else if (command == "ls")
        {
            if (tokens.size() >= 2)
            {
                std::string& target = tokens[1];
                if (target == "src")
                {
                    int i;
                    for (i = 0; i < obj->GetSrcObjectCount(); i++)
                    {
                        FbxObject* srcObj = obj->GetSrcObject(i);
                        std::cout << "        #" << i << " ";
                        PrintObjectID(srcObj);
                        std::cout << std::endl;
                    }
                    continue;
                }
                else if (target == "dst")
                {
                    int i;
                    for (i = 0; i < obj->GetDstObjectCount(); i++)
                    {
                        FbxObject* srcObj = obj->GetDstObject(i);
                        std::cout << "        #" << i << " ";
                        PrintObjectID(srcObj);
                        std::cout << std::endl;
                    }
                    continue;
                }
                else if (target == "prop")
                {
                    FbxProperty prop = obj->GetFirstProperty();
                    int n = 0;
                    while (prop.IsValid())
                    {
                        std::cout << "        #" << n << " ";
                        PrintPropertyID(&prop); std::cout << std::endl;
                        n++;
                        prop = obj->GetNextProperty(prop);
                    }
                    continue;
                }
                else if (target == "time")
                {
                    FbxProperty prop = GetPropertyByIndex(obj, 4);
                    PrintProperty(&prop, false);
                    FbxTime t = prop.Get<FbxTime>();
                    std::cout << "    Raw value:           " << t.Get() << std::endl;
                    std::cout << "    Seconds:             " << t.GetSecondDouble() << std::endl;
                    std::cout << "    Second count:        " << t.GetSecondCount() << std::endl;
                    std::cout << "    Milliseconds:        " << t.GetMilliSeconds() << std::endl;
                    std::cout << "    Frame count:         " << t.GetFrameCount() << std::endl;
                    std::cout << "    Frame count precise: " << t.GetFrameCountPrecise() << std::endl;
                    std::cout << "    Field count:         " << t.GetFieldCount() << std::endl;
                    std::cout << "  Global time mode:      " << FbxTime::GetGlobalTimeMode() << std::endl;
                    std::cout << "  FBXSDK_TC_MILLISECOND: " << FBXSDK_TC_MILLISECOND << std::endl;
                    std::cout << "  FBXSDK_TC_SECOND:      " << FBXSDK_TC_SECOND << std::endl;
                    continue;
                }
                // sprop
                // dprop
                else
                {
                    std::cout << "Unknown target \"" << target << "\"" << std::endl;
                }
            }

            std::cout << "SrcObjects: " << obj->GetSrcObjectCount() << " (src)" << std::endl;
            std::cout << "DstObjects: " << obj->GetDstObjectCount() << " (dst)" << std::endl;
            std::cout << "Properties: " << CountProperties(obj) << " (prop)" << std::endl;
            std::cout << "SrcProperties: " << obj->GetSrcPropertyCount() << " (sprop)" << std::endl;
            std::cout << "DstProperties: " << obj->GetDstPropertyCount() << " (dprop)" << std::endl;
        }
        else if (command == "cd")
        {
            if (tokens.size() < 2)
            {
                std::cout << "Error: No target specified." << std::endl;
                continue;
            }
            if (tokens.size() < 3)
            {
                std::cout << "Error: Target index not specified." << std::endl;
                continue;
            }

            std::string& type = tokens[1];
            int maxindex;
            if (type == "src")
            {
                maxindex = obj->GetSrcObjectCount();
            }
            else if (type == "dst")
            {
                maxindex = obj->GetDstObjectCount();
            }
            else if (type != "prop")
            {
                std::cout << "Error: Unsupported target type \"" << type << "\"" << std::endl;
                continue;
            }
            else if (type != "sprop")
            {
                std::cout << "Error: Unsupported target type \"" << type << "\"" << std::endl;
                continue;
            }
            else if (type != "dprop")
            {
                std::cout << "Error: Unsupported target type \"" << type << "\"" << std::endl;
                continue;
            }
            else
            {
                std::cout << "Error: Unknown target type \"" << type << "\"" << std::endl;
                continue;
            }

            std::string& index_s = tokens[2];
            std::cout << "index_s: \"" << index_s << "\"" << std::endl;
            int index = std::stoi(index_s);
            if (index < 0 || index > maxindex)
            {
                std::cout << "Error: Index (" << index << ") out of range (" << maxindex << ")." << std::endl;
                continue;
            }

            FbxObject* next = nullptr;
            if (type == "src") next = obj->GetSrcObject(index);
            else if (type == "dst") next = obj->GetDstObject(index);

            if (next == nullptr)
            {
                std::cout << "Error: Could not get the object." << std::endl;
                continue;
            }

            obj = next;
            std::cout << "$"; PrintObjectID(obj); std::cout << std::endl;
            continue;
        }
        else
        {
            std::cout << "Unknwon command \"" << command << "\"" << std::endl;
        }
    }
}

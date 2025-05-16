
// Generate FBX files programmatically to test differences in file formats.

#include <iostream>
#include <cctype>
#include <vector>
#include <fbxsdk.h>
#include <fbxsdk/core/fbxdatatypes.h>

#include "../fbxcppcommon/objects.h"
#include "../fbxcppcommon/print.h"

using namespace std;

struct ProgramState
{
    FbxManager* manager;
    FbxScene* scene;

    ProgramState();
};

ProgramState::ProgramState()
{
    manager = FbxManager::Create();
    scene = FbxScene::Create(manager, "");
}

void print_object_properties(FbxObject* obj)
{
    FbxProperty prop = obj->GetFirstProperty();
    int n = 0;
    while (prop.IsValid())
    {
        std::cout << "      #" << n << " ";
        PrintPropertyID(&prop, true);
        cout << " = ";
        PrintPropertyValue(&prop);
        std::cout << std::endl;
        n++;
        prop = obj->GetNextProperty(prop);
    }
}

void print_io_settings(FbxIOSettings* settings)
{
    std::cout << "    SrcObjects: " << settings->GetSrcObjectCount() << " (src)" << std::endl;
    std::cout << "    DstObjects: " << settings->GetDstObjectCount() << " (dst)" << std::endl;
    std::cout << "    Properties: " << CountProperties(settings) << " (prop)" << std::endl;
    print_object_properties(settings);
    std::cout << "    SrcProperties: " << settings->GetSrcPropertyCount() << " (sprop)" << std::endl;
    std::cout << "    DstProperties: " << settings->GetDstPropertyCount() << " (dprop)" << std::endl;
    settings->WriteXMLFile("fbx_io_settings.xml");
}

void print_importer(FbxImporter* importer)
{
    cout << "  IsFBX: " << importer->IsFBX() << endl;
    cout << "  GetFileFormat: " << importer->GetFileFormat() << endl;
    cout << "  GetStatus: " << endl;
    cout << "    Error: " << importer->GetStatus().Error() << endl;
    cout << "    GetCode: " << importer->GetStatus().GetCode() << endl;
    cout << "    GetErrorString: " << importer->GetStatus().GetErrorString() << endl;
    cout << "  GetFileHeaderInfo: " << importer->GetFileHeaderInfo() << endl;
    cout << "    mDefaultRenderResolution: " << endl;
    cout << "      mIsOK: " << importer->GetFileHeaderInfo()->mDefaultRenderResolution.mIsOK << endl;
    cout << "      mCameraName: " << importer->GetFileHeaderInfo()->mDefaultRenderResolution.mCameraName << endl;
    cout << "      mResolutionMode: " << importer->GetFileHeaderInfo()->mDefaultRenderResolution.mResolutionMode << endl;
    cout << "      mResolutionW: " << importer->GetFileHeaderInfo()->mDefaultRenderResolution.mResolutionW << endl;
    cout << "      mResolutionH: " << importer->GetFileHeaderInfo()->mDefaultRenderResolution.mResolutionH << endl;
    cout << "    mBinary: " << importer->GetFileHeaderInfo()->mBinary << endl;
    cout << "    mFileVersion: " << importer->GetFileHeaderInfo()->mFileVersion << endl;
    cout << "    mCreationTimeStampPresent: " << importer->GetFileHeaderInfo()->mCreationTimeStampPresent << endl;
    cout << "    mCreationTimeStamp: " << endl;
    cout << "      mYear: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mYear << endl;
    cout << "      mMonth: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mMonth << endl;
    cout << "      mDay: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mDay << endl;
    cout << "      mHour: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mHour << endl;
    cout << "      mMinute: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mMinute << endl;
    cout << "      mSecond: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mSecond << endl;
    cout << "      mMillisecond: " << importer->GetFileHeaderInfo()->mCreationTimeStamp.mMillisecond << endl;
    cout << "    mCreator: " << importer->GetFileHeaderInfo()->mCreator << endl;
    cout << "    mIOPlugin: " << importer->GetFileHeaderInfo()->mIOPlugin << endl;
    cout << "    mPLE: " << importer->GetFileHeaderInfo()->mPLE << endl;
    cout << "  GetIOSettings: " << importer->GetIOSettings() << endl;
    if (importer->GetIOSettings() != NULL)
    {
        FbxIOSettings* settings = importer->GetIOSettings();
        print_io_settings(settings);
    }
}

void io_settings(ProgramState& state, vector<string>& args)
{
    string& filename = args[0];

    FbxImporter* importer = FbxImporter::Create(state.manager, "");
    FbxIOSettings* settings = FbxIOSettings::Create(state.manager, "");
    std::cout << "    SrcObjects: " << settings->GetSrcObjectCount() << " (src)" << std::endl;
    std::cout << "    DstObjects: " << settings->GetDstObjectCount() << " (dst)" << std::endl;
    std::cout << "    Properties: " << CountProperties(settings) << " (prop)" << std::endl;
    print_object_properties(settings);
    std::cout << "    SrcProperties: " << settings->GetSrcPropertyCount() << " (sprop)" << std::endl;
    std::cout << "    DstProperties: " << settings->GetDstPropertyCount() << " (dprop)" << std::endl;
}

void print_properties(ProgramState& state, vector<string>&) {
    // FbxNode* obj = FbxNode::Create(manager, "obj");
    // FbxProperty* visibility = &obj->Visibility;
    // FbxDataType dt = visibility->GetPropertyDataType();
    // auto prop1 = FbxProperty::Create(obj, dt, "x");
    // cout << "prop1: " << prop1.Get<double>() << endl;
    // prop1.Set(1.0);
    // cout << "prop1: " << prop1.Get<double>() << endl;
    // auto parent = FbxProperty::Create(obj, dt, "x");
    // bool was_found = false;
    // auto prop2 = FbxProperty::Create(obj, dt, "x", "", false, &was_found);
    // prop2.Set(2.0);

    // in C++, properties have identities. if you try to create another one with
    // the same name, it will have the same identity as the first; changing the
    // value of one will change the value of the other as well.
    // unless you set pCheckForDup to false, in which case they will have
    // separate identities.
    // a property's identity persists even though it gets returned from a
    // function as an object, and not as a pointer or reference.


    // cout << "prop1: " << prop1.GetName() << endl;
    // cout << "prop1: " << prop1.GetHierarchicalName() << endl;
    // cout << "prop1: " << prop1.Get<double>() << endl;
    // cout << "was_found: " << was_found << endl;
    // cout << "prop2: " << prop2.GetName() << endl;
    // cout << "prop2: " << prop2.GetHierarchicalName() << endl;
    // cout << "prop2: " << prop2.Get<double>() << endl;
    // cout << "prop1 == prop2: " << (prop1 == prop2) << endl;
    //
    // FbxProperty prop3 = prop2;
    // cout << "prop3: " << prop3.GetName() << endl;
    // cout << "prop3: " << prop3.GetHierarchicalName() << endl;
    // cout << "prop3: " << prop3.Get<double>() << endl;
    // cout << "prop2 == prop3: " << (prop2 == prop3) << endl;
    // prop3.Set(3.0);
    // cout << "prop2: " << prop2.Get<double>() << endl;
    // cout << "prop3: " << prop3.Get<double>() << endl;
}

void import_export(ProgramState& state, vector<string>&) {

    // ex:
    // create a SdkManager
    FbxImporter* importer = FbxImporter::Create(state.manager, "");

    // create an IOSettings object
    // FbxIOSettings* ios = NULL;
    FbxIOSettings* ios = FbxIOSettings::Create(state.manager, IOSROOT);
    // set some IOSettings options
    // ios->SetBoolProp(EXP_FBX_MATERIAL, true);
    // ios->SetBoolProp(EXP_FBX_TEXTURE,  true);

    // create an empty scene
    // create an exporter.
    int lFormat = -1;
    int format6a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 ascii (*.fbx)");
    int format6b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 binary (*.fbx)");
    int format7a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX ascii (*.fbx)");
    int format7b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX binary (*.fbx)");
    FbxExporter* exporter = FbxExporter::Create(state.manager, "");

    // exporter->Initialize("./empty_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./empty_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./empty_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./empty_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);






    
    // auto pr = lSdkManager->GetIOPluginRegistry();
    // int n = pr->GetReaderFormatCount();
    // cout << "reader formats: " << n << endl;
    // cout << "native reader format: " << pr->GetNativeReaderFormat() << endl;
    // int i;
    // for (i=0;i<n;i++)
    // {
    //     cout << "  " << i << " " << pr->GetReaderFormatDescription(i) << endl;
    //     cout << "    " << "ext: " << pr->GetReaderFormatExtension(i) << endl;
    //     cout << "    " << "IsFBX: " << pr->ReaderIsFBX(i) << endl;
    //     cout << "    " << "IsGenuine: " << pr->ReaderIsGenuine(i) << endl;
    // }
    // cout << "writer formats: " << lSdkManager->GetIOPluginRegistry()->GetReaderFormatCount() << endl;
    // cout << "native writer format: " << pr->GetNativeWriterFormat() << endl;
    // for (i=0;i<n;i++)
    // {
    //     cout << "  " << i << " " << pr->GetWriterFormatDescription(i) << endl;
    //     cout << "    " << "ext: " << pr->GetWriterFormatExtension(i) << endl;
    //     cout << "    " << "IsFBX: " << pr->WriterIsFBX(i) << endl;
    //     cout << "    " << "IsGenuine: " << pr->WriterIsGenuine(i) << endl;
    //     cout << "    " << "Writable versions: " << endl;
    //     auto cc = pr->GetWritableVersions(i);
    //     while (cc != 0)
    //     {
    //         auto c = *cc;
    //         if (c == 0)
    //             break;
    //         cout << "      " << c << endl;
    //         cc++;
    //     }
    // }
    
    
    
    
    
    
    // cout << "Current writable versions: " << endl;
    // exporter->Initialize("current_writable_version_7b.fbx", format7b, ios);
    // auto cc = exporter->GetCurrentWritableVersions();
    // while (cc != 0)
    // {
    //     auto c = *cc;
    //     if (c == 0)
    //         break;
    //     cc++;
    //     cout << "  " << c << endl;
    // }





    
    // FbxProperty prop = ios->GetProperty(EXP_FBX_EXPORT_FILE_VERSION);
    // int n = prop.GetEnumCount();
    // cout << "EXP_FBX_EXPORT_FILE_VERSION enum count: " << n << endl;
    // int i;
    // for (i=0;i<n;i++)
    // {
    //     // prop.Set<int>(i);
    //     std::string value = prop.GetEnumValue(i);
    //     std::string filename = "./empty_";
    //     filename.append(value);
    //     std::string filename2 = filename;
    //     cout << "  " << i << ": " << value << endl;
    //     filename.append("_7a.fbx");
    //     filename2.append("_7b.fbx");
    //     exporter->Initialize(filename.c_str(), format7a, ios);
    //     exporter->SetFileExportVersion(FbxString(value.c_str()));
    //     cout << "    current property value (a): " << prop.Get<int>() << endl;
    //     exporter->Export(state.scene);
    //     exporter->Initialize(filename2.c_str(), format7b, ios);
    //     exporter->SetFileExportVersion(FbxString(value.c_str()));
    //     cout << "    current property value (b): " << prop.Get<int>() << endl;
    //     exporter->Export(state.scene);
    // }


    std::string filename73b = "../samples/pirate_20240610_73b.fbx";
    std::string filename77a = "../samples/pirate_20240610_77a.fbx";
    std::string filename77b = "../samples/pirate_20240610_77b.fbx";
    cout << "Initializing \"" << filename73b << "\"... ";
    importer->Initialize(filename73b.c_str(), -1, ios);
    cout << "done." << endl;
    print_importer(importer);
    cout << "Importing \"" << filename73b << "\"... ";
    importer->Import(state.scene);
    cout << "done." << endl;
    print_importer(importer);
    // cout << "Writing \"" << filename77a << "\"... ";
    // exporter->Initialize(filename77a.c_str(), format7a, ios);
    // exporter->Export(state.scene);
    // cout << "done." << endl;
    // cout << "Writing \"" << filename77b << "\"... ";
    // exporter->Initialize(filename77b.c_str(), format7b, ios);
    // exporter->Export(state.scene);
    // cout << "done." << endl;


    


    

    
    // FbxDocumentInfo* docinfo = state.scene->GetDocumentInfo();
    // FbxProperty prop = FbxProperty::Create(docinfo, FbxStringDT, "CustomProp");

    // prop.Set(FbxString("A"));
    // auto x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    //
    // prop.Set(FbxString("A"));
    // auto x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("./custom_sceneinfo_property_7a_1.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_7b_1.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_6a_1.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_6b_1.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("AB"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("./custom_sceneinfo_property_7a_2.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_7b_2.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_6a_2.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_6b_2.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("ABC"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("./custom_sceneinfo_property_7a_3.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_7b_3.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_6a_3.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("./custom_sceneinfo_property_6b_3.fbx", format6b, ios);
    // exporter->Export(state.scene);


    
    // prop.Set(FbxString("Abc::Def"));
    // auto x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_1_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_1_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_1_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_1_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("Abc::Def::Ghi"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_2_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_2_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_2_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_2_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("Abc::Def::Ghi::Jkl"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_3_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_3_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_3_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_3_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("Abc::Def::Ghi::Jkl::Mno"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_4_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_4_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_4_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_4_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);

    // destroy the exporter
    exporter->Destroy();

}



string format_sample_filename(string basename, string formatbase)
{
    string rv = basename + "_" + formatbase + ".fbx";
    return rv;
} 

void export_all_formats(ProgramState& state, vector<string>& args)
{
    auto filename_prefix = args[0];

    FbxImporter* importer = FbxImporter::Create(state.manager, "");
    FbxIOSettings* ios = FbxIOSettings::Create(state.manager, IOSROOT);
    int format6a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 ascii (*.fbx)");
    int format6b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 binary (*.fbx)");
    int format7a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX ascii (*.fbx)");
    int format7b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX binary (*.fbx)");
    FbxExporter* exporter = FbxExporter::Create(state.manager, "");

    auto filename0 = format_sample_filename(filename_prefix, "7a");
    auto filename = FbxString(filename0.c_str());
    exporter->Initialize(filename, format7a, ios);
    exporter->Export(state.scene);

    filename0 = format_sample_filename(filename_prefix, "7b");
    filename = FbxString(filename0.c_str());
    exporter->Initialize(filename, format7b, ios);
    exporter->Export(state.scene);

    filename0 = format_sample_filename(filename_prefix, "61");
    filename = FbxString(filename0.c_str());
    exporter->Initialize(filename, format6a, ios);
    exporter->Export(state.scene);

    filename0 = format_sample_filename(filename_prefix, "6b");
    filename = FbxString(filename0.c_str());
    exporter->Initialize(filename, format6b, ios);
    exporter->Export(state.scene);



    // prop.Set(FbxString("Abc::Def::Ghi"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_2_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_2_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_2_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_2_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("Abc::Def::Ghi::Jkl"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_3_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_3_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_3_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_3_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);
    //
    // prop.Set(FbxString("Abc::Def::Ghi::Jkl::Mno"));
    // x = prop.Get<FbxString>();
    // cout << "CustomProp: " << x << endl;
    // exporter->Initialize("../samples/hierarchy_string_4_7a.fbx", format7a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_4_7b.fbx", format7b, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_4_6a.fbx", format6a, ios);
    // exporter->Export(state.scene);
    // exporter->Initialize("../samples/hierarchy_string_4_6b.fbx", format6b, ios);
    // exporter->Export(state.scene);

    // destroy the exporter
    exporter->Destroy();

}





string format_sample_filename(string basename, string formatbase, FbxString& formatname)
{
    string rv = basename + "_" + formatbase + "_" + string(formatname) + ".fbx";
    return rv;
} 

void export_all_version_variants(ProgramState& state, vector<string>& args)
{
    auto filename_prefix = args[0];

    auto ios = FbxIOSettings::Create(state.manager, IOSROOT);
    auto exporter = FbxExporter::Create(state.manager, "");

    int format6a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 ascii (*.fbx)");
    int format6b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 binary (*.fbx)");
    int format7a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX ascii (*.fbx)");
    int format7b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX binary (*.fbx)");

    auto formatnames = vector<char*>{
        FBX_53_MB55_COMPATIBLE,
        FBX_60_COMPATIBLE,
        FBX_2005_08_COMPATIBLE,
        FBX_2006_02_COMPATIBLE,
        FBX_2006_08_COMPATIBLE,
        FBX_2006_11_COMPATIBLE,
        FBX_2009_00_COMPATIBLE,
        FBX_2009_00_V7_COMPATIBLE,
        FBX_2010_00_COMPATIBLE,
        FBX_2011_00_COMPATIBLE,
        FBX_2012_00_COMPATIBLE,
        FBX_2013_00_COMPATIBLE,
        FBX_2014_00_COMPATIBLE,
        FBX_2016_00_COMPATIBLE,
        FBX_2018_00_COMPATIBLE,
        FBX_2019_00_COMPATIBLE,
        FBX_2020_00_COMPATIBLE,
    };

    for (auto _formatname = formatnames.begin(); _formatname != formatnames.end(); _formatname++)
    {
        auto formatname = FbxString(*_formatname);
        auto filename0 = format_sample_filename(filename_prefix, "7a", formatname);
        auto filename = FbxString(filename0.c_str());
        exporter->Initialize(filename, format7a, ios);
        exporter->SetFileExportVersion(formatname);
        exporter->Export(state.scene);

        filename0 = format_sample_filename(filename_prefix, "7b", formatname);
        filename = FbxString(filename0.c_str());
        exporter->Initialize(filename, format7b, ios);
        exporter->SetFileExportVersion(formatname);
        exporter->Export(state.scene);

        filename0 = format_sample_filename(filename_prefix, "6a", formatname);
        filename = FbxString(filename0.c_str());
        exporter->Initialize(filename, format6a, ios);
        exporter->SetFileExportVersion(formatname);
        exporter->Export(state.scene);

        filename0 = format_sample_filename(filename_prefix, "6b", formatname);
        filename = FbxString(filename0.c_str());
        exporter->Initialize(filename, format6b, ios);
        exporter->SetFileExportVersion(formatname);
        exporter->Export(state.scene);
    }
}

void print_data_types_yaml(ProgramState& state, vector<string>&)
{
    cout << "- ident: FbxUndefinedDT" << endl;
    cout << "  type: " << FbxUndefinedDT.GetType() << endl;
    cout << "  name: " << FbxUndefinedDT.GetName() << endl;
    cout << "- ident: FbxBoolDT" << endl;
    cout << "  type: " << FbxBoolDT.GetType() << endl;
    cout << "  name: " << FbxBoolDT.GetName() << endl;
    cout << "- ident: FbxCharDT" << endl;
    cout << "  type: " << FbxCharDT.GetType() << endl;
    cout << "  name: " << FbxCharDT.GetName() << endl;
    cout << "- ident: FbxUCharDT" << endl;
    cout << "  type: " << FbxUCharDT.GetType() << endl;
    cout << "  name: " << FbxUCharDT.GetName() << endl;
    cout << "- ident: FbxShortDT" << endl;
    cout << "  type: " << FbxShortDT.GetType() << endl;
    cout << "  name: " << FbxShortDT.GetName() << endl;
    cout << "- ident: FbxUShortDT" << endl;
    cout << "  type: " << FbxUShortDT.GetType() << endl;
    cout << "  name: " << FbxUShortDT.GetName() << endl;
    cout << "- ident: FbxIntDT" << endl;
    cout << "  type: " << FbxIntDT.GetType() << endl;
    cout << "  name: " << FbxIntDT.GetName() << endl;
    cout << "- ident: FbxUIntDT" << endl;
    cout << "  type: " << FbxUIntDT.GetType() << endl;
    cout << "  name: " << FbxUIntDT.GetName() << endl;
    cout << "- ident: FbxLongLongDT" << endl;
    cout << "  type: " << FbxLongLongDT.GetType() << endl;
    cout << "  name: " << FbxLongLongDT.GetName() << endl;
    cout << "- ident: FbxULongLongDT" << endl;
    cout << "  type: " << FbxULongLongDT.GetType() << endl;
    cout << "  name: " << FbxULongLongDT.GetName() << endl;
    cout << "- ident: FbxFloatDT" << endl;
    cout << "  type: " << FbxFloatDT.GetType() << endl;
    cout << "  name: " << FbxFloatDT.GetName() << endl;
    cout << "- ident: FbxHalfFloatDT" << endl;
    cout << "  type: " << FbxHalfFloatDT.GetType() << endl;
    cout << "  name: " << FbxHalfFloatDT.GetName() << endl;
    cout << "- ident: FbxDoubleDT" << endl;
    cout << "  type: " << FbxDoubleDT.GetType() << endl;
    cout << "  name: " << FbxDoubleDT.GetName() << endl;
    cout << "- ident: FbxDouble2DT" << endl;
    cout << "  type: " << FbxDouble2DT.GetType() << endl;
    cout << "  name: " << FbxDouble2DT.GetName() << endl;
    cout << "- ident: FbxDouble3DT" << endl;
    cout << "  type: " << FbxDouble3DT.GetType() << endl;
    cout << "  name: " << FbxDouble3DT.GetName() << endl;
    cout << "- ident: FbxDouble4DT" << endl;
    cout << "  type: " << FbxDouble4DT.GetType() << endl;
    cout << "  name: " << FbxDouble4DT.GetName() << endl;
    cout << "- ident: FbxDouble4x4DT" << endl;
    cout << "  type: " << FbxDouble4x4DT.GetType() << endl;
    cout << "  name: " << FbxDouble4x4DT.GetName() << endl;
    cout << "- ident: FbxEnumDT" << endl;
    cout << "  type: " << FbxEnumDT.GetType() << endl;
    cout << "  name: " << FbxEnumDT.GetName() << endl;
    cout << "- ident: FbxStringDT" << endl;
    cout << "  type: " << FbxStringDT.GetType() << endl;
    cout << "  name: " << FbxStringDT.GetName() << endl;
    cout << "- ident: FbxTimeDT" << endl;
    cout << "  type: " << FbxTimeDT.GetType() << endl;
    cout << "  name: " << FbxTimeDT.GetName() << endl;
    cout << "- ident: FbxReferenceDT" << endl;
    cout << "  type: " << FbxReferenceDT.GetType() << endl;
    cout << "  name: " << FbxReferenceDT.GetName() << endl;
    cout << "- ident: FbxBlobDT" << endl;
    cout << "  type: " << FbxBlobDT.GetType() << endl;
    cout << "  name: " << FbxBlobDT.GetName() << endl;
    cout << "- ident: FbxDistanceDT" << endl;
    cout << "  type: " << FbxDistanceDT.GetType() << endl;
    cout << "  name: " << FbxDistanceDT.GetName() << endl;
    cout << "- ident: FbxDateTimeDT" << endl;
    cout << "  type: " << FbxDateTimeDT.GetType() << endl;
    cout << "  name: " << FbxDateTimeDT.GetName() << endl;
    cout << "- ident: FbxColor3DT" << endl;
    cout << "  type: " << FbxColor3DT.GetType() << endl;
    cout << "  name: " << FbxColor3DT.GetName() << endl;
    cout << "- ident: FbxColor4DT" << endl;
    cout << "  type: " << FbxColor4DT.GetType() << endl;
    cout << "  name: " << FbxColor4DT.GetName() << endl;
    cout << "- ident: FbxCompoundDT" << endl;
    cout << "  type: " << FbxCompoundDT.GetType() << endl;
    cout << "  name: " << FbxCompoundDT.GetName() << endl;
    cout << "- ident: FbxReferenceObjectDT" << endl;
    cout << "  type: " << FbxReferenceObjectDT.GetType() << endl;
    cout << "  name: " << FbxReferenceObjectDT.GetName() << endl;
    cout << "- ident: FbxReferencePropertyDT" << endl;
    cout << "  type: " << FbxReferencePropertyDT.GetType() << endl;
    cout << "  name: " << FbxReferencePropertyDT.GetName() << endl;
    cout << "- ident: FbxVisibilityDT" << endl;
    cout << "  type: " << FbxVisibilityDT.GetType() << endl;
    cout << "  name: " << FbxVisibilityDT.GetName() << endl;
    cout << "- ident: FbxVisibilityInheritanceDT" << endl;
    cout << "  type: " << FbxVisibilityInheritanceDT.GetType() << endl;
    cout << "  name: " << FbxVisibilityInheritanceDT.GetName() << endl;
    cout << "- ident: FbxUrlDT" << endl;
    cout << "  type: " << FbxUrlDT.GetType() << endl;
    cout << "  name: " << FbxUrlDT.GetName() << endl;
    cout << "- ident: FbxXRefUrlDT" << endl;
    cout << "  type: " << FbxXRefUrlDT.GetType() << endl;
    cout << "  name: " << FbxXRefUrlDT.GetName() << endl;
    cout << "- ident: FbxTranslationDT" << endl;
    cout << "  type: " << FbxTranslationDT.GetType() << endl;
    cout << "  name: " << FbxTranslationDT.GetName() << endl;
    cout << "- ident: FbxRotationDT" << endl;
    cout << "  type: " << FbxRotationDT.GetType() << endl;
    cout << "  name: " << FbxRotationDT.GetName() << endl;
    cout << "- ident: FbxScalingDT" << endl;
    cout << "  type: " << FbxScalingDT.GetType() << endl;
    cout << "  name: " << FbxScalingDT.GetName() << endl;
    cout << "- ident: FbxQuaternionDT" << endl;
    cout << "  type: " << FbxQuaternionDT.GetType() << endl;
    cout << "  name: " << FbxQuaternionDT.GetName() << endl;
    cout << "- ident: FbxLocalTranslationDT" << endl;
    cout << "  type: " << FbxLocalTranslationDT.GetType() << endl;
    cout << "  name: " << FbxLocalTranslationDT.GetName() << endl;
    cout << "- ident: FbxLocalRotationDT" << endl;
    cout << "  type: " << FbxLocalRotationDT.GetType() << endl;
    cout << "  name: " << FbxLocalRotationDT.GetName() << endl;
    cout << "- ident: FbxLocalScalingDT" << endl;
    cout << "  type: " << FbxLocalScalingDT.GetType() << endl;
    cout << "  name: " << FbxLocalScalingDT.GetName() << endl;
    cout << "- ident: FbxLocalQuaternionDT" << endl;
    cout << "  type: " << FbxLocalQuaternionDT.GetType() << endl;
    cout << "  name: " << FbxLocalQuaternionDT.GetName() << endl;
    cout << "- ident: FbxTransformMatrixDT" << endl;
    cout << "  type: " << FbxTransformMatrixDT.GetType() << endl;
    cout << "  name: " << FbxTransformMatrixDT.GetName() << endl;
    cout << "- ident: FbxTranslationMatrixDT" << endl;
    cout << "  type: " << FbxTranslationMatrixDT.GetType() << endl;
    cout << "  name: " << FbxTranslationMatrixDT.GetName() << endl;
    cout << "- ident: FbxRotationMatrixDT" << endl;
    cout << "  type: " << FbxRotationMatrixDT.GetType() << endl;
    cout << "  name: " << FbxRotationMatrixDT.GetName() << endl;
    cout << "- ident: FbxScalingMatrixDT" << endl;
    cout << "  type: " << FbxScalingMatrixDT.GetType() << endl;
    cout << "  name: " << FbxScalingMatrixDT.GetName() << endl;
    cout << "- ident: FbxMaterialEmissiveDT" << endl;
    cout << "  type: " << FbxMaterialEmissiveDT.GetType() << endl;
    cout << "  name: " << FbxMaterialEmissiveDT.GetName() << endl;
    cout << "- ident: FbxMaterialEmissiveFactorDT" << endl;
    cout << "  type: " << FbxMaterialEmissiveFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialEmissiveFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialAmbientDT" << endl;
    cout << "  type: " << FbxMaterialAmbientDT.GetType() << endl;
    cout << "  name: " << FbxMaterialAmbientDT.GetName() << endl;
    cout << "- ident: FbxMaterialAmbientFactorDT" << endl;
    cout << "  type: " << FbxMaterialAmbientFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialAmbientFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialDiffuseDT" << endl;
    cout << "  type: " << FbxMaterialDiffuseDT.GetType() << endl;
    cout << "  name: " << FbxMaterialDiffuseDT.GetName() << endl;
    cout << "- ident: FbxMaterialDiffuseFactorDT" << endl;
    cout << "  type: " << FbxMaterialDiffuseFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialDiffuseFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialBumpDT" << endl;
    cout << "  type: " << FbxMaterialBumpDT.GetType() << endl;
    cout << "  name: " << FbxMaterialBumpDT.GetName() << endl;
    cout << "- ident: FbxMaterialNormalMapDT" << endl;
    cout << "  type: " << FbxMaterialNormalMapDT.GetType() << endl;
    cout << "  name: " << FbxMaterialNormalMapDT.GetName() << endl;
    cout << "- ident: FbxMaterialTransparentColorDT" << endl;
    cout << "  type: " << FbxMaterialTransparentColorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialTransparentColorDT.GetName() << endl;
    cout << "- ident: FbxMaterialTransparencyFactorDT" << endl;
    cout << "  type: " << FbxMaterialTransparencyFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialTransparencyFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialSpecularDT" << endl;
    cout << "  type: " << FbxMaterialSpecularDT.GetType() << endl;
    cout << "  name: " << FbxMaterialSpecularDT.GetName() << endl;
    cout << "- ident: FbxMaterialSpecularFactorDT" << endl;
    cout << "  type: " << FbxMaterialSpecularFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialSpecularFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialShininessDT" << endl;
    cout << "  type: " << FbxMaterialShininessDT.GetType() << endl;
    cout << "  name: " << FbxMaterialShininessDT.GetName() << endl;
    cout << "- ident: FbxMaterialReflectionDT" << endl;
    cout << "  type: " << FbxMaterialReflectionDT.GetType() << endl;
    cout << "  name: " << FbxMaterialReflectionDT.GetName() << endl;
    cout << "- ident: FbxMaterialReflectionFactorDT" << endl;
    cout << "  type: " << FbxMaterialReflectionFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialReflectionFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialDisplacementDT" << endl;
    cout << "  type: " << FbxMaterialDisplacementDT.GetType() << endl;
    cout << "  name: " << FbxMaterialDisplacementDT.GetName() << endl;
    cout << "- ident: FbxMaterialVectorDisplacementDT" << endl;
    cout << "  type: " << FbxMaterialVectorDisplacementDT.GetType() << endl;
    cout << "  name: " << FbxMaterialVectorDisplacementDT.GetName() << endl;
    cout << "- ident: FbxMaterialCommonFactorDT" << endl;
    cout << "  type: " << FbxMaterialCommonFactorDT.GetType() << endl;
    cout << "  name: " << FbxMaterialCommonFactorDT.GetName() << endl;
    cout << "- ident: FbxMaterialCommonTextureDT" << endl;
    cout << "  type: " << FbxMaterialCommonTextureDT.GetType() << endl;
    cout << "  name: " << FbxMaterialCommonTextureDT.GetName() << endl;
    cout << "- ident: FbxLayerElementUndefinedDT" << endl;
    cout << "  type: " << FbxLayerElementUndefinedDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementUndefinedDT.GetName() << endl;
    cout << "- ident: FbxLayerElementNormalDT" << endl;
    cout << "  type: " << FbxLayerElementNormalDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementNormalDT.GetName() << endl;
    cout << "- ident: FbxLayerElementBinormalDT" << endl;
    cout << "  type: " << FbxLayerElementBinormalDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementBinormalDT.GetName() << endl;
    cout << "- ident: FbxLayerElementTangentDT" << endl;
    cout << "  type: " << FbxLayerElementTangentDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementTangentDT.GetName() << endl;
    cout << "- ident: FbxLayerElementMaterialDT" << endl;
    cout << "  type: " << FbxLayerElementMaterialDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementMaterialDT.GetName() << endl;
    cout << "- ident: FbxLayerElementTextureDT" << endl;
    cout << "  type: " << FbxLayerElementTextureDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementTextureDT.GetName() << endl;
    cout << "- ident: FbxLayerElementPolygonGroupDT" << endl;
    cout << "  type: " << FbxLayerElementPolygonGroupDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementPolygonGroupDT.GetName() << endl;
    cout << "- ident: FbxLayerElementUVDT" << endl;
    cout << "  type: " << FbxLayerElementUVDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementUVDT.GetName() << endl;
    cout << "- ident: FbxLayerElementVertexColorDT" << endl;
    cout << "  type: " << FbxLayerElementVertexColorDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementVertexColorDT.GetName() << endl;
    cout << "- ident: FbxLayerElementSmoothingDT" << endl;
    cout << "  type: " << FbxLayerElementSmoothingDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementSmoothingDT.GetName() << endl;
    cout << "- ident: FbxLayerElementCreaseDT" << endl;
    cout << "  type: " << FbxLayerElementCreaseDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementCreaseDT.GetName() << endl;
    cout << "- ident: FbxLayerElementHoleDT" << endl;
    cout << "  type: " << FbxLayerElementHoleDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementHoleDT.GetName() << endl;
    cout << "- ident: FbxLayerElementUserDataDT" << endl;
    cout << "  type: " << FbxLayerElementUserDataDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementUserDataDT.GetName() << endl;
    cout << "- ident: FbxLayerElementVisibilityDT" << endl;
    cout << "  type: " << FbxLayerElementVisibilityDT.GetType() << endl;
    cout << "  name: " << FbxLayerElementVisibilityDT.GetName() << endl;
    cout << "- ident: FbxAliasDT" << endl;
    cout << "  type: " << FbxAliasDT.GetType() << endl;
    cout << "  name: " << FbxAliasDT.GetName() << endl;
    cout << "- ident: FbxPresetsDT" << endl;
    cout << "  type: " << FbxPresetsDT.GetType() << endl;
    cout << "  name: " << FbxPresetsDT.GetName() << endl;
    cout << "- ident: FbxStatisticsDT" << endl;
    cout << "  type: " << FbxStatisticsDT.GetType() << endl;
    cout << "  name: " << FbxStatisticsDT.GetName() << endl;
    cout << "- ident: FbxTextLineDT" << endl;
    cout << "  type: " << FbxTextLineDT.GetType() << endl;
    cout << "  name: " << FbxTextLineDT.GetName() << endl;
    cout << "- ident: FbxUnitsDT" << endl;
    cout << "  type: " << FbxUnitsDT.GetType() << endl;
    cout << "  name: " << FbxUnitsDT.GetName() << endl;
    cout << "- ident: FbxWarningDT" << endl;
    cout << "  type: " << FbxWarningDT.GetType() << endl;
    cout << "  name: " << FbxWarningDT.GetName() << endl;
    cout << "- ident: FbxWebDT" << endl;
    cout << "  type: " << FbxWebDT.GetType() << endl;
    cout << "  name: " << FbxWebDT.GetName() << endl;
    cout << "- ident: FbxActionDT" << endl;
    cout << "  type: " << FbxActionDT.GetType() << endl;
    cout << "  name: " << FbxActionDT.GetName() << endl;
    cout << "- ident: FbxCameraIndexDT" << endl;
    cout << "  type: " << FbxCameraIndexDT.GetType() << endl;
    cout << "  name: " << FbxCameraIndexDT.GetName() << endl;
    cout << "- ident: FbxCharPtrDT" << endl;
    cout << "  type: " << FbxCharPtrDT.GetType() << endl;
    cout << "  name: " << FbxCharPtrDT.GetName() << endl;
    cout << "- ident: FbxConeAngleDT" << endl;
    cout << "  type: " << FbxConeAngleDT.GetType() << endl;
    cout << "  name: " << FbxConeAngleDT.GetName() << endl;
    cout << "- ident: FbxEventDT" << endl;
    cout << "  type: " << FbxEventDT.GetType() << endl;
    cout << "  name: " << FbxEventDT.GetName() << endl;
    cout << "- ident: FbxFieldOfViewDT" << endl;
    cout << "  type: " << FbxFieldOfViewDT.GetType() << endl;
    cout << "  name: " << FbxFieldOfViewDT.GetName() << endl;
    cout << "- ident: FbxFieldOfViewXDT" << endl;
    cout << "  type: " << FbxFieldOfViewXDT.GetType() << endl;
    cout << "  name: " << FbxFieldOfViewXDT.GetName() << endl;
    cout << "- ident: FbxFieldOfViewYDT" << endl;
    cout << "  type: " << FbxFieldOfViewYDT.GetType() << endl;
    cout << "  name: " << FbxFieldOfViewYDT.GetName() << endl;
    cout << "- ident: FbxFogDT" << endl;
    cout << "  type: " << FbxFogDT.GetType() << endl;
    cout << "  name: " << FbxFogDT.GetName() << endl;
    cout << "- ident: FbxHSBDT" << endl;
    cout << "  type: " << FbxHSBDT.GetType() << endl;
    cout << "  name: " << FbxHSBDT.GetName() << endl;
    cout << "- ident: FbxIKReachTranslationDT" << endl;
    cout << "  type: " << FbxIKReachTranslationDT.GetType() << endl;
    cout << "  name: " << FbxIKReachTranslationDT.GetName() << endl;
    cout << "- ident: FbxIKReachRotationDT" << endl;
    cout << "  type: " << FbxIKReachRotationDT.GetType() << endl;
    cout << "  name: " << FbxIKReachRotationDT.GetName() << endl;
    cout << "- ident: FbxIntensityDT" << endl;
    cout << "  type: " << FbxIntensityDT.GetType() << endl;
    cout << "  name: " << FbxIntensityDT.GetName() << endl;
    cout << "- ident: FbxLookAtDT" << endl;
    cout << "  type: " << FbxLookAtDT.GetType() << endl;
    cout << "  name: " << FbxLookAtDT.GetName() << endl;
    cout << "- ident: FbxOcclusionDT" << endl;
    cout << "  type: " << FbxOcclusionDT.GetType() << endl;
    cout << "  name: " << FbxOcclusionDT.GetName() << endl;
    cout << "- ident: FbxOpticalCenterXDT" << endl;
    cout << "  type: " << FbxOpticalCenterXDT.GetType() << endl;
    cout << "  name: " << FbxOpticalCenterXDT.GetName() << endl;
    cout << "- ident: FbxOpticalCenterYDT" << endl;
    cout << "  type: " << FbxOpticalCenterYDT.GetType() << endl;
    cout << "  name: " << FbxOpticalCenterYDT.GetName() << endl;
    cout << "- ident: FbxOrientationDT" << endl;
    cout << "  type: " << FbxOrientationDT.GetType() << endl;
    cout << "  name: " << FbxOrientationDT.GetName() << endl;
    cout << "- ident: FbxRealDT" << endl;
    cout << "  type: " << FbxRealDT.GetType() << endl;
    cout << "  name: " << FbxRealDT.GetName() << endl;
    cout << "- ident: FbxRollDT" << endl;
    cout << "  type: " << FbxRollDT.GetType() << endl;
    cout << "  name: " << FbxRollDT.GetName() << endl;
    cout << "- ident: FbxScalingUVDT" << endl;
    cout << "  type: " << FbxScalingUVDT.GetType() << endl;
    cout << "  name: " << FbxScalingUVDT.GetName() << endl;
    cout << "- ident: FbxShapeDT" << endl;
    cout << "  type: " << FbxShapeDT.GetType() << endl;
    cout << "  name: " << FbxShapeDT.GetName() << endl;
    cout << "- ident: FbxStringListDT" << endl;
    cout << "  type: " << FbxStringListDT.GetType() << endl;
    cout << "  name: " << FbxStringListDT.GetName() << endl;
    cout << "- ident: FbxTextureRotationDT" << endl;
    cout << "  type: " << FbxTextureRotationDT.GetType() << endl;
    cout << "  name: " << FbxTextureRotationDT.GetName() << endl;
    cout << "- ident: FbxTimeCodeDT" << endl;
    cout << "  type: " << FbxTimeCodeDT.GetType() << endl;
    cout << "  name: " << FbxTimeCodeDT.GetName() << endl;
    cout << "- ident: FbxTimeWarpDT" << endl;
    cout << "  type: " << FbxTimeWarpDT.GetType() << endl;
    cout << "  name: " << FbxTimeWarpDT.GetName() << endl;
    cout << "- ident: FbxTranslationUVDT" << endl;
    cout << "  type: " << FbxTranslationUVDT.GetType() << endl;
    cout << "  name: " << FbxTranslationUVDT.GetName() << endl;
    cout << "- ident: FbxWeightDT" << endl;
    cout << "  type: " << FbxWeightDT.GetType() << endl;
    cout << "  name: " << FbxWeightDT.GetName() << endl;
}

void print_export_formats(ProgramState& state, vector<string>&)
{
    FbxIOSettings* ios = FbxIOSettings::Create(state.manager, IOSROOT);
    int lFormat = -1;
    int format6a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 ascii (*.fbx)");
    int format6b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX 6.0 binary (*.fbx)");
    int format7a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX ascii (*.fbx)");
    int format7b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX binary (*.fbx)");
    FbxExporter* exporter = FbxExporter::Create(state.manager, "");
    int n = state.manager->GetIOPluginRegistry()->GetWriterFormatCount();
    for (int i = 0; i < n; i++)
    {
        cout << i << ":" << endl;
        cout << "  description: " << state.manager->GetIOPluginRegistry()->GetWriterFormatDescription(i) << endl;
        cout << "  extension: " << state.manager->GetIOPluginRegistry()->GetWriterFormatExtension(i) << endl;
        cout << "  writable versions: " << endl;
        char const* const* wvs = state.manager->GetIOPluginRegistry()->GetWritableVersions(i);
        int k =0 ;
        while (wvs && *wvs)
        {
            cout << "  " << k << ": " << *wvs << endl;
            wvs++;
            k++;
        }
    }
    cout << "IO settings for writers: " << endl;
    FbxIOSettings* settings = FbxIOSettings::Create(state.manager, "");
    state.manager->GetIOPluginRegistry()->FillIOSettingsForWritersRegistered(*settings);
    print_io_settings(settings);
}

void print_pirate_geometry_array(ProgramState& state)
{
    FbxImporter* importer = FbxImporter::Create(state.manager, "");
    FbxIOSettings* ios = FbxIOSettings::Create(state.manager, IOSROOT);

    importer->Initialize("../samples/model_20240711.fbx", -1, ios);
    importer->Import(state.scene);

    auto rootnode = state.scene->GetSrcObject(0);
    auto pirate_mesh = rootnode->GetSrcObject(1);
    auto untitled_007 = pirate_mesh->GetSrcObject(0); 
    FbxMesh* mesh = (FbxMesh*)untitled_007;
    cout << "GetPolygonVertexCount: " << mesh->GetPolygonVertexCount() << endl;
    cout << "GetControlPointsCount: " << mesh->GetControlPointsCount() << endl;
    auto control_points = mesh->GetControlPoints();
    auto n = mesh->GetControlPointsCount();
    cout << "control points:" << endl;
    for (int i = 0; i < n; i++)
        cout << "  " << i << ": " << control_points[i] << endl;
}

void convert_pirate_format(ProgramState& state)
{
    FbxImporter* importer = FbxImporter::Create(state.manager, "");
    FbxExporter* exporter = FbxExporter::Create(state.manager, "");
    FbxIOSettings* ios = FbxIOSettings::Create(state.manager, IOSROOT);

    int format7a = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX ascii (*.fbx)");
    int format7b = state.manager->GetIOPluginRegistry()->FindWriterIDByDescription("FBX binary (*.fbx)");

    importer->Initialize("../samples/model_20240711.fbx", -1, ios);
    importer->Import(state.scene);
    
    exporter->Initialize("../samples/model_20240711_7a_" FBX_2014_00_COMPATIBLE ".fbx", format7a, ios);
    exporter->SetFileExportVersion(FBX_2014_00_COMPATIBLE);
    exporter->Export(state.scene);
    exporter->Initialize("../samples/model_20240711_7b_" FBX_2014_00_COMPATIBLE ".fbx", format7b, ios);
    exporter->SetFileExportVersion(FBX_2014_00_COMPATIBLE);
    exporter->Export(state.scene);
}

void gen_empty(ProgramState& state, vector<string>& args)
{
    // Reset the scene to a new, empty one
    if (state.scene != NULL)
    {
        state.scene->Destroy();
        state.scene = NULL;
    }
    state.scene = FbxScene::Create(state.manager, "");
}

void gen_box(ProgramState& state, vector<string>& args)
{
    float x, y, z = 0;
    if (args.size() == 0) {
        x = y = z = 1;
    } else if (args.size() == 1) {
        auto f = stof(args[0]);
        x = y = z = f;
    } else if (args.size() == 2) {
        x = stof(args[0]);
        y = stof(args[1]);
        z = 1;
    } else if (args.size() == 3) {
        x = stof(args[0]);
        y = stof(args[1]);
        z = stof(args[2]);
    }

    gen_empty(state, args);

    // create node
    // create mesh (geometry)
    auto mesh = FbxMesh::Create(state.scene, "box");
    //    vertices
    //        a: 4,1,9,4,1,0,4,0,9,4,0,0,0,1,9,0,1,0,0,0,9,0,0,0
    FbxVector4 v[] = {
        FbxVector4(x, y, z),
        FbxVector4(x, y, 0),
        FbxVector4(x, 0, z),
        FbxVector4(x, 0, 0),
        FbxVector4(0, y, z),
        FbxVector4(0, y, 0),
        FbxVector4(0, 0, z),
        FbxVector4(0, 0, 0)
    };
    mesh->SetControlPointAt(v[0], 0);
    mesh->SetControlPointAt(v[1], 1);
    mesh->SetControlPointAt(v[2], 2);
    mesh->SetControlPointAt(v[3], 3);
    mesh->SetControlPointAt(v[4], 4);
    mesh->SetControlPointAt(v[5], 5);
    mesh->SetControlPointAt(v[6], 6);
    mesh->SetControlPointAt(v[7], 7);
    //    polygon vertex indexes
    //        
    mesh->BeginPolygon();
    mesh->AddPolygon(6);
    mesh->AddPolygon(0);
    mesh->AddPolygon(5);
    mesh->EndPolygon();
    mesh->AddPolygon(0);
    mesh->AddPolygon(6);
    mesh->AddPolygon(3);
    mesh->EndPolygon();
    mesh->AddPolygon(6);
    mesh->AddPolygon(3);
    mesh->AddPolygon(3);
    mesh->EndPolygon();
    mesh->AddPolygon(3);
    mesh->AddPolygon(6);
    mesh->AddPolygon(8);
    mesh->EndPolygon();
    mesh->AddPolygon(4);
    mesh->AddPolygon(7);
    mesh->AddPolygon(7);
    mesh->EndPolygon();
    mesh->AddPolygon(7);
    mesh->AddPolygon(4);
    mesh->AddPolygon(6);
    mesh->EndPolygon();
    mesh->AddPolygon(3);
    mesh->AddPolygon(7);
    mesh->AddPolygon(6);
    mesh->EndPolygon();
    mesh->AddPolygon(3);
    mesh->AddPolygon(5);
    mesh->AddPolygon(2);
    mesh->EndPolygon();
    mesh->AddPolygon(2);
    mesh->AddPolygon(1);
    mesh->AddPolygon(1);
    mesh->EndPolygon();
    mesh->AddPolygon(1);
    mesh->AddPolygon(2);
    mesh->AddPolygon(4);
    mesh->EndPolygon();
    mesh->AddPolygon(0);
    mesh->AddPolygon(5);
    mesh->AddPolygon(5);
    mesh->EndPolygon();
    mesh->AddPolygon(5);
    mesh->AddPolygon(0);
    mesh->AddPolygon(2);
    mesh->EndPolygon();

    auto node = FbxNode::Create(state.scene, "box");
    state.scene->GetRootNode()->AddChild(node);
}

void print_args(vector<string>& args)
{
    bool first = true;
    for (auto arg = args.begin(); arg != args.end(); arg++)
    {
        if (!first) { cout << ", "; }
        first = false;
        cout << *arg;
    }
}

void gen_custom_prop_value(ProgramState& state, vector<string>& args)
{
    //cout << "gen_custom_prop_value args: ";
    //print_args(args);
    //cout << endl;

    //cout << "gen_custom_prop_value about to call gen_empty" << endl;
    gen_empty(state, args);
    //cout << "gen_custom_prop_value about to call GetDocumentInfo" << endl;
    FbxDocumentInfo* docinfo = state.scene->GetDocumentInfo();
    //cout << "gen_custom_prop_value docinfo: " << docinfo << endl;
    //cout << "gen_custom_prop_value about to call FbxProperty::Create" << endl;
    FbxProperty prop = FbxProperty::Create(docinfo, FbxStringDT, "CustomProp");
    //cout << "gen_custom_prop_value prop: " << &prop << endl;

    auto propvalue = args[0];
    //cout << "propvalue: " << propvalue << endl;
    prop.Set(FbxString(propvalue.data()));
}

void load_scene_from_file(ProgramState& state, vector<string>& args)
{
    auto filename = args[0];
    FbxImporter* importer = FbxImporter::Create(state.manager, "");
    FbxIOSettings* ios = FbxIOSettings::Create(state.manager, IOSROOT);
    importer->Initialize(filename.c_str(), -1, ios);
    importer->Import(state.scene);
}

typedef void (*OperationFn) (ProgramState&, std::vector<std::string>&);
struct Operation
{
    std::string name;
    OperationFn fn;
    int nargs = 0;
    vector<string> args;
};

void print_usage(vector<Operation>& ops) 
{
    cout << "gen_samples COMMAND [ARGS...] (COMMAND [ARGS...] ...)" << endl;
    cout << "Commands:" << endl;
    int max_op_name = 0;
    for (auto op = ops.begin(); op != ops.end(); op++)
    {
        if (op->name.length() > max_op_name)
            max_op_name = op->name.length(); 
    }
    for (auto op = ops.begin(); op != ops.end(); op++)
    {
        int padding = max_op_name - op->name.length();
        cout << "  " << op->name << "   ";
        for (auto arg = op->args.begin(); arg != op->args.end(); arg++)
        {
            cout << " " << *arg;
        }
        cout << endl;
    }
}

int main(int argc, char** argv)
{
    auto operations = vector{
        Operation{.name = "io-settings", .fn = io_settings, .args = {"FILENAME"}},
        Operation{.name = "print-properties", .fn = print_properties},
        Operation{.name = "import-export", .fn = import_export},
        Operation{.name = "export-all-version-variants", .fn = export_all_version_variants, .args = {"FILENAME_PREFIX"}},
        Operation{.name = "data-types-yaml", .fn = print_data_types_yaml},
        Operation{.name = "print-export-formats", .fn = print_export_formats},
        Operation{.name = "gen-custom-prop", .fn = gen_custom_prop_value, .args = {"VALUE"}},
        Operation{.name = "export-all-formats", .fn = export_all_formats, .args = {"FILENAME_PREFIX"}},
        Operation{.name = "gen-empty", .fn = gen_empty},
        Operation{.name = "gen-box", .fn = gen_box, .args = {"DX", "DY", "DZ"}},
    };

    if (argc < 2)
    {
        print_usage(operations);
        return 1;
    }

    auto args = vector<string>{};

    auto state = ProgramState();

    int i;
    for (i = 1; i < argc; i++)
    {
        auto arg = std::string(argv[i]);
        bool found = false;
        for (auto op = operations.begin(); op != operations.end(); op++)
        {
            if (arg == op->name)
            {
                found = true;
                args.clear();
                while (true)
                {
                    if (i + 1 >= argc)
                        break;
                    if (args.size() >= op->args.size())
                        break;
                    args.push_back(argv[i+1]);
                    i++;
                }
                // cout << "Running operation \"" << op->name << "\" with args: ";
                for (auto arg1 = args.begin(); arg1 != args.end(); arg1++)
                    cout << *arg1 << " ";
                cout << endl;
                op->fn(state, args);
                break;
            } 
        }
        if (!found)
        {
            cout << "unknown operation \"" << arg << "\"" << endl;
            return 1;
        }
    }
    return 0;
}

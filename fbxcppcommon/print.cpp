
#include "print.h"

#include <iomanip>
#include <sstream>
#include <vector>
#include <algorithm>

#include "Collector.h"
#include "objects.h"
#include "properties.h"

using namespace std;

void PrintObjectGraph(FbxObject* obj)
{
    Collector c;

    vector<FbxObject*> objs;

    c.Visit(obj, &objs);

    cout << endl;

    std::sort(objs.begin(), objs.end(), sort_by_id);

    vector<FbxObject*>::iterator it;
    for (it = objs.begin(); it != objs.end(); ++it)
    {
        PrintObject(*it);
    }
}

void PrintObjectID(FbxObject* obj)
{
    if (obj == NULL)
        cout << "<<null>>";
    else
        cout <<
            "$" << obj->GetUniqueID() << ", " <<
            obj->GetRuntimeClassId().GetName() << ", " <<
            quote(obj->GetName());
}

const char * translate_hier_name(FbxString& name)
{
    if (name == IOSROOT) return "IOSROOT";
    if (name == IOSN_EXPORT) return "IOSN_EXPORT";
    if (name == IOSN_IMPORT) return "IOSN_IMPORT";
    if (name == IOSN_PLUGIN_GRP) return "IOSN_PLUGIN_GRP";
    if (name == IOSN_PLUGIN_UI_WIDTH) return "IOSN_PLUGIN_UI_WIDTH";
    if (name == IOSN_PLUGIN_UI_HEIGHT) return "IOSN_PLUGIN_UI_HEIGHT";
    if (name == IOSN_PLUGIN_VERSIONS_URL) return "IOSN_PLUGIN_VERSIONS_URL";
    if (name == IOSN_PI_VERSION) return "IOSN_PI_VERSION";
    if (name == IOSN_PRESET_SELECTED) return "IOSN_PRESET_SELECTED";
    if (name == IOSN_PRESETS_GRP) return "IOSN_PRESETS_GRP";
    if (name == IOSN_STATISTICS_GRP) return "IOSN_STATISTICS_GRP";
    if (name == IOSN_UNITS_GRP) return "IOSN_UNITS_GRP";
    if (name == IOSN_INCLUDE_GRP) return "IOSN_INCLUDE_GRP";
    if (name == IOSN_ADV_OPT_GRP) return "IOSN_ADV_OPT_GRP";
    if (name == IOSN_AXISCONV_GRP) return "IOSN_AXISCONV_GRP";
    if (name == IOSN_CAMERA_GRP) return "IOSN_CAMERA_GRP";
    if (name == IOSN_LIGHT_GRP) return "IOSN_LIGHT_GRP";
    if (name == IOSN_EXTRA_GRP) return "IOSN_EXTRA_GRP";
    if (name == IOSN_CONSTRAINTS_GRP) return "IOSN_CONSTRAINTS_GRP";
    if (name == IOSN_INPUTCONNECTIONS_GRP) return "IOSN_INPUTCONNECTIONS_GRP";
    if (name == IOSN_INFORMATION_GRP) return "IOSN_INFORMATION_GRP";
    if (name == IOSN_UP_AXIS) return "IOSN_UP_AXIS";
    if (name == IOSN_UP_AXIS_MAX) return "IOSN_UP_AXIS_MAX";
    if (name == IOSN_ZUPROTATION_MAX) return "IOSN_ZUPROTATION_MAX";
    if (name == IOSN_AXISCONVERSION) return "IOSN_AXISCONVERSION";
    if (name == IOSN_AUTO_AXIS) return "IOSN_AUTO_AXIS";
    if (name == IOSN_FILE_UP_AXIS) return "IOSN_FILE_UP_AXIS";
    if (name == IOSN_PRESETS) return "IOSN_PRESETS";
    if (name == IOSN_STATISTICS) return "IOSN_STATISTICS";
    if (name == IOSN_UNITS_SCALE) return "IOSN_UNITS_SCALE";
    if (name == IOSN_TOTAL_UNITS_SCALE_TB) return "IOSN_TOTAL_UNITS_SCALE_TB";
    if (name == IOSN_SCALECONVERSION) return "IOSN_SCALECONVERSION";
    if (name == IOSN_MASTERSCALE) return "IOSN_MASTERSCALE";
    if (name == IOSN_DYN_SCALE_CONVERSION) return "IOSN_DYN_SCALE_CONVERSION";
    if (name == IOSN_UNITSELECTOR) return "IOSN_UNITSELECTOR";
    if (name == IOSN_AUDIO) return "IOSN_AUDIO";
    if (name == IOSN_ANIMATION) return "IOSN_ANIMATION";
    if (name == IOSN_GEOMETRY) return "IOSN_GEOMETRY";
    if (name == IOSN_DEFORMATION) return "IOSN_DEFORMATION";
    if (name == IOSN_MARKERS) return "IOSN_MARKERS";
    if (name == IOSN_CHARACTER) return "IOSN_CHARACTER";
    if (name == IOSN_CHARACTER_AS_MAYA_HIK) return "IOSN_CHARACTER_AS_MAYA_HIK";
    if (name == IOSN_CHARACTER_TYPE) return "IOSN_CHARACTER_TYPE";
    if (name == IOSN_CHARACTER_TYPE_DESC) return "IOSN_CHARACTER_TYPE_DESC";
    if (name == IOSN_SETLOCKEDATTRIB) return "IOSN_SETLOCKEDATTRIB";
    if (name == IOSN_TRIANGULATE) return "IOSN_TRIANGULATE";
    if (name == IOSN_MRCUSTOMATTRIBUTES) return "IOSN_MRCUSTOMATTRIBUTES";
    if (name == IOSN_MESHPRIMITIVE) return "IOSN_MESHPRIMITIVE";
    if (name == IOSN_MESHTRIANGLE) return "IOSN_MESHTRIANGLE";
    if (name == IOSN_MESHPOLY) return "IOSN_MESHPOLY";
    if (name == IOSN_NURB) return "IOSN_NURB";
    if (name == IOSN_PATCH) return "IOSN_PATCH";
    if (name == IOSN_BIP2FBX) return "IOSN_BIP2FBX";
    if (name == IOSN_ASCIIFBX) return "IOSN_ASCIIFBX";
    if (name == IOSN_TAKE) return "IOSN_TAKE";
    if (name == IOSN_GEOMETRYMESHPRIMITIVEAS) return "IOSN_GEOMETRYMESHPRIMITIVEAS";
    if (name == IOSN_GEOMETRYMESHTRIANGLEAS) return "IOSN_GEOMETRYMESHTRIANGLEAS";
    if (name == IOSN_GEOMETRYMESHPOLYAS) return "IOSN_GEOMETRYMESHPOLYAS";
    if (name == IOSN_GEOMETRYNURBSAS) return "IOSN_GEOMETRYNURBSAS";
    if (name == IOSN_GEOMETRYNURBSSURFACEAS) return "IOSN_GEOMETRYNURBSSURFACEAS";
    if (name == IOSN_GEOMETRYPATCHAS) return "IOSN_GEOMETRYPATCHAS";
    if (name == IOSN_TANGENTS_BINORMALS) return "IOSN_TANGENTS_BINORMALS";
    if (name == IOSN_SMOOTH_MESH) return "IOSN_SMOOTH_MESH";
    if (name == IOSN_SELECTION_SET) return "IOSN_SELECTION_SET";
    if (name == IOSN_ANIMATIONONLY) return "IOSN_ANIMATIONONLY";
    if (name == IOSN_SELECTIONONLY) return "IOSN_SELECTIONONLY";
    if (name == IOSN_BONE) return "IOSN_BONE";
    if (name == IOSN_BONEWIDTHHEIGHTLOCK) return "IOSN_BONEWIDTHHEIGHTLOCK";
    if (name == IOSN_BONEASDUMMY) return "IOSN_BONEASDUMMY";
    if (name == IOSN_BONEMAX4BONEWIDTH) return "IOSN_BONEMAX4BONEWIDTH";
    if (name == IOSN_BONEMAX4BONEHEIGHT) return "IOSN_BONEMAX4BONEHEIGHT";
    if (name == IOSN_BONEMAX4BONETAPER) return "IOSN_BONEMAX4BONETAPER";
    if (name == IOSN_REMOVE_SINGLE_KEY) return "IOSN_REMOVE_SINGLE_KEY";
    if (name == IOSN_CURVE_FILTER) return "IOSN_CURVE_FILTER";
    if (name == IOSN_CONSTRAINT) return "IOSN_CONSTRAINT";
    if (name == IOSN_UI) return "IOSN_UI";
    if (name == IOSN_SHOW_UI_MODE) return "IOSN_SHOW_UI_MODE";
    if (name == IOSN_SHOW_WARNINGS_MANAGER) return "IOSN_SHOW_WARNINGS_MANAGER";
    if (name == IOSN_GENERATE_LOG_DATA) return "IOSN_GENERATE_LOG_DATA";
    if (name == IOSN_PERF_GRP) return "IOSN_PERF_GRP";
    if (name == IOSN_REMOVEBADPOLYSFROMMESH) return "IOSN_REMOVEBADPOLYSFROMMESH";
    if (name == IOSN_META_DATA) return "IOSN_META_DATA";
    if (name == IOSN_CACHE_GRP) return "IOSN_CACHE_GRP";
    if (name == IOSN_CACHE_SIZE) return "IOSN_CACHE_SIZE";
    if (name == IOSN_MERGE_MODE) return "IOSN_MERGE_MODE";
    if (name == IOSN_MERGE_MODE_DESCRIPTION) return "IOSN_MERGE_MODE_DESCRIPTION";
    if (name == IOSN_ONE_CLICK_MERGE) return "IOSN_ONE_CLICK_MERGE";
    if (name == IOSN_ONE_CLICK_MERGE_TEXTURE) return "IOSN_ONE_CLICK_MERGE_TEXTURE";
    if (name == IOSN_SAMPLINGPANEL) return "IOSN_SAMPLINGPANEL";
    if (name == IOSN_FILE_FORMAT) return "IOSN_FILE_FORMAT";
    if (name == IOSN_FBX) return "IOSN_FBX";
    if (name == IOSN_DXF) return "IOSN_DXF";
    if (name == IOSN_OBJ) return "IOSN_OBJ";
    if (name == IOSN_3DS) return "IOSN_3DS";
    if (name == IOSN_COLLADA) return "IOSN_COLLADA";
    if (name == IOSN_MOTION_BASE) return "IOSN_MOTION_BASE";
    if (name == IOSN_BIOVISION_BVH) return "IOSN_BIOVISION_BVH";
    if (name == IOSN_MOTIONANALYSIS_HTR) return "IOSN_MOTIONANALYSIS_HTR";
    if (name == IOSN_MOTIONANALYSIS_TRC) return "IOSN_MOTIONANALYSIS_TRC";
    if (name == IOSN_ACCLAIM_ASF) return "IOSN_ACCLAIM_ASF";
    if (name == IOSN_ACCLAIM_AMC) return "IOSN_ACCLAIM_AMC";
    if (name == IOSN_VICON_C3D) return "IOSN_VICON_C3D";
    if (name == IOSN_SKINS) return "IOSN_SKINS";
    if (name == IOSN_POINTCACHE) return "IOSN_POINTCACHE";
    if (name == IOSN_QUATERNION) return "IOSN_QUATERNION";
    if (name == IOSN_NAMETAKE) return "IOSN_NAMETAKE";
    if (name == IOSN_SHAPE) return "IOSN_SHAPE";
    if (name == IOSN_SHAPEATTRIBUTES) return "IOSN_SHAPEATTRIBUTES";
    if (name == IOSN_SHAPEATTRIBUTE_VALUES) return "IOSN_SHAPEATTRIBUTE_VALUES";
    if (name == IOSN_LIGHT) return "IOSN_LIGHT";
    if (name == IOSN_LIGHTATTENUATION) return "IOSN_LIGHTATTENUATION";
    if (name == IOSN_CAMERA) return "IOSN_CAMERA";
    if (name == IOSN_VIEW_CUBE) return "IOSN_VIEW_CUBE";
    if (name == IOSN_BINDPOSE) return "IOSN_BINDPOSE";
    if (name == IOSN_EMBEDTEXTURE_GRP) return "IOSN_EMBEDTEXTURE_GRP";
    if (name == IOSN_EMBEDTEXTURE) return "IOSN_EMBEDTEXTURE";
    if (name == IOSN_EMBEDDED_FOLDER) return "IOSN_EMBEDDED_FOLDER";
    if (name == IOSN_CONVERTTOTIFF) return "IOSN_CONVERTTOTIFF";
    if (name == IOSN_UNLOCK_NORMALS) return "IOSN_UNLOCK_NORMALS";
    if (name == IOSN_CREASE) return "IOSN_CREASE";
    if (name == IOSN_FINESTSUBDIVLEVEL) return "IOSN_FINESTSUBDIVLEVEL";
    if (name == IOSN_BAKEANIMATIONLAYERS) return "IOSN_BAKEANIMATIONLAYERS";
    if (name == IOSN_BAKECOMPLEXANIMATION) return "IOSN_BAKECOMPLEXANIMATION";
    if (name == IOSN_BAKEFRAMESTART) return "IOSN_BAKEFRAMESTART";
    if (name == IOSN_BAKEFRAMEEND) return "IOSN_BAKEFRAMEEND";
    if (name == IOSN_BAKEFRAMESTEP) return "IOSN_BAKEFRAMESTEP";
    if (name == IOSN_BAKEFRAMESTARTNORESET) return "IOSN_BAKEFRAMESTARTNORESET";
    if (name == IOSN_BAKEFRAMEENDNORESET) return "IOSN_BAKEFRAMEENDNORESET";
    if (name == IOSN_BAKEFRAMESTEPNORESET) return "IOSN_BAKEFRAMESTEPNORESET";
    if (name == IOSN_USEMATRIXFROMPOSE) return "IOSN_USEMATRIXFROMPOSE";
    if (name == IOSN_NULLSTOPIVOT) return "IOSN_NULLSTOPIVOT";
    if (name == IOSN_PIVOTTONULLS) return "IOSN_PIVOTTONULLS";
    if (name == IOSN_GEOMNORMALPERPOLY) return "IOSN_GEOMNORMALPERPOLY";
    if (name == IOSN_MAXBONEASBONE) return "IOSN_MAXBONEASBONE";
    if (name == IOSN_MAXNURBSSTEP) return "IOSN_MAXNURBSSTEP";
    if (name == IOSN_PROTECTDRIVENKEYS) return "IOSN_PROTECTDRIVENKEYS";
    if (name == IOSN_DEFORMNULLSASJOINTS) return "IOSN_DEFORMNULLSASJOINTS";
    if (name == IOSN_ENVIRONMENT) return "IOSN_ENVIRONMENT";
    if (name == IOSN_SAMPLINGRATESELECTOR) return "IOSN_SAMPLINGRATESELECTOR";
    if (name == IOSN_SAMPLINGRATE) return "IOSN_SAMPLINGRATE";
    if (name == IOSN_APPLYCSTKEYRED) return "IOSN_APPLYCSTKEYRED";
    if (name == IOSN_CSTKEYREDTPREC) return "IOSN_CSTKEYREDTPREC";
    if (name == IOSN_CSTKEYREDRPREC) return "IOSN_CSTKEYREDRPREC";
    if (name == IOSN_CSTKEYREDSPREC) return "IOSN_CSTKEYREDSPREC";
    if (name == IOSN_CSTKEYREDOPREC) return "IOSN_CSTKEYREDOPREC";
    if (name == IOSN_APPLYKEYREDUCE) return "IOSN_APPLYKEYREDUCE";
    if (name == IOSN_KEYREDUCEPREC) return "IOSN_KEYREDUCEPREC";
    if (name == IOSN_APPLYKEYSONFRM) return "IOSN_APPLYKEYSONFRM";
    if (name == IOSN_APPLYKEYSYNC) return "IOSN_APPLYKEYSYNC";
    if (name == IOSN_APPLYUNROLL) return "IOSN_APPLYUNROLL";
    if (name == IOSN_UNROLLPREC) return "IOSN_UNROLLPREC";
    if (name == IOSN_UNROLLPATH) return "IOSN_UNROLLPATH";
    if (name == IOSN_UNROLLFORCEAUTO) return "IOSN_UNROLLFORCEAUTO";
    if (name == IOSN_AUTOTANGENTSONLY) return "IOSN_AUTOTANGENTSONLY";
    if (name == IOSN_SMOOTHING_GROUPS) return "IOSN_SMOOTHING_GROUPS";
    if (name == IOSN_HARDEDGES) return "IOSN_HARDEDGES";
    if (name == IOSN_EXP_HARDEDGES) return "IOSN_EXP_HARDEDGES";
    if (name == IOSN_BLINDDATA) return "IOSN_BLINDDATA";
    if (name == IOSN_INPUTCONNECTIONS) return "IOSN_INPUTCONNECTIONS";
    if (name == IOSN_INSTANCES) return "IOSN_INSTANCES";
    if (name == IOSN_REFERENCES) return "IOSN_REFERENCES";
    if (name == IOSN_CONTAINEROBJECTS) return "IOSN_CONTAINEROBJECTS";
    if (name == IOSN_BYPASSRRSINHERITANCE) return "IOSN_BYPASSRRSINHERITANCE";
    if (name == IOSN_FORCEWEIGHTNORMALIZE) return "IOSN_FORCEWEIGHTNORMALIZE";
    if (name == IOSN_SHAPEANIMATION) return "IOSN_SHAPEANIMATION";
    if (name == IOSN_SMOOTHKEYASUSER) return "IOSN_SMOOTHKEYASUSER";
    if (name == IOSN_SCALEFACTOR) return "IOSN_SCALEFACTOR";
    if (name == IOSN_AXISCONVERSIONMETHOD) return "IOSN_AXISCONVERSIONMETHOD";
    if (name == IOSN_UPAXIS) return "IOSN_UPAXIS";
    if (name == IOSN_SELECTIONSETNAMEASPOINTCACHE) return "IOSN_SELECTIONSETNAMEASPOINTCACHE";
    if (name == IOSN_KEEPFRAMERATE) return "IOSN_KEEPFRAMERATE";
    if (name == IOSN_ATTENUATIONASINTENSITYCURVE) return "IOSN_ATTENUATIONASINTENSITYCURVE";
    if (name == IOSN_RESAMPLE_ANIMATION_CURVES) return "IOSN_RESAMPLE_ANIMATION_CURVES";
    if (name == IOSN_TIMELINE) return "IOSN_TIMELINE";
    if (name == IOSN_TIMELINE_SPAN) return "IOSN_TIMELINE_SPAN";
    if (name == IOSN_BUTTON_WEB_UPDATE) return "IOSN_BUTTON_WEB_UPDATE";
    if (name == IOSN_BUTTON_EDIT) return "IOSN_BUTTON_EDIT";
    if (name == IOSN_BUTTON_OK) return "IOSN_BUTTON_OK";
    if (name == IOSN_BUTTON_CANCEL) return "IOSN_BUTTON_CANCEL";
    if (name == IOSN_MENU_EDIT_PRESET) return "IOSN_MENU_EDIT_PRESET";
    if (name == IOSN_MENU_SAVE_PRESET) return "IOSN_MENU_SAVE_PRESET";
    if (name == IOSN_UIL) return "IOSN_UIL";
    if (name == IOSN_PLUGIN_PRODUCT_FAMILY) return "IOSN_PLUGIN_PRODUCT_FAMILY";
    if (name == IOSN_PLUGIN_UI_XPOS) return "IOSN_PLUGIN_UI_XPOS";
    if (name == IOSN_PLUGIN_UI_YPOS) return "IOSN_PLUGIN_UI_YPOS";
    if (name == IOSN_FBX_EXTENTIONS_SDK) return "IOSN_FBX_EXTENTIONS_SDK";
    if (name == IOSN_FBX_EXTENTIONS_SDK_WARNING) return "IOSN_FBX_EXTENTIONS_SDK_WARNING";
    if (name == IOSN_COLLADA_FRAME_COUNT) return "IOSN_COLLADA_FRAME_COUNT";
    if (name == IOSN_COLLADA_START) return "IOSN_COLLADA_START";
    if (name == IOSN_COLLADA_TAKE_NAME) return "IOSN_COLLADA_TAKE_NAME";
    if (name == IOSN_COLLADA_TRIANGULATE) return "IOSN_COLLADA_TRIANGULATE";
    if (name == IOSN_COLLADA_SINGLEMATRIX) return "IOSN_COLLADA_SINGLEMATRIX";
    if (name == IOSN_COLLADA_FRAME_RATE) return "IOSN_COLLADA_FRAME_RATE";
    if (name == IOSN_DXF_TRIANGULATE) return "IOSN_DXF_TRIANGULATE";
    if (name == IOSN_DXF_DEFORMATION) return "IOSN_DXF_DEFORMATION";
    if (name == IOSN_DXF_WELD_VERTICES) return "IOSN_DXF_WELD_VERTICES";
    if (name == IOSN_DXF_OBJECT_DERIVATION) return "IOSN_DXF_OBJECT_DERIVATION";
    if (name == IOSN_DXF_REFERENCE_NODE) return "IOSN_DXF_REFERENCE_NODE";
    if (name == IOSN_OBJ_REFERENCE_NODE) return "IOSN_OBJ_REFERENCE_NODE";
    if (name == IOSN_OBJ_TRIANGULATE) return "IOSN_OBJ_TRIANGULATE";
    if (name == IOSN_OBJ_DEFORMATION) return "IOSN_OBJ_DEFORMATION";
    if (name == IOSN_3DS_REFERENCENODE) return "IOSN_3DS_REFERENCENODE";
    if (name == IOSN_3DS_TEXTURE) return "IOSN_3DS_TEXTURE";
    if (name == IOSN_3DS_MATERIAL) return "IOSN_3DS_MATERIAL";
    if (name == IOSN_3DS_ANIMATION) return "IOSN_3DS_ANIMATION";
    if (name == IOSN_3DS_MESH) return "IOSN_3DS_MESH";
    if (name == IOSN_3DS_LIGHT) return "IOSN_3DS_LIGHT";
    if (name == IOSN_3DS_CAMERA) return "IOSN_3DS_CAMERA";
    if (name == IOSN_3DS_AMBIENT_LIGHT) return "IOSN_3DS_AMBIENT_LIGHT";
    if (name == IOSN_3DS_RESCALING) return "IOSN_3DS_RESCALING";
    if (name == IOSN_3DS_FILTER) return "IOSN_3DS_FILTER";
    if (name == IOSN_3DS_SMOOTHGROUP) return "IOSN_3DS_SMOOTHGROUP";
    if (name == IOSN_3DS_TAKE_NAME) return "IOSN_3DS_TAKE_NAME";
    if (name == IOSN_3DS_TEXUVBYPOLY) return "IOSN_3DS_TEXUVBYPOLY";
    if (name == IOSN_ZOOMEXTENTS) return "IOSN_ZOOMEXTENTS";
    if (name == IOSN_GLOBAL_AMBIENT_COLOR) return "IOSN_GLOBAL_AMBIENT_COLOR";
    if (name == IOSN_EDGE_ORIENTATION) return "IOSN_EDGE_ORIENTATION";
    if (name == IOSN_VERSIONS_UI_ALIAS) return "IOSN_VERSIONS_UI_ALIAS";
    if (name == IOSN_VERSIONS_COMP_DESCRIPTIONS) return "IOSN_VERSIONS_COMP_DESCRIPTIONS";
    if (name == IOSN_MODEL_COUNT) return "IOSN_MODEL_COUNT";
    if (name == IOSN_DEVICE_COUNT) return "IOSN_DEVICE_COUNT";
    if (name == IOSN_CHARACTER_COUNT) return "IOSN_CHARACTER_COUNT";
    if (name == IOSN_ACTOR_COUNT) return "IOSN_ACTOR_COUNT";
    if (name == IOSN_CONSTRAINT_COUNT) return "IOSN_CONSTRAINT_COUNT";
    if (name == IOSN_MEDIA_COUNT) return "IOSN_MEDIA_COUNT";
    if (name == IOSN_TEMPLATE) return "IOSN_TEMPLATE";
    if (name == IOSN_PIVOT) return "IOSN_PIVOT";
    if (name == IOSN_GLOBAL_SETTINGS) return "IOSN_GLOBAL_SETTINGS";
    if (name == IOSN_MERGE_LAYER_AND_TIMEWARP) return "IOSN_MERGE_LAYER_AND_TIMEWARP";
    if (name == IOSN_GOBO) return "IOSN_GOBO";
    if (name == IOSN_LINK) return "IOSN_LINK";
    if (name == IOSN_MATERIAL) return "IOSN_MATERIAL";
    if (name == IOSN_TEXTURE) return "IOSN_TEXTURE";
    if (name == IOSN_MODEL) return "IOSN_MODEL";
    if (name == IOSN_NORMAL) return "IOSN_NORMAL";
    if (name == IOSN_BINORMAL) return "IOSN_BINORMAL";
    if (name == IOSN_TANGENT) return "IOSN_TANGENT";
    if (name == IOSN_VERTEXCOLOR) return "IOSN_VERTEXCOLOR";
    if (name == IOSN_POLYGROUP) return "IOSN_POLYGROUP";
    if (name == IOSN_SMOOTHING) return "IOSN_SMOOTHING";
    if (name == IOSN_USERDATA) return "IOSN_USERDATA";
    if (name == IOSN_VISIBILITY) return "IOSN_VISIBILITY";
    if (name == IOSN_EDGECREASE) return "IOSN_EDGECREASE";
    if (name == IOSN_VERTEXCREASE) return "IOSN_VERTEXCREASE";
    if (name == IOSN_HOLE) return "IOSN_HOLE";
    if (name == IOSN_EMBEDDED) return "IOSN_EMBEDDED";
    if (name == IOSN_PASSWORD) return "IOSN_PASSWORD";
    if (name == IOSN_PASSWORD_ENABLE) return "IOSN_PASSWORD_ENABLE";
    if (name == IOSN_CURRENT_TAKE_NAME) return "IOSN_CURRENT_TAKE_NAME";
    if (name == IOSN_COLLAPSE_EXTERNALS) return "IOSN_COLLAPSE_EXTERNALS";
    if (name == IOSN_COMPRESS_ARRAYS) return "IOSN_COMPRESS_ARRAYS";
    if (name == IOSN_COMPRESS_LEVEL) return "IOSN_COMPRESS_LEVEL";
    if (name == IOSN_COMPRESS_MINSIZE) return "IOSN_COMPRESS_MINSIZE";
    if (name == IOSN_EMBEDDED_PROPERTIES_SKIP) return "IOSN_EMBEDDED_PROPERTIES_SKIP";
    if (name == IOSN_EXPORT_FILE_VERSION) return "IOSN_EXPORT_FILE_VERSION";
    if (name == IOSN_SHOW_UI_WARNING) return "IOSN_SHOW_UI_WARNING";
    if (name == IOSN_ADD_MATERIAL_TO_EDIT) return "IOSN_ADD_MATERIAL_TO_EDIT";
    if (name == IOSN_ENABLE_TEX_DISPLAY) return "IOSN_ENABLE_TEX_DISPLAY";
    if (name == IOSN_PREFERED_ENVELOPPE_SYSTEM) return "IOSN_PREFERED_ENVELOPPE_SYSTEM";
    if (name == IOSN_FIRST_TIME_RUN_NOTICE) return "IOSN_FIRST_TIME_RUN_NOTICE";
    if (name == IOSN_EXTRACT_EMBEDDED_DATA) return "IOSN_EXTRACT_EMBEDDED_DATA";
    if (name == IOSN_CALCULATE_LEGACY_SHAPE_NORMAL) return "IOSN_CALCULATE_LEGACY_SHAPE_NORMAL";
    if (name == IOSN_USETMPFILEPERIPHERAL) return "IOSN_USETMPFILEPERIPHERAL";
    if (name == IOSN_CONSTRUCTIONHISTORY) return "IOSN_CONSTRUCTIONHISTORY";
    if (name == IOSN_RELAXED_FBX_CHECK) return "IOSN_RELAXED_FBX_CHECK";
    if (name == IOSN_KEEP_PRODUCER_CAM_SRCOBJ) return "IOSN_KEEP_PRODUCER_CAM_SRCOBJ";
    if (name == IMP_PRESETS) return "IMP_PRESETS";
    if (name == IMP_STATISTICS) return "IMP_STATISTICS";
    if (name == IMP_STATISTICS_GRP) return "IMP_STATISTICS_GRP";
    if (name == IMP_PRESETS_GRP) return "IMP_PRESETS_GRP";
    if (name == IMP_PLUGIN_GRP) return "IMP_PLUGIN_GRP";
    if (name == IMP_INCLUDE_GRP) return "IMP_INCLUDE_GRP";
    if (name == IMP_ADV_OPT_GRP) return "IMP_ADV_OPT_GRP";
    if (name == IMP_FBX_EXT_SDK_GRP) return "IMP_FBX_EXT_SDK_GRP";
    if (name == IMP_FIRST_TIME_RUN_NOTICE_GRP) return "IMP_FIRST_TIME_RUN_NOTICE_GRP";
    if (name == IMP_INFORMATION_GRP) return "IMP_INFORMATION_GRP";
    if (name == IMP_FIRST_TIME_RUN_NOTICE) return "IMP_FIRST_TIME_RUN_NOTICE";
    if (name == IMP_GEOMETRY) return "IMP_GEOMETRY";
    if (name == IMP_AUDIO) return "IMP_AUDIO";
    if (name == IMP_ANIMATION) return "IMP_ANIMATION";
    if (name == IMP_SETLOCKEDATTRIB) return "IMP_SETLOCKEDATTRIB";
    if (name == IMP_MERGE_MODE) return "IMP_MERGE_MODE";
    if (name == IMP_MERGE_MODE_DESCRIPTION) return "IMP_MERGE_MODE_DESCRIPTION";
    if (name == IMP_ONE_CLICK_MERGE) return "IMP_ONE_CLICK_MERGE";
    if (name == IMP_ONE_CLICK_MERGE_TEXTURE) return "IMP_ONE_CLICK_MERGE_TEXTURE";
    if (name == IMP_ADD_MATERIAL_TO_EDIT) return "IMP_ADD_MATERIAL_TO_EDIT";
    if (name == IMP_ENABLE_TEX_DISPLAY) return "IMP_ENABLE_TEX_DISPLAY";
    if (name == IMP_PREFERED_ENVELOPPE_SYSTEM) return "IMP_PREFERED_ENVELOPPE_SYSTEM";
    if (name == IMP_CAMERA_GRP) return "IMP_CAMERA_GRP";
    if (name == IMP_LIGHT_GRP) return "IMP_LIGHT_GRP";
    if (name == IMP_EMBEDDED_GRP) return "IMP_EMBEDDED_GRP";
    if (name == IMP_EXTRACT_FOLDER) return "IMP_EXTRACT_FOLDER";
    if (name == IMP_LIGHT) return "IMP_LIGHT";
    if (name == IMP_ENVIRONMENT) return "IMP_ENVIRONMENT";
    if (name == IMP_CAMERA) return "IMP_CAMERA";
    if (name == IMP_VIEW_CUBE) return "IMP_VIEW_CUBE";
    if (name == IMP_ZOOMEXTENTS) return "IMP_ZOOMEXTENTS";
    if (name == IMP_GLOBAL_AMBIENT_COLOR) return "IMP_GLOBAL_AMBIENT_COLOR";
    if (name == IMP_CURVEFILTERS) return "IMP_CURVEFILTERS";
    if (name == IMP_SAMPLINGPANEL) return "IMP_SAMPLINGPANEL";
    if (name == IMP_DEFORMATION) return "IMP_DEFORMATION";
    if (name == IMP_BONE) return "IMP_BONE";
    if (name == IMP_ATTENUATIONASINTENSITYCURVE) return "IMP_ATTENUATIONASINTENSITYCURVE";
    if (name == IMP_EXTRA_GRP) return "IMP_EXTRA_GRP";
    if (name == IMP_TAKE) return "IMP_TAKE";
    if (name == IMP_KEEPFRAMERATE) return "IMP_KEEPFRAMERATE";
    if (name == IMP_TIMELINE) return "IMP_TIMELINE";
    if (name == IMP_TIMELINE_SPAN) return "IMP_TIMELINE_SPAN";
    if (name == IMP_BAKEANIMATIONLAYERS) return "IMP_BAKEANIMATIONLAYERS";
    if (name == IMP_MARKERS) return "IMP_MARKERS";
    if (name == IMP_QUATERNION) return "IMP_QUATERNION";
    if (name == IMP_PROTECTDRIVENKEYS) return "IMP_PROTECTDRIVENKEYS";
    if (name == IMP_DEFORMNULLSASJOINTS) return "IMP_DEFORMNULLSASJOINTS";
    if (name == IMP_NULLSTOPIVOT) return "IMP_NULLSTOPIVOT";
    if (name == IMP_POINTCACHE) return "IMP_POINTCACHE";
    if (name == IMP_SHAPEANIMATION) return "IMP_SHAPEANIMATION";
    if (name == IMP_CONSTRAINTS_GRP) return "IMP_CONSTRAINTS_GRP";
    if (name == IMP_CONSTRAINT) return "IMP_CONSTRAINT";
    if (name == IMP_CHARACTER) return "IMP_CHARACTER";
    if (name == IMP_CHARACTER_AS_MAYA_HIK) return "IMP_CHARACTER_AS_MAYA_HIK";
    if (name == IMP_CHARACTER_TYPE) return "IMP_CHARACTER_TYPE";
    if (name == IMP_SAMPLINGRATESELECTOR) return "IMP_SAMPLINGRATESELECTOR";
    if (name == IMP_SAMPLINGRATE) return "IMP_SAMPLINGRATE";
    if (name == IMP_UNITS_GRP) return "IMP_UNITS_GRP";
    if (name == IMP_AXISCONV_GRP) return "IMP_AXISCONV_GRP";
    if (name == IMP_CACHE_GRP) return "IMP_CACHE_GRP";
    if (name == IMP_UI) return "IMP_UI";
    if (name == IMP_FILEFORMAT) return "IMP_FILEFORMAT";
    if (name == IMP_PERF_GRP) return "IMP_PERF_GRP";
    if (name == IMP_REMOVEBADPOLYSFROMMESH) return "IMP_REMOVEBADPOLYSFROMMESH";
    if (name == IMP_META_DATA) return "IMP_META_DATA";
    if (name == IMP_FBX_EXTENTIONS_SDK_WARNING) return "IMP_FBX_EXTENTIONS_SDK_WARNING";
    if (name == IMP_SCALECONVERSION) return "IMP_SCALECONVERSION";
    // if (name == IMP_UNITS_TB) return "IMP_UNITS_TB";
    if (name == IMP_MASTERSCALE) return "IMP_MASTERSCALE";
    if (name == IMP_UNITS_SCALE) return "IMP_UNITS_SCALE";
    if (name == IMP_DYN_SCALE_CONVERSION) return "IMP_DYN_SCALE_CONVERSION";
    if (name == IMP_UNITSELECTOR) return "IMP_UNITSELECTOR";
    if (name == IMP_TOTAL_UNITS_SCALE_TB) return "IMP_TOTAL_UNITS_SCALE_TB";
    if (name == IMP_SHOW_UI_MODE) return "IMP_SHOW_UI_MODE";
    if (name == IMP_SHOW_UI_WARNING) return "IMP_SHOW_UI_WARNING";
    if (name == IMP_SHOW_WARNINGS_MANAGER) return "IMP_SHOW_WARNINGS_MANAGER";
    if (name == IMP_GENERATE_LOG_DATA) return "IMP_GENERATE_LOG_DATA";
    if (name == IMP_PLUGIN_VERSIONS_URL) return "IMP_PLUGIN_VERSIONS_URL";
    if (name == IMP_DXF) return "IMP_DXF";
    if (name == IMP_FBX) return "IMP_FBX";
    if (name == IMP_OBJ) return "IMP_OBJ";
    if (name == IMP_3DS) return "IMP_3DS";
    if (name == IMP_MOTION_BASE) return "IMP_MOTION_BASE";
    if (name == IMP_BIOVISION_BVH) return "IMP_BIOVISION_BVH";
    if (name == IMP_MOTIONANALYSIS_HTR) return "IMP_MOTIONANALYSIS_HTR";
    if (name == IMP_ACCLAIM_ASF) return "IMP_ACCLAIM_ASF";
    if (name == IMP_ACCLAIM_AMC) return "IMP_ACCLAIM_AMC";
    if (name == IMP_UNLOCK_NORMALS) return "IMP_UNLOCK_NORMALS";
    if (name == IMP_CREASE) return "IMP_CREASE";
    if (name == IMP_SMOOTHING_GROUPS) return "IMP_SMOOTHING_GROUPS";
    if (name == IMP_HARDEDGES) return "IMP_HARDEDGES";
    if (name == IMP_BLINDDATA) return "IMP_BLINDDATA";
    if (name == IMP_BONE_WIDTHHEIGHTLOCK) return "IMP_BONE_WIDTHHEIGHTLOCK";
    if (name == IMP_BONEASDUMMY) return "IMP_BONEASDUMMY";
    if (name == IMP_BONEMAX4BONEWIDTH) return "IMP_BONEMAX4BONEWIDTH";
    if (name == IMP_BONEMAX4BONEHEIGHT) return "IMP_BONEMAX4BONEHEIGHT";
    if (name == IMP_BONEMAX4BONETAPER) return "IMP_BONEMAX4BONETAPER";
    if (name == IMP_SHAPE) return "IMP_SHAPE";
    if (name == IMP_SKINS) return "IMP_SKINS";
    if (name == IMP_USEMATRIXFROMPOSE) return "IMP_USEMATRIXFROMPOSE";
    if (name == IMP_FORCEWEIGHTNORMALIZE) return "IMP_FORCEWEIGHTNORMALIZE";
    if (name == IMP_APPLYCSTKEYRED) return "IMP_APPLYCSTKEYRED";
    if (name == IMP_CSTKEYREDTPREC) return "IMP_CSTKEYREDTPREC";
    if (name == IMP_CSTKEYREDRPREC) return "IMP_CSTKEYREDRPREC";
    if (name == IMP_CSTKEYREDSPREC) return "IMP_CSTKEYREDSPREC";
    if (name == IMP_CSTKEYREDOPREC) return "IMP_CSTKEYREDOPREC";
    if (name == IMP_AUTOTANGENTSONLY) return "IMP_AUTOTANGENTSONLY";
    if (name == IMP_APPLYKEYREDUCE) return "IMP_APPLYKEYREDUCE";
    if (name == IMP_KEYREDUCEPREC) return "IMP_KEYREDUCEPREC";
    if (name == IMP_APPLYKEYSONFRM) return "IMP_APPLYKEYSONFRM";
    if (name == IMP_APPLYKEYSYNC) return "IMP_APPLYKEYSYNC";
    if (name == IMP_APPLYUNROLL) return "IMP_APPLYUNROLL";
    if (name == IMP_UNROLLPREC) return "IMP_UNROLLPREC";
    if (name == IMP_UNROLLPATH) return "IMP_UNROLLPATH";
    if (name == IMP_UNROLLFORCEAUTO) return "IMP_UNROLLFORCEAUTO";
    if (name == IMP_UP_AXIS) return "IMP_UP_AXIS";
    if (name == IMP_UP_AXIS_MAX) return "IMP_UP_AXIS_MAX";
    if (name == IMP_ZUPROTATION_MAX) return "IMP_ZUPROTATION_MAX";
    if (name == IMP_AXISCONVERSION) return "IMP_AXISCONVERSION";
    if (name == IMP_AUTO_AXIS) return "IMP_AUTO_AXIS";
    if (name == IMP_FILE_UP_AXIS) return "IMP_FILE_UP_AXIS";
    if (name == IMP_CACHE_SIZE) return "IMP_CACHE_SIZE";
    if (name == IMP_PLUGIN_UI_WIDTH) return "IMP_PLUGIN_UI_WIDTH";
    if (name == IMP_PLUGIN_UI_HEIGHT) return "IMP_PLUGIN_UI_HEIGHT";
    if (name == IMP_PRESET_SELECTED) return "IMP_PRESET_SELECTED";
    if (name == IMP_UIL) return "IMP_UIL";
    if (name == IMP_PLUGIN_PRODUCT_FAMILY) return "IMP_PLUGIN_PRODUCT_FAMILY";
    if (name == IMP_PLUGIN_UI_XPOS) return "IMP_PLUGIN_UI_XPOS";
    if (name == IMP_PLUGIN_UI_YPOS) return "IMP_PLUGIN_UI_YPOS";
    if (name == IMP_DXF_WELD_VERTICES) return "IMP_DXF_WELD_VERTICES";
    if (name == IMP_DXF_OBJECT_DERIVATION) return "IMP_DXF_OBJECT_DERIVATION";
    if (name == IMP_DXF_REFERENCE_NODE) return "IMP_DXF_REFERENCE_NODE";
    if (name == IMP_OBJ_REFERENCE_NODE) return "IMP_OBJ_REFERENCE_NODE";
    if (name == IMP_3DS_REFERENCENODE) return "IMP_3DS_REFERENCENODE";
    if (name == IMP_3DS_TEXTURE) return "IMP_3DS_TEXTURE";
    if (name == IMP_3DS_MATERIAL) return "IMP_3DS_MATERIAL";
    if (name == IMP_3DS_ANIMATION) return "IMP_3DS_ANIMATION";
    if (name == IMP_3DS_MESH) return "IMP_3DS_MESH";
    if (name == IMP_3DS_LIGHT) return "IMP_3DS_LIGHT";
    if (name == IMP_3DS_CAMERA) return "IMP_3DS_CAMERA";
    if (name == IMP_3DS_AMBIENT_LIGHT) return "IMP_3DS_AMBIENT_LIGHT";
    if (name == IMP_3DS_RESCALING) return "IMP_3DS_RESCALING";
    if (name == IMP_3DS_FILTER) return "IMP_3DS_FILTER";
    if (name == IMP_3DS_SMOOTHGROUP) return "IMP_3DS_SMOOTHGROUP";
    if (name == IMP_FBX_MODEL_COUNT) return "IMP_FBX_MODEL_COUNT";
    if (name == IMP_FBX_DEVICE_COUNT) return "IMP_FBX_DEVICE_COUNT";
    if (name == IMP_FBX_CHARACTER_COUNT) return "IMP_FBX_CHARACTER_COUNT";
    if (name == IMP_FBX_ACTOR_COUNT) return "IMP_FBX_ACTOR_COUNT";
    if (name == IMP_FBX_CONSTRAINT_COUNT) return "IMP_FBX_CONSTRAINT_COUNT";
    if (name == IMP_FBX_MEDIA_COUNT) return "IMP_FBX_MEDIA_COUNT";
    if (name == IMP_FBX_TEMPLATE) return "IMP_FBX_TEMPLATE";
    if (name == IMP_FBX_PIVOT) return "IMP_FBX_PIVOT";
    if (name == IMP_FBX_GLOBAL_SETTINGS) return "IMP_FBX_GLOBAL_SETTINGS";
    if (name == IMP_FBX_CHARACTER) return "IMP_FBX_CHARACTER";
    if (name == IMP_FBX_CONSTRAINT) return "IMP_FBX_CONSTRAINT";
    if (name == IMP_FBX_MERGE_LAYER_AND_TIMEWARP) return "IMP_FBX_MERGE_LAYER_AND_TIMEWARP";
    if (name == IMP_FBX_GOBO) return "IMP_FBX_GOBO";
    if (name == IMP_FBX_SHAPE) return "IMP_FBX_SHAPE";
    if (name == IMP_FBX_LINK) return "IMP_FBX_LINK";
    if (name == IMP_FBX_MATERIAL) return "IMP_FBX_MATERIAL";
    if (name == IMP_FBX_TEXTURE) return "IMP_FBX_TEXTURE";
    if (name == IMP_FBX_MODEL) return "IMP_FBX_MODEL";
    if (name == IMP_FBX_AUDIO) return "IMP_FBX_AUDIO";
    if (name == IMP_FBX_ANIMATION) return "IMP_FBX_ANIMATION";
    if (name == IMP_FBX_PASSWORD) return "IMP_FBX_PASSWORD";
    if (name == IMP_FBX_PASSWORD_ENABLE) return "IMP_FBX_PASSWORD_ENABLE";
    if (name == IMP_FBX_CURRENT_TAKE_NAME) return "IMP_FBX_CURRENT_TAKE_NAME";
    if (name == IMP_FBX_EXTRACT_EMBEDDED_DATA) return "IMP_FBX_EXTRACT_EMBEDDED_DATA";
    if (name == IMP_FBX_CALCULATE_LEGACY_SHAPE_NORMAL) return "IMP_FBX_CALCULATE_LEGACY_SHAPE_NORMAL";
    if (name == IMP_FBX_NORMAL) return "IMP_FBX_NORMAL";
    if (name == IMP_FBX_BINORMAL) return "IMP_FBX_BINORMAL";
    if (name == IMP_FBX_TANGENT) return "IMP_FBX_TANGENT";
    if (name == IMP_FBX_VERTEXCOLOR) return "IMP_FBX_VERTEXCOLOR";
    if (name == IMP_FBX_POLYGROUP) return "IMP_FBX_POLYGROUP";
    if (name == IMP_FBX_SMOOTHING) return "IMP_FBX_SMOOTHING";
    if (name == IMP_FBX_USERDATA) return "IMP_FBX_USERDATA";
    if (name == IMP_FBX_VISIBILITY) return "IMP_FBX_VISIBILITY";
    if (name == IMP_FBX_EDGECREASE) return "IMP_FBX_EDGECREASE";
    if (name == IMP_FBX_VERTEXCREASE) return "IMP_FBX_VERTEXCREASE";
    if (name == IMP_FBX_HOLE) return "IMP_FBX_HOLE";
    if (name == IMP_RELAXED_FBX_CHECK) return "IMP_RELAXED_FBX_CHECK";
    if (name == IMP_KEEP_PRODUCER_CAM_SRCOBJ) return "IMP_KEEP_PRODUCER_CAM_SRCOBJ";
    if (name == IMP_BUTTON_WEB_UPDATE) return "IMP_BUTTON_WEB_UPDATE";
    if (name == IMP_PI_VERSION) return "IMP_PI_VERSION";
    if (name == EXP_STATISTICS_GRP) return "EXP_STATISTICS_GRP";
    if (name == EXP_ADV_OPT_GRP) return "EXP_ADV_OPT_GRP";
    if (name == EXP_PRESETS_GRP) return "EXP_PRESETS_GRP";
    if (name == EXP_STATISTICS) return "EXP_STATISTICS";
    if (name == EXP_FIRST_TIME_RUN_NOTICE_GRP) return "EXP_FIRST_TIME_RUN_NOTICE_GRP";
    if (name == EXP_INFORMATION_GRP) return "EXP_INFORMATION_GRP";
    if (name == EXP_PLUGIN_GRP) return "EXP_PLUGIN_GRP";
    if (name == EXP_INCLUDE_GRP) return "EXP_INCLUDE_GRP";
    if (name == EXP_FBX_EXT_SDK_GRP) return "EXP_FBX_EXT_SDK_GRP";
    if (name == EXP_UNITS_GRP) return "EXP_UNITS_GRP";
    if (name == EXP_FILEFORMAT) return "EXP_FILEFORMAT";
    if (name == EXP_AXISCONV_GRP) return "EXP_AXISCONV_GRP";
    if (name == EXP_CACHE_GRP) return "EXP_CACHE_GRP";
    if (name == EXP_UI) return "EXP_UI";
    if (name == EXP_FBX_EXTENTIONS_SDK_WARNING) return "EXP_FBX_EXTENTIONS_SDK_WARNING";
    if (name == EXP_FIRST_TIME_RUN_NOTICE) return "EXP_FIRST_TIME_RUN_NOTICE";
    if (name == EXP_SCALEFACTOR) return "EXP_SCALEFACTOR";
    if (name == EXP_AXISCONVERSIONMETHOD) return "EXP_AXISCONVERSIONMETHOD";
    if (name == EXP_UPAXIS) return "EXP_UPAXIS";
    if (name == EXP_UNITS_SCALE) return "EXP_UNITS_SCALE";
    if (name == EXP_MASTERSCALE) return "EXP_MASTERSCALE";
    if (name == EXP_DYN_SCALE_CONVERSION) return "EXP_DYN_SCALE_CONVERSION";
    if (name == EXP_UNITSELECTOR) return "EXP_UNITSELECTOR";
    if (name == EXP_TOTAL_UNITS_SCALE_TB) return "EXP_TOTAL_UNITS_SCALE_TB";
    if (name == EXP_SHOW_UI_MODE) return "EXP_SHOW_UI_MODE";
    if (name == EXP_SHOW_UI_WARNING) return "EXP_SHOW_UI_WARNING";
    if (name == EXP_SHOW_WARNINGS_MANAGER) return "EXP_SHOW_WARNINGS_MANAGER";
    if (name == EXP_GENERATE_LOG_DATA) return "EXP_GENERATE_LOG_DATA";
    if (name == EXP_PLUGIN_VERSIONS_URL) return "EXP_PLUGIN_VERSIONS_URL";
    if (name == EXP_PRESETS) return "EXP_PRESETS";
    if (name == EXP_CAMERA_GRP) return "EXP_CAMERA_GRP";
    if (name == EXP_LIGHT_GRP) return "EXP_LIGHT_GRP";
    if (name == EXP_GEOMETRY) return "EXP_GEOMETRY";
    if (name == EXP_AUDIO) return "EXP_AUDIO";
    if (name == EXP_ANIMATION) return "EXP_ANIMATION";
    if (name == EXP_PIVOTTONULLS) return "EXP_PIVOTTONULLS";
    if (name == EXP_LIGHT) return "EXP_LIGHT";
    if (name == EXP_LIGHTATTENUATION) return "EXP_LIGHTATTENUATION";
    if (name == EXP_ENVIRONMENT) return "EXP_ENVIRONMENT";
    if (name == EXP_CAMERA) return "EXP_CAMERA";
    if (name == EXP_BINDPOSE) return "EXP_BINDPOSE";
    if (name == EXP_SELECTIONONLY) return "EXP_SELECTIONONLY";
    if (name == EXP_INPUTCONNECTIONS_GRP) return "EXP_INPUTCONNECTIONS_GRP";
    if (name == EXP_INPUTCONNECTIONS) return "EXP_INPUTCONNECTIONS";
    if (name == EXP_BYPASSRRSINHERITANCE) return "EXP_BYPASSRRSINHERITANCE";
    if (name == EXP_EMBEDTEXTURE_GRP) return "EXP_EMBEDTEXTURE_GRP";
    if (name == EXP_EMBEDTEXTURE) return "EXP_EMBEDTEXTURE";
    if (name == EXP_CONVERTTOTIFF) return "EXP_CONVERTTOTIFF";
    if (name == EXP_CURVEFILTERS) return "EXP_CURVEFILTERS";
    if (name == EXP_DEFORMATION) return "EXP_DEFORMATION";
    if (name == EXP_BAKECOMPLEXANIMATION) return "EXP_BAKECOMPLEXANIMATION";
    if (name == EXP_BONE) return "EXP_BONE";
    // if (name == EXP_SAMPLINGFRAMERATE) return "EXP_SAMPLINGFRAMERATE";
    if (name == EXP_POINTCACHE) return "EXP_POINTCACHE";
    if (name == EXP_SMOOTHKEYASUSER) return "EXP_SMOOTHKEYASUSER";
    if (name == EXP_EXTRA_GRP) return "EXP_EXTRA_GRP";
    if (name == EXP_REMOVE_SINGLE_KEY) return "EXP_REMOVE_SINGLE_KEY";
    if (name == EXP_NAMETAKE) return "EXP_NAMETAKE";
    if (name == EXP_QUATERNION) return "EXP_QUATERNION";
    if (name == EXP_CONSTRAINTS_GRP) return "EXP_CONSTRAINTS_GRP";
    if (name == EXP_CONSTRAINT) return "EXP_CONSTRAINT";
    if (name == EXP_CHARACTER) return "EXP_CHARACTER";
    if (name == EXP_MRCUSTOMATTRIBUTES) return "EXP_MRCUSTOMATTRIBUTES";
    if (name == EXP_MESHPRIMITIVE) return "EXP_MESHPRIMITIVE";
    if (name == EXP_MESHTRIANGLE) return "EXP_MESHTRIANGLE";
    if (name == EXP_MESHPOLY) return "EXP_MESHPOLY";
    if (name == EXP_NURB) return "EXP_NURB";
    if (name == EXP_PATCH) return "EXP_PATCH";
    if (name == EXP_BIP2FBX) return "EXP_BIP2FBX";
    if (name == EXP_GEOMNORMALPERPOLY) return "EXP_GEOMNORMALPERPOLY";
    if (name == EXP_TANGENTSPACE) return "EXP_TANGENTSPACE";
    if (name == EXP_SMOOTHMESH) return "EXP_SMOOTHMESH";
    if (name == EXP_SELECTIONSET) return "EXP_SELECTIONSET";
    if (name == EXP_FINESTSUBDIVLEVEL) return "EXP_FINESTSUBDIVLEVEL";
    if (name == EXP_MAXBONEASBONE) return "EXP_MAXBONEASBONE";
    if (name == EXP_MAXNURBSSTEP) return "EXP_MAXNURBSSTEP";
    if (name == EXP_CREASE) return "EXP_CREASE";
    if (name == EXP_BLINDDATA) return "EXP_BLINDDATA";
    if (name == EXP_NURBSSURFACEAS) return "EXP_NURBSSURFACEAS";
    if (name == EXP_SMOOTHING_GROUPS) return "EXP_SMOOTHING_GROUPS";
    if (name == EXP_HARDEDGES) return "EXP_HARDEDGES";
    if (name == EXP_ANIMATIONONLY) return "EXP_ANIMATIONONLY";
    if (name == EXP_INSTANCES) return "EXP_INSTANCES";
    if (name == EXP_CONTAINEROBJECTS) return "EXP_CONTAINEROBJECTS";
    if (name == EXP_TRIANGULATE) return "EXP_TRIANGULATE";
    if (name == EXP_EDGE_ORIENTATION) return "EXP_EDGE_ORIENTATION";
    if (name == EXP_SELECTIONSETNAMEASPOINTCACHE) return "EXP_SELECTIONSETNAMEASPOINTCACHE";
    if (name == EXP_GEOMETRYMESHPRIMITIVEAS) return "EXP_GEOMETRYMESHPRIMITIVEAS";
    if (name == EXP_GEOMETRYMESHTRIANGLEAS) return "EXP_GEOMETRYMESHTRIANGLEAS";
    if (name == EXP_GEOMETRYMESHPOLYAS) return "EXP_GEOMETRYMESHPOLYAS";
    if (name == EXP_GEOMETRYNURBSAS) return "EXP_GEOMETRYNURBSAS";
    if (name == EXP_GEOMETRYPATCHAS) return "EXP_GEOMETRYPATCHAS";
    if (name == EXP_BAKEFRAMESTART) return "EXP_BAKEFRAMESTART";
    if (name == EXP_BAKEFRAMEEND) return "EXP_BAKEFRAMEEND";
    if (name == EXP_BAKEFRAMESTEP) return "EXP_BAKEFRAMESTEP";
    if (name == EXP_BAKE_RESAMPLE_ANIMATION_CURVES) return "EXP_BAKE_RESAMPLE_ANIMATION_CURVES";
    if (name == EXP_BAKEFRAMESTARTNORESET) return "EXP_BAKEFRAMESTARTNORESET";
    if (name == EXP_BAKEFRAMEENDNORESET) return "EXP_BAKEFRAMEENDNORESET";
    if (name == EXP_BAKEFRAMESTEPNORESET) return "EXP_BAKEFRAMESTEPNORESET";
    if (name == EXP_FBX) return "EXP_FBX";
    if (name == EXP_DXF) return "EXP_DXF";
    if (name == EXP_COLLADA) return "EXP_COLLADA";
    if (name == EXP_OBJ) return "EXP_OBJ";
    if (name == EXP_3DS) return "EXP_3DS";
    if (name == EXP_MOTION_BASE) return "EXP_MOTION_BASE";
    if (name == EXP_BIOVISION_BVH) return "EXP_BIOVISION_BVH";
    if (name == EXP_ACCLAIM_ASF) return "EXP_ACCLAIM_ASF";
    if (name == EXP_ACCLAIM_AMC) return "EXP_ACCLAIM_AMC";
    if (name == EXP_ASCIIFBX) return "EXP_ASCIIFBX";
    if (name == EXP_CACHE_SIZE) return "EXP_CACHE_SIZE";
    if (name == EXP_SHAPE) return "EXP_SHAPE";
    if (name == EXP_SHAPEATTRIBUTES) return "EXP_SHAPEATTRIBUTES";
    if (name == EXP_SHAPEATTRIBUTESVALUES) return "EXP_SHAPEATTRIBUTESVALUES";
    if (name == EXP_SKINS) return "EXP_SKINS";
    if (name == EXP_APPLYCSTKEYRED) return "EXP_APPLYCSTKEYRED";
    if (name == EXP_SAMPLINGRATE) return "EXP_SAMPLINGRATE";
    if (name == EXP_CSTKEYREDTPREC) return "EXP_CSTKEYREDTPREC";
    if (name == EXP_CSTKEYREDRPREC) return "EXP_CSTKEYREDRPREC";
    if (name == EXP_CSTKEYREDSPREC) return "EXP_CSTKEYREDSPREC";
    if (name == EXP_CSTKEYREDOPREC) return "EXP_CSTKEYREDOPREC";
    if (name == EXP_AUTOTANGENTSONLY) return "EXP_AUTOTANGENTSONLY";
    if (name == EXP_APPLYKEYREDUCE) return "EXP_APPLYKEYREDUCE";
    if (name == EXP_KEYREDUCEPREC) return "EXP_KEYREDUCEPREC";
    if (name == EXP_APPLYKEYSONFRM) return "EXP_APPLYKEYSONFRM";
    if (name == EXP_APPLYKEYSYNC) return "EXP_APPLYKEYSYNC";
    if (name == EXP_APPLYUNROLL) return "EXP_APPLYUNROLL";
    if (name == EXP_UNROLLPREC) return "EXP_UNROLLPREC";
    if (name == EXP_UNROLLPATH) return "EXP_UNROLLPATH";
    if (name == EXP_UNROLLFORCEAUTO) return "EXP_UNROLLFORCEAUTO";
    if (name == EXP_PLUGIN_UI_WIDTH) return "EXP_PLUGIN_UI_WIDTH";
    if (name == EXP_PLUGIN_UI_HEIGHT) return "EXP_PLUGIN_UI_HEIGHT";
    if (name == EXP_PRESET_SELECTED) return "EXP_PRESET_SELECTED";
    if (name == EXP_UIL) return "EXP_UIL";
    if (name == EXP_PLUGIN_PRODUCT_FAMILY) return "EXP_PLUGIN_PRODUCT_FAMILY";
    if (name == EXP_PLUGIN_UI_XPOS) return "EXP_PLUGIN_UI_XPOS";
    if (name == EXP_PLUGIN_UI_YPOS) return "EXP_PLUGIN_UI_YPOS";
    if (name == EXP_BUTTON_WEB_UPDATE) return "EXP_BUTTON_WEB_UPDATE";
    if (name == EXP_PI_VERSION) return "EXP_PI_VERSION";
    if (name == EXP_BUTTON_EDIT) return "EXP_BUTTON_EDIT";
    if (name == EXP_BUTTON_OK) return "EXP_BUTTON_OK";
    if (name == EXP_BUTTON_CANCEL) return "EXP_BUTTON_CANCEL";
    if (name == EXP_MENU_EDIT_PRESET) return "EXP_MENU_EDIT_PRESET";
    if (name == EXP_MENU_SAVE_PRESET) return "EXP_MENU_SAVE_PRESET";
    if (name == EXP_USETMPFILEPERIPHERAL) return "EXP_USETMPFILEPERIPHERAL";
    if (name == EXP_CONSTRUCTIONHISTORY) return "EXP_CONSTRUCTIONHISTORY";
    if (name == EXP_COLLADA_TRIANGULATE) return "EXP_COLLADA_TRIANGULATE";
    if (name == EXP_COLLADA_SINGLEMATRIX) return "EXP_COLLADA_SINGLEMATRIX";
    if (name == EXP_COLLADA_FRAME_RATE) return "EXP_COLLADA_FRAME_RATE";
    if (name == EXP_DXF_TRIANGULATE) return "EXP_DXF_TRIANGULATE";
    if (name == EXP_DXF_DEFORMATION) return "EXP_DXF_DEFORMATION";
    if (name == EXP_OBJ_TRIANGULATE) return "EXP_OBJ_TRIANGULATE";
    if (name == EXP_OBJ_DEFORMATION) return "EXP_OBJ_DEFORMATION";
    if (name == EXP_3DS_REFERENCENODE) return "EXP_3DS_REFERENCENODE";
    if (name == EXP_3DS_TEXTURE) return "EXP_3DS_TEXTURE";
    if (name == EXP_3DS_MATERIAL) return "EXP_3DS_MATERIAL";
    if (name == EXP_3DS_ANIMATION) return "EXP_3DS_ANIMATION";
    if (name == EXP_3DS_MESH) return "EXP_3DS_MESH";
    if (name == EXP_3DS_LIGHT) return "EXP_3DS_LIGHT";
    if (name == EXP_3DS_CAMERA) return "EXP_3DS_CAMERA";
    if (name == EXP_3DS_AMBIENT_LIGHT) return "EXP_3DS_AMBIENT_LIGHT";
    if (name == EXP_3DS_RESCALING) return "EXP_3DS_RESCALING";
    if (name == EXP_3DS_TEXUVBYPOLY) return "EXP_3DS_TEXUVBYPOLY";
    if (name == EXP_FBX_TEMPLATE) return "EXP_FBX_TEMPLATE";
    if (name == EXP_FBX_PIVOT) return "EXP_FBX_PIVOT";
    if (name == EXP_FBX_GLOBAL_SETTINGS) return "EXP_FBX_GLOBAL_SETTINGS";
    if (name == EXP_FBX_CHARACTER) return "EXP_FBX_CHARACTER";
    if (name == EXP_FBX_CONSTRAINT) return "EXP_FBX_CONSTRAINT";
    if (name == EXP_FBX_GOBO) return "EXP_FBX_GOBO";
    if (name == EXP_FBX_SHAPE) return "EXP_FBX_SHAPE";
    if (name == EXP_FBX_MATERIAL) return "EXP_FBX_MATERIAL";
    if (name == EXP_FBX_TEXTURE) return "EXP_FBX_TEXTURE";
    if (name == EXP_FBX_MODEL) return "EXP_FBX_MODEL";
    if (name == EXP_FBX_AUDIO) return "EXP_FBX_AUDIO";
    if (name == EXP_FBX_ANIMATION) return "EXP_FBX_ANIMATION";
    if (name == EXP_FBX_EMBEDDED) return "EXP_FBX_EMBEDDED";
    if (name == EXP_FBX_PASSWORD) return "EXP_FBX_PASSWORD";
    if (name == EXP_FBX_PASSWORD_ENABLE) return "EXP_FBX_PASSWORD_ENABLE";
    if (name == EXP_FBX_COLLAPSE_EXTERNALS) return "EXP_FBX_COLLAPSE_EXTERNALS";
    if (name == EXP_FBX_COMPRESS_ARRAYS) return "EXP_FBX_COMPRESS_ARRAYS";
    if (name == EXP_FBX_COMPRESS_LEVEL) return "EXP_FBX_COMPRESS_LEVEL";
    if (name == EXP_FBX_COMPRESS_MINSIZE) return "EXP_FBX_COMPRESS_MINSIZE";
    if (name == EXP_FBX_EMBEDDED_PROPERTIES_SKIP) return "EXP_FBX_EMBEDDED_PROPERTIES_SKIP";
    if (name == EXP_FBX_EXPORT_FILE_VERSION) return "EXP_FBX_EXPORT_FILE_VERSION";
    if (name == IOSN_MOTION_START) return "IOSN_MOTION_START";
    if (name == IOSN_MOTION_FRAME_COUNT) return "IOSN_MOTION_FRAME_COUNT";
    if (name == IOSN_MOTION_FRAME_RATE) return "IOSN_MOTION_FRAME_RATE";
    if (name == IOSN_MOTION_ACTOR_PREFIX) return "IOSN_MOTION_ACTOR_PREFIX";
    if (name == IOSN_MOTION_RENAME_DUPLICATE_NAMES) return "IOSN_MOTION_RENAME_DUPLICATE_NAMES";
    if (name == IOSN_MOTION_EXACT_ZERO_AS_OCCLUDED) return "IOSN_MOTION_EXACT_ZERO_AS_OCCLUDED";
    if (name == IOSN_MOTION_SET_OCCLUDED_TO_LAST_VALID_POSITION) return "IOSN_MOTION_SET_OCCLUDED_TO_LAST_VALID_POSITION";
    if (name == IOSN_MOTION_AS_OPTICAL_SEGMENTS) return "IOSN_MOTION_AS_OPTICAL_SEGMENTS";
    if (name == IOSN_MOTION_ASF_SCENE_OWNED) return "IOSN_MOTION_ASF_SCENE_OWNED";
    if (name == IOSN_MOTION_MOTION_FROM_GLOBAL_POSITION) return "IOSN_MOTION_MOTION_FROM_GLOBAL_POSITION";
    if (name == IOSN_MOTION_GAPS_AS_VALID_DATA) return "IOSN_MOTION_GAPS_AS_VALID_DATA";
    if (name == IOSN_MOTION_C3D_REAL_FORMAT) return "IOSN_MOTION_C3D_REAL_FORMAT";
    if (name == IOSN_MOTION_CREATE_REFERENCE_NODE) return "IOSN_MOTION_CREATE_REFERENCE_NODE";
    if (name == IOSN_MOTION_TRANSLATION) return "IOSN_MOTION_TRANSLATION";
    if (name == IOSN_MOTION_BASE_T_IN_OFFSET) return "IOSN_MOTION_BASE_T_IN_OFFSET";
    if (name == IOSN_MOTION_BASE_R_IN_PREROTATION) return "IOSN_MOTION_BASE_R_IN_PREROTATION";
    if (name == IOSN_MOTION_DUMMY_NODES) return "IOSN_MOTION_DUMMY_NODES";
    if (name == IOSN_MOTION_LIMITS) return "IOSN_MOTION_LIMITS";
    if (name == IOSN_MOTION_FRAME_RATE_USED) return "IOSN_MOTION_FRAME_RATE_USED";
    if (name == IOSN_MOTION_FRAME_RANGE) return "IOSN_MOTION_FRAME_RANGE";
    if (name == IOSN_MOTION_WRITE_DEFAULT_AS_BASE_TR) return "IOSN_MOTION_WRITE_DEFAULT_AS_BASE_TR";
    if (name == IOSN_MOTION_UP_AXIS_USED_IN_FILE) return "IOSN_MOTION_UP_AXIS_USED_IN_FILE";
    if (name == IMP_MOB_START) return "IMP_MOB_START";
    if (name == IMP_MOB_FRAME_COUNT) return "IMP_MOB_FRAME_COUNT";
    if (name == IMP_MOB_FRAME_RATE) return "IMP_MOB_FRAME_RATE";
    if (name == IMP_MOB_ACTOR_PREFIX) return "IMP_MOB_ACTOR_PREFIX";
    if (name == IMP_MOB_RENAME_DUPLICATE_NAMES) return "IMP_MOB_RENAME_DUPLICATE_NAMES";
    if (name == IMP_MOB_EXACT_ZERO_AS_OCCLUDED) return "IMP_MOB_EXACT_ZERO_AS_OCCLUDED";
    if (name == IMP_MOB_SET_OCCLUDED_TO_LAST_VALID_POSITION) return "IMP_MOB_SET_OCCLUDED_TO_LAST_VALID_POSITION";
    if (name == IMP_MOB_AS_OPTICAL_SEGMENTS) return "IMP_MOB_AS_OPTICAL_SEGMENTS";
    if (name == IMP_MOB_ASF_SCENE_OWNED) return "IMP_MOB_ASF_SCENE_OWNED";
    if (name == IMP_MOB_UP_AXIS_USED_IN_FILE) return "IMP_MOB_UP_AXIS_USED_IN_FILE";
    if (name == IMP_ACCLAIM_AMC_CREATE_REFERENCE_NODE) return "IMP_ACCLAIM_AMC_CREATE_REFERENCE_NODE";
    if (name == IMP_ACCLAIM_AMC_MOTION_BASE_T_IN_OFFSET) return "IMP_ACCLAIM_AMC_MOTION_BASE_T_IN_OFFSET";
    if (name == IMP_ACCLAIM_AMC_MOTION_BASE_R_IN_PREROTATION) return "IMP_ACCLAIM_AMC_MOTION_BASE_R_IN_PREROTATION";
    if (name == IMP_ACCLAIM_AMC_DUMMY_NODES) return "IMP_ACCLAIM_AMC_DUMMY_NODES";
    if (name == IMP_ACCLAIM_AMC_MOTION_LIMITS) return "IMP_ACCLAIM_AMC_MOTION_LIMITS";
    if (name == IMP_ACCLAIM_ASF_CREATE_REFERENCE_NODE) return "IMP_ACCLAIM_ASF_CREATE_REFERENCE_NODE";
    if (name == IMP_ACCLAIM_ASF_MOTION_BASE_T_IN_OFFSET) return "IMP_ACCLAIM_ASF_MOTION_BASE_T_IN_OFFSET";
    if (name == IMP_ACCLAIM_ASF_MOTION_BASE_R_IN_PREROTATION) return "IMP_ACCLAIM_ASF_MOTION_BASE_R_IN_PREROTATION";
    if (name == IMP_ACCLAIM_ASF_DUMMY_NODES) return "IMP_ACCLAIM_ASF_DUMMY_NODES";
    if (name == IMP_ACCLAIM_ASF_MOTION_LIMITS) return "IMP_ACCLAIM_ASF_MOTION_LIMITS";
    if (name == IMP_BIOVISION_BVH_CREATE_REFERENCE_NODE) return "IMP_BIOVISION_BVH_CREATE_REFERENCE_NODE";
    if (name == IMP_MOTIONANALYSIS_HTR_CREATE_REFERENCE_NODE) return "IMP_MOTIONANALYSIS_HTR_CREATE_REFERENCE_NODE";
    if (name == IMP_MOTIONANALYSIS_HTR_MOTION_BASE_T_IN_OFFSET) return "IMP_MOTIONANALYSIS_HTR_MOTION_BASE_T_IN_OFFSET";
    if (name == IMP_MOTIONANALYSIS_HTR_MOTION_BASE_R_IN_PREROTATION) return "IMP_MOTIONANALYSIS_HTR_MOTION_BASE_R_IN_PREROTATION";
    if (name == EXP_MOB_START) return "EXP_MOB_START";
    if (name == EXP_MOB_FRAME_COUNT) return "EXP_MOB_FRAME_COUNT";
    if (name == EXP_MOB_FROM_GLOBAL_POSITION) return "EXP_MOB_FROM_GLOBAL_POSITION";
    if (name == EXP_MOB_FRAME_RATE) return "EXP_MOB_FRAME_RATE";
    if (name == EXP_MOB_GAPS_AS_VALID_DATA) return "EXP_MOB_GAPS_AS_VALID_DATA";
    if (name == EXP_MOB_C3D_REAL_FORMAT) return "EXP_MOB_C3D_REAL_FORMAT";
    if (name == EXP_MOB_ASF_SCENE_OWNED) return "EXP_MOB_ASF_SCENE_OWNED";
    if (name == EXP_ACCLAIM_AMC_MOTION_TRANSLATION) return "EXP_ACCLAIM_AMC_MOTION_TRANSLATION";
    if (name == EXP_ACCLAIM_AMC_FRAME_RATE_USED) return "EXP_ACCLAIM_AMC_FRAME_RATE_USED";
    if (name == EXP_ACCLAIM_AMC_FRAME_RANGE) return "EXP_ACCLAIM_AMC_FRAME_RANGE";
    if (name == EXP_ACCLAIM_AMC_WRITE_DEFAULT_AS_BASE_TR) return "EXP_ACCLAIM_AMC_WRITE_DEFAULT_AS_BASE_TR";
    if (name == EXP_ACCLAIM_ASF_MOTION_TRANSLATION) return "EXP_ACCLAIM_ASF_MOTION_TRANSLATION";
    if (name == EXP_ACCLAIM_ASF_FRAME_RATE_USED) return "EXP_ACCLAIM_ASF_FRAME_RATE_USED";
    if (name == EXP_ACCLAIM_ASF_FRAME_RANGE) return "EXP_ACCLAIM_ASF_FRAME_RANGE";
    if (name == EXP_ACCLAIM_ASF_WRITE_DEFAULT_AS_BASE_TR) return "EXP_ACCLAIM_ASF_WRITE_DEFAULT_AS_BASE_TR";
    if (name == EXP_BIOVISION_BVH_MOTION_TRANSLATION) return "EXP_BIOVISION_BVH_MOTION_TRANSLATION";
    return "<unknown>";
}

void PrintPropertyID(FbxProperty* prop)
{
    PrintPropertyID(prop, false);
}
void PrintPropertyID(FbxProperty* prop, bool hierName)
{
    if (prop == NULL)
        cout << "<<null>>";
    else if (!prop->IsValid())
    {
        cout << "<<invalid>>";
    }
    else
    {
        FbxObject* pobj = prop->GetFbxObject();
        PrintObjectID(pobj);
        cout << " -> " ;
        if (hierName)
        {
            FbxString hierName = prop->GetHierarchicalName();
            cout << quote(hierName);
            cout << " (" << quote(translate_hier_name(hierName)) << ")";
        }
        else
            cout << quote(prop->GetName());
        cout << " lb=\"" << quote(prop->GetLabel()) << "\"";
        cout << " : " << prop->GetPropertyDataType();
    }
}

void PrintObject(FbxObject* obj, bool branch, bool printProperties)
{
    cout << "$"; PrintObjectID(obj); cout << endl;  // extra $ for easy text search
    cout << "    Name = " << quote(obj->GetName()) << endl;
    cout << "      GetNameWithoutNameSpacePrefix = " << quote(obj->GetNameWithoutNameSpacePrefix()) << endl;
    cout << "      GetNameWithNameSpacePrefix = " << quote(obj->GetNameWithNameSpacePrefix()) << endl;
    cout << "      GetInitialName = " << quote(obj->GetInitialName()) << endl;
    cout << "      GetNameSpaceOnly = " << quote(obj->GetNameSpaceOnly()) << endl;
    FbxArray<FbxString*> namespaces = obj->GetNameSpaceArray(':');
    cout << "      GetNameSpaceArray (" << namespaces.GetCount() << ")" << endl;
    int i;
    for (i = 0; i < namespaces.GetCount(); i++)
    {
        FbxString* ns = namespaces.GetAt(i);
        cout << "        # " << i << " " << quote(*ns) << endl;
    }
    cout << "      GetNameOnly = " << quote(obj->GetNameOnly()) << endl;
    cout << "      GetNameSpacePrefix = " << quote(obj->GetNameSpacePrefix()) << endl;
    cout << "    ClassId = " << obj->GetRuntimeClassId().GetName() << endl;
    cout << "    UniqueId = " << obj->GetUniqueID() << endl;
    cout << "    GetScene() = "; PrintObjectID(obj->GetScene()); cout << endl;
    cout << "    GetDocument() = "; PrintObjectID(obj->GetDocument()); cout << endl;
    cout << "    GetRootDocument() = "; PrintObjectID(obj->GetRootDocument()); cout << endl;

    if (printProperties)
    {
        cout << "    SrcObjectCount = " << obj->GetSrcObjectCount() << endl;
        for (i = 0; i < obj->GetSrcObjectCount(); i++)
        {
            FbxObject* srcObj = obj->GetSrcObject(i);
            cout << "        #" << i << " ";
            PrintObjectID(srcObj);
            cout << endl;
        }
        cout << "    DstObjectCount = " << obj->GetDstObjectCount() << endl;
        for (i = 0; i < obj->GetDstObjectCount(); i++)
        {
            FbxObject* dstObj = obj->GetDstObject(i);
            cout << "        #" << i << " ";
            PrintObjectID(dstObj);
            cout << endl;
        }

        FbxProperty prop = obj->GetFirstProperty();
        int n = 0;
        while (prop.IsValid())
        {
            n++;
            prop = obj->GetNextProperty(prop);
        }
        cout << "    Properties " << n << endl;

        prop = obj->GetFirstProperty();
        n = 0;
        while (prop.IsValid())
        {
            cout << "        #" << n << " ";
            PrintPropertyID(&prop); cout << endl;
            PrintProperty(&prop, true);
            n++;
            prop = obj->GetNextProperty(prop);
        }

        cout << "    SrcPropertyCount = " << obj->GetSrcPropertyCount() << endl;
        for (i = 0; i < obj->GetSrcPropertyCount(); i++)
        {
            FbxProperty prop = obj->GetSrcProperty(i);
            cout << "        #" << i << " ";
            PrintPropertyID(&prop);
            cout << endl;
        }
        cout << "    DstPropertyCount = " << obj->GetDstPropertyCount() << endl;
        for (i = 0; i < obj->GetDstPropertyCount(); i++)
        {
            FbxProperty prop = obj->GetDstProperty(i);
            cout << "        #" << i << " ";
            PrintPropertyID(&prop);
            cout << endl;
        }
        if (obj->RootProperty.IsValid())
        {
            cout << "    RootProperty ";
            PrintPropertyID(&obj->RootProperty); cout << endl;
            PrintProperty(&obj->RootProperty);
        }
    }

    if (branch)
    {
        if (obj->Is<FbxCollection>())
            PrintCollection(FbxCast<FbxCollection>(obj));
        else if (obj->Is<FbxAnimCurve>())
            PrintAnimCurve(FbxCast<FbxAnimCurve>(obj));
        else if (obj->Is<FbxAnimCurveNode>())
            PrintAnimCurveNode(FbxCast<FbxAnimCurveNode>(obj));
        else if (obj->Is<FbxDeformer>())
            PrintDeformer(FbxCast<FbxDeformer>(obj));
        else if (obj->Is<FbxNode>())
            PrintNode(FbxCast<FbxNode>(obj));
        else if (obj->Is<FbxNodeAttribute>())
            PrintNodeAttribute(FbxCast<FbxNodeAttribute>(obj));
        else if (obj->Is<FbxPose>())
            PrintPose(FbxCast<FbxPose>(obj));
        else if (obj->Is<FbxSubDeformer>())
            PrintSubDeformer(FbxCast<FbxSubDeformer>(obj));
        else if (obj->Is<FbxSurfaceMaterial>())
            PrintSurfaceMaterial(FbxCast<FbxSurfaceMaterial>(obj));
        else if (obj->Is<FbxTexture>())
            PrintTexture(FbxCast<FbxTexture>(obj));
        else if (obj->Is<FbxVideo>())
            PrintVideo(FbxCast<FbxVideo>(obj));
        else if (obj->Is<FbxGlobalSettings>())
            PrintGlobalSettings(FbxCast<FbxGlobalSettings>(obj));
        else
            cout << "Unknown object class: " << obj->GetRuntimeClassId().GetName() << endl;
    }

    cout << endl;
}



void PrintScene(FbxScene* scene)
{
    int i;

    cout << "    GenericNodeCount = " << scene->GetGenericNodeCount() << endl;
    cout << "    CharacterCount = " << scene->GetCharacterCount() << endl;
    cout << "    CharacterPoseCount = " << scene->GetCharacterPoseCount() << endl;
    cout << "    PoseCount = " << scene->GetPoseCount() << endl;
    for (i = 0; i < scene->GetPoseCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetPose(i));
        cout << endl;
    }
    cout << "    MaterialCount = " << scene->GetMaterialCount() << endl;
    for (i = 0; i < scene->GetMaterialCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetMaterial(i));
        cout << endl;
    }
    cout << "    TextureCount = " << scene->GetTextureCount() << endl;
    for (i = 0; i < scene->GetTextureCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetTexture(i));
        cout << endl;
    }
    cout << "    NodeCount = " << scene->GetNodeCount() << endl;
    for (i = 0; i < scene->GetNodeCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetNode(i));
        cout << endl;
    }
    cout << "    GeometryCount = " << scene->GetGeometryCount() << endl;
    for (i = 0; i < scene->GetGeometryCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetGeometry(i));
        cout << endl;
    }
    cout << "    VideoCount = " << scene->GetVideoCount() << endl;
    for (i = 0; i < scene->GetVideoCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(scene->GetVideo(i));
        cout << endl;
    }

    cout << "    RootNode ";
    PrintObjectID(scene->GetRootNode());
    cout << endl;

    cout << "    GetCurrentAnimationStack() = ";
    PrintObjectID(scene->GetCurrentAnimationStack());
    cout << endl;
}

void PrintAnimLayer(FbxAnimLayer* al)
{
    cout << "        Weight: " << al->Weight.Get() << endl;
    cout << "        Mute: " << al->Mute.Get() << endl;
    cout << "        Solo: " << al->Solo.Get() << endl;
    cout << "        Lock: " << al->Lock.Get() << endl;
    cout << "        Color: " << al->Color.Get() << endl;
    //cout << "        BlendMode: " << al->BlendMode.Get() << endl;
    //cout << "        RotationAccumulationMode: " << al->RotationAccumulationMode.Get() << endl;
    //cout << "        ScaleAccumulationMode: " << al->ScaleAccumulationMode.Get() << endl;

    // blend mode bypass
}

void PrintAnimStack(FbxAnimStack* animStack)
{
    cout << "    GetLocalTimeSpan() = " << animStack->GetLocalTimeSpan() << endl;
    cout << "    GetReferenceTimeSpan() = " << animStack->GetReferenceTimeSpan() << endl;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::ETangentMode& value)

{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eTangentAuto) == FbxAnimCurveDef::eTangentAuto) os << "eTangentAuto";
    if ((value & FbxAnimCurveDef::eTangentTCB) == FbxAnimCurveDef::eTangentTCB) os << "eTangentTCB";
    if ((value & FbxAnimCurveDef::eTangentUser) == FbxAnimCurveDef::eTangentUser) os << "eTangentUser";
    if ((value & FbxAnimCurveDef::eTangentGenericBreak) == FbxAnimCurveDef::eTangentGenericBreak) os << "eTangentGenericBreak";
    if ((value & FbxAnimCurveDef::eTangentBreak) == FbxAnimCurveDef::eTangentBreak) os << "eTangentBreak";
    if ((value & FbxAnimCurveDef::eTangentAutoBreak) == FbxAnimCurveDef::eTangentAutoBreak) os << "eTangentAutoBreak";
    if ((value & FbxAnimCurveDef::eTangentGenericClamp) == FbxAnimCurveDef::eTangentGenericClamp) os << "eTangentGenericClamp";
    if ((value & FbxAnimCurveDef::eTangentGenericTimeIndependent) == FbxAnimCurveDef::eTangentGenericTimeIndependent) os << "eTangentGenericTimeIndependent";
    if ((value & FbxAnimCurveDef::eTangentGenericClampProgressive) == FbxAnimCurveDef::eTangentGenericClampProgressive) os << "eTangentGenericClampProgressive";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EInterpolationType& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eInterpolationConstant) == FbxAnimCurveDef::eInterpolationConstant) os << "eInterpolationConstant";
    if ((value & FbxAnimCurveDef::eInterpolationLinear) == FbxAnimCurveDef::eInterpolationLinear) os << "eInterpolationLinear";
    if ((value & FbxAnimCurveDef::eInterpolationCubic) == FbxAnimCurveDef::eInterpolationCubic) os << "eInterpolationCubic";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EWeightedMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eWeightedAll) == FbxAnimCurveDef::eWeightedAll)
    {
        os << "eWeightedAll";
    }
    else if ((value & FbxAnimCurveDef::eWeightedRight) == FbxAnimCurveDef::eWeightedRight)
    {
        os << "eWeightedRight";
    }
    else if ((value & FbxAnimCurveDef::eWeightedNextLeft) == FbxAnimCurveDef::eWeightedNextLeft)
    {
        os << "eWeightedNextLeft";
    }
    else
    {
        os << "eWeightedNone";
    }
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EConstantMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eConstantNext) == FbxAnimCurveDef::eConstantNext) os << "eConstantNext";
    else os << "eConstantStandard";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EVelocityMode& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eVelocityAll) == FbxAnimCurveDef::eVelocityAll) os << "eVelocityAll";
    else if ((value & FbxAnimCurveDef::eVelocityRight) == FbxAnimCurveDef::eVelocityRight) os << "eVelocityRight";
    else if ((value & FbxAnimCurveDef::eVelocityNextLeft) == FbxAnimCurveDef::eVelocityNextLeft) os << "eVelocityNextLeft";
    else os << "eVelocityNone";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::ETangentVisibility& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eTangentShowBoth) == FbxAnimCurveDef::eTangentShowBoth) os << "eTangentShowBoth";
    else if ((value & FbxAnimCurveDef::eTangentShowLeft) == FbxAnimCurveDef::eTangentShowLeft) os << "eTangentShowLeft";
    else if ((value & FbxAnimCurveDef::eTangentShowRight) == FbxAnimCurveDef::eTangentShowRight) os << "eTangentShowRight";
    else os << "eTangentShowNone";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAnimCurveDef::EDataIndex& value)
{
//    os << (int)value << ":";
    if ((value & FbxAnimCurveDef::eRightSlope) == FbxAnimCurveDef::eRightSlope) os << "eRightSlope";
    if ((value & FbxAnimCurveDef::eNextLeftSlope) == FbxAnimCurveDef::eNextLeftSlope) os << "eNextLeftSlope";
    if ((value & FbxAnimCurveDef::eWeights) == FbxAnimCurveDef::eWeights) os << "eWeights";
    //if ((value & FbxAnimCurveDef::eRightWeight) == FbxAnimCurveDef::eRightWeight) os << "eRightWeight";
    if ((value & FbxAnimCurveDef::eNextLeftWeight) == FbxAnimCurveDef::eNextLeftWeight) os << "eNextLeftWeight";
    if ((value & FbxAnimCurveDef::eVelocity) == FbxAnimCurveDef::eVelocity) os << "eVelocity";
    //if ((value & FbxAnimCurveDef::eRightVelocity) == FbxAnimCurveDef::eRightVelocity) os << "eRightVelocity";
    if ((value & FbxAnimCurveDef::eNextLeftVelocity) == FbxAnimCurveDef::eNextLeftVelocity) os << "eNextLeftVelocity";
    //if ((value & FbxAnimCurveDef::eTCBTension) == FbxAnimCurveDef::eTCBTension) os << "eTCBTension";
    //if ((value & FbxAnimCurveDef::eTCBContinuity) == FbxAnimCurveDef::eTCBContinuity) os << "eTCBContinuity";
    //if ((value & FbxAnimCurveDef::eTCBBias) == FbxAnimCurveDef::eTCBBias) os << "eTCBBias";
    return os;
}

std::ostream& operator<<(std::ostream& os, FbxAnimCurveKey& value)
{
    os << value.GetValue() << ", "
        << value.GetInterpolation() << ", "
        << value.GetTangentMode() << ", "
        << value.GetTangentWeightMode() << ", "
        << value.GetTangentVelocityMode() << ", "
        << value.GetConstantMode() << ", "
        << value.GetTangentVisibility() << ", "
        << "Break: " << value.GetBreak() << ", "
        << "DataFloat: "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)0) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)1) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)2) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)3) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)4) << ", "
            << value.GetDataFloat((FbxAnimCurveDef::EDataIndex)5);
    return os;
}

void PrintAnimCurveKey(int i, FbxTime time, FbxAnimCurveKey key)
{
    cout << "        #" << i << ": " << time << ", " << key << endl;
    if (time != key.GetTime())
    {
        cout << "-------- times don't match: " << time << " != " << key.GetTime() << endl;
    }
}

bool PrintAllCurveKeys = false;

void PrintAnimCurve(FbxAnimCurve* animCurve)
{
    cout << "    KeyGetCount() = " << animCurve->KeyGetCount() << endl;
    if (animCurve->KeyGetCount() <= 6 || PrintAllCurveKeys)
    {
        int i;
        for (i = 0; i < animCurve->KeyGetCount(); i++)
        {
            PrintAnimCurveKey(i, animCurve->KeyGetTime(i), animCurve->KeyGet(i));
        }
    }
    else
    {
        int i;
        for (i = 0; i < 3; i++)
        {
            PrintAnimCurveKey(i, animCurve->KeyGetTime(i), animCurve->KeyGet(i));
        }
        cout << "        ..." << endl;
        for (i = animCurve->KeyGetCount() - 3; i < animCurve->KeyGetCount(); i++)
        {
            PrintAnimCurveKey(i, animCurve->KeyGetTime(i), animCurve->KeyGet(i));
        }
    }
}

void PrintAnimCurveNode(FbxAnimCurveNode* animCurveNode)
{
    cout << "    IsAnimated(pRecurse: false) = " << animCurveNode->IsAnimated(false) << endl;
    cout << "    IsAnimated(pRecurse: true) = " << animCurveNode->IsAnimated(true) << endl;
    FbxTimeSpan interval;
    animCurveNode->GetAnimationInterval(interval);
    cout << "    GetAnimationInterval() = " << interval << endl;
    cout << "    IsComposite() = " << animCurveNode->IsComposite() << endl;
    cout << "    GetChannelsCount() = " << animCurveNode->GetChannelsCount() << endl;
    int i;
    int j;
    for (i = 0; i < animCurveNode->GetChannelsCount(); i++)
    {
        cout << "        #" << i << ": " << quote(animCurveNode->GetChannelName(i).Buffer()) << endl;
        cout << "            GetCurveCount() = " << animCurveNode->GetCurveCount(i) << endl;
        for (j = 0; j < animCurveNode->GetCurveCount(i); j++)
        {
            cout << "                #" << j << ": ";
            PrintObjectID(animCurveNode->GetCurve(i, j));
            cout << endl;
        }
    }
}

void PrintDeformer(FbxDeformer* deformer)
{
    cout << "PrintDeformer: Not Implemented" << endl;
}

const char* ToString(const FbxTransform::EInheritType& value)
{
    switch (value)
    {
        case FbxTransform::eInheritRrSs:    return "eInheritRrSs";
        case FbxTransform::eInheritRSrs:    return "eInheritRSrs";
        case FbxTransform::eInheritRrs:     return "eInheritRrs";
    }

    return "<<unknown EInheritType>>";
}

ostream& operator<<(ostream& os, const FbxTransform::EInheritType& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const EFbxQuatInterpMode& value)
{
    switch (value)
    {
        case eQuatInterpOff:              return "eQuatInterpOff";
        case eQuatInterpClassic:          return "eQuatInterpClassic";
        case eQuatInterpSlerp:            return "eQuatInterpSlerp";
        case eQuatInterpCubic:            return "eQuatInterpCubic";
        case eQuatInterpTangentDependent: return "eQuatInterpTangentDependent";
        case eQuatInterpCount:            return "eQuatInterpCount";
    }

    return "<<unknown EFbxQuatInterpMode>>";
}

ostream& operator<<(ostream& os, const EFbxQuatInterpMode& value)
{
    os << ToString(value);
    return os;
}

const char* ToString(const EFbxRotationOrder& value)
{
    switch (value)
    {
        case eEulerXYZ:   return "eEulerXYZ";
        case eEulerXZY:   return "eEulerXZY";
        case eEulerYZX:   return "eEulerYZX";
        case eEulerYXZ:   return "eEulerYXZ";
        case eEulerZXY:   return "eEulerZXY";
        case eEulerZYX:   return "eEulerZYX";
        case eSphericXYZ: return "eSphericXYZ";
    }

    return "<<unknown EFbxRotationOrder>>";
}

ostream& operator<<(ostream& os, const EFbxRotationOrder& value)
{
    os << ToString(value);
    return os;
}

ostream& operator<<(ostream& os, const FbxObject*& value)
{
    if (value == NULL)
        os << "<<null>>";
    else
        os <<
            value->GetUniqueID() << ", " <<
            value->GetRuntimeClassId().GetName() << ", " <<
            value->GetName();
    return os;
}


const char* ToString(const FbxNode::EShadingMode& value)
{
    switch (value)
    {
        case FbxNode::eHardShading:    return "eHardShading";
        case FbxNode::eWireFrame:      return "eWireFrame";
        case FbxNode::eFlatShading:    return "eFlatShading";
        case FbxNode::eLightShading:   return "eLightShading";
        case FbxNode::eTextureShading: return "eTextureShading";
        case FbxNode::eFullShading:    return "eFullShading";
    }

    return "<<unknown EShadingMode>>";
}

ostream& operator<<(ostream& os, const FbxNode::EShadingMode& value)
{
    os << ToString(value);
    return os;
}

void PrintNode(FbxNode* node)
{

    cout << "    Parent = ";
    PrintObjectID(node->GetParent());
    cout << endl;

    cout << "    ChildCount " << node->GetChildCount() << endl;
    int i;
    for (i = 0; i < node->GetChildCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(node->GetChild(i));
        cout << endl;
    }

    cout << "    Target = ";
    PrintObjectID(node->GetTarget());
    cout << endl;
    cout << "    PostTargetRotation = " << node->GetPostTargetRotation() << endl;
    cout << "    TargetUp = ";
    PrintObjectID(node->GetTargetUp());
    cout << endl;
    cout << "    TargetUpVector = " << node->GetTargetUpVector() << endl;

    cout << "    NodeAttribute = ";
    PrintObjectID(node->GetNodeAttribute());
    cout << endl;
    cout << "    NumNodeAttributes = " << node->GetNodeAttributeCount() << endl;

    FbxTransform::EInheritType inhtype;
    node->GetTransformationInheritType(inhtype);
    cout << "    TransformationInheritType = " << inhtype << endl;

    cout << "    GetCharacterLinkCount() = " << node->GetCharacterLinkCount() << endl;

    cout << "    GetMaterialCount() = " << node->GetMaterialCount() << endl;
    for (i = 0; i < node->GetMaterialCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(node->GetMaterial(i));
        cout << endl;
    }

    cout << "    LclTranslation = " << node->LclTranslation.Get() << endl;
    cout << "    LclRotation = " << node->LclRotation.Get() << endl;
    cout << "    LclScaling = " << node->LclScaling.Get() << endl;
    cout << "    Visibility = " << node->Visibility.Get() << endl;
    cout << "    VisibilityInheritance = " << node->VisibilityInheritance.Get() << endl;
    cout << "    QuaternionInterpolate = " << node->QuaternionInterpolate.Get() << endl;
    cout << "    RotationOffset = " << node->RotationOffset.Get() << endl;
    cout << "    RotationPivot = " << node->RotationPivot.Get() << endl;
    cout << "    ScalingOffset = " << node->ScalingOffset.Get() << endl;
    cout << "    ScalingPivot = " << node->ScalingPivot.Get() << endl;
    cout << "    TranslationActive = " << node->TranslationActive.Get() << endl;
    cout << "    TranslationMin = " << node->TranslationMin.Get() << endl;
    cout << "    TranslationMax = " << node->TranslationMax.Get() << endl;
    cout << "    TranslationMinX = " << node->TranslationMinX.Get() << endl;
    cout << "    TranslationMinY = " << node->TranslationMinY.Get() << endl;
    cout << "    TranslationMinZ = " << node->TranslationMinZ.Get() << endl;
    cout << "    TranslationMaxX = " << node->TranslationMaxX.Get() << endl;
    cout << "    TranslationMaxY = " << node->TranslationMaxY.Get() << endl;
    cout << "    TranslationMaxZ = " << node->TranslationMaxZ.Get() << endl;
    cout << "    RotationOrder = " << node->RotationOrder.Get() << endl;
    cout << "    RotationSpaceForLimitOnly = " << node->RotationSpaceForLimitOnly.Get() << endl;
    cout << "    RotationStiffnessX = " << node->RotationStiffnessX.Get() << endl;
    cout << "    RotationStiffnessY = " << node->RotationStiffnessY.Get() << endl;
    cout << "    RotationStiffnessZ = " << node->RotationStiffnessZ.Get() << endl;
    cout << "    AxisLen = " << node->AxisLen.Get() << endl;
    cout << "    PreRotation = " << node->PreRotation.Get() << endl;
    cout << "    PostRotation = " << node->PostRotation.Get() << endl;
    cout << "    RotationActive = " << node->RotationActive.Get() << endl;
    cout << "    RotationMin = " << node->RotationMin.Get() << endl;
    cout << "    RotationMax = " << node->RotationMax.Get() << endl;
    cout << "    RotationMinX = " << node->RotationMinX.Get() << endl;
    cout << "    RotationMinY = " << node->RotationMinY.Get() << endl;
    cout << "    RotationMinZ = " << node->RotationMinZ.Get() << endl;
    cout << "    RotationMaxX = " << node->RotationMaxX.Get() << endl;
    cout << "    RotationMaxY = " << node->RotationMaxY.Get() << endl;
    cout << "    RotationMaxZ = " << node->RotationMaxZ.Get() << endl;
    cout << "    InheritType = " << node->InheritType.Get() << endl;
    cout << "    ScalingActive = " << node->ScalingActive.Get() << endl;
    cout << "    ScalingMin = " << node->ScalingMin.Get() << endl;
    cout << "    ScalingMax = " << node->ScalingMax.Get() << endl;
    cout << "    ScalingMinX = " << node->ScalingMinX.Get() << endl;
    cout << "    ScalingMinY = " << node->ScalingMinY.Get() << endl;
    cout << "    ScalingMinZ = " << node->ScalingMinZ.Get() << endl;
    cout << "    ScalingMaxX = " << node->ScalingMaxX.Get() << endl;
    cout << "    ScalingMaxY = " << node->ScalingMaxY.Get() << endl;
    cout << "    ScalingMaxZ = " << node->ScalingMaxZ.Get() << endl;
    cout << "    GeometricTranslation = " << node->GeometricTranslation.Get() << endl;
    cout << "    GeometricRotation = " << node->GeometricRotation.Get() << endl;
    cout << "    GeometricScaling = " << node->GeometricScaling.Get() << endl;
    cout << "    MinDampRangeX = " << node->MinDampRangeX.Get() << endl;
    cout << "    MinDampRangeY = " << node->MinDampRangeY.Get() << endl;
    cout << "    MinDampRangeZ = " << node->MinDampRangeZ.Get() << endl;
    cout << "    MaxDampRangeX = " << node->MaxDampRangeX.Get() << endl;
    cout << "    MaxDampRangeY = " << node->MaxDampRangeY.Get() << endl;
    cout << "    MaxDampRangeZ = " << node->MaxDampRangeZ.Get() << endl;
    cout << "    MinDampStrengthX = " << node->MinDampStrengthX.Get() << endl;
    cout << "    MinDampStrengthY = " << node->MinDampStrengthY.Get() << endl;
    cout << "    MinDampStrengthZ = " << node->MinDampStrengthZ.Get() << endl;
    cout << "    MaxDampStrengthX = " << node->MaxDampStrengthX.Get() << endl;
    cout << "    MaxDampStrengthY = " << node->MaxDampStrengthY.Get() << endl;
    cout << "    MaxDampStrengthZ = " << node->MaxDampStrengthZ.Get() << endl;
    cout << "    PreferedAngleX = " << node->PreferedAngleX.Get() << endl;
    cout << "    PreferedAngleY = " << node->PreferedAngleY.Get() << endl;
    cout << "    PreferedAngleZ = " << node->PreferedAngleZ.Get() << endl;
    cout << "    LookAtProperty = " << node->LookAtProperty.Get() << endl;
    cout << "    UpVectorProperty = " << node->UpVectorProperty.Get() << endl;
    cout << "    Show = " << node->Show.Get() << endl;
    cout << "    NegativePercentShapeSupport = " << node->NegativePercentShapeSupport.Get() << endl;
    cout << "    DefaultAttributeIndex = " << node->DefaultAttributeIndex.Get() << endl;
    cout << "    Freeze = " << node->Freeze.Get() << endl;
    cout << "    LODBox = " << node->LODBox.Get() << endl;

    cout << "    GetVisibility() = " << node->GetVisibility() << endl;
    cout << "    GetShadingMode() = " << node->GetShadingMode() << endl;

    // pivot management
    //throw "Not Implemented";

}

void PrintNodeAttribute(FbxNodeAttribute* obj)
{
    if (obj->Is<FbxCamera>())
        PrintCamera(FbxCast<FbxCamera>(obj));
    else if (obj->Is<FbxLight>())
        PrintLight(FbxCast<FbxLight>(obj));
    else if (obj->Is<FbxLayerContainer>())
        PrintLayerContainer(FbxCast<FbxLayerContainer>(obj));
    else if (obj->Is<FbxNull>())
        PrintNull(FbxCast<FbxNull>(obj));
    else if (obj->Is<FbxSkeleton>())
        PrintSkeleton(FbxCast<FbxSkeleton>(obj));
    else
        cout << "Unknown node attribute class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintCamera(FbxCamera* camera)
{
    cout << "PrintCamera: Not Implemented" << endl;
}

void PrintLight(FbxLight* light)
{
    cout << "PrintLight: Not Implemented" << endl;
}

void PrintLayerContainer(FbxLayerContainer* layerContainer)
{
    cout << "    GetLayerCount() = " << layerContainer->GetLayerCount() << endl;
    int i;
    for (i = 0; i < layerContainer->GetLayerCount(); i++)
    {
        cout << "        #" << i << " " << endl;
        PrintLayer(layerContainer->GetLayer(i));
    }

    if (layerContainer->Is<FbxGeometryBase>())
        PrintGeometryBase(FbxCast<FbxGeometryBase>(layerContainer));
    else
        cout << "Unknown node attribute class: " << layerContainer->GetRuntimeClassId().GetName() << endl;
}



ostream& operator<<(ostream& os, const FbxLayerElement::EMappingMode& value)
{
    switch (value)
    {
    case FbxLayerElement::eNone: os << "eNone"; break;
    case FbxLayerElement::eByControlPoint: os << "eByControlPoint"; break;
    case FbxLayerElement::eByPolygonVertex: os << "eByPolygonVertex"; break;
    case FbxLayerElement::eByPolygon: os << "eByPolygon"; break;
    case FbxLayerElement::eByEdge: os << "eByEdge"; break;
    case FbxLayerElement::eAllSame:  os << "eAllSame"; break;
    default:
        os << "<<unknown>>";
        break;
    }
    return os;
}
ostream& operator<<(ostream& os, const FbxLayerElement::EReferenceMode& value)
{
    switch (value)
    {
    case FbxLayerElement::eDirect: os << "eDirect"; break;
    case FbxLayerElement::eIndex: os << "eIndex"; break;
    case FbxLayerElement::eIndexToDirect: os << "eIndexToDirect"; break;
    default:
        os << "<<unknown>>";
        break;
    }
    return os;
}

std::string ToString(const FbxLayerElement* value)
{
    std::string s;
    if (value == NULL)
       s = "<<null>>";
    else
    {
        stringstream ss;
        ss <<
            value->GetName() << ", " <<
            value->GetMappingMode() << ", " <<
            value->GetReferenceMode();
        s = ss.str();
    }
    return s;
}

void PrintLayerTextures(FbxLayerElementTexture* tex, const char* type)
{
    cout << "            GetTextures(" << type << ") = " << ToString(tex) << endl;

    if (tex == NULL) return;

    int i;
    FbxLayerElementArrayTemplate<FbxTexture*>& tarray = tex->GetDirectArray();
    for (i = 0; i < tarray.GetCount(); i++)
    {
        cout << "                #" << i << " ";
        PrintObjectID(tarray.GetAt(i));
        cout << endl;
    }
}

void PrintLayer(FbxLayer* layer)
{
    cout << "            GetNormals() = " << ToString(layer->GetNormals()) << endl;
    cout << "            GetTangents() = " << ToString(layer->GetTangents()) << endl;
    cout << "            GetBinormals() = " << ToString(layer->GetBinormals()) << endl;

    FbxLayerElementMaterial* mats = layer->GetMaterials();
    cout << "            GetMaterials() = " << ToString(mats) << endl;
    int i;
    if (mats != NULL)
    {
        FbxLayerElementTemplate<FbxSurfaceMaterial*>* _mats = mats;
        FbxLayerElementArrayTemplate<FbxSurfaceMaterial*>& marray = _mats->GetDirectArray();
        for (i = 0; i < marray.GetCount(); i++)
        {
            cout << "                #" << i << " ";
            PrintObjectID(marray.GetAt(i));
            cout << endl;
        }
    }

    cout << "            GetPolygonGroups() = " << ToString(layer->GetPolygonGroups()) << endl;
    cout << "            GetUVs() = " << ToString(layer->GetUVs()) << endl;
    cout << "            GetUVSetCount() = " << layer->GetUVSetCount() << endl;
//    cout << "            GetUVSetChannels() = " << ToString(layer->GetUVSetChannels()) << endl;
//    cout << "            GetUVSets() = " << ToString(layer->GetUVSets()) << endl;
    cout << "            GetVertexColors() = " << ToString(layer->GetVertexColors()) << endl;
    FbxLayerElementVertexColor* le = layer->GetVertexColors();
    if (le != NULL)
    {
        FbxLayerElementArrayTemplate<FbxColor> & colors = le->GetDirectArray();
        cout << "                Colors: " << endl;
        if (colors.GetCount() <= 6)
        {
            for (i = 0; i < colors.GetCount(); i++)
                cout << "                    #" << i << ": " << colors.GetAt(i) << endl;
        }
        else
        {
            for (i = 0; i < 3; i++)
                cout << "                    #" << i << ": " << colors.GetAt(i) << endl;
            cout << "                    ..." << endl;
            for (i = colors.GetCount() - 3; i < colors.GetCount(); i++)
                cout << "                    #" << i << ": " << colors.GetAt(i) << endl;
        }
        FbxLayerElementArrayTemplate<int> & indexes = le->GetIndexArray();
        cout << "                Indexes: " << endl;
        if (indexes.GetCount() <= 6)
        {
            for (i = 0; i < indexes.GetCount(); i++)
                cout << "                    #" << i << ": " << indexes.GetAt(i) << endl;
        }
        else
        {
            for (i = 0; i < 3; i++)
                cout << "                    #" << i << ": " << indexes.GetAt(i) << endl;
            cout << "                    ..." << endl;
            for (i = indexes.GetCount() - 3; i < indexes.GetCount(); i++)
                cout << "                    #" << i << ": " << indexes.GetAt(i) << endl;
        }
    }
    cout << "            GetSmoothing() = " << ToString(layer->GetSmoothing()) << endl;
    cout << "            GetVertexCrease() = " << ToString(layer->GetVertexCrease()) << endl;
    cout << "            GetEdgeCrease() = " << ToString(layer->GetEdgeCrease()) << endl;
    cout << "            GetHole() = " << ToString(layer->GetHole()) << endl;
    cout << "            GetUserData() = " << ToString(layer->GetUserData()) << endl;
    cout << "            GetVisibility() = " << ToString(layer->GetVisibility()) << endl;

    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureEmissive), "eTextureEmissive");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureEmissiveFactor), "eTextureEmissiveFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureAmbient), "eTextureAmbient");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureAmbientFactor), "eTextureAmbientFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureDiffuseFactor), "eTextureDiffuseFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureSpecular), "eTextureSpecular");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureNormalMap), "eTextureNormalMap");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureSpecularFactor), "eTextureSpecularFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureShininess), "eTextureShininess");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureBump), "eTextureBump");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureTransparency), "eTextureTransparency");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureTransparencyFactor), "eTextureTransparencyFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureReflection), "eTextureReflection");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureReflectionFactor), "eTextureReflectionFactor");
    PrintLayerTextures(layer->GetTextures(FbxLayerElement::eTextureDisplacement), "eTextureDisplacement");
}

bool PrintAllControlPoints = false;

void PrintGeometryBase(FbxGeometryBase* geometryBase)
{
    int count = geometryBase->GetControlPointsCount();
    cout << "    GetControlPointsCount() = " << count << endl;

    if (count <= 6 || PrintAllControlPoints)
    {
        int i;
        for (i = 0; i < count; i++)
        {
            FbxVector4 cp = geometryBase->GetControlPointAt(i);
            cout << "                #" << i << ": " << cp << endl;
        }
    }
    else
    {
        int i;
        for (i = 0; i < 3; i++)
        {
            FbxVector4 cp = geometryBase->GetControlPointAt(i);
            cout << "        #" << i << ": " << cp << endl;
        }
        cout << "        ..." << endl;
        for (i = count - 3; i < count; i++)
        {
            FbxVector4 cp = geometryBase->GetControlPointAt(i);
            cout << "        #" << i << ": " << cp << endl;
        }
    }

    if (geometryBase->Is<FbxGeometry>())
        PrintGeometry(FbxCast<FbxGeometry>(geometryBase));
    else
        cout << "Unknown node attribute class: " << geometryBase->GetRuntimeClassId().GetName() << endl;
}

void PrintGeometry(FbxGeometry* geometry)
{
    if (geometry->Is<FbxMesh>())
        PrintMesh(FbxCast<FbxMesh>(geometry));
    else
        cout << "Unknown node attribute class: " << geometry->GetRuntimeClassId().GetName() << endl;
}

void PrintMesh(FbxMesh* mesh)
{
    cout << "    GetPolygonCount() = " << mesh->GetPolygonCount() << endl;
}

void PrintNull(FbxNull* null)
{
}

void PrintSkeleton(FbxSkeleton* skeleton)
{
    cout << "PrintSkeleton: Not Implemented" << endl;
}

void PrintPose(FbxPose* pose)
{
    cout << "    IsBindPose = " << pose->IsBindPose() << endl;
    cout << "    IsRestPose = " << pose->IsRestPose() << endl;
    cout << "    Count = " << pose->GetCount() << endl;
    int i;
    for (i = 0; i < pose->GetCount(); i++)
    {
        cout << "        #" << i << " ";
        PrintObjectID(pose->GetNode(i));
        cout << endl;
        const FbxMatrix& m = pose->GetMatrix(i);
        cout << "            Matrix = " <<
            m.mData[0][0] << ", " << m.mData[0][1] << ", " <<
            m.mData[0][2] << ", " << m.mData[0][3] << ", " << endl;
        cout << "            Matrix = " <<
            m.mData[1][0] << ", " << m.mData[1][1] << ", " <<
            m.mData[1][2] << ", " << m.mData[1][3] << ", " << endl;
        cout << "            Matrix = " <<
            m.mData[2][0] << ", " << m.mData[2][1] << ", " <<
            m.mData[2][2] << ", " << m.mData[2][3] << ", " << endl;
        cout << "            Matrix = " <<
            m.mData[3][0] << ", " << m.mData[3][1] << ", " <<
            m.mData[3][2] << ", " << m.mData[3][3] << ", " << endl;
        cout << "            IsLocalMatrix = " <<
            pose->IsLocalMatrix(i) << endl;
    }
}

void PrintSubDeformer(FbxSubDeformer* subDeformer)
{
    cout << "PrintSubDeformer: Not Implemented" << endl;
}

void PrintSurfaceMaterial(FbxSurfaceMaterial* obj)
{
    cout << "    ShadingModel = " << obj->ShadingModel.Get().Buffer() << endl;
    cout << "    MultiLayer = " << obj->MultiLayer.Get() << endl;

    if (obj->Is<FbxSurfaceLambert>())
        PrintSurfaceLambert(FbxCast<FbxSurfaceLambert>(obj));
    else
        cout << "Unknown surface material class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintSurfaceLambert(FbxSurfaceLambert* obj)
{
    FbxDouble3 s;

    s = obj->Emissive.Get();
    cout << "    Emissive = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    EmissiveFactor = " << obj->EmissiveFactor.Get() << endl;
    s = obj->Ambient.Get();
    cout << "    Ambient = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    AmbientFactor = " << obj->AmbientFactor.Get() << endl;
    s = obj->Diffuse.Get();
    cout << "    Diffuse = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    DiffuseFactor = " << obj->DiffuseFactor.Get() << endl;
    s = obj->NormalMap.Get();
    cout << "    NormalMap = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    s = obj->Bump.Get();
    cout << "    Bump = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    BumpFactor = " << obj->BumpFactor.Get() << endl;
    s = obj->TransparentColor.Get();
    cout << "    TransparentColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    TransparencyFactor = " << obj->TransparencyFactor.Get() << endl;
    s = obj->DisplacementColor.Get();
    cout << "    DisplacementColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    DisplacementFactor = " << obj->DisplacementFactor.Get() << endl;
    s = obj->VectorDisplacementColor.Get();
    cout << "    VectorDisplacementColor = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    VectorDisplacementFactor = " << obj->VectorDisplacementFactor.Get() << endl;

    if (obj->Is<FbxSurfacePhong>())
        PrintSurfacePhong(FbxCast<FbxSurfacePhong>(obj));
    else
        cout << "Unknown surface lambert class: " << obj->GetRuntimeClassId().GetName() << endl;
}

void PrintSurfacePhong(FbxSurfacePhong* obj)
{
    FbxDouble3 s = obj->Specular.Get();
    cout << "    Specular = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    SpecularFactor = " << obj->SpecularFactor.Get() << endl;
    cout << "    Shininess = " << obj->Shininess.Get() << endl;
    s = obj->Reflection.Get();
    cout << "    Reflection = " << s[0] << ", " << s[1] << ", " << s[2] << endl;
    cout << "    ReflectionFactor = " << obj->ReflectionFactor.Get() << endl;
}

void PrintVideo(FbxVideo* obj)
{
    cout << "PrintVideo: Not Implemented" << endl;
}

void PrintTexture(FbxTexture* tex)
{
    cout << "PrintTexture: Not Implemented" << endl;
}

void PrintCollection(FbxCollection* col)
{
    cout << "    GetMemberCount() = " << col->GetMemberCount() << endl;
    int i;
    for (i = 0; i < col->GetMemberCount(); i++)
    {
        cout << "        #" << i << ": ";
        PrintObjectID(col->GetMember(i));
        cout << endl;
    }

    if (col->Is<FbxAnimStack>())
        PrintAnimStack(FbxCast<FbxAnimStack>(col));
    else if (col->Is<FbxAnimLayer>())
        PrintAnimLayer(FbxCast<FbxAnimLayer>(col));
    else if (col->Is<FbxDocument>())
        PrintDocument(FbxCast<FbxDocument>(col));
    else
        cout << "Unknown surface lambert class: " << col->GetRuntimeClassId().GetName() << endl;
}

void PrintDocument(FbxDocument* doc)
{
    cout << "    GetRootMemberCount() = " << doc->GetRootMemberCount() << endl;
    int i;
    for (i = 0; i < doc->GetRootMemberCount(); i++)
    {
        cout << "        #" << i << ": ";
        PrintObjectID(doc->GetRootMember(i));
        cout << endl;
    }

    // obj->GetDocumentInfo()

    if (doc->Is<FbxScene>())
        PrintScene(FbxCast<FbxScene>(doc));
    else
        cout << "Unknown surface lambert class: " << doc->GetRuntimeClassId().GetName() << endl;

}

void PrintGlobalSettings(FbxGlobalSettings* obj)
{
    cout << "    GetOriginalUpAxis() = " << obj->GetOriginalUpAxis() << endl;
    cout << "    GetAxisSystem() = " << obj->GetAxisSystem() << endl;
    cout << "    GetSystemUnit() = " << obj->GetSystemUnit() << endl;
    cout << "    GetOriginalSystemUnit() = " << obj->GetOriginalSystemUnit() << endl;
    cout << "    GetAmbientColor() = " << obj->GetAmbientColor() << endl;
    cout << "    GetDefaultCamera() = " << obj->GetDefaultCamera() << endl;
    cout << "    GetTimeMode() = " << obj->GetTimeMode() << endl;
    cout << "    GetDefaultCamera() = " << obj->GetDefaultCamera() << endl;
    cout << "    GetTimeProtocol() = " << obj->GetTimeProtocol() << endl;
    cout << "    GetSnapOnFrameMode() = " << obj->GetSnapOnFrameMode() << endl;
    FbxTimeSpan ts;
    obj->GetTimelineDefaultTimeSpan(ts);
    cout << "    GetTimelineDefaultTimeSpan() = " << ts << endl;
    cout << "    GetCustomFrameRate() = " << obj->GetCustomFrameRate() << endl;
    int numTimeMarkers = obj->GetTimeMarkerCount(); 
    cout << "    GetTimeMarkerCount() = " << numTimeMarkers << endl;
    int i;
    for (i = 0; i < numTimeMarkers; i++)
    {
        FbxStatus status;
        cout << "    GetTimeMarker(" << i << ") = " << obj->GetTimeMarker(i, &status);
        if (status.Error())
            cout << status;
        cout << endl;
    }
    cout << "    GetCurrentTimeMarker() = " << obj->GetCurrentTimeMarker() << endl;
}


std::string quote(const char* s)
{
    int i;
    stringstream ss;
    int n = strlen(s);

    ss << "\"";
    for (i = 0; i < n; i++)
    {
        char ch = s[i];
        if (isprint(ch))
            ss << ch;
        else
        {
            switch (ch)
            {
            case '\r': ss << "\\r"; break;
            case '\n': ss << "\\n"; break;
            case '\t': ss << "\\t"; break;
            default:
                ss << "\\x" << setw(2) << std::hex << (int)(unsigned char)ch;
            }
        }
    }
    ss << "\"";

    return ss.str();
}


std::ostream& operator<<(std::ostream& os, const FbxTime::EMode& value)
{
    switch (value)
    {
    case FbxTime::eDefaultMode   : os << "eDefaultMode"; break;
    case FbxTime::eFrames120     : os << "eFrames120"; break;
    case FbxTime::eFrames100     : os << "eFrames100"; break;
    case FbxTime::eFrames60      : os << "eFrames60"; break;
    case FbxTime::eFrames50      : os << "eFrames50"; break;
    case FbxTime::eFrames48      : os << "eFrames48"; break;
    case FbxTime::eFrames30      : os << "eFrames30"; break;
    case FbxTime::eFrames30Drop  : os << "eFrames30Drop"; break;
    case FbxTime::eNTSCDropFrame : os << "eNTSCDropFrame"; break;
    case FbxTime::eNTSCFullFrame : os << "eNTSCFullFrame"; break;
    case FbxTime::ePAL           : os << "ePAL"; break;
    case FbxTime::eFrames24      : os << "eFrames24"; break;
    case FbxTime::eFrames1000    : os << "eFrames1000"; break;
    case FbxTime::eFilmFullFrame : os << "eFilmFullFrame"; break;
    case FbxTime::eCustom        : os << "eCustom"; break;
    case FbxTime::eFrames96      : os << "eFrames96"; break;
    case FbxTime::eFrames72      : os << "eFrames72"; break;
    case FbxTime::eFrames59dot94 : os << "eFrames59dot94"; break;
    case FbxTime::eModesCount    : os << "eModesCount"; break;
    default:
        os << "<<unknown>>";
        break;
    }
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxTime& value)
{
    os << "[" << value.GetSecondDouble() << "s; " <<
                 value.GetSecondCount() << "s; " <<
                 value.GetFrameCount() << "f; " <<
                 FbxTime::GetGlobalTimeMode() << "tm]";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxTimeSpan& value)
{
    // os << "(start: " << value.GetStart() << ", stop: " << value.GetStop() << ")";
    os << "FbxTimeSpan(start=" << value.GetStart() <<
        ", stop=" << value.GetStop() <<
        ", duration=" << value.GetDuration() <<
        ", direction=" << value.GetDirection() <<
        ")";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxMatrix& value)
{
    os << "[ "
        << value.Get(0, 0) << ", "
        << value.Get(0, 1) << ", "
        << value.Get(0, 2) << ", "
        << value.Get(0, 3) << ", "
        << value.Get(1, 0) << ", "
        << value.Get(1, 1) << ", "
        << value.Get(1, 2) << ", "
        << value.Get(1, 3) << ", "
        << value.Get(2, 0) << ", "
        << value.Get(2, 1) << ", "
        << value.Get(2, 2) << ", "
        << value.Get(2, 3) << ", "
        << value.Get(3, 0) << ", "
        << value.Get(3, 1) << ", "
        << value.Get(3, 2) << ", "
        << value.Get(3, 3) << " ]";
    return os;
}

std::ostream& operator<<(std::ostream& os, const FbxAMatrix& value)
{
    os << "[ "
        << value.Get(0, 0) << ", "
        << value.Get(0, 1) << ", "
        << value.Get(0, 2) << ", "
        << value.Get(0, 3) << ", "
        << value.Get(1, 0) << ", "
        << value.Get(1, 1) << ", "
        << value.Get(1, 2) << ", "
        << value.Get(1, 3) << ", "
        << value.Get(2, 0) << ", "
        << value.Get(2, 1) << ", "
        << value.Get(2, 2) << ", "
        << value.Get(2, 3) << ", "
        << value.Get(3, 0) << ", "
        << value.Get(3, 1) << ", "
        << value.Get(3, 2) << ", "
        << value.Get(3, 3) << " ]";
    return os;
}

bool CanPrintPropertyValue(FbxProperty* prop)
{
    switch (prop->GetPropertyDataType().GetType())
    {
    case eFbxChar:
    case eFbxUChar:
    case eFbxShort:
    case eFbxUShort:
    case eFbxUInt:
    case eFbxLongLong:
    case eFbxULongLong:
    case eFbxBool:
    case eFbxInt:
    case eFbxFloat:
    case eFbxDouble:
    case eFbxDouble2:
    case eFbxDouble3:
    case eFbxDouble4:
    case eFbxString:
    case eFbxTime:
    case eFbxEnum:
        return true;
    }
    return false;
}

void PrintPropertyValue(FbxProperty* prop)
{
    char n[1024];
    int i;
    for (i = 0; i < 1024; i++)
    {
        n[i] = 0;
    }
    char ch;
    unsigned char uch;
    unsigned int ui;
    short sh;
    unsigned short ush;
    long long ll;
    unsigned long long ull;
    bool b;
    float f;
    double d;
    FbxString fstr;
    FbxDouble2 v2;
    FbxDouble3 v3;
    FbxDouble4 v4;
    std::string s;
    std::stringstream ss;
    int count;

    switch (prop->GetPropertyDataType().GetType())
    {
    case eFbxChar:
        ch = prop->Get<char>();
        snprintf(n, sizeof(n), "%i ('%c')", (int)ch, ch);
        break;
    case eFbxUChar:
        uch = prop->Get<unsigned char>();
        snprintf(n, sizeof(n), "%i ('%c')", (unsigned int)uch, uch);
        break;
    case eFbxShort:
        sh = prop->Get<short>();
        snprintf(n, sizeof(n), "%i", (int)sh);
        break;
    case eFbxUShort:
        ush = prop->Get<unsigned short>();
        snprintf(n, sizeof(n), "%ui", (unsigned int)ush);
        break;
    case eFbxUInt:
        ui = prop->Get<unsigned int>();
        snprintf(n, sizeof(n), "%ui", ui);
        break;
    case eFbxLongLong:
        ll = prop->Get<long long>();
        snprintf(n, sizeof(n), "%lli", ll);
        break;
    case eFbxULongLong:
        ull = prop->Get<unsigned long long>();
        snprintf(n, sizeof(n), "%llu", ull);
        break;
    case eFbxBool:
        b = prop->Get<bool>();
        if (b)
            snprintf(n, sizeof(n), "true");
        else
            snprintf(n, sizeof(n), "false");
        break;
    case eFbxInt:
        i = prop->Get<int>();
        snprintf(n, sizeof(n), "%i", i);
        break;
    case eFbxFloat:
        f = prop->Get<float>();
        snprintf(n, sizeof(n), "%f", f);
        break;
    case eFbxDouble:
        d = prop->Get<double>();
        snprintf(n, sizeof(n), "%lf", d);
        break;
    case eFbxDouble2:
        v2 = prop->Get<FbxDouble2>();
        snprintf(n, sizeof(n), "%lf, %lf", v2[0], v2[1]);
        break;
    case eFbxDouble3:
        v3 = prop->Get<FbxDouble3>();
        snprintf(n, sizeof(n), "%lf, %lf, %lf", v3[0], v3[1], v3[2]);
        break;
    case eFbxDouble4:
        v4 = prop->Get<FbxDouble4>();
        snprintf(n, sizeof(n), "%lf, %lf, %lf, %lf", v4[0], v4[1], v4[2],
                 v4[3]);
        break;
    case eFbxString:
        fstr = prop->Get<FbxString>();
        snprintf(n, sizeof(n), "%s", fstr.Buffer());
        s = (fstr.Buffer());
        s = quote(s.c_str());
        snprintf(n, sizeof(n), "%s", s.c_str());
        break;
    case eFbxTime:
        ss << prop->Get<FbxTime>();
        snprintf(n, sizeof(n), "%s", ss.str().c_str());
        break;
    case eFbxEnum:
        count = prop->GetEnumCount();
        fstr = prop->Get<FbxString>();
        ss << fstr.Buffer();
        i = prop->Get<int>();
        ss << ":" << i;
        i = prop->Get<FbxEnum>();
        ss << ":" << i;
        ss << " " << "[";
        for (i = 0; i < count; i++)
        {
            if (i > 0)
                ss << ", ";
            ss << prop->GetEnumValue(i);
        }
        ss << "]";
        snprintf(n, sizeof(n), "%s", ss.str().c_str());
        break;
    default:
        n[0] = '"';
        n[1] = '"';
        n[2] = 0;
        break;
    }

    cout << n;
}

void PrintProperty(FbxProperty* prop, bool indent)
{
    const char * prefix = indent ? "            " : "        ";

    cout << prefix << "Name = " << prop->GetName() << endl;
    FbxDataType type = prop->GetPropertyDataType();
    cout << prefix << "Type = " << type.GetName() << " (" << GetTypeName(type.GetType()) << ")" << endl;
    cout << prefix << "HierName = " << prop->GetHierarchicalName() << endl;
    cout << prefix << "Label = " << prop->GetLabel() << endl;

    int i;
    FbxString fstr;
    FbxDouble2 v2;
    FbxDouble3 v3;
    FbxDouble4 v4;
    std::string s;
    std::stringstream ss;

    if (CanPrintPropertyValue(prop))
    {
        cout << prefix << "Value = ";
        PrintPropertyValue(prop);
        cout << endl;
    }


    cout << prefix << "SrcObjectCount = " << prop->GetSrcObjectCount() << endl;
    for (i = 0; i < prop->GetSrcObjectCount(); i++)
    {
        FbxObject* srcObj = prop->GetSrcObject(i);
        cout << prefix << "    #" << i << " ";
        PrintObjectID(srcObj);
        cout << endl;
    }
    cout << prefix << "DstObjectCount = " << prop->GetDstObjectCount() << endl;
    for (i = 0; i < prop->GetDstObjectCount(); i++)
    {
        FbxObject* dstObj = prop->GetDstObject(i);
        cout << prefix << "    #" << i << " ";
        PrintObjectID(dstObj);
        cout << endl;
    }
    cout << prefix << "SrcPropertyCount = " << prop->GetSrcPropertyCount() << endl;
    for (i = 0; i < prop->GetSrcPropertyCount(); i++)
    {
        FbxProperty prop2 = prop->GetSrcProperty(i);
        cout << prefix << "    #" << i << " ";
        PrintPropertyID(&prop2);
        cout << endl;
    }
    cout << prefix << "DstPropertyCount = " << prop->GetDstPropertyCount() << endl;
    for (i = 0; i < prop->GetDstPropertyCount(); i++)
    {
        FbxProperty prop2 = prop->GetDstProperty(i);
        cout << prefix << "    #" << i << " ";
        PrintPropertyID(&prop2);
        cout << endl;
    }

    cout << prefix << "IsAnimated() = " << prop->IsAnimated() << endl;
    cout << prefix << "IsRoot() = " << prop->IsRoot() << endl;

    cout << prefix << "GetParent() = ";
    FbxProperty parentProp = prop->GetParent();
    PrintPropertyID(&parentProp);
    cout << endl;

    cout << prefix << "GetChild() = ";
    FbxProperty childProp = prop->GetChild();
    PrintPropertyID(&childProp);
    cout << endl;

    cout << prefix << "GetSibling() = ";
    FbxProperty nextProp = prop->GetSibling();
    PrintPropertyID(&nextProp);
    cout << endl;

    i = 0;
    FbxProperty descendent = prop->GetFirstDescendent();
    while (descendent.IsValid())
    {
        i++;
        FbxProperty descendent2 = prop->GetNextDescendent(descendent);
        descendent = descendent2;
    }

    cout << prefix << "Descendents: " << i << endl;
    if (i > 0)
    {
        cout << prefix << "GetFirstDescendent() = ";
        descendent = prop->GetFirstDescendent();
        PrintPropertyID(&parentProp);
        cout << endl;

        while (descendent.IsValid())
        {
            FbxProperty descendent2 = prop->GetNextDescendent(descendent);
            descendent = descendent2;

            if (descendent.IsValid())
            {
                cout << prefix << "GetNextDescendent() = ";
                PrintPropertyID(&parentProp);
                cout << endl;
            }
        }
    }
}


ostream& operator<<(ostream& os, const FbxDouble2& value)
{
    os << value[0] << ", " << value[1];
    return os;
}

ostream& operator<<(ostream& os, const FbxDouble3& value)
{
    os << value[0] << ", " << value[1] << ", " << value[2];
    return os;
}

ostream& operator<<(ostream& os, const FbxDouble4& value)
{
    os << value[0] << ", " << value[1] << ", " << value[2] << ", " << value[3];
    return os;
}

ostream& operator<<(ostream& os, const FbxColor& value)
{
    os << "(R:" << value[0] << ", G:" << value[1] << ", B:" << value[2] << ", A:" << value[3] << ")";
    return os;
}

ostream& operator<<(ostream& os, const FbxDataType& value)
{
    os << value.GetName() << ":" << value.GetType();
    return os;
}

ostream& operator<<(ostream& os, const EFbxType& value)
{
    const char* s;
    switch (value)
    {
    case eFbxUndefined : s = "eFbxUndefined" ; break;
    case eFbxChar      : s = "eFbxChar"      ; break;
    case eFbxUChar     : s = "eFbxUChar"     ; break;
    case eFbxShort     : s = "eFbxShort"     ; break;
    case eFbxUShort    : s = "eFbxUShort"    ; break;
    case eFbxUInt      : s = "eFbxUInt"      ; break;
    case eFbxLongLong  : s = "eFbxLongLong"  ; break;
    case eFbxULongLong : s = "eFbxULongLong" ; break;
    case eFbxHalfFloat : s = "eFbxHalfFloat" ; break;
    case eFbxBool      : s = "eFbxBool"      ; break;
    case eFbxInt       : s = "eFbxInt"       ; break;
    case eFbxFloat     : s = "eFbxFloat"     ; break;
    case eFbxDouble    : s = "eFbxDouble"    ; break;
    case eFbxDouble2   : s = "eFbxDouble2"   ; break;
    case eFbxDouble3   : s = "eFbxDouble3"   ; break;
    case eFbxDouble4   : s = "eFbxDouble4"   ; break;
    case eFbxDouble4x4 : s = "eFbxDouble4x4" ; break;
    case eFbxEnum      : s = "eFbxEnum"      ; break;
    case eFbxString    : s = "eFbxString"    ; break;
    case eFbxTime      : s = "eFbxTime"      ; break;
    case eFbxReference : s = "eFbxReference" ; break;
    case eFbxBlob      : s = "eFbxBlob"      ; break;
    case eFbxDistance  : s = "eFbxDistance"  ; break;
    case eFbxDateTime  : s = "eFbxDateTime"  ; break;
    case eFbxTypeCount : s = "eFbxTypeCount" ; break;
    default: s = "<<unknown EFbxType>>"; break;
    }
    os << s;
    return os;
}

ostream& operator<<(ostream& os, const FbxPropertyHandle& value)
{
    os << "FbxPropertyHandle(" << value.GetName() << ":" << value.GetType() << ")";
    return os;
}

ostream& operator<<(ostream& os, const FbxDateTime& value)
{
    os << "FbxDateTime(" << value.toString() << ")";
    return os;
}

ostream& operator<<(ostream& os, const FbxGlobalSettings::TimeMarker& value)
{
    os << "FbxGlobalSettings::TimeMarker(mName=" << value.mName << ", mTime=" << value.mTime << ", mLoop=" << value.mLoop << ")";
    return os;
}

ostream& operator<<(ostream& os, const FbxSystemUnit& value)
{
    os << "FbxSystemUnit("
        "GetScaleFactor()=" << value.GetScaleFactor() <<
        ", GetScaleFactorAsString()=" << value.GetScaleFactorAsString() <<
        ", GetScaleFactorAsString_Plurial()=" << value.GetScaleFactorAsString_Plurial() <<
        ", GetMultiplier()=" << value.GetMultiplier() <<
        ")";
    return os;
}

ostream& operator<<(ostream& os, const FbxAxisSystem& value)
{
    int fvs = 0;
    auto fv = value.GetFrontVector(fvs);
    int fus = 0;
    auto fu = value.GetFrontVector(fus);
    os << "FbxAxisSystem("
        "GetFrontVector()=" << fv << " [" << fvs << "]" <<
        ", GetUpVector()=" << fu << " [" << fus << "]" <<
        ", GetCoorSystem()=" << value.GetCoorSystem() <<
        ")";
    return os;
}

ostream& operator<<(ostream& os, const FbxAxisSystem::EFrontVector& value)
{
    os << "EFrontVector::";
    if (value == FbxAxisSystem::EFrontVector::eParityEven)
        os << "eParityEven";
    else if (value == FbxAxisSystem::EFrontVector::eParityOdd)
        os << "eParityOdd";
    else
        os << "unknown";
    return os;
}

ostream& operator<<(ostream& os, const FbxAxisSystem::EUpVector& value)
{
    os << "EUpVector::";
    if (value == FbxAxisSystem::EUpVector::eXAxis)
        os << "eXAxis";
    else if (value == FbxAxisSystem::EUpVector::eYAxis)
        os << "eYAxis";
    else if (value == FbxAxisSystem::EUpVector::eZAxis)
        os << "eZAxis";
    else
        os << "unknown";
    return os;
}

ostream& operator<<(ostream& os, const FbxAxisSystem::ECoordSystem& value)
{
    os << "ECoordSystem::";
    if (value == FbxAxisSystem::ECoordSystem::eRightHanded)
        os << "eRightHanded";
    else if (value == FbxAxisSystem::ECoordSystem::eLeftHanded)
        os << "eLeftHanded";
    else
        os << "unknown";
    return os;
}

std::string ToString(const FbxLocalTime& value)
{
    std::stringstream s;
    s << value.mYear << "-" << value.mMonth << "-" << value.mDay << "-" <<
         value.mHour << ":" << value.mMinute << ":" << value.mSecond << "." <<
         value.mMillisecond;
    return s.str();
}

CC=g++
CFLAGS=-c -Wall -I/Applications/Autodesk/FBX\ SDK/2015.1/include
LDFLAGS=-framework Cocoa
STATIC_LIBS=/Applications/Autodesk/FBX\ SDK/2015.1/lib/clang/debug/libfbxsdk.a

SOURCES=AnimCurveKeyTest.cpp AnimCurveNodeTest.cpp AnimCurveTest.cpp AnimLayerTest.cpp AnimStackTest.cpp Assertions.cpp CameraTest.cpp ClusterTest.cpp Collector.cpp DeformerTest.cpp FbxObjectTest.cpp FbxTimeTest.cpp GeometryBaseTest.cpp GeometryTest.cpp LayerContainerTest.cpp LightTest.cpp MatrixTest.cpp MeshTest.cpp NodeTest.cpp NodeTransformsTest.cpp PropertyTest.cpp SceneTest.cpp SkinTest.cpp SubDeformerTest.cpp SurfacePhongTest.cpp TestFixture.cpp TestRunner.cpp basic_types.cpp main.cpp objects.cpp properties.cpp textures.cpp
HEADERS=Assertions.h Collector.h OutputDebugStringBuf.h Tests.h common.h
OBJECTS=$(SOURCES:%.cpp=obj/%.o)
EXECUTABLE=FbxOpenCpp

all: directories $(SOURCES) $(EXECUTABLE)

directories:
	mkdir -p obj bin

obj/%.o: %.cpp
	$(CC) $(CFLAGS) $< -o $@

#.cpp.o:
#	$(CC) $(CFLAGS) $< -o $@

$(EXECUTABLE): $(OBJECTS)
	$(CC) $(LDFLAGS) $(OBJECTS) $(STATIC_LIBS) -o bin/$@


CC=g++

UNAME_S := $(shell uname -s)
ifeq ($(UNAME_S),Linux)
	CFLAGS=-c -Wall -I$(HOME)/usr/fbxsdk/include -pthread
	STATIC_LIBS=$(HOME)/usr/fbxsdk/lib/gcc4/x64/debug/libfbxsdk.a
	LDFLAGS=-lpthread -ldl
endif
ifeq ($(UNAME_S),Darwin)
	CFLAGS=-c -Wall -I/Applications/Autodesk/FBX\ SDK/2015.1/include
	STATIC_LIBS=/Applications/Autodesk/FBX\ SDK/2015.1/lib/clang/debug/libfbxsdk.a
	LDFLAGS=-framework Cocoa
endif

SOURCES=AnimCurveKeyTest.cpp AnimCurveNodeTest.cpp AnimCurveTest.cpp AnimLayerTest.cpp AnimStackTest.cpp Assertions.cpp CameraTest.cpp ClusterTest.cpp Collector.cpp DeformerTest.cpp FbxObjectTest.cpp FbxTimeTest.cpp GeometryBaseTest.cpp GeometryTest.cpp LayerContainerTest.cpp LightTest.cpp MatrixTest.cpp MeshTest.cpp NodeTest.cpp NodeTransformsTest.cpp PropertyTest.cpp SceneTest.cpp SkinTest.cpp SubDeformerTest.cpp SurfacePhongTest.cpp TestFixture.cpp TestRunner.cpp basic_types.cpp main.cpp objects.cpp properties.cpp textures.cpp
HEADERS=Assertions.h Collector.h OutputDebugStringBuf.h Tests.h common.h
OBJECTS=$(SOURCES:%.cpp=obj/%.o)
EXECUTABLE=FbxOpenCpp

.PHONY: all directories clean

all: directories $(SOURCES) $(EXECUTABLE)

directories:
	mkdir -p obj bin

obj/%.o: %.cpp
	$(CC) $(CFLAGS) $< -o $@

#.cpp.o:
#	$(CC) $(CFLAGS) $< -o $@

$(EXECUTABLE): $(OBJECTS)
	$(CC) $(OBJECTS) $(STATIC_LIBS) -o bin/$@ $(LDFLAGS)

clean:
	rm -rf obj bin

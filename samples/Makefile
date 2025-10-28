CC=g++

UNAME_S := $(shell uname -s)

FBXSDK_HOME?=

ifeq ($(FBXSDK_HOME),)
	ifeq ($(UNAME_S),Linux)
		FBXSDK_HOME :=/usr/share/fbxsdk/2020.3.4
	endif
	ifeq ($(UNAME_S),Darwin)
		FBXSDK_HOME :=/Applications/Autodesk/FBX\ SDK/2020.3.4
	endif
endif
$(info FBXSDK_HOME is [$(FBXSDK_HOME)])

COMMON_CFLAGS :=-w -c -Wall -std=c++17 -I$(FBXSDK_HOME)/include -I/usr/local/opt/libxml2/include -I/usr/local/opt/zlib/include -I../fbxcppcommon
COMMON_STATIC_LIBS := ../fbxcppcommon/bin/fbxcppcommon.a
COMMON_LDFLAGS := -L/usr/lib -lz -lxml2 -liconv

ifeq ($(UNAME_S),Linux)
	CFLAGS=-pthread $(COMMON_CFLAGS)
	STATIC_LIBS=$(FBXSDK_HOME)/lib/gcc/x64/debug/libfbxsdk.a $(COMMON_STATIC_LIBS)
	LDFLAGS=-lpthread -ldl  $(COMMON_LDFLAGS)
endif
ifeq ($(UNAME_S),Darwin)
	USE_PTHREAD=0
	CFLAGS=$(COMMON_CFLAGS)
	STATIC_LIBS=$(FBXSDK_HOME)/lib/clang/debug/libfbxsdk.a $(COMMON_STATIC_LIBS)
	LDFLAGS=-framework Cocoa $(COMMON_LDFLAGS)
endif

SOURCES=gen_samples.cpp
HEADERS=
OBJECTS=$(SOURCES:%.cpp=obj/%.o)
EXECUTABLE=gen_samples

.PHONY: all directories clean

all: directories $(SOURCES) $(EXECUTABLE)

directories:
	mkdir -p obj bin

obj/%.o: %.cpp
	$(CC) $(CFLAGS) $< -o $@

$(EXECUTABLE): $(OBJECTS)
	$(CC) $(OBJECTS) $(STATIC_LIBS) -o bin/$@ $(LDFLAGS)

gen: all
	./bin/$(EXECUTABLE)

gen-custom-prop: all
	./bin/$(EXECUTABLE) gen-custom-prop "A" export-all-formats "custom_sceneinfo_property_1"
	./bin/$(EXECUTABLE) gen-custom-prop "AB" export-all-formats "custom_sceneinfo_property_2"
	./bin/$(EXECUTABLE) gen-custom-prop "ABC" export-all-formats "custom_sceneinfo_property_3"

gen-hierarchy-string: all
	./bin/$(EXECUTABLE) gen-custom-prop "Abc::Def" export-all-formats "hierarchy_string_1"
	./bin/$(EXECUTABLE) gen-custom-prop "Abc::Def::Ghi" export-all-formats "hierarchy_string_2"
	./bin/$(EXECUTABLE) gen-custom-prop "Abc::Def::Ghi::Jkl" export-all-formats "hierarchy_string_3"
	./bin/$(EXECUTABLE) gen-custom-prop "Abc::Def::Ghi::Jkl::Mno" export-all-formats "hierarchy_string_4"

clean:
	rm -rf obj bin

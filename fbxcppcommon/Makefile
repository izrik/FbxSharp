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

SOURCES=Collector.cpp fileio.cpp objects.cpp print.cpp properties.cpp textures.cpp
HEADERS=Collector.h fileio.h objects.h print.h properties.h
OBJECTS=$(SOURCES:%.cpp=obj/%.o)
OUTPUT_LIB=fbxcppcommon.a

COMMON_CFLAGS :=-c -Wall -std=c++11 -I$(FBXSDK_HOME)/include -I/usr/local/opt/libxml2/include -I/usr/local/opt/zlib/include
COMMON_STATIC_LIBS := 
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


.PHONY: all directories clean

all: directories $(SOURCES) output

directories:
	mkdir -p obj bin

obj/%.o: %.cpp
	$(CC) $(CFLAGS) $< -o $@

$(OUTPUT_LIB): directories $(OBJECTS)
	ar rcs bin/$@ $(OBJECTS) $(STATIC_LIBS)

output: $(OUTPUT_LIB)

clean:
	rm -rf obj bin

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

COMMON_CFLAGS :=-c -Wall -std=c++11 -I$(FBXSDK_HOME)/include -I/usr/local/opt/libxml2/include -I/usr/local/opt/zlib/include -I../fbxcppcommon
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

SOURCES=main.cpp explore.cpp
HEADERS=explore.h
OBJECTS=$(SOURCES:%.cpp=obj/%.o)
EXECUTABLE=fbxcppcli

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

check: test

test: all
	./bin/$(EXECUTABLE)

clean:
	rm -rf obj bin

#!/bin/bash

function pseudo {
  "$@"
}

SUDO="${SUDO:-"$SUDO"}"

# update
"$SUDO" apt update
"$SUDO" apt -y install gcc g++ make curl wget libxml2-dev zlib1g-dev

# set up
"$SUDO" mkdir -p /build
"$SUDO" chown "$(whoami)" /build

# download and build libiconv
mkdir -p /build/libiconv
cd /build/libiconv
wget http://ftp.gnu.org/pub/gnu/libiconv/libiconv-1.11.tar.gz ; tar -xvf libiconv-1.11.tar.gz
cd /build/libiconv/libiconv-1.11
./configure
make
make check
"$SUDO" make install

mkdir -p /build/fbxsdk
cd /build/fbxsdk
wget https://damassets.autodesk.net/content/dam/autodesk/www/adn/fbx/2020-3-4/fbx202034_fbxsdk_linux.tar.gz
tar -xvf fbx202034_fbxsdk_linux.tar.gz
"$SUDO" mkdir -p /usr/share/fbxsdk/2020.3.4
printf 'yes\nn\n' | ./fbx202034_fbxsdk_linux /usr/share/fbxsdk/2020.3.4

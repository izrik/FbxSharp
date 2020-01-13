# FbxSharp [![Build Status](https://travis-ci.org/izrik/FbxSharp.svg)](https://travis-ci.org/izrik/FbxSharp) [![NuGet](https://img.shields.io/nuget/v/FbxSharp.svg)](http://www.nuget.org/packages/FbxSharp)

A pure C# library for loading FBX files

Description
-----------

FbxSharp was deliberately patterned after [Autodesk’s FBX SDK](http://help.autodesk.com/view/FBX/2015/ENU/?guid=__cpp_ref_annotated_html), though written entirely in C# rather than C++. In general, the classes of FbxSharp match corresponding ones in the SDK, with the difference of not having the “Fbx” prefix on the name of the class.
But of course, there are plenty of special cases. ;)
Anyways, if you’re familiar with using the SDK, you should be able to figure out FbxSharp without any difficulty.

FbxSharp doesn't handle binary files yet, so you have to convert them to ascii.
Also, it's only been only tested against file format version 2013.3, so convert to that while you're at it.

There's an example of how to use the library here: https://github.com/izrik/ChamberLib.FbxSharp/blob/master/FbxModelImporter.cs#L41

Future work will go towards implementing the rest of the api, implementing other versions of the api, and supporting additional file formats.

SDK Interface Versions Implemented:

- [ ] 2020.0.1
- [ ] 2019.5
- [ ] 2019.2
- [ ] 2019.0
- [ ] 2018.1.1
- [ ] 2018.0
- [ ] 2017.1
- [ ] 2017.0
- [ ] 2016.1.2
- [ ] 2016.1
- [ ] 2016
- [X] 2015
- [ ] 2014.2.1
- [ ] 2014.1
- [ ] 2013.3

File Versions Supported:

  [ ]|Version ID|x.y|SDK version(s)|Notes
-----|----------|---|--------------|-----
- [ ]|`7700`|7.7|2020, 2019.5|
- [ ]|`7600`|7.6|
- [ ]|`7500`|7.5|2016.1.2 through 2019.2|
- [ ]|`7400`|7.4|2014, 2015
- [X]|`7300`|7.3|2013.3
- [ ]|`7200`|7.2|
- [ ]|`7100`|7.1|
- [ ]|`7099`|||Compatible with 7.1, and taken as such
- [ ]|`7000`|||Compatible with 7.1, and taken as such
- [ ]|`6100`|6.1|
- [ ]|`6000`|6.0|
- [ ]|`5800`|5.8|
- [ ]|`5000`|5.0|
- [ ]|`4050`|4.5|
- [ ]|`4001`|4.01|
- [ ]|`4000`|4.0|
- [ ]|`3001`|3.01|
- [ ]|`3000`|3.0|
- [ ]|`2001`|2.01|
- [ ]|`2000`|2.0|

- [ ] Ascii
- [ ] Binary

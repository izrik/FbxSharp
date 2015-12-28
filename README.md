# FbxSharp [![Build Status](https://travis-ci.org/izrik/FbxSharp.svg)](https://travis-ci.org/izrik/FbxSharp) [![NuGet](https://img.shields.io/nuget/v/FbxSharp.svg)](http://www.nuget.org/packages/FbxSharp)

A pure C# library for loading FBX files

Description
-----------

FbxSharp was deliberately patterned after [Autodesk’s FBX 2015 SDK](http://help.autodesk.com/view/FBX/2015/ENU/?guid=__cpp_ref_annotated_html), though written entirely in C# rather than C++. In general, the classes of FbxSharp match corresponding ones in the SDK, with the difference of not having the “Fbx” prefix on the name of the class.
But of course, there are plenty of special cases. ;)
Anyways, if you’re familiar with using the SDK, you should be able to figure out FbxSharp without any difficulty.

FbxSharp doesn't handle binary files yet, so you have to convert them to ascii.
Also, it's only been only tested against file format version 2013.3, so convert to that while you're at it.
There's an example of how to use the library here: https://github.com/izrik/ChamberLib.FbxSharp/blob/master/FbxModelImporter.cs#L41

Future work will go towards implementing the rest of the api, implementing other versions of the api, and supporting additional file formats.

SDK Interface Versions Implemented:

- [ ] 2016.1
- [ ] 2016
- [X] 2015
- [ ] 2014.2.1
- [ ] 2014.1
- [ ] 2013.3
- [ ] 2012.2
- [ ] 2011.3.1
- [ ] 2011.3
- [ ] 2011.2
- [ ] 2010.2
- [ ] 2010.0.2
- [ ] 2009.3
- [ ] 2009.1
- [ ] 2006.11.1
- [ ] 2005.12.1
- [ ] 2005.12

File Formats Supported:

- [ ] Ascii
- [ ] Binary
- [ ] 2016.1
- [ ] 2016
- [ ] 2015
- [ ] 2014.2.1
- [ ] 2014.1
- [X] 2013.3
- [ ] 2012.2
- [ ] 2011.3.1
- [ ] 2011.3
- [ ] 2011.2
- [ ] 2010.2
- [ ] 2010.0.2
- [ ] 2009.3
- [ ] 2009.1
- [ ] 2006.11.1
- [ ] 2005.12.1
- [ ] 2005.12

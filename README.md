# Substance Import Plugin Converter
This project allows you to upgrade Allegorithmic Substances built on Unity 2017.4 and earlier, to Unity 2018.1 and later using a combination of the official Substances for Unity plugin, and a lot of .meta file hackery. Special shout out to the person on the Unity forums who discovered FileID hashes were MD4 (then also another shout out to Unity Enterprise Support for fixing my broken implementation in C# for me.)

This removes the need for upgrading to Unity 2017.3/2017.4 then upgrading your project to 2018.2 and allows you to jump from 2017.2 and earlier versions directly by running a simple tool which updates the .meta files. 

It _SHOULD_ update Materials to use the same GUID/FileID pair as before, which means you don't need to edit .prefabs/.unity files to update the FileIDs in there. (huzzah!)

This tool is intended for developers to work with, it is not (yet) a convenient consumer tool. Hopefully Allegorithmic incorporate this or a similar idea into the next version of their plugin.

Use ***SubstanceMetaFileConverter.ConvertFile(old file, new file)*** to convert a .meta file from the old format, to the new.

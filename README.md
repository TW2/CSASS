# CSASS

This is an ASS library for C# that can read and write ASS files. You can also use karaoke with syllables or letters.

How to use it
-

First use the main class:
```c#
Csass ca = new Csass();
```

Then open a file:
```c#
//Load a file (fullpath represents your file to read)
ca.LoadASS(fullpath);
```

Then save changes (if any):
```c#
//Save a file (fullpath represents your file to save)
ca.SaveASS(fullpath, "Your software", "Your website");
```

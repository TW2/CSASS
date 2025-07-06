# CSASS

This is an ASS library for C# that can read and write ASS files. You can also use karaoke with syllables or letters.

How to use it
-

You can use ASS format or SSA format, this example show you only ass way.

First use the main class:
```c#
Csass ca = new Csass();
```

Then open a file:
```c#
//Load a file (fullpath represents your file to read)
ca.LoadASS(fullpath);
```

Then add a Dialogue:
```c#
//Add a new dialogue event to the end of the ca.Events list
ca.AddAssEvent(C_Event.EventType.Dialogue, 0, "0:01:56.80", "0:01:58.09", "Default", 
      "Sakura", 0, 0, 0, "", "Shannnnnnaro!");
//Add a new dialogue event at the index in the ca.Events list
ca.AddAssEvent(C_Event.EventType.Dialogue, 0, "0:01:56.80", "0:01:58.09", "Default", 
      "Naruto", 0, 0, 0, "", "Sakura-chan!", 452);
```

Then add a Comment:
```c#
//Add a new comment event to ca.Events
ca.AddAssEvent(C_Event.EventType.Comment, 0, "0:01:56.80", "0:01:58.09", "Default", 
      "Sakura", 0, 0, 0, "", "Great battle");
//Add a new comment event at the index in the ca.Events list
ca.AddAssEvent(C_Event.EventType.Comment, 0, "0:01:56.80", "0:01:58.09", "Default", 
      "Naruto", 0, 0, 0, "", "And the winner is:", 451);
```

Then remove an event:
```c#
//Remove an event from ca.Events at the index
ca.RemoveAssEvent(50);
```

Then save changes (if any):
```c#
//Save a file (fullpath represents your file to save)
ca.SaveASS(fullpath, "Your software", "Your website");
```

You can join me on Discord to speak or idle, in English or French (cause I'm a half white black Frenchy).

[![Discord](https://github.com/user-attachments/assets/99ec6536-7624-41c1-afd1-7993fc4a1e25)](https://discord.gg/ef8xvA9wsF)

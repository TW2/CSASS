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

Then add a Dialogue:
```c#
//Add a new dialogue event to the end of the ca.Events list
ca.AddDialogueEvent(0, "0:01:56.80", "0:01:58.09", "Default", 
      "Sakura", 0, 0, 0, "", "Shannnnnnaro!");
//Add a new dialogue event at the index in the ca.Events list
ca.AddDialogueEvent(0, "0:01:56.80", "0:01:58.09", "Default", 
      "Naruto", 0, 0, 0, "", "Sakura-chan!", 452);
```

Then add a Comment:
```c#
//Add a new comment event to ca.Events
ca.AddCommentEvent(0, "0:01:56.80", "0:01:58.09", "Default", 
      "Sakura", 0, 0, 0, "", "Great battle");
//Add a new comment event at the index in the ca.Events list
ca.AddCommentEvent(0, "0:01:56.80", "0:01:58.09", "Default", 
      "Naruto", 0, 0, 0, "", "And the winner is:", 451);
```

Then remove an event:
```c#
//Remove an event from ca.Events at the index
ca.RemoveEvent(50);
```

Then save changes (if any):
```c#
//Save a file (fullpath represents your file to save)
ca.SaveASS(fullpath, "Your software", "Your website");
```

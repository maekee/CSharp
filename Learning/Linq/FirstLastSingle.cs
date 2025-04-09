// FIRST, FIRSTORDEFAULT, LAST, LASTORDEFAULT, SINGLE, SINGLEORDEFAULT examples
// If you know that the element exists, use First, Last and Single.
// If you dont know if the element exists, use ..OrDefault methods.

// First, query syntax followed by method syntax. Throws exception, so remember to catch these
resultGhost = (from ghost in ghosts select ghost).First(ghost => ghost.GhostColor == "Yellow");
resultGhost = ghosts.First(ghost => ghost.GhostColor == "Yellow");

// FirstOrDefault, query syntax followed by method syntax. Returns null of no match
resultGhost = (from ghost in ghosts select ghost).FirstOrDefault(ghost => ghost.GhostColor == "Yellow");
resultGhost = ghosts.FirstOrDefault(ghost => ghost.GhostColor == "Yellow");

// FirstOrDefault can have a second parameter, that is a new class object returned if nothing is found instead of null
resultGhost = ghosts.FirstOrDefault(ghost => ghost.GhostColor == "Yellowish",
    new Ghost("MrNothing"));
    
// Last and LastOrDefault, works the same but searches backwards. Just like First, Last also Throws exception, so remember to catch these

// Single, returns of a single one item is found (throws exception if not found or multiple found) 
// SingleOrDefault, returns null instead of exception. Like the other *OrDefault methods.

// Just like the FirstOrDefault, both LastOrDefault and SingleOrDefault can also take a second parameter

// When I started learning C#, I encountered LINQ pretty quickly, and fell in love.
// Here i will collect lots of examples, both using linq query syntax and linc method syntax (lambda)

// Linq query syntax vs methods syntax
newList = (from unit in orgUnits select unit).ToList(); //ToList casts IEnumerable to List
newList = orgUnits.Select(unit => unit).ToList(); //unit => unit is the lambda expression

// ORDER examples using a List<Ghosts> where my ghost instances look like this
// new Ghost("BooBoo", "Pink",14500), //Name, Color and Age

// Order and return class instances, query syntax
newList = (from ghost in ghosts orderby ghost.GhostColor select ghost).ToList();

// Order and return string list, query syntax
stringList = (from ghost in ghosts orderby ghost.GhostColor select ghost.GhostColor).ToList();
// You can add descending and ascending after the fieldname (GhostColor)

// Order and return class instances, methods syntax
newList = ghosts.OrderBy(ghost => ghost.GhostColor).ToList();
newList = ghosts.OrderByDescending(ghost => ghost.GhostColor).ToList();

// Order by two columns, query syntax
newList = (from ghost in ghosts orderby ghost.GhostColor, ghost.GhostName select ghost).ToList();

// Order by two columns, method syntax
newList = ghosts.OrderBy(ghost => ghost.GhostColor).ThenBy(Ghost => Ghost.GhostName).ToList();

// WHERE examples

// Where, query syntax
newList = (from ghost in ghosts where ghost.GhostName.StartsWith("C") && ghost.GhostAge < 500 select ghost).ToList();

// Where, method syntax
newList = ghosts.Where(ghost => ghost.GhostName.StartsWith("C") && ghost.GhostAge < 500).ToList();
newList = ghosts.Where(ghost => Regex.Match(ghost.GhostName, @"^\w+er").Success).ToList();

// FIRST, FIRSTORDEFAULT, LAST, LASTORDEFAULT, SINGLE, SINGLEORDEFAULT examples

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
// SingleOrDefault, returns null instead of exception. Like the other ...OrDefault methods.

// Just like the FirstOrDefault, both LastOrDefault and SingleOrDefault can also take a second parameter

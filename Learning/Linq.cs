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

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

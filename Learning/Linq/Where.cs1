  // Where, query syntax
newList = (from ghost in ghosts where ghost.GhostName.StartsWith("C") && ghost.GhostAge < 500 select ghost).ToList();

// Where, method syntax
newList = ghosts.Where(ghost => ghost.GhostName.StartsWith("C") && ghost.GhostAge < 500).ToList();
newList = ghosts.Where(ghost => Regex.Match(ghost.GhostName, @"^\w+er").Success).ToList();

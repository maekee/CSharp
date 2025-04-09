// Take, takes the amount of elements supplied from the original data structure
// Take query syntax, followed by method syntax
newList = (from ghost in ghosts orderby ghost.GhostName select ghost).Take(10).ToList();
newList = ghosts.OrderBy(ghost => ghost.GhostName).Take(10).ToList();

// We can use the range operator and Take
newList = ghosts.Take(1..3).ToList(); //Starting from index 1 (zero-based) and take up to (but not including) index 3. (returns 2 ghosts, index position 1, 2)
newList = ghosts.Take(5..).ToList(); //Starting with index 5 and the rest
newList = (from ghost in ghosts select ghost).Take(..5).ToList(); //Up to the fifth index (but including index 5)
newList = (from ghost in ghosts select ghost).Take(^5..^2).ToList(); //Starting from reverse, 5th index (not not including) and forward until the 2nd element from the end. (returns 3 ghosts, -4, -3, -2)

// Skip
newList = ghosts.Skip(1).ToList(); //Skip the first
newList = (from ghost in ghosts orderby ghost.GhostName select ghost).Skip(5).ToList(); //Skip the first five

// TAKEWHILE AND SKIPWHILE
// TakeWhile and SkipWhile works as long as the while condition is true, the first item that does not meet the condition will cause the TakeWhile/SkipWhile to stop
// If the first element does not match, nothing is returned. So ordering is important. So we can use it to capture sequences

newList = (from ghost in ghosts
           orderby ghost.GhostName
           select ghost).TakeWhile(ghost => ghost.GhostName.StartsWith("A")).ToList();

newList = ghosts.OrderBy(ghost => ghost.GhostName).SkipWhile(ghost => ghost.GhostName.StartsWith("A")).ToList(); 

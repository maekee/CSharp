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

// TAKE/SKIP examples

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


// DISTINCTBY/DISTINCT
// DistinctBy removes duplicate elements from a sequence based on Lambda expression
// Distinct removes duplicate elements from a sequence:
//   Primitive values are compared directly
//   Custom objects rely on Equals and GetHashCode methods to determine equality, so maybe we need to override the Equas and GetHashCode to compare Name or Age.

var myIntList = new List<int> { 1,2,3,2,1,3,2,2,1,2,1,1,1,2,3,1,3,2,2,1 };
resultIntList = myIntList.DistinctBy(n => n).ToList(); //Results in 1,2,3
resultIntList = myIntList.Distinct().ToList(); //Results in 1,2,3


// CHUNK
// Returns a list of lists that are sized after the parameter value


List<Ghost[]> newGhostList = new();

newGhostList = (from ghost in ghosts
                orderby ghost.GhostName
                select ghost).Chunk(10).ToList();

newGhostList = ghosts.OrderBy(ghost => ghost.GhostAge).Chunk(25).ToList();

List<Ghost[]> newGhostList = new();

newGhostList = (from ghost in ghosts
                orderby ghost.GhostName
                select ghost).Chunk(10).ToList();

newGhostList = ghosts.OrderBy(ghost => ghost.GhostAge).Chunk(25).ToList();

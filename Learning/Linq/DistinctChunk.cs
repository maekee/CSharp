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

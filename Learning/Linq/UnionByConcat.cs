// UNION
// Combine two collections together
Union - No dupes, UnionBy - No dupes, Concat - With dupes

int[] theNumbers = new int[] { 2, 3, 1 };
int[] moreNumbers = new int[] { 4, 6, 5, 1 };

resultIntList = theNumbers.Union(moreNumbers).ToList(); //returns 2,3,1,4,6,5 (no dupes)

// We can also order the list, Method syntax
resultIntList = theNumbers.Union(moreNumbers).OrderBy(n => n).ToList(); //returns 1,2,3,4,5,6

// Query syntax
resultIntList = (from n in theNumbers select n)
                .Union(from m in moreNumbers select m)
                .OrderBy(x => x).ToList();

// UNIONBY
// UnionBy allows you to define what part of the objects in your lists to union by, used to remove duplicates.

newList = ghostsList1.UnionBy(ghostsList2, g => g.GhostAge).ToList(); //Removes duplicates based on GhostAge.


//CONCAT
// Concat combines two lists, and includes duplicates

newList = ghostsList1.Concat(ghostsList2).ToList();

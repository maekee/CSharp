// INTERSECT/INTERSECTBY
// Find all values in common between two lists, simple data types (int, decimal etc) checks values, comparer class to compare class objects
int[] theNumbers = new int[] { 0,1,2,3,4 };
int[] moreNumbers = new int[] { 3,4,5,6,7 };

// Query syntax and method syntax
resultIntList = (from num in theNumbers select num).Intersect(moreNumbers).ToList(); //Returns 3,4
resultIntList = theNumbers.Intersect(moreNumbers).ToList(); //returns 3,4


// IntersectBy allows you to define what part of the objects in your lists will be used to determine if they exist in both lists. Using a key selector.
// The default data type for key expression is string, if you want to change to anything else you must pass two parameters, data type and key expression data type
// Query syntax

newList = (from g1 in ghostsList1 select g1)
          .IntersectBy<Ghost, int>(
            from g2 in ghostsList2 select g2.GhostAge,g1 => g1.GhostAge).ToList();

// Method syntax
newList = ghostsList1.IntersectBy<Ghost, int>(
            ghostsList2.Select(g2 => g2.GhostAge), g1 => g1.GhostAge).ToList();

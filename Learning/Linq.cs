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


// ALL/ANY
// Do All or Any items meet a condition? Returns bool
// IEnumerable<T>.All(predicate) //Does if all items meet the condition
// IEnumerable<T>.Any(predicate) //Does if any item meets the condition

boolResult = ghosts.All(ghost => ghost.GhostName == ghost.GhostColor);
boolResult = (from ghost in ghosts select ghost).Any(ghost => ghost.GhostName == ghost.GhostColor);


// CONTAINS
// Contains() returns true based on exact presence of a specific value
// Also works on strings but is case sensitive (leverages the value-based equality of strings, so no need to worry about the reference equality issues)
// Uses direct equality, so class objects use the default equality comparer, this
// comparer is based on the object's reference, not the object's value.
// This means that Contains will return true only if the object in the collection
// is the exact same object instance as the one you're checking for.

var myIntList = new List<string> { "one", "two", "three" };
boolResult = myIntList.Contains("four");

// In essence, Contains is a more precise check for a exact value,
// while Any is a more flexible check for the existence of elements that meet a condition.

// Contains with custom class Objects, we need to create a new class that inherits from EqualityComparer<T> class
// Within that new class we need to override the Equals and GetHashCode methods with logic that meet our requirements.

public class GhostNameComparer : EqualityComparer<Ghost>
{
    public override bool Equals(Ghost x, Ghost y)
    {
        return (x.GhostName == y.GhostName);
    }
    public override int GetHashCode(Ghost obj) // Have to return a unique value for each object
    {
        return obj.GhostName.GetHashCode();
    }
}

// Then we can use the Contains method and passing in a object of GhostNameComparer
GhostNameComparer ghostComparer = new();

boolResult = ghosts.Contains(new Ghost("Casper"), ghostComparer); // Make sure there is a constructor that takes the parameters passed to the new object


// SEQUENCEEQUAL, compares two collections for value sequence equality containing int, decimal etc.

int[] theNumbers = new int[] { 0, 1, 5 };
int[] moreNumbers = new int[] { 0, 5, 1 };

boolResult = theNumbers.SequenceEqual(moreNumbers); // false : 0,1,5 != 0,5,1
boolResult = theNumbers.SequenceEqual(moreNumbers.OrderBy(n => n)); //true : 0,1,5 = 0,1,5

// Object data types checks reference, create a new comparer class to check values in properties inheriting from EqualityComparer<T>
ComparerClassName comparer = new ComparerClassName();
ghosts.SequenceEqual(ghost2, comparer);


// EXCEPT/EXCEPTBY
// Except returns a new sequence that contains only the elements from the first sequence that are not in the second sequence.
// ExceptBy returns a new sequence based on a condition in lambda.

int[] theNumbers = new int[] { 0, 1, 2, 3 };
int[] moreNumbers = new int[] { 0, 1 };

resultIntList = theNumbers.Except(moreNumbers).ToList(); //Returns 2, 3, because these are not present in moreNumbers

// You can then check the other way and see whats missing in the other list
resultIntList = moreNumbers.(theNumbers.Except).ToList(); //Returns 0, all entries in moreNumbers are present in theNumbers


// ExceptBy allows you to define what part of the objects in your lists will be used to determine if the objects are considered the same.
string[] theNames = new string[] { "davor", "Bertil", "Susse", "David", "Albert", "PooBear", "Ally", "brent", "BabyYoda" };
string[] excludedNames = new string[] { "davor", "PooBear", "Susse" };

// Returns a new sequence containing the elements from theNames for which the extracted keys were not found in excludedNames
stringList = theNames.ExceptBy(excludedNames, name => name).ToList();

List<Ghost> ghostsList1 = new List<Ghost> {
    new Ghost("Casper Sr1","Grey",5000),
    new Ghost("Casper1","White",2000),
    new Ghost("Casper Jr1","White",490)
};
List<Ghost> ghostsList2 = new List<Ghost> {
    new Ghost("Casper Sr2","Grey",4000),
    new Ghost("Casper2","White",2100),
    new Ghost("Casper Jr","White",490)
};

// Find the Ghost objects in ghostsList1 whose GhostAge is not present
// in the GhostAge values of the Ghost objects in ghostsList2
// <Ghost, int> : Crystal clear that the source sequence contains Ghost objects and the comparison is based on int (GhostAge)
IEnumerable<Ghost> diff = ghostsList1.ExceptBy<Ghost, int>(
    ghostsList2.Select(g2 => g2.GhostAge), g1 => g1.GhostAge); //Returns Casper Sr1 and Casper1 because those ages does not exist in ghostList2
// Breaking down
//   Get GhostAge values from ghostsList2
//   Compare GhostAge values from ghostsList1 with GhostAge values from ghostsList2


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

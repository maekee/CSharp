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

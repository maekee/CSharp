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

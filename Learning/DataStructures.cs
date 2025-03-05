// Collections can be categorized into two main types: generic collections and non-generic collections
// Generic Collections us strong type safety by using <T>
// Whenever possible, it's recommended to use generic collections in C# because they offer stronger type safety, better performance, and improved usability

// ARRAYS
int[] intArr = new int[3];
int[] intArr = new int[] { 1, 2, 3 };
string[] strArr = new string[] { "Sweden", "Norway", "Denmark" };

// 2D Array
string[,] str2DArr = new string[,] { { "Dog", "Cat" }, { "Car", "Boat" }, { "Computer", "Tv" } };
Console.WriteLine(str2DArr[0,1]); //Results in Cat

// LISTS, are ordered, can contain duplicates
List<string> myList = new List<string> { };
myList.Add("Sweden");
myList.Add("Norway");
myList.Add("USA");
myList.Remove("USA");

// DICTIONARIES
Dictionary<int, string> animalDictionary = new Dictionary<int, string>();
animalDictionary.Add(1, "Dog");
animalDictionary.Add(2, "Chicken");
animalDictionary.Add(3, "Car");
animalDictionary.Remove(3);

bool exists = animalDictionary.ContainsKey(1); //True

//animalDictionary.Keys and animalDictionary.Values are present to iterate
foreach(string animal in animalDictionary.Values)
{
    Console.WriteLine(animal);
}

Dictionary<string, string[]> anotherAnimalDictionary = new Dictionary<string, string[]>();
anotherAnimalDictionary.Add("Chicken", ["Yellow","White"]);

// HASHSETS
// Do not use keys and duplicate elements are automatically ignored.
// Difference in List<T> and HashSet<T>: Lists are ordered, Lists can contain duplicates, Lists can be accessed by index
// HashSets are unique, HashSets have very fast lookups. Designed for operations like union, intersection and difference.

HashSet<string> nordicCountryHashSet = new HashSet<string>() { "Sweden", "Norway", "Denmark" };
HashSet<string> europeanCountryHashSet = new HashSet<string>() { "Germany", "Ukraine", "Sweden" };

HashSet<string> intersectionSet = new HashSet<string>(nordicCountryHashSet); //Create a copy
intersectionSet.IntersectWith(europeanCountryHashSet); //results in only Sweden present in new HashSet (intersects)

// QUEUES
// FIFO - First-in First-out. We use Enqueue and Dequeue.

Queue<string> myQueue = new Queue<string>();
myQueue.Enqueue("Mikey");
myQueue.Enqueue("Sebz");

Console.WriteLine(myQueue.Peek()); //Peek at the front of the queue = Mikey

myQueue.Dequeue(); //First in, first out = Mikey

Console.WriteLine(myQueue.Peek()); //Who's next? Sebz!

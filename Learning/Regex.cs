// I am a big fan of regex, so here goes...

// Regex.IsMatch
Regex.IsMatch("Uppsala","""U\w+"""); //Returns true

// Regex.Replace
string regexFilter = """(S\w+)""";
string originalString = "Victoria plays with Steve";
string newString = Regex.Replace(originalString, regexFilter, "Herobrine"); //Returns "Victoria plays with Herobrine"

//How about matching from string array, and make it case-insensitive
string[] swedishCitiesArr = "Visby,Stockholm,Malmö,Göteborg,Uppsala,Västerås,Umeå,Kalmar".Split(",");
string regexFilter = """(V\w+|U\w+)""";

foreach (string city in swedishCities.Order())
{
    if (Regex.IsMatch(city.ToLower(), regexFilter.ToLower()))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{city} is a match");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{city} is not a match");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

//We can also use my dear friend System.Linq
var hej = swedishCitiesArr.Where(city => Regex.IsMatch(city.ToLower(), """(v\w+|u\w+)"""));

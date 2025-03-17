// I am a big fan of regex, so here goes...

// Regex.IsMatch //IsMatch returns bool
Regex.IsMatch("Uppsala","""U\w+"""); //Returns true
Regex.IsMatch("uppsala","""U\w+"""); //Returns false (case sensitive)
Regex.IsMatch("uppsala","""U\w+""",RegexOptions.IgnoreCase); //Returns true (case insensitive)

// Regex.Replace
string regexFilter = """(S\w+)""";
string originalString = "Victoria plays with Steve";
string newString = Regex.Replace(originalString, regexFilter, "Herobrine"); //Returns "Victoria plays with Herobrine"

// Regex.Split
string input = @"07/14-2007";
string patternCaptureGroups = @"(-)|(/)";
string patternNoCaptureGroups = @"-|/";

string[] here = Regex.Split(input, patternCaptureGroups); //Returns string array with 07, /, 14, -, 2007 (regex using capture groups)
string[] here = Regex.Split(input, patternNoCaptureGroups); //Returns string array with 07, 14, 2007 (regex using no capture groups)

// Regex.Match code example with capture group
string input = @"07/14/2007";
string pattern = @"\d+/\d+/(\d+)$";

Match regexMatch = Regex.Match(input,pattern);

if (regexMatch.Success)
{
    string matchValue = regexMatch.Groups[1].Value;
}

// Regex.Matches code example that captures all matches
string input = "Monday is the first day, Tuesday is the second and Wednesday third";
string regexFilter = @"(\w{3,6}day)";

MatchCollection result = Regex.Matches(input, regexFilter);

Console.WriteLine($"We get {result.Count} matches"); //3 matches
Console.WriteLine($"The first match is: {result[0].Value}"); //Monday

foreach (var regexMatch in result)
{
    Console.WriteLine(regexMatch);
}

//Code example using IsMatch

//How about matching from string array, and make it case-insensitive
string[] swedishCitiesArr = "Visby,Stockholm,Malmö,Göteborg,Uppsala,Västerås,Umeå,Kalmar".Split(",");
string regexFilter = """(V\w+|U\w+)""";

foreach (string city in swedishCitiesArr.Order())
{
    if (Regex.IsMatch(city, regexFilter,RegexOptions.IgnoreCase))
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

//We can also use my dear friend System.Linq, case insensitive
var matches = swedishCitiesArr.Where(city => Regex.IsMatch(city, """(V\w+|U\w+)""", RegexOptions.IgnoreCase));

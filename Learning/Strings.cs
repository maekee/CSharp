// Strings are immutable, meaning you re-create them in the background of you modify them.
// A string is a reference type, but often behaves like a value type. C# makes string easy to create with the equal operator.

// If there are a lot of string modifications, we can improve performance with StringBuilder.
StringBuilder sb = new StringBuilder();

sb.Append("123");
sb.Append("45");
sb.Replace("12345", "ABCDE");
//sb.Clear();

Console.Write(sb.ToString());

// To save performance we can supply the StringBuilder (SB) with an initial capacity (number characters)
// For small strings or infrequent us the StringBuilder can have an larger overhead, even if its very minimal
// If we know the estimated size, we can supply the capacity to avoid SB from growing unnecessary.
// Even a rough estimate is better than relying on the default capacity (16)
StringBuilder sb = new StringBuilder(2048); //Changes from default capacity 16 to 2048

// If we want to go further down the performance rabbit hole there is also the DefaultInterpolatedStringHandler
DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler();
handler.AppendLiteral($"Hello {name}");
var stringNotComplete = handler.ToString(); //Retrieve the final constructed string without resetting the handler
var finalString = handler.ToStringAndClear(); // Retrieving the final constructed string and then resetting the handler

// Behind the scenes a constructor is used, which we also can explicitly call
string ordinaryHello = new string("Hello");
string fromCharArray = new string(charArray);

// Other nice things we can do with strings...
string formatted = string.Format("The value is: {0}", 42); //Composite formatting
string interpolated = $"The value is: {42}"; //String Interpolation
string filePath = @"C:\Windows\System32\calc.exe"; //Verbatim string literal

combinedString = string.Concat(stringArray);

string rawStringOneLine = """This is a "raw string literal". It can contain characters like \, ' and ".""" //Raw string literal, starts and ends with """;
string rawStringMultipleLines = """
        <xml example = "true">
          <body>
          </body>
        </xml>
        """;
// Raw string literals can be combined with string interpolation
string rawStringMultipleLines = $"""
        <xml example = "true">
          <body>
            <value1>{givenName}</value1>
          </body>
        </xml>
        """;

// In case we have curly braces in the data of the multiline value, we can make string interpolation require two curly braces, just prefix with two dollar signs
string rawStringMultipleLines = $$"""
        Strings are { fun } to {{verb}} with
        """;
        
double doubleValue = 1632.54;
doubleValue.ToString("C", new System.Globalization.CultureInfo("en-US")); //$1,632.54
doubleValue.ToString("$0.00"); // $1632,54
doubleValue.ToString("0.0 kr") // 1632,5 kr

0.1.ToString("P1"); //Percent 10,0%
42.ToString("X"); //Hex 2A
42.ToString("B"); //Binary 101010
42.ToString("D5"); //Digits 00042

int i = 100;
$"{i,-10}X" // "100       X"
$"{i,10}X" // "       100X"

//We can also use the Padding methods
42.ToString().PadLeft(5, 'X'); //XXX42
42.ToString().PadRight(5, 'X'); //42XXX

42.ToString("F2"); //Decimals 42,00

double pi = 3.14159;
string pi = $"Pi to two decimal places: {pi:F2}"; //2 decimals, 3.14

// GUID formatted

//Guid myGuid = Guid.NewGuid(); //Generate new random guid
Guid myGuid = new Guid("00000000-0000-0000-0000-000000000000"); //Used for example

Console.WriteLine("Original Guid: " + myGuid); //00000000-0000-0000-0000-000000000000
Console.WriteLine("N format (32 digits): " + myGuid.ToString("N")); //00000000000000000000000000000000
Console.WriteLine("D format (hyphens): " + myGuid.ToString("D")); //00000000-0000-0000-0000-000000000000
Console.WriteLine("B format (braces): " + myGuid.ToString("B")); //{00000000-0000-0000-0000-000000000000}
Console.WriteLine("P format (parentheses): " + myGuid.ToString("P")); //(00000000-0000-0000-0000-000000000000)
Console.WriteLine("X format (registry-style): " + myGuid.ToString("X")); //{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}

// Static string methods
string.IsNullOrEmpty(myString); //null or empty string ("")
string.IsNullOrWhiteSpace(myString); //null, empty string ("") or white space (spaces, tabs, new lines)

// We can compare strings with == and Equals, the difference is additiona options
// Which method do you think looks best for case-insensitive match? If you ask me? resultD!
string stringUpper = "Hello";
string stringLower = "hello";

bool resultA = stringUpper == stringLower; //false
bool resultB = stringUpper.ToLower() == stringLower.ToLower(); //true
bool resultC = stringLower.Equals(stringUpper); //false
bool resultD = stringLower.Equals(stringUpper, StringComparison.OrdinalIgnoreCase); //true

// We can also use the string.Compare
// Returns an integer that indicates the relationship of the two substrings to each other in the sort order.
// 0 : Same position, 1 or -1 : Not the same position = not equals
int resA = string.Compare(stringUpper, stringLower, StringComparison.OrdinalIgnoreCase); //returns 0
int resA = string.Compare(stringUpper, stringLower); //returns 1

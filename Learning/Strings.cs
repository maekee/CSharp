// Strings are immutable, meaning you re-create them in the background of you modify them.
// If there are a lot of string modifications, we can improve performance with StringBuilder.

StringBuilder sb = new StringBuilder();

sb.Append("123");
sb.Append("45");
sb.Replace("12345", "ABCDE");
sb.Clear();

Console.Write(sb.ToString());

// A string is a reference type, but often behaves like a value type. C# makes string easy to create with the equal operator.
// Behind the scenes a constructor is used, which we also can explicitly call

string ordinaryHello = new string("Hello");
string fromCharArray = new string(charArray);

// Other nice things we can do with strings...
string formatted = string.Format("The value is: {0}", 42); //Composite formatting

string interpolated = $"The value is: {42}"; //String Interpolation

string filePath = @"C:\Windows\System32\calc.exe"; //Verbatim string literal

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

// Static string methods
string.IsNullOrEmpty(myString); //null or empty string ("")
string.IsNullOrWhiteSpace(myString); //null, empty string ("") or white space (spaces, tabs, new lines)

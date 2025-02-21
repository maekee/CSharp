/*
  Suffixing data types
  5 //integer
  5f //float
  5m //decimal
*/

/*
Always use decimal if precision is important
decimal myDecimal = 1.12345678m;
float myFloat = (float)myDecimal;

results in
myDecimal = 1,12345678
myFloat   = 1,1234568
*/

int intValue = 5;

// Implicit casting means safe casting
decimal myDecimal = intValue;

// Explicit casting means unsafe casting, you need to specify the target type with parentheses
// This is a narrowing conversion. Meaning truncating everything on the right side of .
int myInt = (int)myDecimal;

// Convert Class methods. Converting rounds up. (decimal 1.5 to int, becomes 2)
Convert.ToString()
Convert.ToInt16()
Convert.ToInt32() //int is System.Int32
Convert.ToInt64()
Convert.ToDecimal()
Convert.ToBoolean()
Convert.ToDateTime()
Convert.ToUInt16() .ToUInt32() .ToUInt64() //Only positive numbers
etc..

// The data types classes have the Parse method
Boolean.Parse()
int.Parse()
Decimal.Parse()
float.Parse()
Double.Parse()
DateTime.Parse()
TimeSpan.Parse()
etc....

// The TryParse method can be used to verify
if (int.TryParse(numbersInString, out intResult))
{
  Console.WriteLine($"Conversion was successful to variable {intResult}");
}

// Or just get a simple bool if TryParse could convert or not
bool success = decimal.TryParse(inputVariable, out decimal decimalNumber);

// Culture in the way. When doing conversions make sure you know if the system is using . or , when dealing with decimals
// You can force this to always be EN-US (using .) so behaviour does not change from system to system in different regions.

// CurrentCulture "sv-SE" uses , which makes below code result in false
bool success = decimal.TryParse("12.3", out decimal dec);

// But in US, or forcing to use CurrentCulture US like code below.
CultureInfo.CurrentCulture = new CultureInfo("en-US");
// Now decimals use . and the success results in true

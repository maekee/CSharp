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

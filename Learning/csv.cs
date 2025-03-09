// There are several ways to read from CSV files

// CsvHelper, 3rd party .NET Library. The simplest way

// With the TextFieldParser
using Microsoft.VisualBasic.FileIO;

using (TextFieldParser parser = new TextFieldParser(csvFile))
{
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");
    
    if (!parser.EndOfData) //Optional
    {
        parser.ReadLine(); //Read the first line (columns), so its skipped in the while loop
    }
    
    while (!parser.EndOfData)
    {
        string[] fields = parser.ReadFields();
        // Code logic
    }
}

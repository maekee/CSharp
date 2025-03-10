// Here we convert list of objects to Json, save to file, read from file and deserialize back to list of objects again

using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;

// Person class constructor uses GivenName and SurName below
List<Person> listOfPersons = new List<Person>
{
    new Person("Maekee", "McSeaSharper"),
    new Person("Sören", "Ärlandsson"),
    new Person("Karin", "Spözwich"),
    new Person("Taxi", "Überzon")
};

// JsonSerializer by default escape Unicode characters outside the basic ASCII range (like Swedish åäö)
// You need to tell JsonSerializer to not escape Unicode characters
var jsonSerializeOptions = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

// Serializing (C# Object to JSON)
// Converting list of Person objects to JSON and save in jsonString, use jsonSerializeOptions
string jsonString = JsonSerializer.Serialize(listOfPersons, jsonSerializeOptions);

// Write jsonString to file
using (StreamWriter writer = new StreamWriter(jsonPath, false, Encoding.UTF8)) //false overwrites, true appends
{
    writer.Write(jsonString);
}

// Read content of file
string jsonStringFromFile = File.ReadAllText(jsonPath,Encoding.UTF8);

// Deserializing (JSON to C# Object)
// Re-create the list and class objects from file
List<Person> importedList = JsonSerializer.Deserialize<List<Person>>(jsonStringFromFile);

// Remember to handle potential exceptions (e.g., KeyNotFoundException, InvalidOperationException) when accessing or manipulating JSON nodes.

////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Nodes;

// Creating JsonObject
JsonObject myJson = new()
{
    ["Name"] = "Maekee",
    ["noCars"] = 2,
    ["isMan"] = true,
    ["address"] = new JsonObject
    {
        ["street"] = "Street 1",
        ["City"] = "Stockholm"
    },
    ["Hobbies"] = new JsonArray { "Photography", "Coding" }
};

// JsonNode:   (Base Class): Represents any JSON value (object, array, string, number, boolean, or null).
// JsonObject: Represents a JSON object (a collection of key-value pairs).
//             Use indexers (["key"]) to access or set values
// JsonArray:  Represents a JSON array (an ordered list of values).
//             Use indexers ([index]) to access or set elements
// JsonValue:  Represents a single JSON value (string, number, boolean, or null).
//             Use GetValue<T>() to retrieve the underlying value.

string theName = myJson["Name"].GetValue<string>(); //Get name
string street = myJson["address"]["street"].GetValue<string>(); //Get address

myJson["noCars"] = 3; //Updating value
myJson["Job"] = "Developer"; //Add item "Job"

////////////////////////////////////////////////////////////////////////////////
// Performance problems when working with large json files??
// If you want read-only access with better performance (especially for large JSON documents),
// consider using JsonDocument and JsonElement. JsonNode is mutable and creates a new object
// in memory for each element, while JsonDocument parses the JSON into a read-only structure.

string json = @"{ ""name"": ""Charlie"", ""age"": 40 }";
using JsonDocument document = JsonDocument.Parse(json);
JsonElement root = document.RootElement;
Console.WriteLine(root.GetProperty("name").GetString());

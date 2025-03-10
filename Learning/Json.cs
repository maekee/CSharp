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

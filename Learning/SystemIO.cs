// Lets play with CRUD (Create, Read, Update, Delete) in System.IO
// We have a few .NET classes we can look at to help us. For example Path, File, FileInfo, Directory, DirectoryInfo

// FOLDERS
Create : Directory.CreateDirectory, Directory.CreateDirectory
Read   : Directory.Exists, Directory.GetFiles, Directory.GetDirectories, Directory.EnumerateFiles, DirectoryInfo
Update : Directory.Move //includes Rename
Delete : Directory.Delete

//Code examples

Directory.CreateDirectory(folderPath);
Directory.Move(folderPath, newFolderPath); //Can also be used to rename folders
Directory.Delete(folderPath);

string[] files = Directory.GetFiles(folderPath); //returns 
// Waits until all files have been found before returning the entire array into memory

// There is also an EnumerateFiles method, which returns an IEnumerable<string> instead of string[].
// Ideal when you're processing files sequentially and don't need to load the entire list into memory.
// + When dealing with directories containing a large number of files.
// + when you want to start processing files as soon as they are found.

// Search for ini files in folder and subfolders
foreach (string filePath in Directory.EnumerateFiles(basePath, "*.ini", SearchOption.AllDirectories))
{
    Console.WriteLine(filePath);
}

// FILE
Create : File.Create, File.Copy
Read   : File.Exists, File.ReadAllLines, File.ReadAllText, File.ReadAllBytes, FileInfo
Update : File.AppendText, File.AppendAllLines, File.WriteAllLines
Delete : File.Delete

// Building Paths
There are two Methods we can use to building Paths: Path.Combine and Path.Join. They work similar and sometimes the same.
//Path.Combine discards one path if the other is an absolute path
//Path.Join joins together paths what ever values are supplied.

Path.Combine(@"C:\Folder123\", @"C:\Folder123\"); //results in "C:\Folder123\"
Path.Join(@"C:\Folder123\", @"C:\Folder123\"); //results in "C:\Folder123\C:\\Folder123\"
// Path.xxxx(@"C:\Folder123", @"filename.txt") //Join and Combine will give the same result

// If you want to use Windows standardfolders like Documents, Desktop etc there is an Enum available called Environment.SpecialFolder
https://learn.microsoft.com/en-us/dotnet/api/system.environment.specialfolder
// Get the dynamic path with the GetFolderPath method:
System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //Retrieves the MyDocuments path
    
// Code examples

string basePath = @"D:\CSharp-Projects\RandomFiles\";
string iniFile = Path.Combine(basePath, "application.ini");
string newIniFile = Path.Combine(basePath, "AppZ.ini");
string backupIniFile = Path.Combine(basePath, "backup.ini");

File.Delete(iniFile); //Delete the file
File.Delete(newIniFile); //Delete the file
File.Delete(backupIniFile); //Delete the file

//Create or overwrite a new file
FileStream fs = File.Create(iniFile);
fs.Close();

File.Move(iniFile, newIniFile, true); //Rename (Move) the file
File.Copy(newIniFile, backupIniFile, true); //Copy the file

//Build content and add to file
StringBuilder content = new StringBuilder();
content.AppendLine("[System]");
content.Append("Hostname=");
content.Append("Computer001");
File.WriteAllText(newIniFile,content.ToString()); //Write content to file


// Display Content in file with the using keyword
// The using keyword in C# ensure that resources, such as file streams are properly disposed of after they are no longer needed
// Designed to work with objects that implement the IDisposable interface (defines the Dispose() method)
// FileStream, StreamReader, and StreamWriter implement IDisposable.

using (StreamReader streamReader = new StreamReader(newIniFile))
{
    while (!streamReader.EndOfStream)
    {
        string line = streamReader.ReadLine();
        if (Regex.IsMatch(line, "regexMatchStringHere", RegexOptions.IgnoreCase))
        {
            Console.WriteLine(line);
        }
    }
}

// Write line with the using statement and StreamWriter
using (StreamWriter daWriter = new StreamWriter(filePath, false, Encoding.UTF8)) //false overwrites, true appends
{
    daWriter.Write(customString);
}

//Display content in file from string array
string[] contentData = File.ReadAllLines(newIniFile); 
foreach (string line in contentData) //Read all lines as string[]
{
    Console.WriteLine(line);
}

//Display content in file from string
string contentRaw = File.ReadAllText(newIniFile);
Console.WriteLine(contentRaw.Replace("\r\n", "\n")); //Read all lines and replace with newlines

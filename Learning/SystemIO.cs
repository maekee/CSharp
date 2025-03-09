// Lets play with CRUD (Create, Read, Update, Delete) in System.IO
// We have a few .NET classes we can look at to help us. For example Path, File, FileInfo, Directory, DirectoryInfo

// FOLDERS
Create : Directory.CreateDirectory, Directory.CreateDirectory
Read   : Directory.Exists, Directory.GetFiles, Directory.GetDirectories, Directory.EnumerateFiles, DirectoryInfo
Update : Directory.Move //includes Rename
Delete : Directory.Delete

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

//Display content in file from string array
string[] contentData = File.ReadAllLines(newIniFile); 
foreach (string line in contentData) //Read all lines as string[]
{
    Console.WriteLine(line);
}

//Display content in file from string
string contentRaw = File.ReadAllText(newIniFile);
Console.WriteLine(contentRaw.Replace("\r\n", "\n")); //Read all lines and replace with newlines


//
foreach (string Name in Directory.GetFiles(@"C:\windows", "b*"))
//
foreach(string Name in Directory.GetFileSystemEntries(@"C:\windows", "b*"))
{
    Console.WriteLine(Name);
}
Console.ReadLine();

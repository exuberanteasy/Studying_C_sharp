//
//   Peace!
//


//=== 取得電腦上的邏輯磁碟名稱
foreach(string Name in Directory.GetLogicalDrives())
    
//=== 取得參數 path 指定的資料夾內所有檔案的名稱(包含完整路徑)
foreach (string Name in Directory.GetFiles(@"C:\windows", "b*"))
    
//=== 取得參數 path 指定的資料夾
foreach(string Name in Directory.GetFileSystemEntries(@"C:\windows", "b*"))
{
    Console.WriteLine(Name);
}
Console.ReadLine();

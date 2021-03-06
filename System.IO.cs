//
//   Peace!
//

//=== 把檔案讀出來(存檔注意是要 Unicode 編碼)
StreamReader objReader = new StreamReader(@"D:\Poetry1.txt", System.Text.Encoding.Unicode);
string MyLine = objReader.ReadLine();          //從檔案指標的位置讀取一行
while (MyLine != null)                         //檢查是否碰到檔案結尾
{
    Console.WriteLine(MyLine);
    MyLine = objReader.ReadLine();
}
objReader.Close();
Console.ReadLine();


//=== 
string Path = @"D:\MyDir";
if (Directory.Exists(Path) == false)
{
    Directory.CreateDirectory(Path);
}
Console.WriteLine("資料夾建立時間: " + Directory.GetCreationTime(Path));
Console.WriteLine("資料夾最後存取時間: " + Directory.GetLastAccessTime(Path));
Console.WriteLine("資料夾的跟目錄: " + Directory.GetDirectoryRoot(Path));

Console.ReadLine();

//=== 如果目的地沒有資料夾，那就自己創一個吧
string path = @"C:\testGO\testDirectory";
if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
}


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

//=================================[[ StreamWriter 類別的方法 ]]=====================================
//== 使用 WriteLine() 加入第 X 行文字
StreamWriter objWriter = new StreamWriter(@"D:\MyText.txt", true);
objWriter.WriteLine("這是使用WriteLine() 方法加入第一行文字");
objWriter.WriteLine();
objWriter.WriteLine("這是使用WriteLine() 方法加入第二行文字");
objWriter.WriteLine();
objWriter.WriteLine("這是使用WriteLine() 方法加入第三行文字");
objWriter.WriteLine();
objWriter.Close();


// 檔案會亂碼
// 用 FileStream 物件讀取檔案的全部內容並顯示出來
FileStream objFileStream = new FileStream(@"D:\Poetry3.txt", FileMode.Open, FileAccess.Read);
byte[] MyByteArray = new byte[objFileStream.Length];
string Content = "";
objFileStream.Read(MyByteArray, 0, System.Convert.ToInt32(objFileStream.Length));
foreach(byte MyByte in MyByteArray)
{
    Content = Content + System.Convert.ToChar(MyByte);
}
Console.Write(Content);
objFileStream.Close();
Console.ReadLine();

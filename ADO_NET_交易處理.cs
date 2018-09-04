17-33 - Visual C# 2017 程式設計經典
ADO.NET 交易處理

Step 1:建立名為 cn 的 Connection 資料來源連接物件 => 呼叫該物件的 Begin Transaction方法
      以便取得名為 tran 的 Transaction 交易物件
SqlConnection cn = new SqlConnection("連接字串");
cn.Open();
SqlTransaction tran = cn.BeginTransaction(); //傳回 tran 交易物件

Step 2:建立一連串要執行的資料庫操作工作的 Command 物件，並指定該 Command 物件所要執行的SQL語法、

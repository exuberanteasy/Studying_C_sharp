17-33 - Visual C# 2017 程式設計經典
ADO.NET 交易處理

Step 1:建立名為 cn 的 Connection 資料來源連接物件 => 呼叫該物件的 Begin Transaction方法
      以便取得名為 tran 的 Transaction 交易物件
  SqlConnection cn = new SqlConnection("連接字串");
  cn.Open();
  SqlTransaction tran = cn.BeginTransaction(); //傳回 tran 交易物件

Step 2:建立一連串要執行的資料庫操作工作的 Command 物件，並指定該 Command 物件所要執行的 SQL語法、
       cn 連接物件(Connection)及 tran 交易物件。
  SqlCommand cmd1 = new SqlCommand("SQL語法 1", cn, tran);
  SqlCommand cmd2 = new SqlCommand("SQL語法 2", cn, tran);

  SqlCommand cmdN = new SqlCommand("SQL語法 N", cn, tran);

Step 3:使用 Command 物件的 ExecuteNonQuery方法執行 SQL語法，使多個資料庫的操作功能能執行。
  cmd1.ExecuteNonQuery();
  cmd2.ExecuteNonQuery();
  cmdN.ExecuteNonQuery();

Step 4: 執行全部資料庫操作工作後，若沒有發生錯誤，可以使用 Transaction 物件的 Commit方法來認可此交易，
        此時即將所有 Command物件所指定的資料庫操作工作寫入資料庫中。寫法如下:
  tran.Commit();

Step 5: 若發生錯誤，即執行 Transaction物件的 Rollback方法來回復交易，使資料庫內容回復到執行交易之前的狀態
  
 
TransactionDemo1.sln => 另外做一個連接
P.17-37

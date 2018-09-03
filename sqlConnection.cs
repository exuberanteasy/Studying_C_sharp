using System.Data.SqlClient;  //記得加上這一行

private void Form1_Load(object sender, EventArgs e)
{
    sqlConnection1.Open();  //開啟資料連接
    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader(); // 建立 SqlDataReader 物件
    while (sqlDataReader1.Read())  // 顯示查詢結果中的學生姓名
    {
        comboBox1.Items.Add(sqlDataReader1.GetString(1)); //單選
        
        checkedListBox1.Items.Add(sqlDataReader1.GetString(1)); //複選
    }
    sqlDataReader1.Close();  //關閉 SqlDataReader 物件
    sqlConnection1.Close();  //關閉資料連接
}

//==================================================
SELECT  學號, 姓名, 中文, 數學, English
FROM     成績單
WHERE   (中文 > 90)
    
//=========================================================
//DataSet 物件與控制項的整合運用
private void Form1_Load(object sender, EventArgs e)
{
    sqlDataAdapter1.Fill(dataSet11);
}

//======================================================
=> 由於 DataSet 物件會記錄欄位結構，因此，若您修改過 SqlDataAdapter 物件的 SelectCommand 屬性鎖鑰執行的
Select 陳述式(該陳述式決定了要取得哪些欄位)，請記得刪除原來的 DataSet 物件，重新產生一個 DataSet 物件
=> 任何有 DataSource 屬性的控制項都可以與資料庫整合運用，例如 ComboBox、ListBox、CheckedListBox、DataGridView 等。

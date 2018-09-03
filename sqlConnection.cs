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

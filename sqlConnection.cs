private void Form1_Load(object sender, EventArgs e)
{
    sqlConnection1.Open();  //開啟資料連接
    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader(); // 建立 SqlDataReader 物件
    while (sqlDataReader1.Read())  // 顯示查詢結果中的學生姓名
    {
        comboBox1.Items.Add(sqlDataReader1.GetString(1));
    }
    sqlDataReader1.Close();  //關閉 SqlDataReader 物件
    sqlConnection1.Close();  //關閉資料連接
}

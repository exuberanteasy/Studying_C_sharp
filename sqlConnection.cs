private void Form1_Load(object sender, EventArgs e)
{
    sqlConnection1.Open();  //開
    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader(); // 建立 SqlDataReader 物件
    while (sqlDataReader1.Read())
    {
        comboBox1.Items.Add(sqlDataReader1.GetString(1));
    }
    sqlDataReader1.Close();  //關閉Sql
    sqlConnection1.Close();
}

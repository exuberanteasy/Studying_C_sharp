private void button1_Click(object sender, EventArgs e)
{
    const double PI = 3.14;
    double Radius = System.Convert.ToDouble(textBox1.Text);
    double CirleArea = PI * Radius * Radius;
    MessageBox.Show("圓的面積為" + Convert.ToString(CirleArea)); //System. 可以簡化
}

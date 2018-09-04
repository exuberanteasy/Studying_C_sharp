using ADO.NET.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET
{
    public partial class FrmConnected : Form
    {
        public FrmConnected()
        {
            InitializeComponent();

            LoadToComboBox();

            CreateListViewcolumns();
            this.tabControl1.SelectedIndex = 3;
            this.tabControl2.SelectedIndex = 2;

            // pictureBox1.DragEnter += pictureBox1_dragEnter;

            this.pictureBox1.AllowDrop = true;
            this.pictureBox1.DragEnter += PictureBox1_DragEnter;
            this.pictureBox1.DragDrop += PictureBox1_DragDrop;

            //this.DragEnter += FrmConnected_dragEnter;

            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.DragEnter += FlowLayoutPanel1_DragEnter;
            this.flowLayoutPanel1.DragDrop += FlowLayoutPanel1_DragDrop;



        }

        private void FlowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
            for(int i =0; i<filenames.Length; i++)
            //foreach()
            {
                PictureBox pcb = new PictureBox();
                pcb.SizeMode = PictureBoxSizeMode.StretchImage;
                pcb.BorderStyle = BorderStyle.Fixed3D;
                this.flowLayoutPanel1.Controls.Add(pcb);
            }
        }

        private void FlowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] st = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.pictureBox1.Image = Image.FromFile(st[0]);

        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void CreateListViewcolumns()
        {
            this.listView1.View = View.Details;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("Select * from Customers where Country= '" + comboBox1.Text + "'", conn))
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                          
                            this.listView1.Items.Clear();
                            while (dataReader.Read())
                            {
                                ListViewItem x = this.listView1.Items.Add(dataReader[0].ToString());
                                
                                if (x.Index % 2 == 0)
                                {
                                    x.BackColor = Color.Crimson;
                                }
                                else
                                {
                                    x.BackColor = Color.Brown;
                                }
                                for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                                {
                                    x.SubItems.Add(dataReader[i].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadToComboBox()
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    
                    using (SqlCommand command = new SqlCommand("Select distinct Country from Customers", conn))
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            this.comboBox1.Items.Clear();
                            while (dataReader.Read())
                            {
                                this.comboBox1.Items.Add(dataReader["Country"]);
                            }
                            this.comboBox1.SelectedIndex = 1;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("Select* from Customers where Country='"+this.comboBox1.Text+"'", conn))
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            this.listView1.Items.Clear();
                            while (dataReader.Read())
                            {
                                this.listView1.Items.Add(dataReader[0].ToString());
                            }
                            
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            for(int i = 1;i<=10;i++)
            {
                ListViewGroup IvGroup = this.listView3.Groups.Add(i.ToString(), "Country" + 1);
                for(int j = 1;j<=5;j++)
                {
                    ListViewItem IvItem = listView3.Items.Add(j.ToString());
                    IvItem.Group = IvGroup;
                }

                
            }
            for (int i = 1; i <= 10; i++)
            {
                TreeNode x = this.treeView1.Nodes.Add(i.ToString());
                for (int j = 1; j <= 5; j++)
                {
                    x.Nodes.Add(i+","+j.ToString());
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        string userName = this.textBox1.Text;
                        string password = this.textBox2.Text;
                        command.CommandText = "Insert into Member(Username,Password) values ('"+userName+"','"+password +"')";
                        command.Connection = conn;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert member sucessfully");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())

                    {
                        string userName = this.textBox1.Text;
                        string password = this.textBox2.Text;

                        command.CommandText = "select * from MyMember where UserName ='" + userName + "' and Password = '" + password + "'";
                        MessageBox.Show(command.CommandText);

                        command.Connection = conn;

                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                MessageBox.Show("Login member successfully");
                            }
                            else
                            {
                                MessageBox.Show("Login mmeber  failed");
                            }
                        }
                    } //command.Dispose()
                }// auto conn.Close(); conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        string userName = this.textBox1.Text;
                        string password = this.textBox2.Text;
                        command.CommandText = "Insert into Member(Username,Password) values (@Username, @Password)";
                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 16).Value = userName;
                        //SqlParameter p1 = new SqlParameter();
                        //p1.ParameterName = "@Username";
                        //p1.SqlDbType = SqlDbType.NVarChar;
                        //p1.Size = 16;
                        //p1.Value = userName;
                        //command.Parameters.Add(p1);
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;
                        command.Connection = conn;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert member sucessfully");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        string userName = this.textBox1.Text;
                        string password = this.textBox2.Text;
                        command.CommandText = "InsertMember";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 16).Value = userName;                     
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                        //====================================
                        SqlParameter p1 = new SqlParameter();
                        p1.ParameterName = "@return_Value";
                        p1.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(p1);

                        //==================================
                        command.Connection = conn;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert member sucessfully ,  Member ID="+p1.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        string userName = this.textBox1.Text;
                        string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.textBox2.Text, "sha1");
                        command.CommandText = "InsertMember";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 16).Value = userName;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                        //====================================
                        SqlParameter p1 = new SqlParameter();
                        p1.ParameterName = "@return_Value";
                        p1.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(p1);

                        //==================================
                        command.Connection = conn;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert member sucessfully ,  Member ID=" + p1.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string userName = this.textBox1.Text;
            string password = this.textBox2.Text;
            this.memberTableAdapter1.Insert(userName, password);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "select Max(UnitPrice) from Products";
                        this.listBox1.Items.Add("Max UnitPrice = " + command.ExecuteScalar());

                        command.CommandText = "select Min(UnitPrice) from Products";
                        this.listBox1.Items.Add("Min UnitPrice = " + command.ExecuteScalar());
                        command.CommandText = "select Avg(UnitPrice) from Products";
                        this.listBox1.Items.Add("Avg UnitPrice = " + command.ExecuteScalar());
                        command.CommandText = "select Count(*) from Products";
                        this.listBox1.Items.Add("Count = " + command.ExecuteScalar());
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("select * from Products", conn))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while(dataReader.Read())
                            {
                                this.listBox1.Items.Add(dataReader[ProductName]);
                            }
                        }
                     }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        conn.Open();

                        string MyCommand = "CREATE TABLE[dbo].[MyImageTable]" +"("+

                           " [ImageID][int] IDENTITY(1,1) NOT NULL," +
                           "[Description] [text] NULL," +
                           "[Image] [image] NULL," +
                           "CONSTRAINT[PK_MyImageTable] PRIMARY KEY CLUSTERED" +"("+
                           " [ImageID] ASC" + 
                           ")WITH(PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON"+")"+" ON[PRIMARY]" +
                           ") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";
                        command.CommandText = MyCommand;
                        command.ExecuteNonQuery();
                        MessageBox.Show("create Table succesfully");

                    }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        string userName = this.textBox1.Text;
                        string password = this.textBox2.Text;

                        //========================
                        Byte[] bytes;//={ 1, 3 };
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        this.pictureBox1.Image.Save(ms, ImageFormat.Bmp);
                        bytes = ms.GetBuffer();

                        //
                        command.CommandText = "Insert into MyimageTable(Description,Image) values (@Description, @Image)";
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = this.textBox4.Text;// DateTime.Now;
                        command.Parameters.Add("@Image", SqlDbType.VarBinary).Value = bytes;
                        command.Connection = conn;

                        conn.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Insert member sucessfully");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {                                                
                        command.CommandText = "select * from MyImageTable";
                  
                        command.Connection = conn;

                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            this.listBox3.Items.Clear();
                            this.listBox4.Items.Clear();
                            while(dataReader.Read())
                            {
                                this.listBox3.Items.Add(dataReader["Description"]);
                                this.listBox4.Items.Add(dataReader["ImageID"]);
                            }
                           
                        }                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ImageID = (int)this.listBox4.Items[this.listBox3.SelectedIndex];
            showImage(ImageID);
        }

        private void showImage(int imageID)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "select * from MyImageTable where ImageID="+imageID;

                        command.Connection = conn;

                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            byte[] bytes = (byte[])dataReader["Image"];
                            //MessageBox.Show("bytes Length = " + bytes.Length);
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                            this.pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.pictureBox2.Image = this.pictureBox2.ErrorImage;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "select * from MyImageTable " ;

                        command.Connection = conn;

                        conn.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            this.listBox5.Items.Clear();
                                while(dataReader.Read())
                            {
                                MyImage x = new MyImage();
                                x.ImageID = (int)dataReader["ImageID"];
                                x.Desc = dataReader["Description"].ToString();

                                this.listBox5.Items.Add(x);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.pictureBox2.Image = this.pictureBox2.ErrorImage;
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.listBox5.SelectedIndex==-1)
            {
                return;
            }
            else
            {
                int ImageID = ((MyImage)this.listBox5.Items[this.listBox5.SelectedIndex]).ImageID;
                showImage(ImageID);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void FrmConnected_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dataset.MyImageTable' 資料表。您可以視需要進行移動或移除。
            this.myImageTableTableAdapter.Fill(this.dataset.MyImageTable);

        }

        private void myImageTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.myImageTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataset);

        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
class MyImage
{
    internal int ImageID;
    internal string Desc;
    public override string ToString()
    {
        return this.ImageID + "-" + this.Desc;
    }
}


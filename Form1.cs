using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQl_WindowForm_Sudhir_n01324321
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-CCPDKVPS\\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //  SqlCommand cmd = new SqlCommand("insert into Students(FirstName) values('"+textBox1.Text+"')", con);
            // con.Open();
            // int i = cmd.ExecuteNonQuery();
            // if (i != 0)
            // {
            //     MessageBox.Show("Data Inserted");
            // }
            // else
            // {
            //     MessageBox.Show("Error");

            // }



            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Students] (FirstName , LastName , StudentId , Semester) values('" + txtfirstname.Text + "' ,'" + txtlastname.Text + "', '" + textstudentid.Text + "','" + textsem.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            Displaydata();
            MessageBox.Show("Data Inserted");

        }

          
        public void Displaydata()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Students]";
            cmd.ExecuteNonQuery();

            DataTable table = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Displaydata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from [Students] where FirstName = '" + txtfirstname.Text + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
            Displaydata();
            MessageBox.Show("Data Removed");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [Students] SET LastName = '"+txtlastname.Text+ "' ,StudentId = '" + textstudentid.Text + "' , Semester = '" + textsem.Text + "'  where FirstName = '" + txtfirstname.Text + "' ";
            cmd.ExecuteNonQuery();
            con.Close();
            Displaydata();
            MessageBox.Show("Data Updated");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from [Students] where FirstName = '" + txtSearch.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }
    }
}

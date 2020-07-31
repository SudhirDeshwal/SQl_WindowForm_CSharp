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
        //Connection string
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-CCPDKVPS\\SQLEXPRESS;Initial Catalog=demo;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }


        //Insert in db
        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Sql query
            cmd.CommandText = "insert into [Students] (FirstName , LastName , StudentId , Semester) values('" + txtfirstname.Text + "' ,'" + txtlastname.Text + "', '" + textstudentid.Text + "','" + textsem.Text + "')";
            
            //execute query
            cmd.ExecuteNonQuery();
            con.Close();
            Displaydata();
            MessageBox.Show("Data Inserted");

        }

          

        //display in grid view form db
        public void Displaydata()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

          //Sql  query
            cmd.CommandText = "Select * from [Students]";
            cmd.ExecuteNonQuery();

            DataTable table = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            //Execute the  query

            dataadp.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Displaydata();
        }


        //delete from db by name
        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //Sql  query
            cmd.CommandText = "Delete from [Students] where FirstName = '" + txtfirstname.Text + "' ";
            //Execute   query
            cmd.ExecuteNonQuery();
            con.Close();
            Displaydata();
            MessageBox.Show("Data Removed");
        }


       //update in db by name
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //Sql  query
            cmd.CommandText = "UPDATE [Students] SET LastName = '"+txtlastname.Text+ "' ,StudentId = '" + textstudentid.Text + "' , Semester = '" + textsem.Text + "'  where FirstName = '" + txtfirstname.Text + "' ";

            //Execute  query
            cmd.ExecuteNonQuery();
            con.Close();
            Displaydata();
            MessageBox.Show("Data Updated");
        }


        //search in db by name and display in grid view
        private void btnSearch_Click(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //Sql  query
            cmd.CommandText = "Select * from [Students] where FirstName = '" + txtSearch.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);

            //Execute  query
            dataadp.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }


        //search in db by name and display in text boxes
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            //Sql  query
            cmd.CommandText = "Select * from [Students] where FirstName = '" + txtfirstname.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            //Execute  query
            dataadp.Fill(table);
            dataGridView1.DataSource = table;

            SqlDataReader dr = cmd.ExecuteReader();


            //fetching name in textboxes
            if (dr.HasRows)
            {
                while (dr.Read())
                { 
                    txtfirstname.Text = dr["FirstName"].ToString();
                    txtlastname.Text = dr["LastName"].ToString();
                    textstudentid.Text = dr["StudentId"].ToString();
                    textsem.Text = dr["Semester"].ToString();
                }
            }
            else
            {

                MessageBox.Show("Name is not in the table");
            }
            con.Close();
        }
    }
}

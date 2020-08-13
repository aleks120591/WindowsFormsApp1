using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1{
    public partial class Form3 : Form{
        OleDbConnection con;
            OleDbDataAdapter da;
            OleDbCommand cmd;
            DataSet ds;
        public Form3(){
            InitializeComponent();
        }
        void GetBook(){
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=books.mdb");
            da = new OleDbDataAdapter("SELECT *FROM books", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "books");
            dataGridView1.DataSource = ds.Tables["books"];
            con.Close();
        }
        private void Form3_Load(object sender, EventArgs e){
            GetBook();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e){
            string query = "Insert into books (autor, name, anotation) values (@fName, @lName, @aName)";
            cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@fName", textBox1.Text);
            cmd.Parameters.AddWithValue("@lName", textBox2.Text);
            cmd.Parameters.AddWithValue("@aName", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GetBook();
        }
    }
}

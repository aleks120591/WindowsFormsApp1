using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApp1{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();            
        }
        
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e){
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e){

        }

        private void Form1_Load(object sender, EventArgs e){
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e){

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e){

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e){
            Form Form2 = new Form2();
            Form2.Show();
            //this.Hide();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e){
            Form Form3 = new Form3();
            Form3.Show();
        }
    }
}

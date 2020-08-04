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
            PopulateTreeView();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }
        private void PopulateTreeView(){
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"../..");
            if (info.Exists){
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo){
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs){
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0){
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e){
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories()){
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles()){
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public System.Windows.Forms.DockStyle Dock { get; set; }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e){
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e){

        }

        private void Form1_Load(object sender, EventArgs e){
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

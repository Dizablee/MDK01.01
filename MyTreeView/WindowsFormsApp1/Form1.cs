using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;
using MyLib.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<TreeNodeModel> treeData_;
        private StaffModel staffModel_;
        public Form1()
        {
            InitializeComponent();
            treeData_ = new List<TreeNodeModel>();

            staffModel_ = new StaffModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            {
                treeData_.Add(new TreeNodeModel("Сайты"));
                var siteNode = treeData_[0];
                var site = siteNode.AddChildNode("Бухгалтеры");
                var siteNod = site.AddChildNode("Специалисты.org");
                siteNod.AddChildNode("Кандидаты");

                var prof = siteNode.AddChildNode("Программисты");
                var proff = prof.AddChildNode("Профессия.com");
                proff.AddChildNode("Кандидаты");

                var profi = siteNode.AddChildNode("Товароведы");
                var freelance = profi.AddChildNode("Фриланс.ru");
                freelance.AddChildNode("Кандидаты");





            }
            
            FillTreeNodeCollection(treeData_, MyTreeView.Nodes);
            MyTreeView.ExpandAll();

            Table.DataSource = staffModel_.Staff;
            FillTableAliases();
        }

        static private void FillTreeNodeCollection(List<TreeNodeModel> sourceData, 
                                                   TreeNodeCollection targetData) 
        {
            foreach (var node in sourceData)
            {
                var treeNode = new TreeNode(node.Staff); 
                targetData.Add(treeNode); 
                if (node.Children != null && node.Children.Count > 0)
                {
                    FillTreeNodeCollection(node.Children, treeNode.Nodes); 
                }
            }
        }
        private void FillTableAliases()
        {
            foreach (DataGridViewColumn column in Table.Columns)
            {
                if (Staff.Aliases.TryGetValue(column.Name, out string alias))
                {
                    column.HeaderText = alias;
                }
            }
            Table.Columns[Table.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void MyTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show($"Вы дважды кликнули на узел: {e.Node.Text}");
        }

        private void MyTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show($"Вы развернули узел: {e.Node.Text}");
        }

        private void MyTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show($"Вы свернули узел: {e.Node.Text}");
        }

        private void MyTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            MessageBox.Show($"Вы хотите развернуть узел: {e.Node.Text}");
        }

        private void MyTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            MessageBox.Show($"Вы хотите свернуть узел: {e.Node.Text}");
        }
    }
}
    
 


       
      
    

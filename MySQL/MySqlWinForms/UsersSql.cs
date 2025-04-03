using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlWinForms
{
    public partial class UsersSql: Form
    {
        SQLUserConnect sqlreader = new SQLUserConnect();
        public UsersSql()
        {
            InitializeComponent();
            UsersTable.Dock = DockStyle.Fill;
            UsersTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UsersTable.DataSource = sqlreader.ReadUsers();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
          
            if (UsersTable.SelectedRows.Count > 0)
            {
                User loginToDelete = UsersTable.SelectedRows[0].DataBoundItem as User ;

                SQLUserConnect sqlConnect = new SQLUserConnect();
                bool success = sqlConnect.DeleteUser(loginToDelete.Login);

                if (success)
                {
                    UsersTable.DataSource = sqlreader.ReadUsers();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            AddAndRedact addAndRedact = new AddAndRedact();
           
            if (addAndRedact.ShowDialog() == DialogResult.OK)
            {
         
                UsersTable.DataSource = sqlreader.ReadUsers();
            }
        }
    }
}

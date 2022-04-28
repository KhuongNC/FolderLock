using FoldeLock.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoldeLock
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TxtPath.Text = Settings.Default.user;

            if (TxtPath.Text == "")
            {
                FrmSetPass frmSetPass = new FrmSetPass();
                frmSetPass.Show();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using this app");
            Application.Exit();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == Settings.Default.password && txtUser.Text == Settings.Default.user)
            {
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect");
            }
        }
    }
}

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
    public partial class FrmSetPass : Form
    {
        public FrmSetPass()
        {
            InitializeComponent();
        }

        private void FrmSetPass_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void ButtonSet_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Please Enter your user name");
                txtUser.Focus();
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Please Enter your password");
                txtPass.Focus();
            }
            else
            {
                Settings.Default.user = txtUser.Text.Trim();
                Settings.Default.password = txtPass.Text.Trim();
                Settings.Default.Save();

                MessageBox.Show("User Name And Password Save Successfully");
                this.Close();
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxShowPassword.CheckState == CheckState.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}

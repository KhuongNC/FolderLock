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
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            TxtHiden.Text = Settings.Default.password;
            TxtOldPassword.UseSystemPasswordChar = true;
            TxtNewPassword.UseSystemPasswordChar = true;
            TxtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtNewPassword.UseSystemPasswordChar = CbShowPassword.CheckState != CheckState.Checked;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (TxtOldPassword.Text != TxtHiden.Text)
            {
                MessageBox.Show("Old password is incorect");
            }
            else if (TxtNewPassword.Text != "" && TxtNewPassword.Text == TxtConfirmPassword.Text)
            {
                Settings.Default.Save();
                MessageBox.Show("Change password successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("New password don't match");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

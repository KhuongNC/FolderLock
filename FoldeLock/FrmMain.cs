using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoldeLock
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using app");
            Application.Exit();
        }

        #region Change drive icon
        private void BtnChangeIconHDD_Click(object sender, EventArgs e)
        {
            GbChangeIconHDD.Visible = true;
            GbFolderLockUnlock.Visible = false;
            GbFileHidden.Visible = false;
            GbDirectoryHidden.Visible = false;
            PanelHidden.Visible = false;
            PanelInfo.Visible = false;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSelectIcon_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtIcon.Text = openFileDialog1.FileName;
        }

        private void BtnChangeIcon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Make sure you run as Administrator");
            if (TxtIcon.Text == "")
            {
                MessageBox.Show("Please select an icon");
            }

            if (CbDriveLetter.SelectedItem == null)
            {
                MessageBox.Show("Please select a driver letter");
            }
            else
            {
                Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\Explorer.exe\\Drives" + "\\" +
                    CbDriveLetter.SelectedItem + "\\" + "DefaultIcon");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\Applications\\Explorer.exe\\Drives\\" +
                    CbDriveLetter.SelectedItem + "\\" + "DefaultIcon", "", TxtIcon.Text.Trim(), RegistryValueKind.String);

                MessageBox.Show("Icon changed sucessfully");
            }
        }

        private void BtnCloseInChangeIcon_Click(object sender, EventArgs e)
        {
            GbChangeIconHDD.Visible = false;
        }
        #endregion

        #region Folder Lock
        private void BtnBrowserFolderLock_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            if (TxtFolderPath.Text == "")
            {
                MessageBox.Show("Select folder path");
            }
            else
            {
                FileSecurity fs = File.GetAccessControl(TxtFolderPath.Text);
                fs.AddAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
                File.SetAccessControl(TxtFolderPath.Text, fs);

                MessageBox.Show("Folder lock");
            }
        }
        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            if (TxtFolderPath.Text == "")
            {
                MessageBox.Show("Select folder path");
            }
            else
            {
                FileSecurity fs = File.GetAccessControl(TxtFolderPath.Text);
                fs.RemoveAccessRule(new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny));
                File.SetAccessControl(TxtFolderPath.Text, fs);

                MessageBox.Show("Folder unlock");
            }
        }
        private void BtnCloseInFolderLock_Click(object sender, EventArgs e)
        {
            GbFolderLockUnlock.Visible = false;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DoctorGuid
{
    public partial class FormShortCutEdit : Form
    {
        private AppItem appItem;
        public FormShortCutEdit(AppItem _appItem)
        {
            InitializeComponent();

            appItem = _appItem;

            this.textBoxName.Text = appItem.Name;
            this.textBoxFileName.Text = appItem.FileName;

            if (appItem.AppType.ToLower().Equals("exe"))
            {
                this.radioButtonExe.Checked = true;
            }
            else
            {
                this.radioButtonExplorer.Checked = true;
            }

            this.textBoxProcessName.Text = appItem.ProcessName;

            this.textBoxUrl.Text = appItem.Url;

            this.textBoxIcon.Text = appItem.Icon;

        }

        private void FormShortCutEdit_Load(object sender, EventArgs e)
        {

        }

        public AppItem GetAppItem()
        {
            appItem.Name = this.textBoxName.Text;
            appItem.FileName = this.textBoxFileName.Text;
            if (this.radioButtonExe.Checked)
            {
                appItem.AppType = AppTypeEnum.Exe.ToString();
            }
            else
            {
                appItem.AppType = AppTypeEnum.Explorer.ToString();
            }
            appItem.ProcessName = this.textBoxProcessName.Text;
            appItem.Url = this.textBoxUrl.Text;
            appItem.Icon = this.textBoxIcon.Text;

            return appItem;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.textBoxName.Text.Trim().Length < 1)
            {
                MessageBox.Show("显示名称不能为空");
                return;
            }

            if (this.textBoxFileName.Text.Trim().Length < 1)
            {
                MessageBox.Show("程序不能为空");
                return;
            }

            if (this.textBoxProcessName.Text.Trim().Length < 1)
            {
                MessageBox.Show("进程名称不能为空");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() != DialogResult.OK)
                return;


            string strFileName = openFileDialog2.FileName;
            
            string newName = openFileDialog2.SafeFileName;

            if (newName == null)
                return;
            
            string iconPath = Environment.CurrentDirectory + "\\icons\\";

            if (!Directory.Exists(iconPath))
            {
                Directory.CreateDirectory(iconPath);
            }

            //如果有重名的，进行重新命名 
            string destFileName = iconPath + newName;
            if (File.Exists(destFileName))
            {
                string realName = Path.GetFileNameWithoutExtension(strFileName);
                string extName = Path.GetExtension(strFileName);

                newName = realName + DateTime.Now.ToString("yyyyMMddHHmmss");
                newName = newName + extName;

                destFileName = iconPath + newName;
            }

            File.Copy(strFileName,destFileName);

            this.textBoxIcon.Text = newName;
        }

        private void btnSelectFileName_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFileName.Text = openFileDialog1.FileName;
            }
        }
    }
}

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
    public partial class FormMain : Form
    {

        private List<AppItemObject> mAppItems;

        ListViewGroup mDefaultGroup;
        ListViewGroup mCustomGroup;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            mDefaultGroup = new ListViewGroup("默认");
            mCustomGroup = new ListViewGroup("自定义");
            mDefaultGroup.HeaderAlignment = HorizontalAlignment.Center;
            mCustomGroup.HeaderAlignment = HorizontalAlignment.Center;
            this.listView1.Groups.Add(mDefaultGroup);
            this.listView1.Groups.Add(mCustomGroup);
            this.listView1.ShowGroups = true;

            this.listView1.View = View.LargeIcon;

            LoadShortCut();

        }

        private void LoadShortCut()
        {
            ShortCutManager.Instance().Clear();
            this.listView1.Items.Clear();

            ShortCutManager.Instance().LoadAllFromFile();

            mAppItems = ShortCutManager.Instance().mShortCutList;

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(32, 32);

            listView1.LargeImageList = imgList; //这里设置listView的SmallImageList ,用imgList将其撑大  

            this.listView1.BeginUpdate();

            int nLen = mAppItems.Count;

            for (int i = 0; i < nLen; i++)
            {
                ListViewItem lvi = new ListViewItem();

                imgList.Images.Add(mAppItems[i].GetImage());

                lvi.ImageIndex = i;

                lvi.Text = mAppItems[i].AppItem.Name;

                lvi.ToolTipText = String.Format("双击图标打开【{0}】", lvi.Text);

                if (mAppItems[i].IsDefault)
                {
                    lvi.Group = mDefaultGroup;
                }
                else
                {
                    lvi.Group = mCustomGroup;
                }
               
                this.listView1.Items.Add(lvi);

            }

            this.listView1.EndUpdate();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.listView1.Clear();  //从控件中移除所有项和列（包括列表头）。 

            this.listView1.Items.Clear();  //只移除所有的项。

            ShortCutManager.Instance().Clear();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lt = this.listView1.SelectedItems;
            if (lt.Count > 0)
            {
                int nIndex = lt[0].ImageIndex;

                mAppItems[nIndex].Start();
            }
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void ToolStripMenuItemModify_Click(object sender, EventArgs e)
        {
            FormCustomShortCut dlg = new FormCustomShortCut();

            if (System.Windows.Forms.DialogResult.OK == dlg.ShowDialog())
            {
                LoadShortCut();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoctorGuid
{
    public partial class FormCustomShortCut : Form
    {
        private List<AppItemObject> mAppItems;

        public FormCustomShortCut()
        {
            InitializeComponent();

            mAppItems = new List<AppItemObject>();
        }
        
        private void FormCustomShortCut_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;

            mAppItems.Clear();
            foreach (var appItemObject in ShortCutManager.Instance().mShortCutList)
            {
                if(!appItemObject.IsDefault)
                    mAppItems.Add(appItemObject);
            }

            RefreshListView();
        }

        private void RefreshListView()
        {
            listView1.Items.Clear();

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

                this.listView1.Items.Add(lvi);
            }

            this.listView1.EndUpdate();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppItem appItem = new AppItem();
            FormShortCutEdit dlg = new FormShortCutEdit(appItem);
            dlg.Text = "添加快捷方式";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                mAppItems.Add(new AppItemObject(dlg.GetAppItem(), "", false));
                RefreshListView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var lt = this.listView1.SelectedItems;
            if (lt.Count > 0)
            {
                int nIndex = lt[0].ImageIndex;

                if (MessageBox.Show(String.Format("确定要删除【{0}】快捷方式吗？", mAppItems[nIndex].AppItem.Name), "删除确认", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK)
                {
                    mAppItems.RemoveAt(nIndex);
                
                    RefreshListView();
                }
                
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var lt = this.listView1.SelectedItems;
            if (lt.Count > 0)
            {
                int nIndex = lt[0].ImageIndex;


                FormShortCutEdit dlg = new FormShortCutEdit(mAppItems[nIndex].AppItem);
                dlg.Text = "修改快捷方式";
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    mAppItems[nIndex].AppItem = dlg.GetAppItem();
                    RefreshListView();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string customShortCutPath = Environment.CurrentDirectory + "\\CustomShortCut.xml";
                HKApplications mApps = new HKApplications();
                List<AppItem> list = new List<AppItem>();
                foreach (var appItemObject in mAppItems)
                {
                    list.Add(appItemObject.AppItem);
                }
                mApps.AppItems = list.ToArray();

                XmlSerializer.SaveToXml(customShortCutPath, mApps, typeof(HKApplications), null);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

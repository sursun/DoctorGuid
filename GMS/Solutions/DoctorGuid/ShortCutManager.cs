using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DoctorGuid
{
    public class ShortCutManager
    {
        public static ShortCutManager _instance = null;

        public static ShortCutManager Instance()
        {
            if (_instance == null)
            {
                _instance = new ShortCutManager();
            }
            return _instance;
        }

        public ShortCutManager()
        {
            mShortCutList = new List<AppItemObject>();

            //LoadAllFromFile();
        }

        public List<AppItemObject> mShortCutList;
  
        public void LoadAllFromFile()
        {
            LoadDefaultFromFile();

            LoadCustomFromFile();
        }

        public void LoadCustomFromFile()
        {

            foreach (var obj in mShortCutList)
            {
                if (!obj.IsDefault)
                {
                    obj.Exit();

                    mShortCutList.Remove(obj);
                }
            }
            
            string customShortCutPath = Environment.CurrentDirectory + "\\CustomShortCut.xml";
            string iconPath = Environment.CurrentDirectory + "\\icons\\";
            
            try
            {
                HKApplications mApps = (HKApplications)XmlSerializer.LoadFromXml(customShortCutPath, typeof(HKApplications));

                if (mApps != null && mApps.AppItems != null && mApps.AppItems.Length > 0)
                {
                    int nLen = mApps.AppItems.Length;
                    for (int i = 0; i < nLen; i++)
                    {
                        AppItemObject obj = new AppItemObject(mApps.AppItems[i], iconPath,false);

                        mShortCutList.Add(obj);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void LoadDefaultFromFile()
        {
            foreach (var obj in mShortCutList)
            {
                if (obj.IsDefault)
                {
                    obj.Exit();

                    mShortCutList.Remove(obj);
                }
            }
           
            string defaultShortCutPath = Environment.CurrentDirectory + "\\DefaultShortCut.xml";

            string iconPath = Environment.CurrentDirectory + "\\icons\\";

            try
            {
                HKApplications mApps = (HKApplications)XmlSerializer.LoadFromXml(defaultShortCutPath, typeof(HKApplications));

                if (mApps != null && mApps.AppItems != null && mApps.AppItems.Length > 0)
                {
                    int nLen = mApps.AppItems.Length;
                    for (int i = 0; i < nLen; i++)
                    {
                        AppItemObject obj = new AppItemObject(mApps.AppItems[i], iconPath,true);

                        mShortCutList.Add(obj);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void Clear()
        {
            foreach (var appItemObject in mShortCutList)
            {
                appItemObject.Exit();
            }
            mShortCutList.Clear();
     
        }
    }
}

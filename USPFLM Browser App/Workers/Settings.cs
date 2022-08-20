using System;

namespace USPFLM_Browser_App
{
    internal class Settings
    {
        public bool topMost = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString()); 

        public string myUsernameMainForm
        {
            get
            {
                string username = Properties.Settings.Default["Username"].ToString();

                if (username == "")
                {
                    return "USPFLM Browser App";
                }
                else
                {
                    return $"{username} | USPFLM Browser App";
                }
            }
        }

        public string myUsernameFileExplorer
        {
            get
            {
                string username = Properties.Settings.Default["Username"].ToString();

                if (username == "")
                {
                    return "File Explorer";
                }
                else
                {
                    return $"{username} | File Explorer";
                }
            }
        }

        public string myUsernameTextEditor
        {
            get
            {
                string username = Properties.Settings.Default["Username"].ToString();

                if (username == "")
                {
                    return "Text Editor";
                }
                else
                {
                    return $"{username} | Text Editor";
                }
            }
        }
    }
}

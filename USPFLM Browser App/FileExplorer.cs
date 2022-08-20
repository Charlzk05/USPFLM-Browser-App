using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USPFLM_Browser_App
{
    public partial class FileExplorer : Form
    {
        Settings settings = new Settings();

        public FileExplorer()
        {
            InitializeComponent();
            newTab();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                browser.GoBack();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                browser.GoForward();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                browser.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                browser.Navigate(textBox1.Text);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (tabControl1.SelectedIndex != -1)
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                    browser.Navigate(folderBrowser.SelectedPath);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                if (tabControl1.TabPages.Count == 10)
                {
                    // DO NOTHING
                }
                else
                {
                    newTab();
                    tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 1)
            {
                // DO NOTHING
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void newTab()
        {
            WebBrowser webBrowser = new WebBrowser();
            TabPage tabPage = new TabPage();

            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Navigate("C:\\");
            webBrowser.Navigated += webBrowser_navigated;

            tabPage.Text = webBrowser.Url.AbsolutePath.ToString();
            tabPage.Controls.Add(webBrowser);

            tabControl1.TabPages.Add(tabPage);
        }

        // EVENTS

        private void FileExplorer_Load(object sender, EventArgs e)
        {
            this.Text = settings.myUsernameFileExplorer;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    // DO NOTHING
                }
                else
                {
                    try
                    {
                        var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                        browser.Navigate(textBox1.Text);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Invalid Path!", "Error (System.ArgumentException)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 3)
            {
                if (textBox1.Text == @"C:\")
                {
                    textBox1.ForeColor = Color.DimGray;
                }
                else if (textBox1.Text == @"c:\")
                {
                    textBox1.ForeColor = Color.DimGray;
                }
                else
                {
                    textBox1.ForeColor = Color.Black;
                }
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }
        }

        private void webBrowser_navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            label2.Text = $"Current Path: {e.Url.AbsolutePath.ToString()}";
            tabControl1.SelectedTab.Text = e.Url.AbsolutePath.ToString();
        }

        private void FileExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                if (tabControl1.SelectedIndex != -1)
                {
                    if (tabControl1.TabPages.Count == 10)
                    {
                        // DO NOTHING
                    }
                    else
                    {
                        newTab();
                        tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
                    }
                }
            }
            else if (e.Control && e.KeyCode == Keys.W)
            {
                if (tabControl1.TabPages.Count == 1)
                {

                }
                else
                {
                    tabControl1.SelectTab(tabControl1.SelectedIndex = 1);
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var browser = (WebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            label2.Text = $"Current Path: {browser.Url.AbsolutePath.ToString()}";
        }
    }
}

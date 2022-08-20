using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;

namespace USPFLM_Browser_App
{
    public partial class MainForm : Form
    {
        Settings settings = new Settings();

        public MainForm()
        {
            InitializeComponent();
            InitializeBrowser();
        }

        private void InitializeBrowser()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = Path.GetFullPath("./cache");
            Cef.Initialize(settings);
        }

        private void changeUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUsername username = new ChangeUsername();
            username.ShowDialog();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topMostToolStripMenuItem.Checked == true)
            {
                this.TopMost = true;
                Properties.Settings.Default["TopMost"] = topMostToolStripMenuItem.Checked;
            }
            else
            {
                this.TopMost = false;
                Properties.Settings.Default["TopMost"] = topMostToolStripMenuItem.Checked;
            }
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileExplorer explorer = new FileExplorer();
            explorer.Show();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.Back();
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.Forward();
        }

        private void viewPageSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSource source = new PageSource(mainBrowser.GetSourceAsync().Result, mainBrowser.Address);
            SourceForm form1 = new SourceForm();
            form1.ShowDialog();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.ShowDevTools();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.Refresh();
        }


        private void textEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditor textEditor = new TextEditor();
            textEditor.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // EVENTS

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Default Size - 1120, 789
            mainBrowser.LoadUrl("https://uspflm.com/");

            this.Text = settings.myUsernameMainForm;

            int width = Int32.Parse(Properties.Settings.Default["MainXSize"].ToString());
            int height = Int32.Parse(Properties.Settings.Default["MainYSize"].ToString());
            this.Size = new Size(width, height);

            topMostToolStripMenuItem.Checked = Convert.ToBoolean(Properties.Settings.Default["TopMost"].ToString());
        }

        private void mainBrowser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => label1.Text = $"Status: Loading"));
            this.Invoke((MethodInvoker)(() => progressBar1.Enabled = true));
            this.Invoke((MethodInvoker)(() => progressBar1.Visible = true));
        }

        private void mainBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => label1.Text = $"Status: {e.HttpStatusCode}"));
            this.Invoke((MethodInvoker)(() => progressBar1.Enabled = false));
            this.Invoke((MethodInvoker)(() => progressBar1.Visible = false));
        }

        private void mainBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => label2.Text = $"URL: {e.Address}"));
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Properties.Settings.Default["MainXSize"] = this.Size.Width;
            Properties.Settings.Default["MainYSize"] = this.Size.Height;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void mainBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => label3.Text = $"Title: {e.Title}"));
        }
    }
}

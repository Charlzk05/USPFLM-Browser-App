using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.IO;

namespace USPFLM_Browser_App
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void newTab()
        {
            TabPage tabPage = new TabPage();
            FastColoredTextBox fastColored = new FastColoredTextBox();

            fastColored.Dock = DockStyle.Fill;
            fastColored.IndentBackColor = Color.White;
            fastColored.Font = new Font("Consolas", 10, FontStyle.Regular);

            tabPage.Text = "Untitled";
            tabPage.Controls.Add(fastColored);
            tabControl1.TabPages.Add(tabPage);
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 1)
            {

            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                if (tabControl1.TabPages.Count == 10)
                {
                    // DO NOTHING
                }
                else
                {
                    if (tabControl1.SelectedIndex != -1)
                    {
                        OpenFileDialog openFile = new OpenFileDialog();
                        openFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                        if (openFile.ShowDialog() == DialogResult.OK)
                        {
                            StreamReader streamReader = new StreamReader(openFile.FileName);

                            newTab();
                            tabControl1.SelectTab(tabControl1.SelectedIndex + 1);

                            var textbox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                            var content = File.ReadAllText(openFile.FileName);

                            textbox.Text = content;
                            tabControl1.TabPages[tabControl1.SelectedIndex].Text = Path.GetFileName(openFile.FileName);
                            label2.Text = $"Encoding: {streamReader.CurrentEncoding.EncodingName}";

                            streamReader.Close();
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                var textbox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                File.WriteAllText(saveFile.FileName, textbox.Text);
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = Path.GetFileName(saveFile.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "All Files (*.*)|*.*";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    var textbox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];

                    File.WriteAllText(saveFile.FileName, textbox.Text);
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = Path.GetFileName(saveFile.FileName);
                }
            }
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var textBox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                textBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var textBox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                textBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var textBox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                textBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var textBox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                textBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var textBox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                textBox.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                var textBox = (FastColoredTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
                textBox.SelectAll();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EVENTS

        private void TextEditor_Load(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            newTab();
            this.Text = settings.myUsernameTextEditor;
        }
    }
}

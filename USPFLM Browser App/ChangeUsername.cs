using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USPFLM_Browser_App
{
    public partial class ChangeUsername : Form
    {
        public ChangeUsername()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 3)
            {
                MessageBox.Show("Username must be at least 3 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("You have to restart the app to get the changes displayed.", "Restart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Properties.Settings.Default["Username"] = textBox1.Text;
                Properties.Settings.Default.Save();

                var message = MessageBox.Show("Restart now?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have to restart the app to get the changes displayed.", "Restart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default["Username"] = "";
            Properties.Settings.Default.Save();

            var message = MessageBox.Show("Restart now?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // EVENTS

        private void ChangeUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length <= 3)
                {
                    MessageBox.Show("Username must be at least 3 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You have to restart the app to get the changes displayed.", "Restart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Properties.Settings.Default["Username"] = textBox1.Text;
                    Properties.Settings.Default.Save();

                    var message = MessageBox.Show("Restart now?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (message == DialogResult.Yes)
                    {
                        Application.Restart();
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}

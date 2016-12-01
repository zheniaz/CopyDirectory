using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CopyDirectory
{
    public partial class CopyDirectory : Form
    {
        string from_dir;
        string to_dir;
        public CopyDirectory()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            MessageBox.Show("Hello, DCSL Software!\n");
            from_dir = "";
            to_dir = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                from_dir = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && !Directory.Exists(from_dir))
                MessageBox.Show("wrong path source");
            else if (textBox2.Text == "" && !Directory.Exists(to_dir))
                MessageBox.Show("wrong path target");
            else
                CopyDir(from_dir,to_dir);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
                to_dir = textBox2.Text;
        }

        void CopyDir(string from_dir, string to_dir)
        {
            try
            {
                DirectoryInfo dir_info = new DirectoryInfo(from_dir);

                foreach (DirectoryInfo dir in dir_info.GetDirectories())
                {
                    if (Directory.Exists(to_dir + "\\" + dir.Name) != true)
                    {
                        Directory.CreateDirectory(to_dir + "\\" + dir.Name);
                    }

                    CopyDir(dir.FullName, to_dir + "\\" + dir.Name);
                }

                foreach (string file in Directory.GetFiles(from_dir))
                {
                    string filikStr = file.Substring(file.LastIndexOf('\\'), file.Length - 1 - file.LastIndexOf('\\'));
                    File.Copy(file, to_dir + "\\" + filikStr, true);
                    listBox1.Items.Add(filikStr.Remove(0,1));
                }
            }
            catch
            {
                MessageBox.Show("Try again");
            }
        }

        void SomeMethod()
        {
            Application.DoEvents();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PythonInstaller_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_setpath_Click(object sender, EventArgs e)
        {
            if (!PublicValue.Python_Installed)
            {
                Form2 f2 = new Form2();
                f2.Owner = this;
                f2.Show();
            }
            else
            {
                MessageBox.Show("Python已安装！请勿重复安装！");
                return;
            }
        }

        private void Form1_pip_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Owner = this;
            f3.Show();
        }

        private void setPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PublicValue.Python_path = openFileDialog1.FileName;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/simplerjiang/Python_Installer_GUI");
        }

        private void Form1_showpath_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
    }
    public static class PublicValue
    {
        public static bool Python_Installed { get; set; } = false;
        public static bool Models_List { get; set; } = false;
        public static string Python_path { get; set; } = "";
        public static bool UpdateModels_List { get; set; } = false;
    }
}

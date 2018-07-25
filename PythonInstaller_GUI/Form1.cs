using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            f3.Show();
        }

        
    }
    public static class PublicValue
    {
        public static bool Python_Installed { get; set; } = false;
        public static bool Models_List { get; set; } = false;
    }
}

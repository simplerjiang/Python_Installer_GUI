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
using System.Diagnostics;

namespace PythonInstaller_GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.textBox1.Text = "正在开始..." + Environment.NewLine;
            string str_path = Environment.CurrentDirectory;
            if (Environment.Is64BitOperatingSystem)
            {
                string python_path = Path.Combine(str_path, "Python3.7-x64");
                string python86_path = Path.Combine(str_path, "Python3.7-x86");
                string python_script_path = Path.Combine(python_path, "Scripts");
                if (!Directory.Exists(python_path))
                {
                    this.textBox1.AppendText("Python3.7-x64文件不存在！错误！" + Environment.NewLine);
                    this.textBox1.AppendText(python_path + Environment.NewLine);
                    this.textBox1.AppendText("已结束..." + Environment.NewLine);
                    MessageBox.Show("Python文件不存在" + Environment.NewLine + "你有可能在使用简易版，无法部署");
                    goto end;
                }
                else if (!Directory.Exists(python_script_path))
                {
                    this.textBox1.AppendText("Python3.7-x64\\Scripts\\不存在！错误！" + Environment.NewLine);
                    this.textBox1.AppendText("已结束..." + Environment.NewLine);
                    goto end;

                }
                this.textBox1.AppendText("Python3.7的地址为：" + python_path + Environment.NewLine);
                this.textBox1.AppendText("Python3.7的第二地址为：" + python_script_path + Environment.NewLine);
                string lastest_path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                string[] foreach_path1 = lastest_path.Split(';');
                foreach (string i in foreach_path1)
                {
                    if (i.Equals(python_path + "\\"))
                    {
                        this.textBox1.AppendText("Python环境已存在！" + Environment.NewLine);
                        goto end1;
                    }
                }
                string all_path = lastest_path;
                python_path = ";" + python_path + "\\";
                all_path += python_path;
                Environment.SetEnvironmentVariable("Path", all_path, EnvironmentVariableTarget.Machine);
                end1: this.textBox1.AppendText("继续执行..." + Environment.NewLine);
                all_path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                string[] foreach_path2 = all_path.Split(';');
                foreach (string b in foreach_path2)
                {
                    if (b.Equals(python_script_path + "\\"))
                    {
                        this.textBox1.AppendText("Python\\Scripts环境已存在！" + Environment.NewLine);
                        this.textBox1.AppendText("已结束..." + Environment.NewLine);
                        goto end2;
                    }
                }
                python_script_path = ";" + python_script_path + "\\";
                all_path += python_script_path;
                Environment.SetEnvironmentVariable("Path", all_path, EnvironmentVariableTarget.Machine);
                end2: this.textBox1.AppendText("继续执行..." + Environment.NewLine);
                lastest_path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                string[] foreach_path3 = lastest_path.Split(';');
                this.textBox1.AppendText("已完成添加环境！" + Environment.NewLine);
                this.textBox1.AppendText("目前系统变量如下：" + Environment.NewLine);
                foreach (string c in foreach_path3)
                {
                    this.textBox1.AppendText(c + Environment.NewLine);
                }
            }
            else
            {
                string python_path = Path.Combine(str_path, "Python3.7-x86");
                string python64_path = Path.Combine(str_path, "Python3.7-x64");
                string python_script_path = Path.Combine(python_path, "Scripts");
                if (!Directory.Exists(python_path))
                {
                    this.textBox1.AppendText("Python3.7-x86文件不存在！错误！" + Environment.NewLine);
                    MessageBox.Show("Python文件不存在" + Environment.NewLine + "你有可能在使用简易版，无法部署");
                    goto end;
                }
                else if (!Directory.Exists(python_script_path))
                {
                    this.textBox1.AppendText("\\Python3.7-x86\\Scripts\\不存在！错误！" + Environment.NewLine);
                    goto end;

                }
                this.textBox1.AppendText("Python3.7的地址为：" + python_path + Environment.NewLine);
                this.textBox1.AppendText("Python3.7的第二地址为：" + python_script_path + Environment.NewLine);
                string lastest_path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                string[] foreach_path1 = lastest_path.Split(';');
                foreach (string i in foreach_path1)
                {
                    if (i.Equals(python_path + "\\"))
                    {
                        this.textBox1.AppendText("Python环境已存在！" + Environment.NewLine);
                        goto end1;
                    }
                }
                string all_path = lastest_path;
                python_path = ";" + python_path + "\\";
                all_path += python_path;
                Environment.SetEnvironmentVariable("Path", all_path, EnvironmentVariableTarget.Machine);
                end1: this.textBox1.AppendText("继续执行..." + Environment.NewLine);
                all_path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                string[] foreach_path2 = all_path.Split(';');
                foreach (string b in foreach_path2)
                {
                    if (b.Equals(python_script_path + "\\"))
                    {
                        this.textBox1.AppendText("Python\\Scripts环境已存在！" + Environment.NewLine);
                        goto end2;
                    }
                }
                python_script_path = ";" + python_script_path + "\\";
                all_path += python_script_path;
                Environment.SetEnvironmentVariable("Path", all_path, EnvironmentVariableTarget.Machine);
                end2: this.textBox1.AppendText("继续执行..." + Environment.NewLine);
                lastest_path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                string[] foreach_path3 = lastest_path.Split(';');
                this.textBox1.AppendText("已完成添加环境！" + Environment.NewLine);
            }
            end: Form2_finishbutton.Enabled = true;
            Form2_finishbutton.Visible = true;
        }

        private void Form2_finishbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

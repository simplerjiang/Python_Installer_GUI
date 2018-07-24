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
    public partial class Form3 : Form
    {
        public char StartFileArg { get; private set; }

        public Form3()
        {
            InitializeComponent();
            Cmd_Back_Text(1);
            Cmd_Back_Text(2);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //选择好按钮并开启卸载button
        {
            if (!this.but_Uninstall.Enabled && this.listBox1.SelectedIndex != -1)
            {
                if ((string)this.listBox1.SelectedItem != "暂无数据")
                {
                    this.but_Uninstall.Enabled = true;
                }
                else
                {
                    this.listBox1.SelectedIndex = -1;
                }
            }
        }

        private void text_path_KeyDown(object sender, KeyEventArgs e) // 全选事件
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        public void Cmd_Back_Text(int mode)
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";      // 命令  
                                                                // 参数  
            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
                                                                //CmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  
            

            if (mode == 1)
            {
                CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p1_OutputDataReceived);
            }
            else if (mode == 2)
            {
                CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p2_OutputDataReceived);
                CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            }

            CmdProcess.Start();
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();
            if (mode == 1)
            {
                CmdProcess.StandardInput.WriteLine("python -V");
            }
            else if (mode == 2)
            {
                CmdProcess.StandardInput.WriteLine("where python");
            }

        }
        private void p1_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    // 4. 异步调用，需要invoke  
                    this.Invoke(new Action<string>((result) =>
                    {
                        string[] strs = result.Split('\n');
                        foreach (string str in strs)
                        {
                            if (str.StartsWith("Python "))
                            {
                                string[] python_paths = str.Split(' ');
                                string python_path = python_paths[1];
                                this.label_info.Text = "目前的Python版本：" + python_path;
                                return;
                            }
                        }
                        MessageBox.Show("没有找到Python环境！");
                    }), new object[] { e.Data });
                }
            }
        }

        private void p2_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    // 4. 异步调用，需要invoke  
                    this.Invoke(new Action<string>((result) =>
                    {
                        string[] strs = result.Split('\n');
                        foreach (string str in strs)
                        {
                            if (str.EndsWith("python.exe"))
                            {
                                this.text_path.Text = str;
                                return;
                            }
                        }
                    }), new object[] { e.Data });
                }
            }
        }


        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("没有找到Python环境！");
                        Close();
                    }));
                }
            }
        }

    }
}

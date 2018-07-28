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
        public Form3()
        {
            InitializeComponent();
            Cmd_Back_Text(1);
            Cmd_Back_Text(2);
            Cmd_Back_Text(3);
        }
        public void Reload_Form3()
        {
            Cmd_Back_Text(1);
            Cmd_Back_Text(2);
            Cmd_Back_Text(3);
        }

        #region Python版本及地址
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
                CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p1_OutputDataReceived);
                CmdProcess.EnableRaisingEvents = true;
                CmdProcess.Exited += new EventHandler(P1Process_Exited);
            }
            else if (mode == 2)
            {
                CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p2_OutputDataReceived);
                CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            }
            else if (mode == 3) //加载列表
            {
                this.listBox1.Items.Clear();
                CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p3_OutputDataReceived);
                CmdProcess.EnableRaisingEvents = true;
                CmdProcess.Exited += new EventHandler(CmdProcess_Exited);
            }

            CmdProcess.Start();
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();
            if (mode == 1)
            {
                if (PublicValue.Python_path == "")
                {
                    CmdProcess.StandardInput.WriteLine("python -V&exit");
                }
                else
                {
                    CmdProcess.StandardInput.WriteLine(PublicValue.Python_path + " -V&exit");
                }
            }
            else if (mode == 2)
            {
                CmdProcess.StandardInput.WriteLine("where python&exit");
            }
            else if (mode == 3)
            {
                if (PublicValue.Python_path == "")
                {
                    CmdProcess.StandardInput.WriteLine("python -m pip list&exit");
                }
                else
                {
                    CmdProcess.StandardInput.WriteLine(PublicValue.Python_path + " -m pip list&exit");
                }
            }

        }
        private void p1_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    // 4. 异步调用，需要invoke  
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        string[] strs = result.Split('\n');
                        foreach (string str in strs)
                        {
                            if (str.StartsWith("Python"))
                            {
                                string[] python_paths = str.Split(' ');
                                string python_path = python_paths[1];
                                this.label_info.Text = "目前的Python版本：" + python_path;
                                PublicValue.Python_Installed = true;
                                return;
                            }
                        }
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
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        if (PublicValue.Python_path != "")
                        {
                            this.text_path.Text = PublicValue.Python_path;
                            return;
                        }
                        string[] strs = result.Split('\n');
                        foreach (string str in strs)
                        {
                            if (str.EndsWith("python.exe"))
                            {
                                if (PublicValue.Python_path == "")
                                {
                                    this.text_path.Text = str;
                                    return;
                                }
                                else
                                {
                                    this.text_path.Text = PublicValue.Python_path;
                                    return;
                                }
                            }
                        }
                    }), new object[] { e.Data });
                }
            }
        }
        private void p3_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    // 4. 异步调用，需要invoke  
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        string[] strs = result.Split('\n');
                        List<string> all_models = new List<string>();
                        foreach (string str in strs)
                        {
                            if (PublicValue.Models_List == false)
                            {
                                if (str.StartsWith("-"))
                                {
                                    PublicValue.Models_List = true;
                                }
                            }
                            else
                            {
                                all_models.Add(str);
                            }
                        }
                        this.listBox1.Items.AddRange(all_models.ToArray()); 
                    }), new object[] { e.Data });
                }
            }
        }
        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            PublicValue.Models_List = false;
        }
        private void P1Process_Exited(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    if (label_info.Text.Equals("目前的Python版本："))
                    {
                        if (this.GetTimes < 3)
                        {
                            this.GetTimes += 1;
                            this.Cmd_Back_Text(1);
                        }
                    }
                    else
                    {
                        this.GetTimes = 0;
                    }
                }));
            }
        }

        private bool Python_num_again { get; set; } = false;
        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        Close();
                    }));
                }
            }
        }
        #endregion
        public int GetTimes { get; set; } = 0;
        #region 静态方法
        public static string GetModelsName(string In) //已测试
        {
            string[] results = In.Split(' ');
            return results[0];
        }
        #endregion

        private void Model_name_TextChanged(object sender, EventArgs e)
        {
            if (Model_name.Text != "")
            {
                if (!this.but_Install.Enabled)
                {
                    this.but_Install.Enabled = true;
                }
            }
            else
            {
                this.but_Install.Enabled = false;
            }
        }

        private void but_Install_Click(object sender, EventArgs e)
        {
            if (Model_name.Text == "")
            {
                MessageBox.Show("请输入模块名！");
                return;
            }
            ModelDownloadForm dform = new ModelDownloadForm(Model_name.Text)
            {
                Owner = this
            };
            dform.ShowDialog();

        }

        private void but_Uninstall_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个模块");
                return;
            }
            string models_name = GetModelsName((string)listBox1.SelectedItem);
            ModelsUninstallForm uninstallForm = new ModelsUninstallForm(models_name);
            uninstallForm.Owner = this;
            uninstallForm.ShowDialog();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            ModelUpdate modelUpdate = new ModelUpdate
            {
                Owner = this
            };
            modelUpdate.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchModel searchModel = new SearchModel
            {
                Owner = this
            };
            searchModel.Show();
        }
    }
}

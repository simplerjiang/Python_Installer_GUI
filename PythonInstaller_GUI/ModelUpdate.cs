using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace PythonInstaller_GUI
{
    public partial class ModelUpdate : Form
    {
        public ModelUpdate()
        {
            InitializeComponent();
            GetModelUpdateInfo();
        }
        #region 初始化
        public void GetModelUpdateInfo()
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";
            CmdProcess.StartInfo.CreateNoWindow = true;
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;
            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(GetInfoOutPutToBox);
            CmdProcess.EnableRaisingEvents = true;
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);
            CmdProcess.Start();
            if (PublicValue.Python_path == "")
            {
                CmdProcess.StandardInput.WriteLine("python -m pip list -o&exit");
            }
            else
            {
                CmdProcess.StandardInput.WriteLine(PublicValue.Python_path + " -m pip list -o&exit");
            }
            CmdProcess.BeginErrorReadLine();
            CmdProcess.BeginOutputReadLine();
        }
        private void GetInfoErrToBox(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        DialogResult flag = MessageBox.Show("出现错误！是否查看错误信息？", "出现错误！", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        if (flag == DialogResult.Yes)
                        {
                            MessageBox.Show(result);
                        }
                        return;
                    }), new object[] { e.Data });
                }
            }
        }
        private void GetInfoOutPutToBox(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        string[] strs = result.Split('\n');
                        List<string> all_models = new List<string>();
                        foreach (string str in strs)
                        {
                            if (PublicValue.UpdateModels_List == false)
                            {
                                if (str.StartsWith("--"))
                                {
                                    PublicValue.UpdateModels_List = true;
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
            PublicValue.UpdateModels_List = false;
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    int length = default(int);
                    string a;
                    try
                    {
                        a = ((string)this.listBox1.Items[1]);
                    }
                    catch
                    {
                        MessageBox.Show("哎呀！好像没有可以更新的模块！");
                        this.Close();
                        this.Dispose();
                        return;
                    }
                    length = a.Length;
                    if (length < 30)
                    {
                        this.listBox1.Items[0] = "模块名  目前版本 最新版本  种类";
                    }
                    else if (length < 40 && length > 30)
                    {
                        this.listBox1.Items[0] = "模块名         目前版本  最新版本  种类";
                    }
                    else if (length > 40)
                    {
                        this.listBox1.Items[0] = "模块名                  目前版本  最新版本  种类";
                    }
                }));
            }
        }
        #endregion

        #region 按钮事件
        private void num_box_TextChanged(object sender, EventArgs e)
        {
            if (this.num_box.Text == "")
            {
                this.radioButton1.Checked = true;
            }
            else
            {
                this.radioButton1.Checked = false;
            }
        }
        private void start_but_Click(object sender, EventArgs e)
        {
            string[] models_info = GetModelsName((string)this.listBox1.SelectedItem);
            fStartToUpdate(models_info[0]);
        }
        public static string[] GetModelsName(string In) 
        {
            string[] results = In.Split(' ');
            return results;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsFinished)
            {
                this.listBox1.SelectedIndex = -1;
                return;
            }
            if (listBox1.SelectedIndex == -1 || listBox1.SelectedIndex == 0)
            {
                this.start_but.Enabled = false;
                this.listBox1.SelectedIndex = -1;
                return;
            }
            
            this.start_but.Enabled = true;
            string[] models_info = GetModelsName((string)this.listBox1.SelectedItem);
            this.Model_name.Text = models_info[0];
        }

        private void Model_name_TextChanged(object sender, EventArgs e)
        {
            if (Model_name.Text == "")
            {
                this.start_but.Enabled = false;
            }
            else
            {
                if (!this.start_but.Enabled)
                {
                    if (this.IsFinished)
                    {
                        this.start_but.Enabled = true;
                    }
                }
            }
        }
        private void ModelUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.IsFinished)
            {
                DialogResult flag = MessageBox.Show("确认关闭吗？" + Environment.NewLine + "关闭不会停止正在进行安装或卸载", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (flag == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region 开始下载
        public void fStartToUpdate(string Model_name)
        {
            if (Model_name == "")
            {
                MessageBox.Show("请输入模块名或选择一个模块");
                return;
            }
            this.Cmd_info_box.Clear();
            this.start_but.Enabled = false;
            this.IsFinished = false;
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";
            CmdProcess.StartInfo.CreateNoWindow = true;
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;
            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(eDownInfoToBox);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(eErrToBox);
            CmdProcess.EnableRaisingEvents = true;
            CmdProcess.Exited += new EventHandler(eExitEvent);
            CmdProcess.Start();
            string sNum;
            if (this.radioButton1.Checked)
            {
                sNum = "";
            }
            else if (this.num_box.Text != "")
            {
                sNum = "==" + this.num_box.Text;
            }
            else
            {
                sNum = "";
            }
            if (PublicValue.Python_path == "")
            {
                CmdProcess.StandardInput.WriteLine("python -m pip install "+  Model_name + sNum+ " --upgrade&exit");
            }
            else
            {
                CmdProcess.StandardInput.WriteLine(PublicValue.Python_path + " -m pip install " + Model_name + sNum + " --upgrade&exit");
            }
            CmdProcess.BeginErrorReadLine();
            CmdProcess.BeginOutputReadLine();
        }

        private void eDownInfoToBox(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        string[] results = result.Split('\n');
                        foreach (string i in results)
                        {
                            this.Cmd_info_box.AppendText(i + Environment.NewLine);
                        }
                    }), new object[] { e.Data });
                }
            }
        }
        private void eErrToBox(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action<string>((result) =>
                    {
                        DialogResult flag = MessageBox.Show("出现错误！是否查看错误信息？", "出现错误！", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                        if (flag == DialogResult.Yes)
                        {
                            MessageBox.Show(result);
                        }
                        return;
                    }), new object[] { e.Data });
                }
            }
        }
        private void eExitEvent(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("已完成！请查看是否成功！");
                    this.start_but.Enabled = true;
                    Form3 PresentForm = (Form3)this.Owner;
                    this.IsFinished = true;
                    this.listBox1.Items.Clear();
                    this.listBox1.Items.Add("正在加载....");
                    this.GetModelUpdateInfo();
                    PresentForm.Reload_Form3();

                }));
            }
        }
        #endregion

        #region 属性
        public bool IsFinished { get; set; } = true;

        #endregion

    }
}

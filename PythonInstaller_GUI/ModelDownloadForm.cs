using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PythonInstaller_GUI
{
    public partial class ModelDownloadForm : Form
    {
        public ModelDownloadForm(string Model_name)
        {
            InitializeComponent();
            this.Model_name.Text = Model_name;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                radioButton1.Checked = false;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }

        private void num_box_TextChanged(object sender, EventArgs e)
        {
            if (num_box.Text != "")
            {
                if (radioButton1.Checked)
                {
                    radioButton1.Checked = false;
                }
            }
            else
            {
                if (!radioButton1.Checked)
                {
                    radioButton1.Checked = true;
                }
            }
        }

        private void start_but_Click(object sender, EventArgs e)
        {
            this.IsFinished = false;
            this.start_but.Enabled = false;
            string InstallArg;
            if (!radioButton1.Checked)
            {
                if (num_box.Text !="")
                {
                    InstallArg = "==" + num_box.Text;
                }
                else
                {
                    InstallArg = "";
                }
            }
            else
            {
                InstallArg = "";
            }
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";
            CmdProcess.StartInfo.CreateNoWindow = true;
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;
            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(OutPutToBox);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(ErrToBox);
            CmdProcess.EnableRaisingEvents = true;
            CmdProcess.Exited += new EventHandler(ExitEvent);
            CmdProcess.Start();
            if (PublicValue.Python_path == "")
            {
                CmdProcess.StandardInput.WriteLine("python -m pip install " + Model_name.Text + InstallArg + "&exit");
            }
            else
            {
                CmdProcess.StandardInput.WriteLine(PublicValue.Python_path + " -m pip install " + Model_name.Text + InstallArg + "&exit");
            }
            CmdProcess.BeginErrorReadLine();
            CmdProcess.BeginOutputReadLine();
            this.start_but.Text = "正在安装";
        }

        private void OutPutToBox(object sender, DataReceivedEventArgs e)
        {
            if (e.Data!=null)
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
                    }),new object[] { e.Data });
                }
            }
        }
        private void ErrToBox(object sender, DataReceivedEventArgs e)
        {
            if (e.Data!=null)
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
        private void ExitEvent(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("已完成！请查看是否成功！");
                    this.start_but.Text = "安装完成";
                    this.IsFinished = true;
                    try
                    {
                        Form3 PresentForm = (Form3)this.Owner;
                        PresentForm.Reload_Form3();
                    }
                    catch
                    {}
                }));
            }
        }
        public bool IsFinished { get; set; } = false;
        private void ModelDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}

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
    public partial class ModelsUninstallForm : Form
    {
        public ModelsUninstallForm(string model_name)
        {
            InitializeComponent();
            this.Model_name = model_name;
            DialogResult flag = MessageBox.Show("你需要卸载的模块是：" + this.Model_name, "确认卸载", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (flag == DialogResult.Cancel)
            {
                this.Close();
                this.Dispose();
                return;
            }
            else
            {
                Uninstall_ModelAsync(Model_name);
            }
        }
        public async Task Uninstall_ModelAsync(string model_name)
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";      // 命令  
                                                            // 参数  
            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(ErrToBox);
            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(OutPutToBox);
            CmdProcess.EnableRaisingEvents = true;
            CmdProcess.Exited += new EventHandler(ExitEvent);
            CmdProcess.Start();
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();
            await CmdProcess.StandardInput.WriteLineAsync("python -m pip uninstall " + Model_name +" -y&exit");
        }
        private void OutPutToBox(object sender, DataReceivedEventArgs e)
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
                            this.textBox1.AppendText(i + Environment.NewLine);
                        }
                    }), new object[] { e.Data });
                }
            }
        }
        private void ErrToBox(object sender, DataReceivedEventArgs e)
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
        private void ExitEvent(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("已完成！请查看是否成功！");
                    this.finish_but.Enabled = true;
                    Form3 PresentForm = (Form3)this.Owner;
                    this.IsFinished = true;
                    PresentForm.Reload_Form3();
                }));
            }
        }
        public bool IsFinished { get; set; } = false;
        public string Model_name { get; set; }

        private void finish_but_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void ModelsUninstallForm_FormClosing(object sender, FormClosingEventArgs e)
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

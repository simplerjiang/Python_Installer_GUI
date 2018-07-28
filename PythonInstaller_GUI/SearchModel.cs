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
    public partial class SearchModel : Form
    {
        public SearchModel()
        {
            InitializeComponent();
        }


        #region 控件事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                this.search_but.Enabled = false;
            }
            else
            {
                if (this.IsFinished)
                {
                    this.search_but.Enabled = true;
                }
            }
        }
        #endregion

        #region 属性
        public bool IsFinished { get; set; } = true;
        public bool IsPrint { get; set; } = false;
        #endregion

        #region 搜索
        public void fStartToSearch(string Model_name)
        {
            if (Model_name == "")
            {
                MessageBox.Show("请输入模块名");
                return;
            }
            this.search_but.Text = "搜索中..";
            this.listBox1.Items.Clear();
            this.search_but.Enabled = false;
            this.IsFinished = false;
            this.download_but.Enabled = false;
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
            if (PublicValue.Python_path == "")
            {
                CmdProcess.StandardInput.WriteLine("python -m pip search " + Model_name  + "&exit");
            }
            else
            {
                CmdProcess.StandardInput.WriteLine(PublicValue.Python_path + " -m pip search " + Model_name + "&exit");
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
                        foreach (string Ss in results)
                        {
                            if (Ss.EndsWith("&exit")&&!this.IsPrint)
                            {
                                this.IsPrint = true;
                                continue;
                            }
                            if (!Ss.StartsWith(" ")&&this.IsPrint)
                            {
                                string[] SSS = Ss.Split(' ');
                                this.listBox1.Items.Add(SSS[0]);
                            }
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
                    this.search_but.Text = "搜索";
                    this.search_but.Enabled = true;
                    this.download_but.Enabled = true;
                    this.IsFinished = true;
                    this.IsPrint = false;
                }));
            }
        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                this.download_but.Enabled = false;
            }
            else
            {
                if (this.IsFinished)
                {
                    this.download_but.Enabled = true;
                }
            }
        }

        private void search_but_Click(object sender, EventArgs e)
        {
            fStartToSearch(this.textBox1.Text);
        }

        private void download_but_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个模块");
            }
            ModelDownloadForm modelDownloadForm = new ModelDownloadForm((string)listBox1.SelectedItem)
            {
                Owner = this
            };
            modelDownloadForm.ShowDialog();

        }
    }
}

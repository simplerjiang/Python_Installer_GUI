namespace PythonInstaller_GUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Form1_title = new System.Windows.Forms.Label();
            this.Form1_setpath = new System.Windows.Forms.Button();
            this.Form1_pip = new System.Windows.Forms.Button();
            this.Form1_showpath = new System.Windows.Forms.Button();
            this.setPath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Form1_title
            // 
            this.Form1_title.AutoSize = true;
            this.Form1_title.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Form1_title.Location = new System.Drawing.Point(49, 27);
            this.Form1_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Form1_title.Name = "Form1_title";
            this.Form1_title.Size = new System.Drawing.Size(204, 25);
            this.Form1_title.TabIndex = 0;
            this.Form1_title.Text = "Python自动安装";
            // 
            // Form1_setpath
            // 
            this.Form1_setpath.Location = new System.Drawing.Point(54, 94);
            this.Form1_setpath.Margin = new System.Windows.Forms.Padding(2);
            this.Form1_setpath.Name = "Form1_setpath";
            this.Form1_setpath.Size = new System.Drawing.Size(197, 39);
            this.Form1_setpath.TabIndex = 1;
            this.Form1_setpath.Text = "设置Python环境";
            this.Form1_setpath.UseVisualStyleBackColor = true;
            this.Form1_setpath.Click += new System.EventHandler(this.Form1_setpath_Click);
            // 
            // Form1_pip
            // 
            this.Form1_pip.Location = new System.Drawing.Point(54, 148);
            this.Form1_pip.Margin = new System.Windows.Forms.Padding(2);
            this.Form1_pip.Name = "Form1_pip";
            this.Form1_pip.Size = new System.Drawing.Size(197, 39);
            this.Form1_pip.TabIndex = 1;
            this.Form1_pip.Text = "pip包管理";
            this.Form1_pip.UseVisualStyleBackColor = true;
            this.Form1_pip.Click += new System.EventHandler(this.Form1_pip_Click);
            // 
            // Form1_showpath
            // 
            this.Form1_showpath.Location = new System.Drawing.Point(54, 255);
            this.Form1_showpath.Margin = new System.Windows.Forms.Padding(2);
            this.Form1_showpath.Name = "Form1_showpath";
            this.Form1_showpath.Size = new System.Drawing.Size(197, 39);
            this.Form1_showpath.TabIndex = 1;
            this.Form1_showpath.Text = "软件信息";
            this.Form1_showpath.UseVisualStyleBackColor = true;
            // 
            // setPath
            // 
            this.setPath.Location = new System.Drawing.Point(54, 200);
            this.setPath.Margin = new System.Windows.Forms.Padding(2);
            this.setPath.Name = "setPath";
            this.setPath.Size = new System.Drawing.Size(197, 39);
            this.setPath.TabIndex = 1;
            this.setPath.Text = "设置特定路径";
            this.setPath.UseVisualStyleBackColor = true;
            this.setPath.Click += new System.EventHandler(this.setPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.FileName = "python.exe";
            this.openFileDialog1.Filter = "Python主程序|*.exe";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 320);
            this.Controls.Add(this.Form1_showpath);
            this.Controls.Add(this.setPath);
            this.Controls.Add(this.Form1_pip);
            this.Controls.Add(this.Form1_setpath);
            this.Controls.Add(this.Form1_title);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Python自动安装";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Form1_title;
        private System.Windows.Forms.Button Form1_setpath;
        private System.Windows.Forms.Button Form1_pip;
        private System.Windows.Forms.Button Form1_showpath;
        private System.Windows.Forms.Button setPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}


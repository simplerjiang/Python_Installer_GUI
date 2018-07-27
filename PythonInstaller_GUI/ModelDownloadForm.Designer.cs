namespace PythonInstaller_GUI
{
    partial class ModelDownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start_but = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.num_box = new System.Windows.Forms.TextBox();
            this.Model_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmd_info_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start_but);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.num_box);
            this.groupBox1.Controls.Add(this.Model_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // start_but
            // 
            this.start_but.Location = new System.Drawing.Point(592, 27);
            this.start_but.Name = "start_but";
            this.start_but.Size = new System.Drawing.Size(81, 32);
            this.start_but.TabIndex = 0;
            this.start_but.Text = "开始安装";
            this.start_but.UseVisualStyleBackColor = true;
            this.start_but.Click += new System.EventHandler(this.start_but_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoCheck = false;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 7F);
            this.radioButton1.Location = new System.Drawing.Point(486, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "自动最新版";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // num_box
            // 
            this.num_box.Location = new System.Drawing.Point(374, 31);
            this.num_box.Name = "num_box";
            this.num_box.Size = new System.Drawing.Size(106, 25);
            this.num_box.TabIndex = 2;
            this.num_box.TextChanged += new System.EventHandler(this.num_box_TextChanged);
            // 
            // Model_name
            // 
            this.Model_name.Location = new System.Drawing.Point(101, 31);
            this.Model_name.Name = "Model_name";
            this.Model_name.Size = new System.Drawing.Size(171, 25);
            this.Model_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "指定版本号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "需安装模块：";
            // 
            // Cmd_info_box
            // 
            this.Cmd_info_box.Location = new System.Drawing.Point(13, 122);
            this.Cmd_info_box.Multiline = true;
            this.Cmd_info_box.Name = "Cmd_info_box";
            this.Cmd_info_box.ReadOnly = true;
            this.Cmd_info_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Cmd_info_box.Size = new System.Drawing.Size(672, 282);
            this.Cmd_info_box.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "输出窗口";
            // 
            // ModelDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 421);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cmd_info_box);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModelDownloadForm";
            this.Text = "ModelDownloadForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelDownloadForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button start_but;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox num_box;
        private System.Windows.Forms.TextBox Model_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Cmd_info_box;
        private System.Windows.Forms.Label label3;
    }
}
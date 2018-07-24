namespace PythonInstaller_GUI
{
    partial class Form3
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.but_Uninstall = new System.Windows.Forms.Button();
            this.Model_name = new System.Windows.Forms.TextBox();
            this.but_Install = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "暂无数据"});
            this.listBox1.Location = new System.Drawing.Point(235, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(315, 244);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // but_Uninstall
            // 
            this.but_Uninstall.Enabled = false;
            this.but_Uninstall.Location = new System.Drawing.Point(467, 301);
            this.but_Uninstall.Name = "but_Uninstall";
            this.but_Uninstall.Size = new System.Drawing.Size(83, 25);
            this.but_Uninstall.TabIndex = 1;
            this.but_Uninstall.Text = "卸载模块";
            this.but_Uninstall.UseVisualStyleBackColor = true;
            // 
            // Model_name
            // 
            this.Model_name.Location = new System.Drawing.Point(235, 301);
            this.Model_name.Name = "Model_name";
            this.Model_name.Size = new System.Drawing.Size(137, 25);
            this.Model_name.TabIndex = 2;
            // 
            // but_Install
            // 
            this.but_Install.Enabled = false;
            this.but_Install.Location = new System.Drawing.Point(378, 301);
            this.but_Install.Name = "but_Install";
            this.but_Install.Size = new System.Drawing.Size(83, 25);
            this.but_Install.TabIndex = 1;
            this.but_Install.Text = "安装模块";
            this.but_Install.UseVisualStyleBackColor = true;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(13, 13);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(145, 15);
            this.label_info.TabIndex = 3;
            this.label_info.Text = "目前的Python版本：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "路径地址:";
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(313, 10);
            this.text_path.Name = "text_path";
            this.text_path.ReadOnly = true;
            this.text_path.Size = new System.Drawing.Size(235, 25);
            this.text_path.TabIndex = 4;
            this.text_path.Text = "C:\\Users\\Administrator\\AppData\\Local\\Programs\\Python\\Python36\\python3.exe";
            this.text_path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_path_KeyDown);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 340);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.Model_name);
            this.Controls.Add(this.but_Install);
            this.Controls.Add(this.but_Uninstall);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button but_Uninstall;
        private System.Windows.Forms.TextBox Model_name;
        private System.Windows.Forms.Button but_Install;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_path;
    }
}
namespace PythonInstaller_GUI
{
    partial class SearchModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchModel));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.search_but = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.download_but = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // search_but
            // 
            this.search_but.Enabled = false;
            this.search_but.Location = new System.Drawing.Point(219, 12);
            this.search_but.Name = "search_but";
            this.search_but.Size = new System.Drawing.Size(103, 25);
            this.search_but.TabIndex = 2;
            this.search_but.Text = "搜索";
            this.search_but.UseVisualStyleBackColor = true;
            this.search_but.Click += new System.EventHandler(this.search_but_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(431, 289);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // download_but
            // 
            this.download_but.Enabled = false;
            this.download_but.Location = new System.Drawing.Point(340, 12);
            this.download_but.Name = "download_but";
            this.download_but.Size = new System.Drawing.Size(103, 25);
            this.download_but.TabIndex = 2;
            this.download_but.Text = "下载";
            this.download_but.UseVisualStyleBackColor = true;
            this.download_but.Click += new System.EventHandler(this.download_but_Click);
            // 
            // SearchModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 364);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.download_but);
            this.Controls.Add(this.search_but);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchModel";
            this.Text = "搜索模块包";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button search_but;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button download_but;
    }
}
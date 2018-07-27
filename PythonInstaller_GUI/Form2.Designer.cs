namespace PythonInstaller_GUI
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Form2_label = new System.Windows.Forms.Label();
            this.Form2_finishbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 89);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(520, 212);
            this.textBox1.TabIndex = 0;
            // 
            // Form2_label
            // 
            this.Form2_label.AutoSize = true;
            this.Form2_label.Location = new System.Drawing.Point(17, 21);
            this.Form2_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Form2_label.Name = "Form2_label";
            this.Form2_label.Size = new System.Drawing.Size(433, 15);
            this.Form2_label.TabIndex = 1;
            this.Form2_label.Text = "正在设置Python环境！请勿删除本程序！否则会造成丢失Python";
            // 
            // Form2_finishbutton
            // 
            this.Form2_finishbutton.Enabled = false;
            this.Form2_finishbutton.Location = new System.Drawing.Point(401, 48);
            this.Form2_finishbutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Form2_finishbutton.Name = "Form2_finishbutton";
            this.Form2_finishbutton.Size = new System.Drawing.Size(124, 27);
            this.Form2_finishbutton.TabIndex = 2;
            this.Form2_finishbutton.Text = "完成";
            this.Form2_finishbutton.UseVisualStyleBackColor = true;
            this.Form2_finishbutton.Visible = false;
            this.Form2_finishbutton.Click += new System.EventHandler(this.Form2_finishbutton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 321);
            this.Controls.Add(this.Form2_finishbutton);
            this.Controls.Add(this.Form2_label);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Form2_label;
        private System.Windows.Forms.Button Form2_finishbutton;
    }
}
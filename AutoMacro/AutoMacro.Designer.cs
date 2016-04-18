using System.ComponentModel;
using System.Windows.Forms;

namespace AutoMacro
{
    partial class AutoMacro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Please focus on the window you want to use macro and press CTRL + 1.";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(15, 44);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(516, 470);
            this.txtCode.TabIndex = 1;
            this.txtCode.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "2. Macro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "CTRL + 1 : Select window.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "CTRL + 2 : Get mouse position.";
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonRun.Location = new System.Drawing.Point(12, 520);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 5;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // AutoMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 554);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Name = "AutoMacro";
            this.Text = "AutoMacro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private RichTextBox txtCode;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonRun;
    }
}
namespace DocConverter
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmdGo = new System.Windows.Forms.Button();
            this.lblSkip = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.lblCurrentPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory Path to Process";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(12, 36);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(548, 20);
            this.txtSourcePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Items Done:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(74, 91);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "0";
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(12, 62);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(75, 23);
            this.cmdGo.TabIndex = 4;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // lblSkip
            // 
            this.lblSkip.AutoSize = true;
            this.lblSkip.Location = new System.Drawing.Point(74, 112);
            this.lblSkip.Name = "lblSkip";
            this.lblSkip.Size = new System.Drawing.Size(13, 13);
            this.lblSkip.TabIndex = 6;
            this.lblSkip.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Items Skip:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(74, 133);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(13, 13);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Items Error:";
            // 
            // txtErrors
            // 
            this.txtErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrors.Location = new System.Drawing.Point(12, 149);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrors.Size = new System.Drawing.Size(548, 331);
            this.txtErrors.TabIndex = 9;
            // 
            // lblCurrentPath
            // 
            this.lblCurrentPath.AutoSize = true;
            this.lblCurrentPath.Location = new System.Drawing.Point(93, 67);
            this.lblCurrentPath.Name = "lblCurrentPath";
            this.lblCurrentPath.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentPath.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 492);
            this.Controls.Add(this.lblCurrentPath);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSkip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.Label lblSkip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.Label lblCurrentPath;
    }
}


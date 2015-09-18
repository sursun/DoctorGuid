namespace DoctorGuid
{
    partial class FormShortCutEdit
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonExe = new System.Windows.Forms.RadioButton();
            this.radioButtonExplorer = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProcessName = new System.Windows.Forms.TextBox();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.btnSelectFileName = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.textBoxIcon = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(95, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(151, 21);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "显示名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "图标";
            // 
            // radioButtonExe
            // 
            this.radioButtonExe.AutoSize = true;
            this.radioButtonExe.Checked = true;
            this.radioButtonExe.Location = new System.Drawing.Point(95, 84);
            this.radioButtonExe.Name = "radioButtonExe";
            this.radioButtonExe.Size = new System.Drawing.Size(71, 16);
            this.radioButtonExe.TabIndex = 3;
            this.radioButtonExe.TabStop = true;
            this.radioButtonExe.Text = "应用程序";
            this.radioButtonExe.UseVisualStyleBackColor = true;
            // 
            // radioButtonExplorer
            // 
            this.radioButtonExplorer.AutoSize = true;
            this.radioButtonExplorer.Location = new System.Drawing.Point(202, 84);
            this.radioButtonExplorer.Name = "radioButtonExplorer";
            this.radioButtonExplorer.Size = new System.Drawing.Size(47, 16);
            this.radioButtonExplorer.TabIndex = 4;
            this.radioButtonExplorer.Text = "网址";
            this.radioButtonExplorer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "进程名称";
            // 
            // textBoxProcessName
            // 
            this.textBoxProcessName.Location = new System.Drawing.Point(95, 122);
            this.textBoxProcessName.Name = "textBoxProcessName";
            this.textBoxProcessName.Size = new System.Drawing.Size(151, 21);
            this.textBoxProcessName.TabIndex = 6;
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.Location = new System.Drawing.Point(252, 222);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(75, 23);
            this.btnSelectIcon.TabIndex = 7;
            this.btnSelectIcon.Text = "选择";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "网址（参数）";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(95, 173);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(327, 21);
            this.textBoxUrl.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "程序位置";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(95, 47);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(246, 21);
            this.textBoxFileName.TabIndex = 6;
            // 
            // btnSelectFileName
            // 
            this.btnSelectFileName.Location = new System.Drawing.Point(347, 46);
            this.btnSelectFileName.Name = "btnSelectFileName";
            this.btnSelectFileName.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFileName.TabIndex = 7;
            this.btnSelectFileName.Text = "选择";
            this.btnSelectFileName.UseVisualStyleBackColor = true;
            this.btnSelectFileName.Click += new System.EventHandler(this.btnSelectFileName_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(347, 308);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // textBoxIcon
            // 
            this.textBoxIcon.Location = new System.Drawing.Point(95, 224);
            this.textBoxIcon.Name = "textBoxIcon";
            this.textBoxIcon.Size = new System.Drawing.Size(151, 21);
            this.textBoxIcon.TabIndex = 11;
            // 
            // FormShortCutEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 343);
            this.Controls.Add(this.textBoxIcon);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectFileName);
            this.Controls.Add(this.btnSelectIcon);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.textBoxProcessName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonExplorer);
            this.Controls.Add(this.radioButtonExe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormShortCutEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormShortCutEdit";
            this.Load += new System.EventHandler(this.FormShortCutEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonExe;
        private System.Windows.Forms.RadioButton radioButtonExplorer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProcessName;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button btnSelectFileName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox textBoxIcon;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}
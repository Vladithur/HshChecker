namespace HshCheckerWindow
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
            this.checkBoxExe = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.selectFolder = new System.Windows.Forms.Button();
            this.go = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.checkBoxService = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxExe
            // 
            this.checkBoxExe.AutoSize = true;
            this.checkBoxExe.Location = new System.Drawing.Point(12, 50);
            this.checkBoxExe.Name = "checkBoxExe";
            this.checkBoxExe.Size = new System.Drawing.Size(125, 17);
            this.checkBoxExe.TabIndex = 1;
            this.checkBoxExe.Text = "Check Only .exe files";
            this.checkBoxExe.UseVisualStyleBackColor = true;
            this.checkBoxExe.CheckedChanged += new System.EventHandler(this.checkBoxExe_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder To Check";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(104, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(237, 20);
            this.textBox.TabIndex = 3;
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(347, 12);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(75, 23);
            this.selectFolder.TabIndex = 4;
            this.selectFolder.Text = "Sellect";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // go
            // 
            this.go.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.go.Location = new System.Drawing.Point(143, 41);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(164, 33);
            this.go.TabIndex = 5;
            this.go.Text = "CHECK";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // del
            // 
            this.del.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.del.Location = new System.Drawing.Point(313, 41);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(109, 33);
            this.del.TabIndex = 6;
            this.del.Text = "Delete md5\'s";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // checkBoxService
            // 
            this.checkBoxService.AutoSize = true;
            this.checkBoxService.Location = new System.Drawing.Point(12, 82);
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.Size = new System.Drawing.Size(352, 17);
            this.checkBoxService.TabIndex = 7;
            this.checkBoxService.Text = "Start \"Check\" as soon as run ( Should be used if you set it as a task )";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.CheckedChanged += new System.EventHandler(this.checkBoxService_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.checkBoxService);
            this.Controls.Add(this.del);
            this.Controls.Add(this.go);
            this.Controls.Add(this.selectFolder);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxExe);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 150);
            this.MinimumSize = new System.Drawing.Size(450, 150);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxExe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.CheckBox checkBoxService;
    }
}


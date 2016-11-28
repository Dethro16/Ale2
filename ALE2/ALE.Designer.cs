namespace ALE2
{
    partial class ALE
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
            this.cBFiles = new System.Windows.Forms.ComboBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rTBText = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cBDirectory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDfa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBString = new System.Windows.Forms.TextBox();
            this.btnParseString = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAccepted = new System.Windows.Forms.Label();
            this.rTBTestCase = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBFiles
            // 
            this.cBFiles.FormattingEnabled = true;
            this.cBFiles.ItemHeight = 16;
            this.cBFiles.Location = new System.Drawing.Point(104, 46);
            this.cBFiles.Margin = new System.Windows.Forms.Padding(4);
            this.cBFiles.Name = "cBFiles";
            this.cBFiles.Size = new System.Drawing.Size(264, 24);
            this.cBFiles.TabIndex = 0;
            this.cBFiles.SelectedIndexChanged += new System.EventHandler(this.cBFiles_SelectedIndexChanged);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(377, 46);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(125, 26);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Read NDFA";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "File:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 187);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1154, 416);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // rTBText
            // 
            this.rTBText.Location = new System.Drawing.Point(677, 4);
            this.rTBText.Margin = new System.Windows.Forms.Padding(4);
            this.rTBText.Name = "rTBText";
            this.rTBText.Size = new System.Drawing.Size(232, 175);
            this.rTBText.TabIndex = 7;
            this.rTBText.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDirectoryToolStripMenuItem,
            this.addToFavoritesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.fileToolStripMenuItem.Text = "Directory";
            this.fileToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // setDirectoryToolStripMenuItem
            // 
            this.setDirectoryToolStripMenuItem.Name = "setDirectoryToolStripMenuItem";
            this.setDirectoryToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.setDirectoryToolStripMenuItem.Text = "Set directory...";
            this.setDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setDirectoryToolStripMenuItem_Click);
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addToFavoritesToolStripMenuItem.Text = "Add to favorites";
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // cBDirectory
            // 
            this.cBDirectory.FormattingEnabled = true;
            this.cBDirectory.Location = new System.Drawing.Point(104, 4);
            this.cBDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.cBDirectory.Name = "cBDirectory";
            this.cBDirectory.Size = new System.Drawing.Size(560, 24);
            this.cBDirectory.TabIndex = 9;
            this.cBDirectory.SelectedIndexChanged += new System.EventHandler(this.cBDirectory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Is DFA?: ";
            // 
            // lbDfa
            // 
            this.lbDfa.AutoSize = true;
            this.lbDfa.Location = new System.Drawing.Point(587, 49);
            this.lbDfa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDfa.Name = "lbDfa";
            this.lbDfa.Size = new System.Drawing.Size(76, 17);
            this.lbDfa.TabIndex = 11;
            this.lbDfa.Text = "True/False";
            this.lbDfa.TextChanged += new System.EventHandler(this.lbDfa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "String:";
            // 
            // tBString
            // 
            this.tBString.Location = new System.Drawing.Point(104, 94);
            this.tBString.Margin = new System.Windows.Forms.Padding(4);
            this.tBString.Name = "tBString";
            this.tBString.Size = new System.Drawing.Size(264, 22);
            this.tBString.TabIndex = 13;
            // 
            // btnParseString
            // 
            this.btnParseString.Location = new System.Drawing.Point(377, 94);
            this.btnParseString.Margin = new System.Windows.Forms.Padding(4);
            this.btnParseString.Name = "btnParseString";
            this.btnParseString.Size = new System.Drawing.Size(125, 28);
            this.btnParseString.TabIndex = 14;
            this.btnParseString.Text = "Parse string";
            this.btnParseString.UseVisualStyleBackColor = true;
            this.btnParseString.Click += new System.EventHandler(this.btnParseString_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Accepted:";
            // 
            // lbAccepted
            // 
            this.lbAccepted.AutoSize = true;
            this.lbAccepted.Location = new System.Drawing.Point(593, 97);
            this.lbAccepted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAccepted.Name = "lbAccepted";
            this.lbAccepted.Size = new System.Drawing.Size(76, 17);
            this.lbAccepted.TabIndex = 16;
            this.lbAccepted.Text = "True/False";
            this.lbAccepted.TextChanged += new System.EventHandler(this.lbAccepted_TextChanged);
            // 
            // rTBTestCase
            // 
            this.rTBTestCase.Location = new System.Drawing.Point(996, 5);
            this.rTBTestCase.Name = "rTBTestCase";
            this.rTBTestCase.Size = new System.Drawing.Size(174, 175);
            this.rTBTestCase.TabIndex = 17;
            this.rTBTestCase.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(916, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Test case:";
            // 
            // ALE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 618);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rTBTestCase);
            this.Controls.Add(this.lbAccepted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnParseString);
            this.Controls.Add(this.tBString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDfa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBDirectory);
            this.Controls.Add(this.rTBText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cBFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ALE";
            this.Text = "Automata in Professional Practice";
            this.Load += new System.EventHandler(this.ALE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBFiles;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rTBText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cBDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDfa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBString;
        private System.Windows.Forms.Button btnParseString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbAccepted;
        private System.Windows.Forms.RichTextBox rTBTestCase;
        private System.Windows.Forms.Label label5;
    }
}


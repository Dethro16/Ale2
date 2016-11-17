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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBFiles
            // 
            this.cBFiles.FormattingEnabled = true;
            this.cBFiles.ItemHeight = 13;
            this.cBFiles.Location = new System.Drawing.Point(78, 37);
            this.cBFiles.Name = "cBFiles";
            this.cBFiles.Size = new System.Drawing.Size(199, 21);
            this.cBFiles.TabIndex = 0;
            this.cBFiles.SelectedIndexChanged += new System.EventHandler(this.cBFiles_SelectedIndexChanged);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(283, 37);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(94, 21);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Read NDFA";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(663, 338);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(516, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(154, 143);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.fileToolStripMenuItem.Text = "Directory";
            this.fileToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // setDirectoryToolStripMenuItem
            // 
            this.setDirectoryToolStripMenuItem.Name = "setDirectoryToolStripMenuItem";
            this.setDirectoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.setDirectoryToolStripMenuItem.Text = "Set directory...";
            this.setDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setDirectoryToolStripMenuItem_Click);
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addToFavoritesToolStripMenuItem.Text = "Add to favorites";
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // cBDirectory
            // 
            this.cBDirectory.FormattingEnabled = true;
            this.cBDirectory.Location = new System.Drawing.Point(78, 3);
            this.cBDirectory.Name = "cBDirectory";
            this.cBDirectory.Size = new System.Drawing.Size(421, 21);
            this.cBDirectory.TabIndex = 9;
            this.cBDirectory.SelectedIndexChanged += new System.EventHandler(this.cBDirectory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Is DFA?: ";
            // 
            // lbDfa
            // 
            this.lbDfa.AutoSize = true;
            this.lbDfa.Location = new System.Drawing.Point(440, 40);
            this.lbDfa.Name = "lbDfa";
            this.lbDfa.Size = new System.Drawing.Size(59, 13);
            this.lbDfa.TabIndex = 11;
            this.lbDfa.Text = "True/False";
            this.lbDfa.TextChanged += new System.EventHandler(this.lbDfa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "String:";
            // 
            // tBString
            // 
            this.tBString.Location = new System.Drawing.Point(78, 76);
            this.tBString.Name = "tBString";
            this.tBString.Size = new System.Drawing.Size(199, 20);
            this.tBString.TabIndex = 13;
            // 
            // btnParseString
            // 
            this.btnParseString.Location = new System.Drawing.Point(283, 76);
            this.btnParseString.Name = "btnParseString";
            this.btnParseString.Size = new System.Drawing.Size(94, 23);
            this.btnParseString.TabIndex = 14;
            this.btnParseString.Text = "Parse string";
            this.btnParseString.UseVisualStyleBackColor = true;
            this.btnParseString.Click += new System.EventHandler(this.btnParseString_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Accepted:";
            // 
            // lbAccepted
            // 
            this.lbAccepted.AutoSize = true;
            this.lbAccepted.Location = new System.Drawing.Point(445, 79);
            this.lbAccepted.Name = "lbAccepted";
            this.lbAccepted.Size = new System.Drawing.Size(59, 13);
            this.lbAccepted.TabIndex = 16;
            this.lbAccepted.Text = "True/False";
            this.lbAccepted.TextChanged += new System.EventHandler(this.lbAccepted_TextChanged);
            // 
            // ALE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 502);
            this.Controls.Add(this.lbAccepted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnParseString);
            this.Controls.Add(this.tBString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDfa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBDirectory);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cBFiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.RichTextBox richTextBox1;
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
    }
}


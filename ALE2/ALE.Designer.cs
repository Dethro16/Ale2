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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tBRE = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCreateNDFA = new System.Windows.Forms.Button();
            this.rTBTestResults = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbFinite = new System.Windows.Forms.Label();
            this.rTBWords = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btNFADFA = new System.Windows.Forms.Button();
            this.pBDFA = new System.Windows.Forms.PictureBox();
            this.btREADPDA = new System.Windows.Forms.Button();
            this.btnParsePDA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBDFA)).BeginInit();
            this.SuspendLayout();
            // 
            // cBFiles
            // 
            this.cBFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(487, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // rTBText
            // 
            this.rTBText.Location = new System.Drawing.Point(505, 27);
            this.rTBText.Name = "rTBText";
            this.rTBText.Size = new System.Drawing.Size(226, 275);
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
            this.menuStrip1.Size = new System.Drawing.Size(1350, 24);
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
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Is DFA?: ";
            // 
            // lbDfa
            // 
            this.lbDfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "String:";
            // 
            // tBString
            // 
            this.tBString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBString.Location = new System.Drawing.Point(78, 105);
            this.tBString.Name = "tBString";
            this.tBString.Size = new System.Drawing.Size(199, 20);
            this.tBString.TabIndex = 13;
            // 
            // btnParseString
            // 
            this.btnParseString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParseString.Location = new System.Drawing.Point(283, 91);
            this.btnParseString.Name = "btnParseString";
            this.btnParseString.Size = new System.Drawing.Size(94, 34);
            this.btnParseString.TabIndex = 14;
            this.btnParseString.Text = "Parse string NDFA";
            this.btnParseString.UseVisualStyleBackColor = true;
            this.btnParseString.Click += new System.EventHandler(this.btnParseString_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Accepted:";
            // 
            // lbAccepted
            // 
            this.lbAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccepted.AutoSize = true;
            this.lbAccepted.Location = new System.Drawing.Point(320, 128);
            this.lbAccepted.Name = "lbAccepted";
            this.lbAccepted.Size = new System.Drawing.Size(59, 13);
            this.lbAccepted.TabIndex = 16;
            this.lbAccepted.Text = "True/False";
            this.lbAccepted.TextChanged += new System.EventHandler(this.lbAccepted_TextChanged);
            // 
            // rTBTestCase
            // 
            this.rTBTestCase.Location = new System.Drawing.Point(505, 320);
            this.rTBTestCase.Margin = new System.Windows.Forms.Padding(2);
            this.rTBTestCase.Name = "rTBTestCase";
            this.rTBTestCase.Size = new System.Drawing.Size(111, 240);
            this.rTBTestCase.TabIndex = 17;
            this.rTBTestCase.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 305);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Test case input:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(737, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(601, 612);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // tBRE
            // 
            this.tBRE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBRE.Location = new System.Drawing.Point(844, 30);
            this.tBRE.Name = "tBRE";
            this.tBRE.Size = new System.Drawing.Size(199, 20);
            this.tBRE.TabIndex = 28;
            this.tBRE.Text = "*(A)";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(737, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Regular Expression:";
            // 
            // btnCreateNDFA
            // 
            this.btnCreateNDFA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNDFA.Location = new System.Drawing.Point(1049, 30);
            this.btnCreateNDFA.Name = "btnCreateNDFA";
            this.btnCreateNDFA.Size = new System.Drawing.Size(65, 35);
            this.btnCreateNDFA.TabIndex = 23;
            this.btnCreateNDFA.Text = "Construct NDFA";
            this.btnCreateNDFA.UseVisualStyleBackColor = true;
            this.btnCreateNDFA.Click += new System.EventHandler(this.btnCreateNDFA_Click);
            // 
            // rTBTestResults
            // 
            this.rTBTestResults.Location = new System.Drawing.Point(620, 320);
            this.rTBTestResults.Margin = new System.Windows.Forms.Padding(2);
            this.rTBTestResults.Name = "rTBTestResults";
            this.rTBTestResults.Size = new System.Drawing.Size(111, 240);
            this.rTBTestResults.TabIndex = 29;
            this.rTBTestResults.Text = "";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(617, 305);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Test Result";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Is Finite:";
            // 
            // lbFinite
            // 
            this.lbFinite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFinite.AutoSize = true;
            this.lbFinite.Location = new System.Drawing.Point(437, 128);
            this.lbFinite.Name = "lbFinite";
            this.lbFinite.Size = new System.Drawing.Size(59, 13);
            this.lbFinite.TabIndex = 34;
            this.lbFinite.Text = "True/False";
            // 
            // rTBWords
            // 
            this.rTBWords.Location = new System.Drawing.Point(507, 577);
            this.rTBWords.Margin = new System.Windows.Forms.Padding(2);
            this.rTBWords.Name = "rTBWords";
            this.rTBWords.Size = new System.Drawing.Size(224, 140);
            this.rTBWords.TabIndex = 35;
            this.rTBWords.Text = "";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(504, 562);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Words:";
            // 
            // btNFADFA
            // 
            this.btNFADFA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btNFADFA.Location = new System.Drawing.Point(386, 56);
            this.btNFADFA.Name = "btNFADFA";
            this.btNFADFA.Size = new System.Drawing.Size(113, 29);
            this.btNFADFA.TabIndex = 37;
            this.btNFADFA.Text = "NDFA to DFA";
            this.btNFADFA.UseVisualStyleBackColor = true;
            this.btNFADFA.Click += new System.EventHandler(this.btNFADFA_Click);
            // 
            // pBDFA
            // 
            this.pBDFA.Location = new System.Drawing.Point(12, 342);
            this.pBDFA.Name = "pBDFA";
            this.pBDFA.Size = new System.Drawing.Size(487, 375);
            this.pBDFA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBDFA.TabIndex = 38;
            this.pBDFA.TabStop = false;
            // 
            // btREADPDA
            // 
            this.btREADPDA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btREADPDA.Location = new System.Drawing.Point(283, 64);
            this.btREADPDA.Name = "btREADPDA";
            this.btREADPDA.Size = new System.Drawing.Size(94, 21);
            this.btREADPDA.TabIndex = 39;
            this.btREADPDA.Text = "Read PDA";
            this.btREADPDA.UseVisualStyleBackColor = true;
            this.btREADPDA.Click += new System.EventHandler(this.btREADPDA_Click);
            // 
            // btnParsePDA
            // 
            this.btnParsePDA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParsePDA.Location = new System.Drawing.Point(386, 91);
            this.btnParsePDA.Name = "btnParsePDA";
            this.btnParsePDA.Size = new System.Drawing.Size(113, 34);
            this.btnParsePDA.TabIndex = 40;
            this.btnParsePDA.Text = "Parse string PDA";
            this.btnParsePDA.UseVisualStyleBackColor = true;
            this.btnParsePDA.Click += new System.EventHandler(this.btnParsePDA_Click);
            // 
            // ALE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnParsePDA);
            this.Controls.Add(this.btREADPDA);
            this.Controls.Add(this.pBDFA);
            this.Controls.Add(this.btNFADFA);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rTBWords);
            this.Controls.Add(this.lbFinite);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rTBTestResults);
            this.Controls.Add(this.tBRE);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCreateNDFA);
            this.Controls.Add(this.pictureBox2);
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
            this.Name = "ALE";
            this.Text = "Automata in Professional Practice";
            this.Load += new System.EventHandler(this.ALE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBDFA)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tBRE;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCreateNDFA;
        private System.Windows.Forms.RichTextBox rTBTestResults;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbFinite;
        private System.Windows.Forms.RichTextBox rTBWords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btNFADFA;
        private System.Windows.Forms.PictureBox pBDFA;
        private System.Windows.Forms.Button btREADPDA;
        private System.Windows.Forms.Button btnParsePDA;
    }
}


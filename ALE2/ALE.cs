using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE2
{
    public partial class ALE : Form
    {
        Parser parser = new Parser();
        Automaton automata;

        public ALE()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (cBDirectory.Text == "" || cBFiles.Text == "")
            {
                MessageBox.Show("Select a directory and/or file!");
                return;
            }
            automata = parser.ParseFiniteAutomata(cBDirectory.Text + "\\" + cBFiles.Text);
            lbDfa.Text = automata.CheckDFA().ToString();

            automata.GeneratePicture();

            pictureBox1.ImageLocation = @"C:\Program Files (x86)\Graphviz2.38\bin\abc.png";
        }

        /// <summary>
        /// Returns a list of strings with filenames
        /// </summary>
        /// <param name="fbd"></param>
        /// <param name="possiblePath"></param>
        /// <returns></returns>
        private List<string> GetFilesFromDir(FolderBrowserDialog fbd = null, string possiblePath = "")
        {
            List<string> temp = new List<string>();

            if (fbd != null)
            {
                temp = Directory.GetFiles(fbd.SelectedPath).ToList();

                MessageBox.Show("Files found: " + temp.Count.ToString(), "Message");
            }
            else
            {
                temp = Directory.GetFiles(possiblePath).ToList();
            }


            List<string> files = new List<string>();

            foreach (var item in temp)
            {
                files.Add(Path.GetFileName(item));
            }

            return files;
        }

        private void setDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
            {
                MessageBox.Show("Try again.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                files = GetFilesFromDir(fbd);
            }

            string dirName = new DirectoryInfo(fbd.SelectedPath).Name;
            cBDirectory.Items.Add(fbd.SelectedPath);
            cBDirectory.SelectedItem = fbd.SelectedPath;

            cBFiles.Items.Clear();
            foreach (string item in files)
            {
                cBFiles.Items.Add(item);
            }

            cBDirectory.Refresh();
        }

        /// <summary>
        /// Add filepath to favourites WIP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logFile = File.ReadAllLines(@"..\..\Favourites.txt");
            List<string> LogList = new List<string>(logFile);

            if (!LogList.Contains(cBDirectory.Text))
            {
                LogList.Add(cBDirectory.Text);
            }

            File.WriteAllLines(@"..\..\Favourites.txt", LogList);
        }

        private void ALE_Load(object sender, EventArgs e)
        {
            var logFile = File.ReadAllLines(@"..\..\Favourites.txt");
            List<string> LogList = new List<string>(logFile);

            foreach (var item in LogList)
            {
                cBDirectory.Items.Add(item);
            }
        }

        private void cBDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBFiles.Items.Clear();

            foreach (var item in GetFilesFromDir(null, cBDirectory.SelectedItem.ToString()))
            {
                cBFiles.Items.Add(item);
            }
        }

        private void cBFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(cBDirectory.Text + "\\" + cBFiles.Text);
        }



        private void btnParseString_Click(object sender, EventArgs e)
        {
            lbAccepted.Text = automata.CheckInputString(tBString.Text).ToString();
        }



        private void lbDfa_TextChanged(object sender, EventArgs e)
        {
            if (lbDfa.Text == "True")
            {
                lbDfa.BackColor = Color.Green;
            }
            else
            {
                lbDfa.BackColor = Color.Red;
            }
        }

        private void lbAccepted_TextChanged(object sender, EventArgs e)
        {
            if (lbAccepted.Text == "True")
            {
                lbAccepted.BackColor = Color.Green;
            }
            else
            {
                lbAccepted.BackColor = Color.Red;
            }
        }
    }
}

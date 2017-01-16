using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ALE2
{
    public partial class ALE : Form
    {
        Parser parser = new Parser();
        Automaton automata;
        Automaton automataDFA;
        Automaton automataPDA;
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
            automata.AssignTransitions();
            automata.AssignGraphViz();

            rTBTestCase.Clear();
            rTBTestResults.Clear();
            rTBWords.Clear();
            //AppendToRTB(rTBTestCase, new List<string>() { automata.CheckTestDFA() });
            rTBTestCase.AppendText("is DFA: " + automata.Dfa + "\n");
            List<string> toTb = new List<string>();
            if (automata.CheckDFA() == automata.Dfa)
            {
                toTb.Add("DFA: " + automata.Dfa + " V");
            }
            else
            {
                toTb.Add("DFA: " + automata.Dfa + " X");
            }

            AppendToRTB(rTBTestResults, toTb);

            AppendToRTB(rTBTestCase, automata.CheckTestWords());


            AppendToRTB(rTBTestResults, automata.TestWords);
            //automata.CheckTestWords();


            lbDfa.Text = automata.CheckDFA().ToString();



            parser.GeneratePicture(automata.StateList, automata.TransitionList);

            pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "abc.png";

            automata.Words.Clear();
            automata.ClearStates();
            automata.ClearTransitions();
            //check how many words
            if (automata.CheckAllWords(automata.StateList[0], ""))
            {
                lbFinite.Text = "True";
                lbFinite.BackColor = Color.Green;
            }
            else
            {
                lbFinite.Text = "False";
                lbFinite.BackColor = Color.Red;
            }


            rTBWords.AppendText("All words:\n");
            foreach (Word word in automata.Words)
            {

                rTBWords.AppendText("Word: " + word.StringValue);
                rTBWords.AppendText("\n");
                rTBWords.AppendText("Accepted: " + word.Accepted);
                rTBWords.AppendText("\n");
            }

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

            try
            {
                if (fbd != null)
                {
                    temp = Directory.GetFiles(fbd.SelectedPath).ToList();

                    MessageBox.Show("Files found: " + temp.Count.ToString(), "Message");
                }
                else
                {
                    temp = Directory.GetFiles(possiblePath).ToList();
                }

            }
            catch (System.IO.DirectoryNotFoundException)
            {
                return null;
                //throw;
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

        private void AppendToRTB(RichTextBox textBox, List<string> temp)
        {
            foreach (var item in temp)
            {
                if (item.Contains('X'))//wrong
                {
                    RichTextBoxExtensions.AppendText(textBox, item, Color.Red);
                    textBox.AppendText("\n");
                }
                else if (item.Contains('V'))
                {
                    RichTextBoxExtensions.AppendText(textBox, item, Color.Green);
                    textBox.AppendText("\n");
                }
                else
                {
                    textBox.AppendText(item);
                    textBox.AppendText("\n");
                }
            }
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
            List<string> fileList = GetFilesFromDir(null, cBDirectory.SelectedItem.ToString());
            cBFiles.Items.Clear();
            if (fileList == null)
            {
                MessageBox.Show("Directory does not exist!");
                cBFiles.SelectedIndex = -1;
                cBFiles.Items.Clear();
                rTBText.Clear();
                rTBTestCase.Clear();
                tBString.Clear();
                return;

            }
            foreach (var item in fileList)
            {
                cBFiles.Items.Add(item);
            }
        }

        private void cBFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBFiles.SelectedIndex == -1)
            {
                return;
            }
            rTBText.Text = File.ReadAllText(cBDirectory.Text + "\\" + cBFiles.Text);
        }

        private void btnParseString_Click(object sender, EventArgs e)
        {
            automata.ClearStates();
            automata.ClearTransitions();
            lbAccepted.Text = automata.BFSTraversal(automata.StateList[0], tBString.Text).ToString();
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



        private void btnCreateNDFA_Click(object sender, EventArgs e)
        {
            if (tBRE.Text == "")
            {
                MessageBox.Show("Please provide a regular expression.");
                return;
            }

            Automaton automata = new Automaton(new List<State>(), new List<string>(), new List<Transition>());
            Tokenizer t = new Tokenizer();
            parser.StrippedTokenList = t.Scan(tBRE.Text);
            Node temp = parser.ParseTree();

            parser.stateCount = 0;
            automata = parser.ParseTreeToAutomata(temp, automata);

            //automata.AssignAlphabet();
            automata.AssignTransitions();
            automata.AssignStates();
            parser.SaveNDFAToFile(automata);
            //parser.ParseRE(automaton, tBRE.Text);

            automata.AssignGraphViz();


            parser.GeneratePicture(automata.StateList, automata.TransitionList);

            pictureBox2.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "abc.png";
            //parser.ParseRegExToNode(tBRE.Text);
            //parser.ParseTest(tBRE.Text, new List<Automaton>());
        }

        private void btNFADFA_Click(object sender, EventArgs e)
        {
            automataDFA = automata.SetStateTable(automata);
            //List<State> temp = automata.stateListDFA
            automataDFA.StateList = automataDFA.StateList.Distinct().ToList();

            automataDFA.AssignTransitions();
            automataDFA.AssignStates();
            // automata.StateList = temp;
            //automataDFA.AssignTransitions();

            automataDFA.CleanDuplicates();
            automataDFA.AssignGraphViz();


            parser.GeneratePicture(automataDFA.StateList, automataDFA.TransitionList, "Dfa.png");

            pBDFA.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "Dfa.png";
        }

        private void btREADPDA_Click(object sender, EventArgs e)
        {
            if (cBDirectory.Text == "" || cBFiles.Text == "")
            {
                MessageBox.Show("Select a directory and/or file!");
                return;
            }
            automataPDA = parser.ParsePDA(cBDirectory.Text + "\\" + cBFiles.Text);
            automataPDA.AssignTransitions();
            automataPDA.AssignGraphViz();

            rTBTestCase.Clear();
            rTBTestResults.Clear();
            rTBWords.Clear();

            parser.GeneratePicture(automataPDA.StateList, automataPDA.TransitionList, "PDA.png");

            pBDFA.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "PDA.png";
            //lbDfa.Text = automata.CheckDFA().ToString();
        }

        private void btnParsePDA_Click(object sender, EventArgs e)
        {
            automataPDA.ClearTransitions();
            automataPDA.currentStack = automataPDA.stack;

            lbAccepted.Text = automataPDA.PDATraversal(automataPDA.StateList[0], tBString.Text).ToString();
        }
    }
}

public static class RichTextBoxExtensions
{
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;

        box.SelectionColor = color;
        box.AppendText(text);
        box.SelectionColor = box.ForeColor;
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    class Parser
    {
        string fileCodeNDFA;
        public string FileCodeNDFA
        {
            get { return fileCodeNDFA; }
            set { fileCodeNDFA = value; }
        }

        List<Token> strippedTokenList = new List<Token>();
        public List<Token> StrippedTokenList
        {
            get { return strippedTokenList; }
            set { strippedTokenList = value; }
        }

        int currentId = 0;

        /// <summary>
        /// Parses the file with format for finite automata
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Automaton ParseFiniteAutomata(string path)
        {
            List<State> stateList = new List<State>();
            List<Transition> transList = new List<Transition>();
            List<string> alphabet = new List<string>();

            Automaton automata = new Automaton(stateList, alphabet, transList);

            string[] lines = File.ReadAllLines(path);

            int count = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);

                if (CheckContains(line, "alphabet"))
                {
                    foreach (string item in StripValues(line, 1))
                    {
                        foreach (char val in item)
                        {
                            alphabet.Add(val.ToString());
                        }
                    }
                    automata.Alphabet = alphabet;
                }
                else if (CheckContains(line, "state"))
                {
                    foreach (var item in StripValues(line, 2))
                    {
                        stateList.Add(new State(item));
                    }
                    automata.StateList = stateList;
                }
                else if (CheckContains(line, "final"))
                {
                    List<string> temp = StripValues(line, 3)[0].Split(',').ToList();


                    foreach (var item in temp)
                    {
                        // item = item.TrimEnd();
                        automata.FindState(item).IsFinal = true;
                    }
                }
                else if (CheckContains(line, "transition") && !CheckContains(line, "#"))
                {
                    List<string> temp = lines.Skip(count + 1).ToList();
                    automata.TransitionList = ParseTransitions(temp, automata);
                }
                else if (line == "end.")
                {
                    //Finished with transitions
                }
                else if (CheckContains(line, "dfa:"))
                {
                    if (StripValues(line, 5)[1] == "y")
                    {
                        automata.Dfa = true;
                    }
                    else
                    {
                        automata.Dfa = false;
                    }

                }
                else if (CheckContains(line, "finite:"))
                {
                    if (StripValues(line, 5)[1] == "y")
                    {
                        automata.Finite = true;
                    }
                    else
                    {
                        automata.Finite = false;
                    }
                }
                else if (CheckContains(line, "words:"))
                {
                    List<string> temp = lines.Skip(count + 1).ToList();
                    automata.Words = ParseWords(temp, automata);
                }

                count++;
            }

            //automata.AssignTransitions();
            //automata.AssignGraphViz();

            return automata;
        }

        /// <summary>
        /// Method to parse the transition, needs access to automaton to be able to find the states
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="automaton"></param>
        /// <returns></returns>
        private List<Transition> ParseTransitions(List<string> lines, Automaton automaton)
        {
            List<Transition> temp = new List<Transition>();
            foreach (var item in lines)
            {
                if (item == "")
                {
                    continue;
                }
                if (item == "end.")
                {
                    break;
                }
                List<string> info = new List<string>();
                info = StripValues(item, 4);

                temp.Add(new Transition(automaton.FindState(info[0]), automaton.FindState(info[2]), info[1][0]));
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="automaton"></param>
        /// <returns></returns>
        private List<Word> ParseWords(List<string> lines, Automaton automaton)
        {
            List<Word> temp = new List<Word>();
            foreach (var item in lines)
            {
                if (item == "end.")
                {
                    break;
                }
                string val = item.Split(',')[0];
                string ac = item.Split(',')[1];
                bool temp1;
                if (ac == "n")
                {
                    temp1 = false;
                }
                else
                {
                    temp1 = true;
                }

                temp.Add(new Word(val, temp1));
            }

            return temp;
        }


        /// <summary>
        /// Check if the line contains keyword
        /// </summary>
        /// <param name="line"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        private bool CheckContains(string line, string keyWord)
        {
            if (line.Contains(keyWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Strips the values based on what it is reading, alphabet, states, ect
        /// Returns list of values
        /// </summary>
        /// <param name="line"></param>
        /// <param name="delimiterID"></param>
        /// <returns></returns>
        private List<string> StripValues(string line, int delimiterID)
        {
            List<string> words = new List<string>();

            switch (delimiterID)
            {
                case 1://alphabet
                    words = line.Split(new string[] { "alphabet: " }, StringSplitOptions.None).ToList();
                    words = words.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    return words;
                case 2://State
                    words = line.Split(new string[] { "states: " }, StringSplitOptions.None).ToList();
                    words = words.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    words = words[0].Split(',').ToList();
                    words = words.Select(x => x.Trim()).ToList();
                    return words;
                // return words;
                case 3://Final
                    words = line.Split(new string[] { "final: " }, StringSplitOptions.None).ToList();
                    words = words.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    List<string> temp = new List<string>();
                    foreach (var item in words)
                    {
                        temp.Add(item.TrimEnd());
                    }
                    return temp;
                case 4://Transition
                    words.Add(line.Replace("-->", ","));
                    words = words[0].Split(',').ToList();
                    words = words.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    words = words.Select(c => { c = c.Trim(); return c; }).ToList();
                    return words;
                case 5:
                    words = line.Split(':').ToList();

                    return words;
                default:
                    break;
            }

            return words;
        }

        /// <summary>
        /// Creates the picture
        /// </summary>
        /// <returns></returns>
        public void GeneratePicture(List<State> StateList, List<Transition> TransitionList, string fileName = "")
        {
            if (fileName == "")
            {
                fileName = "abc.png";
            }
            string code = "digraph myAutomaton {\nrankdir = LR;\n\"" + "\" [shape = none]";
            int stateCount = 0;

            foreach (State state in StateList)
            {
                code += "\n" + state.GraphValue;
            }

            foreach (Transition transition in TransitionList)
            {
                if (stateCount == 0)
                {
                    code += "\n" + "\"" + "\"" + " -> " + "\"" + StateList[0].StringValue + "\"";
                }

                code += "\n" + transition.GraphValue;


                stateCount++;
            }

            code += "\n}";

            string saveLocation = @"C:\Program Files (x86)\Graphviz2.38\bin";
            //code = "graph logic {node [ fontname = \"Arial\" ] " + code + "}";

            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotFile.dot");
            File.WriteAllText(file, code);

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WorkingDirectory = Path.GetDirectoryName(saveLocation);
            processInfo.FileName = saveLocation + "\\dot.exe";
            // Console.Write(AppDomain.CurrentDomain.BaseDirectory);
            processInfo.Arguments = "-Tpng -o" + AppDomain.CurrentDomain.BaseDirectory + fileName + " " + file;
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            Process proc = Process.Start(processInfo);
            proc.WaitForExit();
        }

        private Automaton ParseLetter(Automaton automaton, char c, int stateIndex, int transIndex)
        {
            if (automaton.ConnectingStates.Count == 0)
            {
                return automaton;
            }
            automaton.Alphabet.Add(c.ToString());

            State s1 = automaton.GetStateByParam(transIndex, false); //gets null here need to check that out because transindex aka transition is 2 instead of 1 but those should be two in the fgirst place
            State s2 = automaton.GetStateByParam(transIndex, true);
            if (s1 == null || s2 == null)
            {
                return automaton;
            }

            s1.IsFinal = false;
            Transition trans = new Transition(s1, s2, c);

            trans.InitialState.OutTrans.Add(trans);
            trans.EndState.InTrans.Add(trans);

            automaton.ConnectingStates.Remove(s1);
            automaton.ConnectingStates.Remove(s2);

            automaton.TransitionList.Add(trans);

            return automaton;
        }
        private Automaton ParseOr(Automaton automaton, int stateIndex, int transIndex, bool leftRight)
        {
            List<State> tempStateList = new List<State>();

            if (transIndex == 0)
            {

                for (int i = stateIndex; i < stateIndex + 6; i++)
                {
                    /*
                        0 = init = 0
                        1 = left = 1
                        2 = right = 1
                        3 = left = 1
                        4 = right = 1
                        5 = final = 0
                    */
                    State tempState = new State(i.ToString(), i);
                    tempStateList.Add(tempState);
                    if (tempStateList.Count == 1 || tempStateList.Count == 4 || tempStateList.Count == 5)
                    {
                        tempStateList.Last().IsStart = true;

                    }
                    else
                    {
                        tempStateList.Last().IsFinal = true;
                    }

                    if (tempStateList.Count == 2 || tempStateList.Count == 3 || tempStateList.Count == 4 || tempStateList.Count == 5)
                    {
                        tempStateList.Last().TransIndex = transIndex + 1;
                    }
                    else
                    {
                        tempStateList.Last().TransIndex = transIndex;
                    }

                }

                automaton.StateList.AddRange(tempStateList);
                automaton.TransitionList.Add(new Transition(tempStateList[0], tempStateList[1], '_'));
                automaton.ConnectingStates.Add(tempStateList[1]);
                automaton.TransitionList.Add(new Transition(tempStateList[0], tempStateList[2], '_'));
                automaton.ConnectingStates.Add(tempStateList[2]);
                automaton.TransitionList.Add(new Transition(tempStateList[3], tempStateList[5], '_'));
                automaton.ConnectingStates.Add(tempStateList[3]);
                automaton.TransitionList.Add(new Transition(tempStateList[4], tempStateList[5], '_'));
                automaton.ConnectingStates.Add(tempStateList[4]);

            }
            else
            {
                for (int i = stateIndex + 1; i < stateIndex + 5; i++)
                {
                    State tempState = new State(i.ToString(), i);
                    tempStateList.Add(tempState);

                    //tempStateList.Last().IsFinal = true;

                    if (tempStateList.Count == 1 || tempStateList.Count == 2)
                    {
                        tempStateList.Last().IsFinal = true;

                    }
                    else
                    {
                        tempStateList.Last().IsStart = true;
                    }

                    tempStateList.Last().TransIndex = transIndex + 1;
                }

                if (automaton.ConnectingStates.Count == 0)
                {
                    return automaton;
                }

                int xyz = 0;

                if (leftRight)
                {
                    xyz = 1;
                }
                else
                {
                    xyz = 2;
                }

                automaton.StateList.AddRange(tempStateList);
                automaton.ConnectingStates[0].IsFinal = false;
                automaton.TransitionList.Add(new Transition(automaton.ConnectingStates[0], tempStateList[0], '_'));
                //automaton.ConnectingStates.Add(tempStateList[0]);

                automaton.TransitionList.Add(new Transition(automaton.ConnectingStates[0], tempStateList[1], '_'));
                //automaton.ConnectingStates.Add(tempStateList[1]);



                automaton.TransitionList.Add(new Transition(tempStateList[2], automaton.ConnectingStates[xyz], '_'));
                // automaton.ConnectingStates.Add(tempStateList[2]);

                automaton.TransitionList.Add(new Transition(tempStateList[3], automaton.ConnectingStates[xyz], '_'));
                //automaton.ConnectingStates.Add(tempStateList[3]);

                if (leftRight)
                {
                    automaton.ConnectingStates.Remove(automaton.ConnectingStates[0]);
                    automaton.ConnectingStates.Remove(automaton.ConnectingStates[0]);
                }
                else
                {
                    automaton.ConnectingStates.Remove(automaton.ConnectingStates[2]);
                    automaton.ConnectingStates.Remove(automaton.ConnectingStates[0]);
                }

                automaton.ConnectingStates.AddRange(tempStateList);



            }

            return automaton;
        }

        private string GetString(string expression, int index)
        {
            var aStringBuilder = new StringBuilder(expression);
            aStringBuilder.Remove(0, index);
            expression = aStringBuilder.ToString();
            return expression;
        }

        static int GetMatchingBracket(string input)
        {
            int output = 0;
            Stack<int> openingBraces = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openingBraces.Push(i);
                }
                else if (input[i] == ')')
                {
                    if (openingBraces.Count == 1)
                    {
                        return i;
                    }
                    else
                    {
                        openingBraces.Pop();
                    }
                }
            }

            return output;
        }

        private Automaton AddSubAutomata(Automaton original, Automaton subAutomata, State initial, State End)
        {
            if (subAutomata.TransitionList.Count == 1)
            {
                //subAutomata.TransitionList.Last().InitialState = original.StateList[0];
                //subAutomata.TransitionList.Last().EndState = original.StateList[1];
                original.TransitionList.Add(subAutomata.TransitionList.Last());
            }
            else//Multiple ones
            {

                //int lastId = original.GetLastStateId();

                //foreach (State item in subAutomata.StateList)
                //{

                //}

                //foreach (var item in subAutomata.StateList)
                //{
                //    lastId += 1;
                //    item.Id = lastId;
                //    item.StringValue = lastId.ToString();
                //}


                original.StateList.AddRange(subAutomata.StateList);
                original.TransitionList.AddRange(subAutomata.TransitionList);

                //original.TransitionList.Add(subAutomata.TransitionList.First());
            }


            return original;
        }
        public int stateCount = 0;

        public Automaton ParseTreeToAutomata(Node node, Automaton automata, State initial = null, State final = null)
        {
            Automaton subAutomaton = new Automaton(null, null, null);
            Automaton tempAutomata = new Automaton(new List<State>(), new List<string>(), new List<Transition>());
            //State initial = new State(automata.GetLastStateId().ToString(), automata.GetLastStateId());
            if (initial == null)
            {
                initial = new State(stateCount.ToString(), stateCount);
                stateCount++;
                //tempAutomata.StateList.Add(initial);
            }


            initial.IsStart = true;
            tempAutomata.StateList.Add(initial);
            if (final != null)
            {
                tempAutomata.StateList.Add(final);
            }

            if (node.Token is OrToken)
            {
                State start1 = new State(stateCount.ToString(), stateCount);
                tempAutomata.StateList.Add(start1);
                stateCount++;

                State end1 = new State(stateCount.ToString(), stateCount);
                stateCount++;
                tempAutomata.StateList.Add(end1);


                if (final == null)
                {
                    tempAutomata.StateList.Add(end1);
                    subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, start1, end1);
                }
                else
                {
                    subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, start1, end1);
                }

                node.Children.RemoveAt(0);
                tempAutomata = AddSubAutomata(tempAutomata, subAutomaton, start1, end1);

                tempAutomata.TransitionList.Add(new Transition(initial, start1, '_'));

                State start2 = new State(stateCount.ToString(), stateCount);
                tempAutomata.StateList.Add(start2);
                tempAutomata.TransitionList.Add(new Transition(initial, start2, '_'));
                stateCount++;
                State end2 = new State(stateCount.ToString(), stateCount);
                stateCount++;
                tempAutomata.StateList.Add(end2);
                if (final == null)
                {
                    State finalOPState = new State(stateCount.ToString(), stateCount);
                    stateCount++;
                    finalOPState.IsFinal = true;
                    tempAutomata.StateList.Add(finalOPState);
                    tempAutomata.TransitionList.Add(new Transition(end1, finalOPState, '_'));
                    tempAutomata.TransitionList.Add(new Transition(end2, finalOPState, '_'));
                }
                else
                {
                    tempAutomata.TransitionList.Add(new Transition(end1, final, '_'));
                    tempAutomata.TransitionList.Add(new Transition(end2, final, '_'));
                }

                subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, start2, end2);

                tempAutomata = AddSubAutomata(tempAutomata, subAutomaton, start2, end2);

            }

            if (node.Token is RepetitionToken)
            {

                State start1 = new State(stateCount.ToString(), stateCount);
                stateCount++;
                State end1 = new State(stateCount.ToString(), stateCount);
                stateCount++;
                tempAutomata.StateList.Add(start1);
                tempAutomata.StateList.Add(end1);

                if (final == null)
                {
                    State tempFinal = new State(stateCount.ToString(), stateCount);
                    stateCount++;
                    final = tempFinal;
                }
                tempAutomata.StateList.Add(final);

                tempAutomata.TransitionList.Add(new Transition(initial, start1, '_'));
                tempAutomata.TransitionList.Add(new Transition(initial, final, '_'));
                tempAutomata.TransitionList.Add(new Transition(end1, start1, '_'));
                tempAutomata.TransitionList.Add(new Transition(end1, final, '_'));

                subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, start1, end1);

                tempAutomata = AddSubAutomata(tempAutomata, subAutomaton, start1, end1);

            }

            if (node.Token is AndToken)
            {
                State middle = new State(stateCount.ToString(), stateCount);
                stateCount++;
                tempAutomata.StateList.Add(middle);

                if (initial == null)
                {

                }
                else
                {
                    subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, initial, middle);
                    tempAutomata = AddSubAutomata(tempAutomata, subAutomaton, initial, middle);

                }
                // Automaton subAutomaton = new Automaton(null, null, null);
                node.Children.RemoveAt(0);
                if (final == null)
                {
                    final = new State(stateCount.ToString(), stateCount);
                    stateCount++;
                    tempAutomata.StateList.Add(final);

                    subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, middle, final);
                    //tempAutomata = AddSubAutomata(tempAutomata, subAutomaton, middle, final);

                }
                else
                {
                    subAutomaton = ParseTreeToAutomata(node.Children.First(), tempAutomata, middle, final);

                }
                tempAutomata = AddSubAutomata(tempAutomata, subAutomaton, middle, final);

            }

            if (node.Token is VariableToken)
            {
                if (final == null)
                {
                    final = new State(tempAutomata.GetLastStateId().ToString(), tempAutomata.GetLastStateId());
                    tempAutomata.StateList.Add(final);
                }

                tempAutomata.TransitionList.Add(new Transition(initial, final, node.Token.ToString()[0]));
            }

            return tempAutomata;
        }




        public void SaveNDFAToFile(Automaton auto)
        {
            fileCodeNDFA = string.Empty;
            fileCodeNDFA += "alphabet: ";
            foreach (string letter in auto.Alphabet)
            {
                fileCodeNDFA += letter;
            }
            fileCodeNDFA = fileCodeNDFA.Remove(fileCodeNDFA.Length - 1);
            fileCodeNDFA += "\nstates: ";
            foreach (State item in auto.StateList)
            {
                fileCodeNDFA += item.StringValue + ",";
            }
            fileCodeNDFA = fileCodeNDFA.Remove(fileCodeNDFA.Length - 1);

            fileCodeNDFA += "\nfinal: ";

            foreach (State state in auto.StateList)
            {
                if (state.IsFinal)
                {
                    fileCodeNDFA += state.StringValue + ",";
                }

            }
            fileCodeNDFA = fileCodeNDFA.Remove(fileCodeNDFA.Length - 1);

            fileCodeNDFA += "\ntransitions:\n";
            foreach (Transition item in auto.TransitionList)
            {
                fileCodeNDFA += item.InitialState.StringValue + "," + item.TransitionChar.ToString() + " --> " + item.EndState.StringValue + "\n";
            }
            fileCodeNDFA += "end.";


            File.WriteAllText(@"..\..\Files\ndfaFile.txt", fileCodeNDFA);
        }



        public Node ParseTree(int temp = 0)
        {
            int nodeNumber = temp;
            Token SourceToken = StrippedTokenList[0];
            StrippedTokenList.RemoveAt(0);

            List<Node> nodes = new List<Node>();

            while (strippedTokenList.Count != 0)
            {
                if (StrippedTokenList[0] is Operand)
                {
                    nodes.Add(ParseTree(nodeNumber));
                }
                else if (StrippedTokenList[0] is VariableToken)
                {
                    nodes.Add(new Node(StrippedTokenList[0], nodeNumber));
                    nodeNumber++;
                    StrippedTokenList.RemoveAt(0);
                }

                if (nodes.Count == 2 || (nodes.Count == 1 && SourceToken is RepetitionToken))
                {
                    break;
                }

            }

            Node tempNode = new Node(SourceToken, nodeNumber);
            nodeNumber++;

            tempNode.Children = nodes;

            return tempNode;
        }



    }
}

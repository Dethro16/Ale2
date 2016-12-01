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
                        automata.FindState(item).IsFinal = true;
                    }
                }
                else if (CheckContains(line, "transition"))
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

            automata.AssignTransitions();
            automata.AssignGraphViz();

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
                    return words;
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
        public void GeneratePicture(List<State> StateList, List<Transition> TransitionList)
        {
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
            processInfo.WorkingDirectory = Path.GetDirectoryName(saveLocation + "\\dot.exe");
            processInfo.FileName = saveLocation + "\\dot.exe";
            Console.Write(AppDomain.CurrentDomain.BaseDirectory);
            processInfo.Arguments = "-Tpng -o" + AppDomain.CurrentDomain.BaseDirectory + "abc.png " + file;
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            Process proc = Process.Start(processInfo);
            proc.WaitForExit();
        }

        private void GetSubExpression(Stack<char> input)
        {

        }

        public void tryingShit(string input, int stateIndex = 0)
        {
            Stack<char> temp = new Stack<char>(input.Reverse());
            int openBracket = 0;
            while (temp.Count > 0)
            {
                char c = temp.Pop();

                if (Char.IsLetter(c))
                {
                    State s1 = new State(stateIndex.ToString());
                    State s2 = new State(stateIndex.ToString());
                    Transition t1 = new Transition(s1, s2, c);
                }
                if (c == '(')
                {
                    openBracket += 1;
                }
                if (c == ')')
                {
                    openBracket -= 1;
                }

                if (c == '|')
                {

                }
                if (c == '.')
                {

                }
            }


        }


        //public void CreateNFA(string input)
        //{
        //    Queue<State> q = new Queue<State>();
        //    Stack<State> st = new Stack<State>();

        //    Queue<Transition> outputQueue = new Queue<Transition>();
        //    List<State> stateList = new List<State>();

        //    int stateIndex = 0;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        char check = input[i];
        //        if (Char.IsLetter(check))
        //        {
        //            State S1 = new State(stateIndex.ToString());
        //            S1.CurrentTransitionIndex = i;
        //            stateIndex += 1;

        //            State S2 = new State(stateIndex.ToString());
        //            S2.CurrentTransitionIndex = i;
        //            stateIndex += 1;

        //            stateList.Add(S1);
        //            stateList.Add(S2);

        //            outputQueue.Enqueue(new Transition(S1, S2, check));
        //        }
        //        else if (check == '*')//Epsilon transition
        //        {

        //        }
        //        else if (check == '|')
        //        {

        //        }
        //        else if (check == '.')
        //        {

        //        }
        //        else if (check == ',')
        //        {

        //        }
        //        else if (check == '(')
        //        {

        //        }
        //        else if (check == ')')
        //        {

        //        }
        //    }
        //}

        //public void ParseMe(string input)
        //{
        //    List<Automaton> temp = new List<Automaton>();

        //    while (ParseTest(input, temp) != null)
        //    {
        //        //temp.Add(ParseTest(input, temp));
        //    }
        //}
        //public List<Automaton> ParseTest(string input, List<Automaton> auto, int i = 0, int stateIndex = 0)
        //{
        //    Automaton temp = new Automaton(new List<State>(), new List<string>(), new List<Transition>());

        //    for (; i < input.Length; i++)
        //    {
        //        char c = input[i];

        //        if (c == '(')
        //        {

        //        }
        //        if (c == '.')
        //        {
        //            auto = ParseTest(input, auto, i+1);
        //        }
        //        if (Char.IsLetter(c))
        //        {
        //            State S1 = new State(stateIndex.ToString());
        //            stateIndex += 1;
        //            State S2 = new State(stateIndex.ToString());
        //            stateIndex += 1;

        //            temp.StateList.Add(S1);
        //            temp.StateList.Add(S2);

        //            Transition T1 = new Transition(S1, S2, c);
        //            temp.TransitionList.Add(T1);
        //            auto.Add(temp);

        //            auto.AddRange(ParseTest(input, auto, i+1, stateIndex));
        //        }
        //    }

        //    return auto;

        //}




        //private State CreateState(char c, int index)
        //{
        //    if (Char.IsLetter(c))
        //    {
        //        //return new Transition(null, null, c);
        //    }

        //    switch (c)
        //    {
        //        case '_':
        //            break;
        //        case '|':
        //            break;
        //        case '*':
        //            break;
        //        case '.':
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public Automaton TreeToNDFA()
        //{

        //    return null;
        //}

        //public void KleeneState()
        //{

        //}

        //public void ParseRegExToNode(string input)
        //{
        //    Tokenizer t = new Tokenizer();
        //    List<Token> tokenList = t.Scan(input);
        //    ToNode(tokenList);
        //    //InfixToPrefix(tokenList);
        //}

        //public void InfixToPrefix(List<Token> input)
        //{
        //    Stack<Token> tokenStack = new Stack<Token>();
        //    List<Token> end = new List<Token>();
        //    int index = 0;
        //    while (input.Count > 0)
        //    {
        //        Token check = input[index];
        //        if (check is VariableToken)
        //        {
        //            tokenStack.Push(check);
        //        }
        //        if (check is OpenParenthesis)
        //        {
        //            tokenStack.Push(check);
        //        }
        //        if (check is Operand)
        //        {
        //            while (tokenStack.Count > 0)
        //            {
        //                end.Add(tokenStack.Pop());
        //            }
        //        }
        //        else if (check is ClosedParenthesis)
        //        {
        //            while (tokenStack.Last().GetType() != typeof(OpenParenthesis))
        //            {
        //                end.Add(tokenStack.Pop());
        //            }
        //        }
        //        index += 1;
        //    }
        //}

        //private List<State> OrNode(int stateIndex)
        //{
        //    return null;
        //}
        //private Token GetNextGood(Stack<Token> stt)
        //{
        //    while (stt.Count > 0)
        //    {
        //        Token st = stt.Pop();

        //        if (st is VariableToken)
        //        {

        //        }
        //    }
        //}
        //private void ToNode(List<Token> tokenList)
        //{
        //    tokenList.Reverse();
        //    Stack<Token> stt = new Stack<Token>(tokenList);
        //    List<State> stateList = new List<State>();
        //    List<Transition> transitionList = new List<Transition>();
        //    int stateIndex = 0;
        //    int i = 0;
        //    while (tokenList.Count > 0)
        //    {
        //        Token t = stt.Pop();
        //        if (t is VariableToken)
        //        {
        //            State S1 = new State(stateIndex.ToString());
        //            S1.CurrentTransitionIndex = i;
        //            stateIndex += 1;

        //            State S2 = new State(stateIndex.ToString());
        //            S2.CurrentTransitionIndex = i;
        //            stateIndex += 1;

        //            Transition trans = new Transition(S1, S2, t.ToString().ToCharArray()[0]);
        //            S1.OutTrans.Add(trans);
        //            S2.InTrans.Add(trans);
        //            stateList.Add(S1);
        //            stateList.Add(S2);
        //            transitionList.Add(trans);

        //        }
        //        else if (t is RepetitionToken)
        //        {

        //        }
        //        else if (t is AndToken)
        //        {

        //        }

        //        else if (t is OrToken)
        //        {
        //            stateList.AddRange(OrNode(stateIndex));
        //        }
        //        else if (t is EpsilonToken)
        //        {

        //        }
        //        i += 1;
        //    }
        //}

        //public void ParseRegularExpression(string input)
        //{
        //    //Shunting yard algorithm to produce AST
        //    Queue<State> q = new Queue<State>();
        //    Stack<State> st = new Stack<State>();

        //    Queue<Transition> outputQueue = new Queue<Transition>();
        //    // q.Enqueue(CreateState(input[0], 0));
        //    int stateIndex = 0;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        char check = input[i];
        //        if (Char.IsLetter(check))
        //        {
        //            State S1 = new State(stateIndex.ToString());
        //            S1.CurrentTransitionIndex = i;
        //            stateIndex += 1;

        //            State S2 = new State(stateIndex.ToString());
        //            S2.CurrentTransitionIndex = i;
        //            stateIndex += 1;

        //            outputQueue.Enqueue(new Transition(S1, S2, check));
        //        }
        //        else if (check == '*')//Epsilon transition
        //        {

        //        }
        //        else if (check == '|')
        //        {

        //        }
        //        else if (check == '.')
        //        {

        //        }
        //        else if (check == ',')
        //        {

        //        }
        //        else if (check == '(')
        //        {

        //        }
        //        else if (check == ')')
        //        {

        //        }
        //    }
        //    //Check first token
        //    //If token is letter push it to the outputQueue
        //    //if token is function token push on stack
        //    //if token is , 
        //    //until the token at the top of the stack is a left parenthesis pop operators off the stack onto the output queue
        //    //if token is operator  while there is an operator token 

        //    while (q.Count > 0)
        //    {

        //    }
        //}

    }
}

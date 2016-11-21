using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    class Automaton
    {
        List<State> stateList;
        List<string> alphabet;
        List<Transition> transitionList;

        bool dfa;
        bool finite;
        List<Word> words = new List<Word>();

        /// <summary>
        /// Contains all states
        /// </summary>
        public bool Dfa
        {
            get { return dfa; }
            set { dfa = value; }
        }

        /// <summary>
        /// Contains all states
        /// </summary>
        public bool Finite
        {
            get { return finite; }
            set { finite = value; }
        }

        /// <summary>
        /// Contains all states
        /// </summary>
        public List<Word> Words
        {
            get { return words; }
            set { words = value; }
        }

        /// <summary>
        /// Contains all states
        /// </summary>
        public List<State> StateList
        {
            get { return stateList; }
            set { stateList = value; }
        }

        /// <summary>
        /// Contains the alphabet
        /// </summary>
        public List<string> Alphabet
        {
            get { return alphabet; }
            set { alphabet = value; }
        }

        /// <summary>
        /// Contains all transitions
        /// </summary>
        public List<Transition> TransitionList
        {
            get { return transitionList; }
            set { transitionList = value; }
        }

        public Automaton(List<State> _stateList, List<string> _alphabet, List<Transition> _transitionList)
        {
            stateList = _stateList;
            alphabet = _alphabet;
            transitionList = _transitionList;
        }

        /// <summary>
        /// Loops through all states to find a matching name
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public State FindState(string stateName)
        {
            foreach (var item in StateList)
            {
                if (item.StringValue == stateName)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns all final states
        /// </summary>
        /// <returns></returns>
        public List<State> GetFinalStates()
        {
            List<State> temp = new List<State>();

            foreach (State item in StateList)
            {
                if (item.IsFinal)
                {
                    temp.Add(item);
                }
            }

            return temp;
        }

        /// <summary>
        /// Assigns all transitions to their states
        /// </summary>
        public void AssignTransitions()
        {
            foreach (State state in StateList)
            {
                foreach (Transition transition in TransitionList)
                {
                    if (state.StringValue == transition.InitialState.StringValue)
                    {
                        state.OutTrans.Add(transition);
                    }

                    if (state.StringValue == transition.EndState.StringValue)
                    {
                        state.InTrans.Add(transition);
                    }
                }

            }
        }

        /// <summary>
        /// Assigns all graphviz values
        /// </summary>
        public void AssignGraphViz()
        {
            foreach (State state in StateList)
            {
                if (state.IsFinal)
                {
                    state.GraphValue = "\"" + state.StringValue + "\"" + " [shape = doublecircle]";
                }
                else
                {
                    state.GraphValue = "\"" + state.StringValue + "\"" + " [shape = circle]";
                }
            }

            foreach (Transition transition in TransitionList)
            {
                transition.GraphValue = "\"" + transition.InitialState.StringValue + "\"" + " -> " + "\"" + transition.EndState.StringValue + "\"" + "[label=\"" + transition.TransitionChar + "\"]";
            }

        }

        /// <summary>
        /// Checks if the graph is a DFA
        /// </summary>
        /// <returns></returns>
        public bool CheckDFA()
        {
            foreach (State state in StateList)
            {
                if (!state.CheckTransitions(Alphabet))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearStates()
        {
            foreach (State state in StateList)
            {
                state.CurrentTransitionIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool BFSTraversal(State state, string input)
        {
            if (input == "")
            {
                input = "_";
            }
            Queue<State> q = new Queue<State>();
            q.Enqueue(state);

            int index = 0;
            while (q.Count > 0)
            {
                state = q.Dequeue();
                index = state.CurrentTransitionIndex;
                if (index == input.Length)
                {
                    if (state.IsFinal)
                    {
                        return true;
                    }
                    else if (!(state.OutTrans.Count > 0))
                    {
                        continue;
                    }
                }

                if (state.OutTrans.Count > 0)
                {
                    int index12 = 0;
                    foreach (Transition item in state.OutTrans)
                    {
                        if (state.CurrentTransitionIndex != input.Length && (item.CanTravel(input[index])))
                        {
                            index12++;
                            item.id = index;
                            if (item.TransitionChar == '_')
                            {
                                item.EndState.CurrentTransitionIndex = index;
                            }
                            else
                            {
                                item.EndState.CurrentTransitionIndex = index + 1;
                            }
                            q.Enqueue(item.EndState);
                        }
                        else if (item.TransitionChar == '_')
                        {
                            index12++;
                            item.id = index;
                            item.EndState.CurrentTransitionIndex = index;
                            q.Enqueue(item.EndState);
                        }
                        if (input == "_" && state.IsFinal)
                        {
                            return true;
                        }
                        if (state.IsFinal && state.CurrentTransitionIndex == input.Length)
                        {
                            return true;
                        }
                    }
                }
                else if (state.IsFinal && index == input.Length)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Creates the picture
        /// </summary>
        /// <returns></returns>
        public void GeneratePicture()
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

            string file = Path.Combine(saveLocation, "dotFile.dot");
            File.WriteAllText(file, code);

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WorkingDirectory = Path.GetDirectoryName(saveLocation + "\\dot.exe");
            processInfo.FileName = saveLocation + "\\dot.exe";
            processInfo.Arguments = "-Tpng -oabc.png dotFile.dot";
            processInfo.ErrorDialog = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            Process proc = Process.Start(processInfo);
            proc.WaitForExit();
        }

    }
}

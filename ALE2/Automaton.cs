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
        State startState;
        List<State> stateList;
        List<string> alphabet;
        List<Transition> transitionList;
        public List<State> ConnectingStates = new List<State>();

        bool dfa;
        bool finite;
        List<Word> words = new List<Word>();

        public List<State> currentStates = new List<State>();

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
        public State StartState
        {
            get { return startState; }
            set { startState = value; }
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

        public List<State> GetStartStates()
        {
            List<State> temp = new List<State>();

            foreach (State item in StateList)
            {
                if (item.IsStart)
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

        public void CheckForEmptyFinal()
        {

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

        public int GetLastStateId()
        {
            try
            {
                var item = StateList.Max(x => x.Id);
                return item;
            }
            catch (Exception)
            {
                return 0;
            }
            //return -1;

        }

        public State GetStateByParam(int transitionIndex, bool isStartFinal)
        {
            List<State> tempStates = ConnectingStates.Where(p => p.TransIndex == transitionIndex).ToList();

            //tempStates = tempStates.Where(p => tempStates.Any(l => p.TransIndex == transitionIndex)).ToList();

            //tempStates = tempStates.Where(e => transitionIndex);

            foreach (State state in tempStates)
            {
                if (state.TransIndex == transitionIndex)
                {
                    if (!isStartFinal && state.IsStart == isStartFinal)
                    {
                        State tempe = StateList.Find(x => x == state);
                        tempe.IsFinal = false;
                        return state;
                    }

                    else if (isStartFinal && state.IsStart == isStartFinal)
                    {
                        State tempe = StateList.Find(x => x == state);
                        tempe.IsStart = false;
                        return state;
                    }
                }
            }
            return null;
        }

        public State GetFinalStateByIndex(int i)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                default:
                    break;
            }
            return null;
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
        /// <returns></returns>
        public string CheckTestDFA()
        {
            if (CheckDFA() == Dfa)
            {
                return "DFA: " + Dfa + " V";
            }
            else
            {
                return "DFA: " + Dfa + " X";
            }
        }

        public List<string> CheckTestWords()
        {
            List<string> checkedWords = new List<string>();
            for (int i = 0; i < Words.Count; i++)
            {
                bool temp = BFSTraversal(StateList[0], Words[i].StringValue);
                ClearStates();
                if (Words[i].Accepted == temp)
                {
                    checkedWords.Add("Word-" + i + ": " + Words[i].StringValue + " " + Words[i].Accepted + ": V");
                }
                else
                {
                    checkedWords.Add("Word-" + i + ": " + Words[i].StringValue + " " + Words[i].Accepted + ": X");
                }
                Words[i].IsAccepted = temp;
            }

            return checkedWords;
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
                    foreach (Transition item in state.OutTrans)
                    {
                        if (state.CurrentTransitionIndex != input.Length && (item.CanTravel(input[index])))
                        {
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

    }
}

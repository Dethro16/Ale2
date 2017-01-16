using System;
using System.Collections.Generic;
using System.Linq;
namespace ALE2
{
    class Automaton
    {
        State startState;
        List<State> stateList;
        List<string> alphabet;
        List<Transition> transitionList;
        public List<State> ConnectingStates = new List<State>();
        List<State> possibleStateList = new List<State>();
        public string stack = "";
        public string currentStack = "";
        bool dfa;
        bool finite;
        List<Word> words = new List<Word>();
        List<string> testWords = new List<string>();

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
        public List<string> TestWords
        {
            get { return testWords; }
            set { testWords = value; }
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
        /// Contains all states
        /// </summary>
        public List<State> PossibleStateList
        {
            get { return possibleStateList; }
            set { possibleStateList = value; }
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
                    if (transition.TransitionChar != '_')
                    {
                        alphabet.Add(transition.TransitionChar.ToString());
                    }
                    if (state.StringValue == transition.InitialState.StringValue)
                    {
                        state.OutTrans.Add(transition);
                    }
                    if (transition.EndState == null)
                    {
                        continue;
                    }
                    if (state.StringValue == transition.EndState.StringValue)
                    {
                        state.InTrans.Add(transition);
                    }
                }

            }
            var unique = new HashSet<string>(alphabet);
            alphabet.Clear();
            foreach (var s in unique)
            {
                alphabet.Add(s);
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
                if (transition.EndState == null)
                {
                    continue;
                }
                if (transition.pdaValue != "")
                {
                    transition.GraphValue = "\"" + transition.InitialState.StringValue + "\"" + " -> " + "\"" + transition.EndState.StringValue + "\"" + "[label=\"" + transition.pdaValue + "\"]";
                }
                else
                {
                    transition.GraphValue = "\"" + transition.InitialState.StringValue + "\"" + " -> " + "\"" + transition.EndState.StringValue + "\"" + "[label=\"" + transition.TransitionChar + "\"]";
                }
            }

        }


        public void AssignStates()
        {
            foreach (State state in StateList)
            {
                if (state.OutTrans.Count == 0) //Final
                {
                    state.IsStart = false;
                    state.IsFinal = true;
                }

                if (state.InTrans.Count == 0)
                {
                    state.IsStart = true;
                    state.IsFinal = false;
                }
            }
        }


        public int GetLastStateId()
        {
            try
            {
                var item = StateList.Max(x => x.Id);
                return item + 1;
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
        public bool CheckTestDFA()
        {
            if (CheckDFA() == Dfa)
            {
                //return "DFA: " + Dfa + " V";
                return true;
            }
            else
            {
                return false;
                // return "DFA: " + Dfa + " X";
            }
        }

        public void ClearTransitions()
        {
            foreach (Transition trans in TransitionList)
            {
                trans.HasTravelled = false;
                trans.currentPriority = 5;
            }
        }

        public List<string> CheckTestWords()
        {
            List<string> checkedWords = new List<string>();
            List<string> result = new List<string>();
            for (int i = 0; i < Words.Count; i++)
            {
                bool temp = BFSTraversal(StateList[0], Words[i].StringValue);
                ClearStates();
                ClearTransitions();
                checkedWords.Add("Word-" + i + ": " + Words[i].StringValue);

                if (Words[i].Accepted == temp)
                {
                    testWords.Add(Words[i].Accepted + ": V");
                }
                else
                {
                    testWords.Add(Words[i].Accepted + ": X");
                }

                Words[i].IsAccepted = temp;
                ClearTransitions();
            }

            //testWords;
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

                        if (item.TransitionChar == '_' && item.InitialState == item.EndState)
                        {

                        }
                        else
                        {

                            if (state.CurrentTransitionIndex != input.Length && (item.CanTravel(input[index])))
                            {
                                item.id = index;
                                if (item.TransitionChar == '_' && !item.HasTravelled)
                                {
                                    item.EndState.CurrentTransitionIndex = index;
                                    item.HasTravelled = true;
                                    q.Enqueue(item.EndState);
                                }
                                else
                                {
                                    State tempState = new State(item.EndState.StringValue, item.EndState.Id);
                                    tempState.OutTrans = item.EndState.OutTrans;
                                    tempState.InTrans = item.EndState.InTrans;
                                    tempState.IsFinal = item.EndState.IsFinal;
                                    tempState.IsStart = item.EndState.IsStart;
                                    item.HasTravelled = true;
                                    tempState.CurrentTransitionIndex = index + 1;
                                    q.Enqueue(tempState);
                                    //item.EndState.CurrentTransitionIndex = index + 1;
                                }
                                //q.Enqueue(item.EndState);
                            }
                            else if (item.TransitionChar == '_' && !item.HasTravelled)
                            {
                                item.id = index;

                                State tempState = new State(item.EndState.StringValue, item.EndState.Id);
                                tempState.OutTrans = item.EndState.OutTrans;
                                tempState.InTrans = item.EndState.InTrans;
                                tempState.IsFinal = item.EndState.IsFinal;
                                tempState.IsStart = item.EndState.IsStart;
                                tempState.CurrentTransitionIndex = index;

                                item.HasTravelled = true;
                                // item.EndState.CurrentTransitionIndex = index;
                                q.Enqueue(tempState);
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

                    //end of loop
                    state.HasTravelled += 1;
                    if (state.HasTravelled == 1)
                    {
                        foreach (Transition trans in state.OutTrans)
                        {
                            trans.HasTravelled = false;
                        }
                    }

                }
                else if (state.IsFinal && (index == input.Length || input == "_"))
                {
                    return true;
                }

            }
            return false;
        }

        private bool wordExist(string val)
        {
            foreach (Word word in Words)
            {
                if (val == word.StringValue)
                {
                    return true;
                }
            }
            return false;
        }
        List<Transition> hasTravelled = new List<Transition>();
        public bool CheckAllWords(State currState, string currWord)
        {
            List<string> temp = new List<string>();

            foreach (Transition trans in currState.OutTrans)
            {
                if (hasTravelled.Contains(trans))
                {
                    // isfi
                    return false;
                }
                if (trans.TransitionChar != '_')
                {
                    currWord += trans.TransitionChar;
                }
                trans.HasTravelled = true;
                hasTravelled.Add(trans);
                if (CheckAllWords(trans.EndState, currWord))
                {
                    if (currWord == "d")
                    {

                    }
                    ClearStates();
                    ClearTransitions();
                    if (BFSTraversal(StateList[0], currWord) && (!wordExist(currWord)))
                    {
                        Words.Add(new Word(currWord, true));
                        temp.Add(currWord);
                        hasTravelled.Clear();
                    }

                }
                else
                {
                    return false;
                }



            }

            return true;
        }

        public bool CheckFinite()
        {
            foreach (State state in StateList)
            {
                foreach (Transition trans in state.OutTrans)
                {
                    if (trans.EndState == state)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        private List<State> GetConnectingStates(State state, string letter)
        {
            List<State> connectingStates = new List<State>();

            foreach (char item in state.StringValue)
            {
                foreach (Transition trans in FindState(item.ToString()).OutTrans)
                {
                    if (trans.TransitionChar.ToString() == letter)
                    {
                        connectingStates.Add(trans.EndState);
                    }
                }

            }

            return connectingStates.Distinct().ToList();
        }

        private bool stateExists(State s1, List<State> list)
        {
            foreach (var item in list)
            {
                if (s1.StringValue == item.StringValue)
                {
                    return true;
                }
            }
            return false;
        }

        public void CleanDuplicates()
        {
            List<State> tempStateList = new List<State>();
            foreach (var item in StateList)
            {
                if (stateExists(item, tempStateList) || item.StringValue == "")
                {
                    continue;
                }
                else
                {
                    tempStateList.Add(item);
                }
            }
            StateList = tempStateList;
        }

        public List<State> stateListDFA = new List<State>();
        public List<Transition> transitionListDFA = new List<Transition>();

        public Automaton SetStateTable(Automaton automata)
        {
            Automaton DFAAutomata = new Automaton(new List<State>(), automata.Alphabet, new List<Transition>());

            List<State> history = new List<State>();
            List<State> final = new List<State>();

            List<State> currentStateList = new List<State>();
            State newState = new State(automata.StateList[0].StringValue);
            currentStateList.Add(newState);
            DFAAutomata.StateList.Add(newState);

            while (currentStateList.Count != 0)
            {
                State currentState = currentStateList[0];
                currentStateList.Remove(currentStateList[0]);
                //Now get possible state
                List<State> possibleStateList = new List<State>();

                if (stateExists(currentState, history))
                {
                    continue;
                }

                foreach (string letter in Alphabet)
                {
                    string tempStateVal = "";
                    foreach (State item in GetConnectingStates(currentState, letter))
                    {
                        tempStateVal += item.StringValue;
                    }

                    possibleStateList.Add(new State(tempStateVal));


                }

                int finalCount = 0;
                for (int i = 0; i < alphabet.Count; i++)
                {
                    if (possibleStateList[i].StringValue == "")
                    {
                        finalCount++;
                        continue;
                    }
                    Transition trans = new Transition(currentState, possibleStateList[i], alphabet[i][0]);
                    DFAAutomata.TransitionList.Add(trans);
                }

                if (finalCount == automata.alphabet.Count)
                {
                    currentState.IsFinal = true;
                }

                //Now check whether this was added to history before
                List<State> newTempList = new List<State>();
                foreach (var item in possibleStateList)
                {
                    if (history.Contains(item))
                    {
                        continue;
                    }
                    DFAAutomata.StateList.Add(item);


                    newTempList.Add(item);


                }
                history.Add(currentState);
                currentStateList.AddRange(newTempList);


            }


            //Now have to classify all finalstates
            DFAAutomata = SetFinalStates(automata, DFAAutomata);

            return DFAAutomata;
        }

        private Automaton SetFinalStates(Automaton automata, Automaton DFAAutomata)
        {
            string stateFinal = "";

            foreach (State item in automata.StateList)
            {
                if (item.IsFinal)
                {
                    stateFinal = item.StringValue;
                }
            }

            foreach (State item in DFAAutomata.StateList)
            {
                if (item.StringValue.Contains(stateFinal))
                {
                    item.IsFinal = true;
                }
            }

            return DFAAutomata;
        }

        public static bool ContainsAllItems(List<State> a, List<State> b)
        {
            return !b.Except(a).Any();
        }

        private List<State> CanTravel(State state, string letter)
        {
            List<State> tempList = new List<State>();
            foreach (Transition trans in state.OutTrans)
            {
                if (trans.TransitionChar.ToString() == letter || trans.TransitionChar == '_')
                {
                    state.PossibleStates.Add(trans.EndState);
                    tempList.Add(trans.EndState);
                }
            }

            return tempList;
        }

        public bool PDATraversal(State state, string input = "_")
        {
            State currentState = state;
            List<Transition> OutTrans = currentState.OutTrans;
            //First check of user input to see if correct
            foreach (char item in input)
            {
                if (!alphabet.Contains(item.ToString()))
                {
                    return false;
                }
            }

            int index = 0;
            while (currentState != null)
            {
                int transIndex = GetPriority(OutTrans, input, currentStack, index);
                if (transIndex == -1)
                {
                    return false;
                }
                Transition tempTrans = OutTrans[transIndex];
                currentState = tempTrans.EndState;
                OutTrans = currentState.OutTrans;
                index++;
                if (tempTrans.TransitionChar == '_')
                {
                    index--;
                }

                if (currentStack == tempTrans.removeFromStack)
                {
                    currentStack = currentStack.Remove(currentStack.Length - 1);
                }

                if (tempTrans.pushToStack != "_")
                {
                    currentStack += tempTrans.pushToStack;
                }

                if (index == input.Length && currentState.IsFinal && currentStack.Length == 0)
                {
                    return true;
                }

            }

            return false;
        }

        private int GetPriority(List<Transition> outTrans, string input, string stack, int index)
        {
            List<Transition> tempTransList = new List<Transition>();
            tempTransList.AddRange(outTrans);
            List<Transition> temp = new List<Transition>();


            string compare = "";

            if (index == input.Length)//at end
            {
                compare = " ";
            }
            else
            {
                compare = input[index].ToString();
            }
            if (currentStack.Length == 0)
            {

            }
            foreach (Transition trans in outTrans)
            {
                if (currentStack.Length != 0 && trans.TransitionChar == compare[0] && trans.removeFromStack == currentStack[currentStack.Length - 1].ToString())
                {
                    trans.currentPriority = 1;
                    temp.Add(trans);
                }
                if (trans.removeFromStack == "_" && trans.TransitionChar == compare[0])
                {
                    trans.currentPriority = 2;
                    temp.Add(trans);
                }
                if (currentStack.Length != 0 && trans.TransitionChar == '_' && trans.removeFromStack == currentStack[currentStack.Length - 1].ToString())
                {
                    trans.currentPriority = 3;
                    temp.Add(trans);
                }
                if (trans.TransitionChar == '_' && trans.removeFromStack == "_")
                {
                    trans.currentPriority = 4;
                    temp.Add(trans);
                }
            }

            int lowestIndex = -1;
            int previousPrio = 5;
            for (int i = 0; i < tempTransList.Count; i++)
            {
                int currentPrio = tempTransList[i].currentPriority;
                if (tempTransList[i].currentPriority < previousPrio)
                {
                    previousPrio = currentPrio;
                    lowestIndex = outTrans.IndexOf(tempTransList[i]);
                }
            }

            return lowestIndex;
        }

    }
}

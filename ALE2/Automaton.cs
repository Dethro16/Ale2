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
        List<State> possibleStateList = new List<State>();

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
                if (transition.EndState == null)
                {
                    continue;
                }
                transition.GraphValue = "\"" + transition.InitialState.StringValue + "\"" + " -> " + "\"" + transition.EndState.StringValue + "\"" + "[label=\"" + transition.TransitionChar + "\"]";
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
                else if (state.IsFinal && index == input.Length)
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

        private List<State> GetMatchingStates(State state, string character)
        {
            List<State> tempList = new List<State>();

            foreach (char item in state.StringValue)
            {
                tempList.AddRange(CanTravel(FindState(item.ToString()), character));

            }
            return tempList.Distinct().ToList();
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
            //currentStateList.Add(new List<State>());
            // currentStateList.Add(automata.StateList[0]);
            // State tempState1 = new State(automata.StateList[0].StringValue);
            // DFAAutomata.StateList.Add(tempState1);

            //List<List<State>> history = new List<List<State>>();

            while (currentStateList.Count != 0)
            {
                State currentState = currentStateList[0];
                //List<State> _currentStateList = currentStateList;
                currentStateList.Remove(currentStateList[0]);
                //Now get possible state
                List<State> possibleStateList = new List<State>();

                if (stateExists(currentState, history))
                {
                    //currentState.Add(currentStateList[0]);
                    //currentStateList.Add()
                    continue;
                }

                //  foreach (State _state in _currentStateList)//This needs to only be 1 state so that the output is always 2 states instead of multiple, over time will have huge output
                //{
                foreach (string letter in Alphabet)
                {
                    string tempStateVal = "";
                    foreach (State item in GetConnectingStates(currentState, letter))
                    {
                        tempStateVal += item.StringValue;
                    }

                    possibleStateList.Add(new State(tempStateVal));


                }



                //  }

                int finalCount = 0;
                for (int i = 0; i < alphabet.Count; i++)
                {
                    if (possibleStateList[i].StringValue == "")
                    {
                        finalCount++;
                        //currentState.IsFinal = true;
                        //Transition transFinal
                        continue;
                    }
                    Transition trans = new Transition(currentState, possibleStateList[i], alphabet[i][0]);
                    DFAAutomata.TransitionList.Add(trans);

                    //Transition trans = new Transition(currentState, possibleStateList[i], alphabet[i][0]);
                    //DFAAutomata.TransitionList.Add(trans);


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
                //DFAAutomata.AssignTransitions();
                //DFAAutomata.AssignStates();
                history.Add(currentState);
                currentStateList.AddRange(newTempList);


            }




            //while (currentStateList.Count != 0)
            //{
            //    List<State> currentStatetempList = currentStateList[0];
            //    currentStateList.Remove(currentStatetempList);
            //    State currentState = new State("");
            //    State tempState = new State(currentState.StringValue);
            //    List<State> tempStateList = new List<State>();
            //    foreach (State tempListItem in currentStatetempList)
            //    {
            //        foreach (string letter in automata.alphabet)
            //        {
            //            string dfaState = "";

            //            foreach (State _state in GetMatchingStates(tempListItem, letter))
            //            {
            //                dfaState += _state.StringValue;
            //            }

            //            //foreach (State __state in CanTravel(tempListItem, letter))
            //            //{

            //            //}

            //            State tempNewState = new State(dfaState);
            //            tempState.StringValue = tempListItem.StringValue;
            //            Transition trans = new Transition(tempState, tempNewState, letter[0]);

            //            //tempNewState.OutTrans.Add(new Transition(currentState, tempNewState, letter[0]));
            //            if (!stateExists(tempState, history))
            //            {

            //                history.Add(tempState);
            //            }

            //            if (!stateExists(tempNewState, history))
            //            {
            //                tempStateList.Add(tempNewState);
            //               // currentStateList.Add(tempNewState);
            //                final.Add(tempState);
            //                transitionListDFA.Add(trans);
            //            }

            //        }

            //    }


            //    //At end must add all states together as 1 state + all transitions
            //    history.Add(tempState);


            //}







            //List<List<State>> history = new List<List<State>>();
            //List<List<State>> PossibleStateList = new List<List<State>>();
            //List<List<State>> CurrentStateList = new List<List<State>>();

            //List<State> currentState = new List<State>();
            //currentState.Add(automata.StateList[0]);
            //CurrentStateList.Add(currentState);


            //while (CurrentStateList.Count != 0)
            //{
            //    List<State> tempStateList = new List<State>();
            //    tempStateList = CurrentStateList.First();
            //    CurrentStateList.RemoveAt(0);

            //    if (ContainsList(tempStateList, history))
            //    {
            //        continue;
            //    }

            //    List<List<State>> wouldBeAdded = new List<List<State>>();
            //    foreach (State state in tempStateList)
            //    {

            //        foreach (string letter in alphabet)
            //        {
            //            List<State> _temp = GetConnectingStates(state, letter);
            //            bool listExists = false;
            //            foreach (List<State> list in history)
            //            {
            //                if (ContainsAllItems(list, _temp))
            //                {
            //                    listExists = true;
            //                }
            //            }

            //            if (!listExists)
            //            {
            //                wouldBeAdded.Add(_temp);
            //                CurrentStateList.Add(_temp);
            //            }



            //            string DfaStateString = "";

            //            foreach (State s in tempStateList)
            //            {
            //                DfaStateString += s.StringValue;
            //            }

            //            State DfaState = new State(DfaStateString);
            //            stateListDFA.Add(DfaState);
            //            List<State> beforeadding = new List<State>();
            //            foreach (var item in CombineStates(wouldBeAdded))
            //            {
            //                //stateListDFA.Add(tempState);
            //                beforeadding.Add(DfaState);
            //                //tempState.OutTrans.Add();
            //            }

            //            foreach (var item in beforeadding)
            //            {
            //                DfaState.OutTrans.Add(new Transition(DfaState, item, letter[0]));
            //                stateListDFA.Add(item);
            //            }


            //        }


            //    }

            //    history.Add(tempStateList);

            //}
            //stateListDFA = final;



            DFAAutomata.AssignTransitions();
            DFAAutomata.AssignStates();
            //Now have to classify all finalstates
            string stateFinal = "";

            foreach (State item in DFAAutomata.StateList)
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


        private List<State> CombineStates(List<List<State>> temp)
        {
            List<State> combinedStates = new List<State>();
            foreach (List<State> item in temp)
            {
                string tempState = "";
                foreach (State s in item)
                {
                    tempState += s.StringValue;
                }
                combinedStates.Add(new State(tempState));
            }

            return combinedStates;
        }

        private bool ContainsList(List<State> checkFor, List<List<State>> checkAgainst)
        {
            foreach (List<State> tempList in checkAgainst)
            {
                var a = new HashSet<State>(tempList).SetEquals(checkFor);
                if (a)
                {
                    return true;
                }


            }
            return false;
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

    }
}

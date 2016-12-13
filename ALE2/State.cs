using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    class State
    {
        string stringValue;
        bool isFinal = false;
        bool isStart = false;
        List<Transition> inTrans = new List<Transition>();
        List<Transition> outTrans = new List<Transition>();
        int currentTransIndex;
        string graphValue;
        int id;
        int transIndex = 0;

        bool connectToAnd = false;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int TransIndex
        {
            get { return transIndex; }
            set { transIndex = value; }
        }

        /// <summary>
        /// String value of the state, A, B, ect
        /// </summary>
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

        /// <summary>
        /// If this is a final state
        /// </summary>
        public bool IsFinal
        {
            get { return isFinal; }
            set { isFinal = value; }
        }

        public bool IsStart
        {
            get { return isStart; }
            set { isStart = value; }
        }


        public bool ConnectToAnd
        {
            get { return connectToAnd; }
            set { connectToAnd = value; }
        }

        /// <summary>
        /// Current Transition index
        /// </summary>
        public int CurrentTransitionIndex
        {
            get { return currentTransIndex; }
            set { currentTransIndex = value; }
        }


        /// <summary>
        /// All incoming transitions
        /// </summary>
        public List<Transition> InTrans
        {
            get { return inTrans; }
            set { inTrans = value; }
        }

        /// <summary>
        /// All outgoing transitions
        /// </summary>
        public List<Transition> OutTrans
        {
            get { return outTrans; }
            set { outTrans = value; }
        }

        /// <summary>
        /// Graph value of the state, A, B, ect
        /// </summary>
        public string GraphValue
        {
            get { return graphValue; }
            set { graphValue = value; }
        }


        public State(string stringValue, int id = 0)
        {
            StringValue = stringValue;
            Id = id;
        }


        /// <summary>
        /// Checks the transitions if they match for DFA Algorithm
        /// </summary>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public bool CheckTransitions(List<string> alphabet)
        {
            foreach (Transition item in OutTrans)
            {
                if (!alphabet.Contains(item.TransitionChar.ToString()) || item.TransitionChar == '_')
                {
                    return false;
                }
            }

            if (OutTrans.Count != alphabet.Count)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loops through all out transition to see if the transition character is equal
        /// </summary>
        /// <param name="c"></param>
        /// <returns>end state object</returns>
        public State CheckCharacter(char c)
        {
            foreach (Transition trans in OutTrans)
            {
                if (trans.TransitionChar == '_')//epsilon case
                {
                    //Get the end state but do not wipe the character
                }
                if (trans.TransitionChar == c)
                {
                    return trans.EndState;
                }
            }
            return null;
        }

    }
}

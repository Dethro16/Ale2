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
        List<Transition> inTrans = new List<Transition>();
        List<Transition> outTrans = new List<Transition>();

        string graphValue;

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


        public State(string stringValue)
        {
            StringValue = stringValue;
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

    }
}

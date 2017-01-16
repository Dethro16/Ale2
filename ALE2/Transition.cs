using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    class Transition
    {
        State initialState;
        char transitionChar;
        State endState;
        public string removeFromStack;
        public string pushToStack;
        public string pdaValue = "";
        string graphValue;
        bool hasTravelled = false;
        public int currentPriority = 5;

        public int id;
        /// <summary>
        /// Initial transition state
        /// </summary>
        public State InitialState
        {
            get { return initialState; }
            set { initialState = value; }
        }

        /// <summary>
        /// Transition character
        /// </summary>
        public char TransitionChar
        {
            get { return transitionChar; }
            set { transitionChar = value; }
        }


        /// <summary>
        /// Ending state of transition
        /// </summary>
        public State EndState
        {
            get { return endState; }
            set { endState = value; }
        }

        /// <summary>
        /// If the transition was used before
        /// </summary>
        public bool HasTravelled
        {
            get { return hasTravelled; }
            set { hasTravelled = value; }
        }

        /// <summary>
        /// Graph value of the state, A, B, ect
        /// </summary>
        public string GraphValue
        {
            get { return graphValue; }
            set { graphValue = value; }
        }


        public Transition(State initialState, State endState, char transitionChar)
        {
            InitialState = initialState;
            EndState = endState;
            TransitionChar = transitionChar;
        }


        public bool CanTravel(char c)
        {
            if (TransitionChar == c || TransitionChar == '_')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

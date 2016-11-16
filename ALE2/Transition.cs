﻿using System;
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

        string graphValue;


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

    }
}

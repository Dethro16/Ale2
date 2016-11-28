using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    class Word
    {
        string stringValue;
        bool accepted;
        bool isAccepted;

        /// <summary>
        /// String value of the word
        /// </summary>
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

        public bool Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }

        public bool IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; }
        }

        public Word(string value, bool accepted)
        {
            StringValue = value;
            Accepted = accepted;
            IsAccepted = false;
        }
    }
}

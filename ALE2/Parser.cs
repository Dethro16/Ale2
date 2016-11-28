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

    }
}

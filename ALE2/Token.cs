using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE2
{
    public class Tokenizer
    {
        private StringReader reader;

        public List<Token> Scan(string expression)
        {
            reader = new StringReader(expression);

            var tokens = new List<Token>();
            while (reader.Peek() != -1)
            {
                var c = (char)reader.Peek();
                if (Char.IsWhiteSpace(c))
                {
                    reader.Read();
                    continue;
                }

                if (Char.IsLetter(c))
                {
                    string nr = ParseVariable();
                    tokens.Add(new VariableToken(c.ToString()));
                }
                else if (c == '(')
                {
                    tokens.Add(new OpenParenthesis());
                    reader.Read();
                }
                else if (c == ')')
                {
                    tokens.Add(new ClosedParenthesis());
                    reader.Read();
                }
                else if (c == '*')
                {
                    tokens.Add(new RepetitionToken());
                    reader.Read();
                }
                else if (c == '.')
                {
                    tokens.Add(new AndToken());
                    reader.Read();
                }
                else if (c == '|')
                {
                    tokens.Add(new OrToken());
                    reader.Read();
                }
                else if (c == ',')
                {
                    tokens.Add(new commaToken());
                    reader.Read();
                }
                else
                    throw new Exception("Unknown character in expression: " + c);
            }

            return tokens.ToList();
        }

        private string ParseVariable()
        {
            string var = "";
            while (Char.IsLetter((char)reader.Peek()))
            {
                var += (char)reader.Read();
                return var;
            }

            return var;
        }
    }
    public abstract class Token
    {
    }

    public class Parenthesis : Token
    {
    }

    public class Operand : Token
    {
    }

    public class OpenParenthesis : Parenthesis
    {
        public override string ToString()
        {
            return "(";
        }
    }

    public class ClosedParenthesis : Parenthesis
    {
        public override string ToString()
        {
            return ")";
        }
    }

    public class VariableToken : Token
    {
        private readonly string value;

        public VariableToken(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return value;
        }
    }

    public class RepetitionToken : Operand
    {
        public override string ToString()
        {
            return "*";
        }
    }

    public class EpsilonToken : Operand
    {
        public override string ToString()
        {
            return "_";
        }
    }

    public class AndToken : Operand
    {
        public override string ToString()
        {
            return ".";
        }
    }

    public class OrToken : Operand
    {
        public override string ToString()
        {
            return "|";
        }
    }

    public class commaToken : Token
    {
        public override string ToString()
        {
            return ",";
        }
    }
}

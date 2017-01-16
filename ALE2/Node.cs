using System.Collections.Generic;

namespace ALE2
{
    class Node
    {
        private Token token;
        private List<Node> children;
        private string infix;
        private string codeValue;
        private int nodeNumber;
        private string linkedNode;

        public Token Token
        {
            get { return token; }
            set { token = value; }
        }

        public List<Node> Children
        {
            get { return children; }
            set { children = value; }
        }

        public string Infix
        {
            get { return infix; }
            set { infix = value; }
        }

        public string CodeValue
        {
            get { return codeValue; }
            set { codeValue = value; }
        }

        public string LinkedNode
        {
            get { return linkedNode; }
            set { linkedNode = value; }
        }

        public int NodeNumber
        {
            get { return nodeNumber; }
            set { nodeNumber = value; }
        }

        public Node(Token token, int nodeNumber)
        {
            Token = token;
            NodeNumber = nodeNumber;
            Children = new List<Node>();
        }


        public void linkNodes()
        {
            string node = "node{0} -- node{1}";
            foreach (var item in Children)
            {
                if (item.Token is VariableToken)
                {
                    LinkedNode += string.Format(node, NodeNumber.ToString(), item.NodeNumber.ToString());
                    LinkedNode += "\n";
                }
                else
                {
                    LinkedNode += string.Format(node, NodeNumber.ToString(), item.NodeNumber.ToString());
                    LinkedNode += "\n";
                    item.linkNodes();
                }
            }
        }

    }
}

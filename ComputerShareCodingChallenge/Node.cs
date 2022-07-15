using System;

namespace ComputerShareCodingChallenge
{
	public class Node
	{
		private char nodeValue;
		private Node? leftNode;
		private Node? rightNode;

        public Node()
		{
			leftNode = null;
			rightNode = null;
		}


		//Getters and Setters for the encapsulated data
		public char NodeValue
        {
			get { return nodeValue; }
			set { nodeValue = value; }
        }

		public Node LeftNode
        {
			get { return leftNode; }
			set { leftNode = value; }
        }

        public Node RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }
    }
}


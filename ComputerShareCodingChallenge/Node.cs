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

		public char NodeValue
        {
			get { return nodeValue; }
			set { nodeValue = value; }
        }

	}
}


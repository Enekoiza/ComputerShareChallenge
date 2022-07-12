﻿using System;
namespace ComputerShareCodingChallenge
{
	public class BinaryTree
	{
		private Node? root;

        public BinaryTree()
		{
            root = new Node();
		}

		public Node Root
        {
			get { return root; }
			set { root = value; }
        }


		public void createTree(string filePath)
        {



            Node temp = new Node();
            Node current = new Node();

            string line = "";

            using (var reader = new System.IO.StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> dictionary = line.Split(" ").ToList<string>();
                    current = Root;
                    foreach (char sign in dictionary[1])
                    {
                        if(sign == '.')
                        {
                            if(current.LeftNode == null)
                            {
                                current.LeftNode = new Node();
                            }
                            current = current.LeftNode;
                        }
                        if (sign == '-')
                        {
                            if (current.RightNode == null)
                            {
                                current.RightNode = new Node();
                            }
                            current = current.RightNode;
                        }

                    }

                    current.NodeValue = char.Parse(dictionary[0]);


                }
            }
        }


	}
}

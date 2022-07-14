using System;
using System.Linq;

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

        public string decode(Node rootNode, string codedMessage)
        {
            string result = string.Empty;

            Node temp = new Node();


            List<string> morsePattern = codedMessage.Split(" ").ToList<string>();

            foreach (string letter in morsePattern)
            {
                temp = rootNode;

                foreach (char sign in letter)
                {
                    if (sign == '.') temp = temp.LeftNode;
                    if (sign == '-') temp = temp.RightNode;
                }
                result = result + temp.NodeValue;
            }

            

            return result;
        }

        public string encode(Node rootNode, string codedMessage)
        {
            List<string> result = new List<string>();

            string finalEncodedMessage = string.Empty;

            foreach (var letter in codedMessage.Select((value, index) => new {value, index}))
            {
                result.Clear();
                if (letter.value == ' ') 
                {
                    finalEncodedMessage += "/";
                    continue;
                }
                if (letter.index != 0 && !finalEncodedMessage.EndsWith("/")) finalEncodedMessage += " ";
                
                trasverseTree(rootNode, result, letter.value);
                string encodedLetter = string.Join("", result);
                finalEncodedMessage += encodedLetter;
            }


            return finalEncodedMessage;
        }
        
        public bool trasverseTree(Node rootNode, List<string> finalMorseString, char letter)
        {
            if (rootNode == null) return false;
            else if (rootNode.NodeValue == letter) return true;
            else
            {
                if (trasverseTree(rootNode.LeftNode, finalMorseString, letter) == true)
                {
                    finalMorseString.Insert(0, ".");
                    return true;
                }
                else if (trasverseTree(rootNode.RightNode, finalMorseString, letter) == true)
                {
                    finalMorseString.Insert(0, "-");
                    return true;
                }
            }


            return false;

        }


    }
}


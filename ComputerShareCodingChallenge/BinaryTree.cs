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


        //Given a filepath holding the data of each letter and each conversion
		public void createTree(string filePath)
        {

            
            //Current will be used as a node to move through the creating tree
            Node current = new Node();

            string line = String.Empty;

            //Create a stream reader and then read line by line until an empty line is found which means EOF
            using (var reader = new System.IO.StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    //Separate both the character and its code
                    List<string> dictionary = line.Split(" ").ToList<string>();
                    
                    //Point the current to the root of the tree before trasversing
                    current = Root;

                    //Find the char position in the tree an assign the value to the corresponding node
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

            char[] delimeters = { ' ', '/' };


            List<string> wordPattern = codedMessage.Split("/").ToList<string>();



            foreach (var word in wordPattern)
            {
                List<string> letterPattern = word.Split(" ").ToList<string>();

                foreach (string letter in letterPattern)
                {

                    temp = rootNode;

                    foreach (char sign in letter)
                    {
                        if (sign == '.') temp = temp.LeftNode;
                        if (sign == '-') temp = temp.RightNode;
                    }
                    result = result + temp.NodeValue;
                }

                result += " ";
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


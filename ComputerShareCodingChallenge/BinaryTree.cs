using System;
using System.Linq;

namespace ComputerShareCodingChallenge
{
    //Class to support the implementation of a binary tree
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


        //Decode the given message
        public string decode(Node rootNode, string codedMessage)
        {


            string result = string.Empty;

            Node temp = new Node();


            //Separate the coded message into elements of a list using the / delimeter
            List<string> wordPattern = codedMessage.Split("/").ToList<string>();


            //Iterate through the generated words
            foreach (var word in wordPattern)
            {
                //Separate the elements in the list by a " " delimeter which represents the word boundaries.
                List<string> letterPattern = word.Split(" ").ToList<string>();

                //Iterate through the generated characters
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

                //Add the space representing a new word.
                if(word != wordPattern.Last()) result += " ";
            }


            return result;
        }


        //Encode the given message
        public string encode(Node rootNode, string codedMessage)
        {
            List<string> result = new List<string>();

            string finalEncodedMessage = string.Empty;


            //Iterate through the given message with the value and the index as letter parameters
            foreach (var letter in codedMessage.Select((value, index) => new {value, index}))
            {
                result.Clear();

                //If the character is a " " place a "/" to represent the word delimeter
                if (letter.value == ' ') 
                {
                    finalEncodedMessage += "/";
                    continue;
                }

                //Between every character but not the first of the string or the first of each word place a " " as character boundary
                if (letter.index != 0 && !finalEncodedMessage.EndsWith("/")) finalEncodedMessage += " ";
                
                //Trasverse the tree inserting into result the encoded character passed through letter.value
                trasverseTree(rootNode, result, letter.value);
                //Unify the items in the list as a string
                string encodedLetter = string.Join("", result);

                //Keep adding the values to the final message
                finalEncodedMessage += encodedLetter;
            }


            return finalEncodedMessage;
        }
        

        //Function to recursivelly access all the nodes until one is found with the desired character
        public bool trasverseTree(Node rootNode, List<string> finalMorseString, char letter)
        {
            //If this is the end of the branch
            if (rootNode == null) return false;
            //If the desired node is found
            else if (rootNode.NodeValue == letter) return true;
            else
            {
                //Traverse to the right or left branch of the tree
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


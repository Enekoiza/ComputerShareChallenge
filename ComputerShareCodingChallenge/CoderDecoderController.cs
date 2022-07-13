using System;

namespace ComputerShareCodingChallenge
{
	public class CoderDecoderController
	{
		public CoderDecoderController()
		{
			//Loop to ask the user the action to perform
            while (true)
            {
				Console.WriteLine("Please choose to code by typing 'C' or decode by typing 'D'. 'E' for exiting the program.");
                var input = Console.ReadLine().ToUpper();
				if (input == "C" || input == "D") break;
				if (input == "E")
                {
					Console.WriteLine("The program ended successfully.");
					return;
                }

            }

			BinaryTree myTree = new BinaryTree();

			string pathToDictionaryFile = Directory.GetCurrentDirectory() + "/MorseDictionary.txt";

			myTree.createTree(pathToDictionaryFile);

			Node rootNode = new Node();

			myTree.decode(myTree.Root, ".... --- .-.. .-");
		}
	}
}

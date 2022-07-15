using System;

namespace ComputerShareCodingChallenge
{
	//Controller to make the work around the MVC approach
	public class CoderDecoderController
	{
		public CoderDecoderController()
		{
			//Loop to ask the user the action to perform
            while (true)
            {
				Console.WriteLine("Please choose to code by typing 'C' or decode by typing 'D'. 'E' for exiting the program.");
                var input = Console.ReadLine().ToUpper();
				if (input == "E")
				{
					Console.WriteLine("The program ended successfully.");
					return;
				}

				BinaryTree myTree = new BinaryTree();

				string pathToDictionaryFile = Directory.GetCurrentDirectory() + "/MorseDictionary.txt";

				myTree.createTree(pathToDictionaryFile);

				Node rootNode = new Node();

				rootNode = myTree.Root;

				string message = string.Empty;

				if (input == "D")
                {
					Console.WriteLine("Enter a message to decode: ");

					message = Console.ReadLine();

					
					Console.WriteLine($"The decoded message is: {myTree.decode(rootNode, message)}");

				}
				if(input == "C")
                {
					Console.WriteLine("Enter a message to decode: ");

					message = Console.ReadLine();

					Console.WriteLine($"The decoded message is: {myTree.encode(rootNode, message)}");

				}


			}


		}
	}
}

using System;

namespace ComputerShareCodingChallenge
{
	//Controller to make the work around the MVC approach
	public class CoderDecoderController
	{
		public CoderDecoderController()
		{
		}
		public string AskForCommand()
        {
			Console.WriteLine("Please choose to code by typing 'C' or decode by typing 'D'.");

			var command = Console.ReadLine().ToUpper();

			return command;
		}

		public BinaryTree GenerateTree()
        {
			BinaryTree myTree = new BinaryTree();

			string pathToDictionaryFile = Directory.GetCurrentDirectory() + "/MorseDictionary.txt";

			myTree.createTree(pathToDictionaryFile);

			return myTree;

		}


		public void ProcessCommand(string command, BinaryTree tree)
        {



			string message = string.Empty;

			if (command == "D")
			{
				Console.WriteLine("Enter a message to decode: ");

				message = Console.ReadLine();

				Console.WriteLine($"The decoded message is: {tree.decode(tree.Root, message.ToUpper())}");

			}
			if (command == "C")
			{
				Console.WriteLine("Enter a message to encode: ");

				message = Console.ReadLine();

				Console.WriteLine($"The decoded message is: {tree.encode(tree.Root, message.ToUpper())}");

			}
		}


	}
}

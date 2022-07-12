using System;

namespace ComputerShareCodingChallenge
{
	public class CoderDecoderController
	{
		public CoderDecoderController()
		{
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

			Node newNode = new Node();
			newNode.NodeValue = 'a';
			string line = "";
			using (var reader = new System.IO.StreamReader("../../../MorseDictionary.txt"))
			{
				while ((line = reader.ReadLine()) != null)
				{

				}
			}
		}
	}
}

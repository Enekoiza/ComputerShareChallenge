using System;
namespace ComputerShareCodingChallenge
{
	public class BinaryTree
	{
		private Node? root;

        public BinaryTree()
		{
			root = null;
		}

		public Node Root
        {
			get { return root; }
			set { root = value; }
        }


		public void createTree(string filePath)
        {

            string line = "";
            using (var reader = new System.IO.StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {

                }
            }
        }


	}
}


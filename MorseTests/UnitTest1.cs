using ComputerShareCodingChallenge;


namespace MorseTests
{
    [TestClass]
    public class EncodeTests
    {
        private readonly BinaryTree _binaryTree;

        public EncodeTests()
        {
            _binaryTree = new BinaryTree();
            _binaryTree.createTree("C:/Users/Eneko/source/repos/Enekoiza/ComputerShareChallenge/ComputerShareCodingChallenge/bin/Debug/net6.0/MorseDictionary.txt");
        }


        [TestMethod]
        public void Encode_HELLOWORLD()
        {
            // Arrange
            string decodedMessage = "HELLO WORLD";
            string expected = ".... . .-.. .-.. ---/.-- --- .-. .-.. -..";


            //Act
            string actual = _binaryTree.encode(_binaryTree.Root, decodedMessage);

            //Assert
            Assert.AreEqual(expected, actual, "The message is not correct.");
        }

        [TestMethod]
        public void Encode_BYEWORLD()
        {
            // Arrange
            string decodedMessage = "BYE WORLD";
            string expected = "-... -.-- ./.-- --- .-. .-.. -..";


            //Act
            string actual = _binaryTree.encode(_binaryTree.Root, decodedMessage);



            //Assert
            Assert.AreEqual(expected, actual, "The message is not correct.");
        }

        [TestMethod]
        public void Decode_WELCOMETOCOMPUTERSHARE()
        {
            // Arrange
            string decodedMessage = ".-- . .-.. -.-. --- -- ./- ---/-.-. --- -- .--. ..- - . .-. ... .... .- .-. .";
            string expected = "WELCOME TO COMPUTERSHARE";


            //Act
            string actual = _binaryTree.decode(_binaryTree.Root, decodedMessage);



            //Assert
            Assert.AreEqual(expected, actual, "The message is not correct.");
        }


        [TestMethod]
        public void Decode_COMPUTINGCHALLENGE()
        {
            // Arrange
            string decodedMessage = "-.-. --- -- .--. ..- - .. -. --./-.-. .... .- .-.. .-.. . -. --. .";
            string expected = "COMPUTING CHALLENGE";


            //Act
            string actual = _binaryTree.decode(_binaryTree.Root, decodedMessage);



            //Assert
            Assert.AreEqual(expected, actual, "The message is not correct.");
        }


    }
}
//Application done by Eneko Izaguirre Martin


//The application tries to emulate the MVC approach.

//The application works around the idea of a encoder and decoder of morse.
//Given a morse message the console application transform the message into a legible message
//On the other hand, if the application receives the correct instruction and a legible message it will return an encoded message
//The application uses a binary tree in order to encode or decode the message.





namespace ComputerShareCodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            CoderDecoderController challenge = new CoderDecoderController();

            var command = challenge.AskForCommand();

            var tree = challenge.GenerateTree();

            challenge.ProcessCommand(command, tree);
        }
    }
}

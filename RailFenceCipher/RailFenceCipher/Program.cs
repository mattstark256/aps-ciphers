using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFenceCipher
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matt's Rail Fence Cipher Program");

            while (true)
            {
                Console.WriteLine("\nWould you like to encode or decode a message?\n1: Encode\n2: Decode");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    EncodeMessage();
                }
                else if (choice == "2")
                {
                    DecodeMessage();
                }
                else
                {
                    Console.WriteLine("Input not recognized.");
                }
            }
        }


        static void EncodeMessage()
        {
            Console.WriteLine("\nPlease enter a number representing the fence height");
            int fenceHeight = GetNumericInput();
            Console.WriteLine("\nPlease enter the message to be encoded.");
            string message = Console.ReadLine();

            string encodedMessage = "";

            for (int row = 0; row < fenceHeight; row++)
            {
                int j = 0;
                while (true)
                {
                    j += row;
                    if (j >= message.Length) break;
                    encodedMessage += message[j];
                    j += (fenceHeight - 1 - row) * 2;
                    if (j >= message.Length) break;
                    if (row != 0 && row != fenceHeight - 1)
                    {
                        encodedMessage += message[j];
                    }
                    j += row;
                }
            }

            Console.WriteLine("\nThe encoded message is as follows:");
            Console.WriteLine(encodedMessage + "//END");
        }


        static void DecodeMessage()
        {
            Console.WriteLine("\nPlease enter a number representing the fence height");
            int fenceHeight = GetNumericInput();
            Console.WriteLine("\nPlease enter the message to be decoded.");
            string message = Console.ReadLine();

            string decodedMessage = message;

            int characterIndex = 0;
            for (int row = 0; row < fenceHeight; row++)
            {
                int j = 0;
                while (true)
                {
                    j += row;
                    if (j >= message.Length) break;
                    decodedMessage = decodedMessage.Remove(j, 1).Insert(j, message[characterIndex].ToString());
                    characterIndex++;
                    j += (fenceHeight - 1 - row) * 2;
                    if (j >= message.Length) break;
                    if (row != 0 && row != fenceHeight - 1)
                    {
                        decodedMessage = decodedMessage.Remove(j, 1).Insert(j, message[characterIndex].ToString());
                        characterIndex++;
                    }
                    j += row;
                }
            }

            Console.WriteLine("\nThe decoded message is as follows:");
            Console.WriteLine(decodedMessage);
        }


        static int GetNumericInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int key))
                {
                    return key;
                }
                else
                {
                    Console.WriteLine("Number not recognized. Please enter a number.");
                }
            }
        }
    }
}

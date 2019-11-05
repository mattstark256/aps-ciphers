using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScytaleCipher
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matt's Scytale Cipher Program");

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
            Console.WriteLine("\nPlease enter a number representing the scytale circumference");
            int circumference = GetNumericInput();
            Console.WriteLine("\nPlease enter the message to be encoded.");
            string message = Console.ReadLine();

            string encodedMessage = "";
            int width = (int)Math.Ceiling((float)message.Length / circumference);
            Console.WriteLine("Message width: " + width);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < circumference; j++)
                {
                    int pos = j * width + i;
                    if (pos >= message.Length)
                    {
                        encodedMessage += " ";
                    }
                    else
                    {
                        encodedMessage += message[pos];
                    }
                }
            }

            Console.WriteLine("\nThe encoded message is as follows:");
            Console.WriteLine(encodedMessage);
        }


        static void DecodeMessage()
        {
            Console.WriteLine("\nPlease enter a number representing the scytale circumference");
            int circumference = GetNumericInput();
            Console.WriteLine("\nPlease enter the message to be decoded.");
            string message = Console.ReadLine();

            string decodedMessage = "";
            int width = (int)Math.Ceiling((float)message.Length / circumference);
            Console.WriteLine("Message width: " + width);

            for (int j = 0; j < circumference; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int pos = i * circumference + j;
                    if (pos >= message.Length)
                    {
                        decodedMessage += " ";
                    }
                    else
                    {
                        decodedMessage += message[pos];
                    }
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

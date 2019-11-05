using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Matt's Caesar Cipher Program");

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
            Console.WriteLine("\nPlease enter a numeric key.");
            int key = GetNumericInput();
            Console.WriteLine("\nPlease enter the message to be encoded.");
            string message = Console.ReadLine();

            string encodedMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                encodedMessage += ShiftCharacter(message[i], key);
            }

            Console.WriteLine("\nThe encoded message is as follows:");
            Console.WriteLine(encodedMessage);
        }


        static void DecodeMessage()
        {
            Console.WriteLine("\nPlease enter a numeric key.");
            int key = GetNumericInput();
            Console.WriteLine("\nPlease enter the message to be decoded.");
            string message = Console.ReadLine();

            string decodedMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                decodedMessage += ShiftCharacter(message[i], -key);
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


        static char ShiftCharacter(char character, int key)
        {
            if (IsLowercase(character))
            {
                return (char)((character + key - 97 + 26) % 26 + 97);
            }
            else if (IsUppercase(character))
            {
                return (char)((character + key - 65 + 26) % 26 + 65);
            }
            else
            {
                return character;
            }
        }


        static bool IsLowercase(char character)
        {
            return character >= 97 && character <= 122;
        }


        static bool IsUppercase(char character)
        {
            return character >= 65 && character <= 90;
        }
    }
}

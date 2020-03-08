using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {

            Vigenere cipher = new Vigenere();

            Console.WriteLine("Letter matrix:");
            Console.WriteLine("_____________________________________________________________");
            cipher.PrintMatrix();
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();

            string cipherText = "Making a cipher is hard";
            string cipherKey = "tikki";

            Console.WriteLine("Text to cipher: ");
            Console.WriteLine("..............." + cipherText);

            string encipheredText = cipher.Encipher(cipherText, cipherKey);
            Console.WriteLine("Ciphered text: ");
            Console.WriteLine("..............." + encipheredText);

            string decipheredText = cipher.Decipher(encipheredText, cipherKey);
            Console.WriteLine("Deciphered text: ");
            Console.WriteLine("..............." + decipheredText);
            Console.WriteLine();

            Console.Read();
        }



    }
}

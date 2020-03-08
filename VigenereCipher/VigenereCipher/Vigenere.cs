using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Vigenere
    {
        private static readonly string standardAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private char[,] matrix;
        public string Alphabet { get; private set; }
        public char[] AlphabetArray { get; private set; }

        public Vigenere(string alphabet)
        {
            SetAlphabet(alphabet);
        }

        public Vigenere() : this(standardAlphabet) { }

        public void SetAlphabet(string alphabet)
        {
            try
            {
                Alphabet = alphabet;
                AlphabetArray = Alphabet.ToCharArray();
                CreateMatrix();

            }
            catch (Exception)
            {
                throw new Exception("Not a correct alphabet format.");
            }
        }

        private void CreateMatrix()
        {
            int i, j;
            int counter = 0;
            int arrLenght = AlphabetArray.Length;
            bool reverse = false;
            this.matrix = new char[arrLenght, arrLenght];
            char[,] newMatrix = new char[arrLenght, arrLenght];

            /* Stored values into the array*/
            for (i = 0; i < arrLenght; i++)
            {
                for (j = 0; j < arrLenght; j++)
                {
                    matrix[i, j] = AlphabetArray[j];
                }
            }

            for (i = 0; i < arrLenght; i++)
            {
                for (j = 0; j < arrLenght; j++)
                {

                    if (!reverse)
                    {

                        if (counter >= arrLenght)
                        {
                            reverse = true;
                            counter = 0;
                        }
                    }
                    if (j == 0)
                    {
                        counter = j + i;
                        reverse = false;
                    }
                    newMatrix[i, j] = matrix[i, counter];
                    counter++;

                }
            }
            matrix = newMatrix;

        }

        public void PrintMatrix()
        {
            StringBuilder header = new StringBuilder();
            StringBuilder headerLine = new StringBuilder();
            header.Append("   ");
            headerLine.Append("___");
            for (int i = 0; i < AlphabetArray.Length; i++)
            {
                header.Append(AlphabetArray[i].ToString());
                header.Append(" ");
                headerLine.Append("__");
            }
            Printer.PrintLine(header.ToString());
            Printer.PrintLine(headerLine.ToString());

            for (int i = 0; i < AlphabetArray.Length; i++)
            {
                Printer.Print(AlphabetArray[i] + "| ");

                for (int j = 0; j < AlphabetArray.Length; j++)
                {
                    Printer.Print(matrix[i, j] + " ");
                }
                Printer.PrintLine("");
            }
        }

        private int AlphaIndex(char c)
        {
            return (char.ToUpper(c) - 64) - 1;
        }

        public string Encipher(string input, string key)
        {
            input = input.Replace(" ", "").Trim();
            key = key.Replace(" ", "").Trim();
            StringBuilder encryptedText = new StringBuilder();
            int keyCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(keyCount == key.Length)
                {
                    keyCount = 0;
                }
                encryptedText.Append(matrix[AlphaIndex(input[i]), AlphaIndex(key[keyCount])]);
                keyCount++;
            }
            return encryptedText.ToString();

        }

        public string Decipher(string input, string key)
        {
            input = input.Replace(" ", "").Trim();
            key = key.Replace(" ", "").Trim();

            //Change multidimensional array to Jagged Array.
            char[][] jaggedMatrix = Enumerable.Range(0, matrix.GetLength(0))
             .Select(x => Enumerable.Range(0, matrix.GetLength(1))
                 .Select(y => matrix[x, y]).ToArray())
             .ToArray();

            StringBuilder decryptedText = new StringBuilder();
            int keyCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (keyCount == key.Length)
                {
                    keyCount = 0;
                }

                char[] targetArr = jaggedMatrix[AlphaIndex(key[keyCount])];
                int arrIndex = Array.IndexOf(targetArr, input[i]);
                char targetLetter = AlphabetArray[arrIndex];

                decryptedText.Append(targetLetter);
                keyCount++;
            }
            return decryptedText.ToString();
        }
        
    }
}

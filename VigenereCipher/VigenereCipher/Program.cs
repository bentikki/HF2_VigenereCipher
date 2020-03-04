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
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ".ToCharArray();


            int i, j, counter;
            char[,] arr1 = new char[29, 29];

            Console.Write("\n\nRead a 2D array of size 3x3 and print the matrix :\n");
            Console.Write("------------------------------------------------------\n");


            /* Stored values into the array*/
            Console.Write("Input elements in the matrix :\n");
            for (i = 0; i < 29; i++)
            {
                for (j = 0; j < 29; j++)
                {
                    arr1[i, j] = alphabet[j];
                }
            }

            for (i = 0; i < 29; i++)
            {
                for (j = 0; j < 29; j++)
                {

                    counter = j + i;
                    if (counter >= 29)
                    {
                        counter = 0;
                        counter++;
                    }

                    Console.Write(arr1[i, counter] + " ");
                    counter++;
                }
                Console.WriteLine();

            }

            Console.Read();
        }



    }
}

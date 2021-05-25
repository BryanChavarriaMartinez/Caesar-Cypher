using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Caesar_Cypher
{
    class Result
    {
        public static string caesarCipher(string s, int k)
        {
            string encrypted = "";

            // Maximum rotates: 100 
            if (k >= 0 && k < 100)
            {
                foreach (var c in s)
                {
                    //If it's not a letter catch the character
                    if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                    {
                        encrypted += c;
                    }
                    else
                    {
                        // Work with the letter in lowercase
                        var c1 = c.ToString().ToLower()[0];

                        // c1 (Current letter) = (c1 + rotation k numbers) % (to module) 26
                        c1 += (char)(k % 26);

                        // If it's bigger than z in ASCII code starts back in the alphabet -26
                        if (c1 > 'z')
                        {
                            c1 -= (char)26;
                        }

                        // If the current letter is supposed to be Upper case change it
                        if (!(c >= 'a' && c <= 'z'))
                        {
                            c1 = c1.ToString().ToUpper()[0];
                        }
                        encrypted += c1;
                    }
                }
                return encrypted;
            }
            return "Overpasses the maximum rotation";
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            Console.Write("Insert your message: ");
            string s = Console.ReadLine();
            Console.Write("Rotations: ");
            int k = Convert.ToInt32(Console.ReadLine().Trim());

            string result = Result.caesarCipher(s, k);
            Console.WriteLine("Encrypted message: " + result);

            Console.WriteLine("\nDone. Press any key to continue.");
            Console.ReadKey();
        }
    }
}

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

        public static string AnticaesarCipher(string s, int k)
        {
            string unencrypted = "";

            foreach (var c in s)
            {
                if (c == ' ' || c == '_')
                {
                    unencrypted += c;
                }
                else
                {
                    var c1 = c.ToString()[0];

                    // c1 (Current letter) = (c1 - rotation k numbers) % (to module) 26
                    c1 -= (char)(k % 26);

                    // If it's bigger than z in ASCII code starts back in the alphabet -26
                    if (c1 > 'z')
                    {
                        c1 -= (char)26;
                    }

                    if (c1 < 'a')
                    {
                        c1 += (char)26;
                    }

                    // If the current letter is supposed to be Upper case change it
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        c1 = c1.ToString().ToUpper()[0];
                    }
                    unencrypted += c1;
                }
            }
            return unencrypted;
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n******** Menu ******** ");
                Console.WriteLine("\n1 - Encrypt Message ");
                Console.WriteLine("2 - Unencrypt Message ");
                Console.WriteLine("3 - Exit ");
                Console.Write("\nSelection: ");
                int y = Convert.ToInt32(Console.ReadLine().Trim());

                if (y == 1)
                {
                    Console.Write("Insert your message: ");
                    string s = Console.ReadLine();
                    Console.Write("Rotations: ");
                    int k = Convert.ToInt32(Console.ReadLine().Trim());

                    string result = Result.caesarCipher(s, k);
                    Console.WriteLine("Encrypted message: " + result);
                }

                if (y == 2)
                {
                    Console.Write("Insert your encrypted message: ");
                    string s = Console.ReadLine();
                    Console.Write("Rotations: ");
                    int k = Convert.ToInt32(Console.ReadLine().Trim());

                    string result = Result.AnticaesarCipher(s, k);
                    Console.WriteLine("Unencrypted message: " + result);
                }

                if (y == 3)
                {
                    Environment.Exit(0);
                }

                if (y != 1 && y != 2 && y != 3)
                {
                    Console.WriteLine("\nYou didn't input a valid option.");
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}
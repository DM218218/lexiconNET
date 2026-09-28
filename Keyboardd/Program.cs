using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyboardd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? correctString = Console.ReadLine();
            string? stickyString = Console.ReadLine();
            Keyboardd keyboardd = new Keyboardd();

            if (string.IsNullOrEmpty(correctString) || string.IsNullOrEmpty(stickyString))
            {
                Console.WriteLine("Input correct string and sticky string");
                return;
            }

            keyboardd.FindStickys3(correctString, stickyString);
        }
    }

    class Keyboardd
    {
        public Keyboardd()
        {

        }

        internal void FindStickys(string correctString, string stickyString)
        {
            int j = 0;
            //cheat to get distinct values
            Dictionary<char, int> output = new();

            for (int i = 0; i < correctString.Length; i++)
            {

                Console.WriteLine($"{correctString[i]} {stickyString[j]}");
                if (correctString[i] != stickyString[j])
                {
                    Console.WriteLine($"{correctString[i]} != {stickyString[j]}");
                    //The characters are not the same move ahead extra in stickyString and save character
                    try
                    {
                        output.Add(stickyString[j], 0);
                    }
                    catch (ArgumentException)
                    {
                        //ignoring this since we're using it to only get unique characters
                    }
                    //Console.Write(stickyString[j]);
                    j++;
                }

                //move stickString ahead either way to follow i
                j++;

                //this is the last character, we will finish. But final char has not been checked for repetition.
                //Do it here as a special case, if j is less than stickString length then there is more stickysting hence repetition
                if (i == correctString.Length - 1)
                {
                    if (j < stickyString.Length)
                    {
                        //The characters are not the same move ahead extra in stickyString and save character
                        try
                        {
                            output.Add(stickyString[j], 0);
                        }
                        catch (ArgumentException)
                        {
                            //ignoring this since we're using it to only get unique characters
                        }
                    }
                }
            }

            foreach (char c in output.Keys)
            {
                Console.Write(c);
            }
        }


        internal void FindStickys2(string correctString, string stickyString)
        {
            int j = stickyString.Length - 1;
            //cheat using dictionary to get distinct values
            Dictionary<char, int> output = new();

            for (int i = correctString.Length - 1; i >= 0; i--)
            {
                if (correctString[i] != stickyString[j])
                {
                    //The characters are not the same move ahead extra in stickyString and save character
                    try
                    {
                        output.Add(stickyString[j], 0);
                    }
                    catch (ArgumentException)
                    {
                        //ignoring this since we're using it to only get unique characters
                    }
                    //Console.Write(stickyString[j]);
                    j--;
                }

                //move stickString ahead either way to follow i
                j--;
            }

            foreach (char c in output.Keys)
            {
                Console.Write(c);
            }
        }

        internal void FindStickys3(string correctString, string stickyString)
        {
            Dictionary<char, int> correctDict = countChars(correctString);
            Dictionary<char, int> stickyDict = countChars(stickyString);


            foreach (char c in correctDict.Keys)
            {
                if (correctDict[c] != stickyDict[c])
                {
                    Console.Write(c);
                }
            }
        }

        private Dictionary<char, int> countChars(string input)
        {
            Dictionary<char, int> output = new();

            foreach (char c in input)
            {
                if(!output.TryAdd(c, 1))
                {
                    //char already added, update count
                    output[c] += 1;
                }
            }

            return output;
        }
    }
}

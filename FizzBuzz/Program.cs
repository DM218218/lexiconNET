using System;

namespace FizzBuzz
{
    struct InputBlock
    {
        public int X;
        public int Y;
        public int N;
    }

    class Program
    {

        static void Main()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();

            string newInput = Console.ReadLine();            

            fizzBuzz.ProcessInput(fizzBuzz.ExtractInput(newInput.Split(" ")));
        }
    }

    class FizzBuzz
    {
        public FizzBuzz()
        {
        }

        public InputBlock ExtractInput(string[] args)
        {
            InputBlock input = new InputBlock();

            if (args.Length == 3)
            {
                if(!String.IsNullOrEmpty(args[0]))
                {
                    if(!int.TryParse(args[0], out input.X))
                    {
                        Console.WriteLine("Faulty input X.");
                        return input;
                    }
                }
                else
                {
                    Console.WriteLine("X input malformed.");
                }

                if (!String.IsNullOrEmpty(args[1]))
                {
                    if (!int.TryParse(args[1], out input.Y))
                    {
                        Console.WriteLine("Faulty input Y.");
                        return input;
                    }
                }
                else
                {
                    Console.WriteLine("Y input malformed.");
                }

                if (!String.IsNullOrEmpty(args[2]))
                {
                    if (!int.TryParse(args[2], out input.N))
                    {
                        Console.WriteLine("Faulty input N.");
                        return input;
                    }
                }
                else
                {
                    Console.WriteLine("N input malformed.");
                }
            }
            else
            {
                Console.WriteLine("Please provide X, Y, and N.");
            }

            return input;
        }

        public void ProcessInput(InputBlock input)
        {
            for (int i = 1; i <= input.N; i++)
            {
                if (i % input.X != 0 && i % input.Y != 0)
                {
                    Console.Write(i);
                }
                else
                {
                    if (i % input.X == 0)
                    {
                        Console.Write("Fizz");
                    }

                    if (i % input.Y == 0)
                    {
                        Console.Write("Buzz");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FightingFraud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FightingFraud fightingFraud = new FightingFraud();

            var inputLine = "";
            inputLine = Console.ReadLine();

            int n = 0;
            if (!int.TryParse(inputLine, out n))
            {
                if (fightingFraud.debug)
                {
                    Console.WriteLine("Please provide length of schedule as a number.");
                }
                else
                {
                    Console.WriteLine("no");
                }
                return;
            }

            List<string> schedule = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if(string.IsNullOrEmpty(line))
                    {
                        if (fightingFraud.debug)
                        {
                            Console.WriteLine("Please provide schedule as series of dropoff, pickup statements.");
                        }
                        else
                        {
                            Console.WriteLine("no");
                        }
                        return;
                }

                schedule.Add(line);
            }

            fightingFraud.AnalyzeInput(schedule);
        }
    }

    class FightingFraud
    {
        public bool debug = true;

        struct ProcessedInput
        {
            public Dictionary<string, int> Pickups = new Dictionary<string, int>();
            public Dictionary<string, int> Dropoffs = new Dictionary<string, int>();

            public ProcessedInput()
            {
            }
        }

        public FightingFraud()
        {

        }

        internal void AnalyzeInput(List<string> schedule)
        {
            if (schedule.Count % 2 != 0)
            {
                //odd number of entries means unmatched entry hence invalid schedule.
                if (debug)
                {
                    Console.WriteLine("no\todd number entries");
                }
                else
                {
                    Console.WriteLine("no");
                }
                return;
            }

            int check = 1;
            ProcessedInput processedInputs = ProcessInput(schedule, out check);

            if(check == 1)
            {
                if (debug)
                {
                    Console.WriteLine("ProcessInput encountered an error.");
                }
                else
                {
                    Console.WriteLine("no");
                }
                return;
            }

            if(check == 2)
            {
                //duplicate entry
                if (debug)
                {
                    Console.WriteLine("no\tduplicate entry");
                }
                else
                {
                    Console.WriteLine("no");
                }
                return;
            }

            if (processedInputs.Pickups.Count != processedInputs.Dropoffs.Count)
            {
                //dangling pickup or droppoff
                if (debug)
                {
                    Console.WriteLine("no\tdangling pickup or droppoff");
                }
                else
                {
                    Console.WriteLine("no");
                }
                return;
            }

            foreach(var entry in processedInputs.Pickups)
            {
                if (processedInputs.Dropoffs.TryGetValue(entry.Key, out int dropoff))
                {
                    if(entry.Value > dropoff)
                    {
                        //pickup is after dropoff
                        if (debug)
                        {
                            Console.WriteLine("no\tpickup after dropoff");
                        }
                        else
                        {
                            Console.WriteLine("no");
                        }
                        return;
                    }
                }
                else
                {
                    //no dropoff for given pickup
                    if (debug)
                    {
                        Console.WriteLine("no\tno dropoff for pickup");
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }
                    return;
                }
            }

            Console.WriteLine("yes");
        }

        private ProcessedInput ProcessInput(List<string> schedule, out int errorOrEarlyOut)
        {
            ProcessedInput output = new ProcessedInput();
            errorOrEarlyOut = 0;

            for (int i = 0; i < schedule.Count; i++)
            {
                string[] splitInput = schedule[i].Split(" ");

                if (splitInput.Length != 2)
                {
                    if (debug)
                    {
                        Console.WriteLine($"Malformed schedule line in input: {schedule[i]}");
                    }
                    errorOrEarlyOut = 1;
                    break;
                }

                try
                {
                    if (splitInput[0] == "pickup")
                    {
                        output.Pickups.Add(splitInput[1], i);
                    }
                    else if (splitInput[0] == "dropoff")
                    {
                        output.Dropoffs.Add(splitInput[1], i);
                    }
                    else
                    {
                        if (debug)
                        {
                            Console.WriteLine($"Unknown schedule task type {splitInput[0]}");
                        }
                        errorOrEarlyOut = 1;
                        break;
                    }
                }
                catch (ArgumentException e) //The key identifier already exists, invalid schedule
                {
                    errorOrEarlyOut = 2;
                    break;
                }
            }

            return output;
        }
    }
}

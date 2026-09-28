using System;
using System.Collections.Generic;

namespace FightingMonsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FightingMonsters fightingMonsters = new FightingMonsters();

            Console.ReadLine(); //Discard first line, not needed.

            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Provide number of monsters as a number, followed by monster powers separated by spaces on a second line.");
                return;
            }

            string[] stringMonsters = input.Split(" ");
            List<int> monsters = new List<int>(stringMonsters.Length);

            foreach(string power in stringMonsters)
            {
                int tempPower = 0;

                if(int.TryParse(power, out tempPower))
                {
                    monsters.Add(tempPower);
                }
                else
                {
                    Console.WriteLine("Monster power must be integer");
                    return;
                }
            }

            fightingMonsters.FindMonsterPairing(monsters);
        }
    }

    class FightingMonsters
    {
        private bool iterative = true;
        private bool calc = true;
        public FightingMonsters() 
        { 
            
        }

        internal void FindMonsterPairing(List<int> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                //we need to fight everyone in case who attacks first matters
                for (int j = 0; j < monsters.Count; j++)
                {
                    if (i == j)
                    {
                        //don't fight yourself
                        continue;
                    }

                    if (iterative)
                    {
                        int attackMonster = monsters[i];
                        int defenseMonster = monsters[j];
                        int round = 1;

                        if(calc)
                        {
                            continue;
                        }

                        Math.Abs(attackMonster - defenseMonster);

                        while (attackMonster > 0 && defenseMonster > 0)
                        {
                            if(round % 2 == 0)
                            {
                                //defenders turn
                                attackMonster -= defenseMonster;
                            }
                            else
                            {
                                //attackers turn
                                defenseMonster -= attackMonster;
                            }

                            round++;
                        }

                        if (attackMonster == 1)
                        {
                            //found a match, add one to index since output should not start at zero
                            Console.WriteLine($"{i + 1} {j + 1}");
                            return;
                        }

                        if (defenseMonster == 1)
                        {
                            //found a match, add one to index since output should not start at zero
                            Console.WriteLine($"{j + 1} {i + 1}");
                            return;
                        }
                    }
                    else
                    {
                        if (SimulateFight(monsters[i], monsters[j]))
                        {
                            //found a match, add one to index since output should not start at zero
                            Console.WriteLine($"{i + 1} {j + 1}");
                            return;
                        }
                    }
                }
            }

            //no match found
            Console.WriteLine("impossible");
        }

        bool SimulateFight(int attacker, int defender)
        {
            //Next step will be end and success quit early
            if(attacker == 1 && defender == 1)
            {
                return true;
            }

            //check if fight is over
            if(attacker < 0 || defender < 0)
            {
                if(attacker == 1 || defender == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //apply damage and proceed to next step
            return SimulateFight(defender - attacker, attacker);
        }
    }
}

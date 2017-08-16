using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndeedPrime3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = new string[2];
            commands[0] = "LGLRLRLGGGLRLRLR";
            commands[1] = "L";

            string[] results = doesCircleExist(commands);

            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);

            Console.ReadLine();
        }

        static string[] doesCircleExist(string[] commands)
        {
            string[] ret = new string[commands.Length];

            for (int i = 0; i < commands.Length; ++i)
            {
                Robot rob = new Robot();
                char[] currentCommands = commands[i].ToArray();

                for (int j = 0; j < currentCommands.Length; ++j)
                {
                    if (currentCommands[j].ToString() == Commands.G.ToString())
                    {
                        switch (rob.currentDirection)
                        {
                            case Direction.North:
                                ++rob.currentNode[1];
                                break;
                            case Direction.South:
                                --rob.currentNode[1];
                                break;
                            case Direction.West:
                                --rob.currentNode[0];
                                break;
                            case Direction.East:
                                ++rob.currentNode[0];
                                break;
                        }
                    }
                    else if (currentCommands[j].ToString() == Commands.L.ToString())
                    {
                        switch (rob.currentDirection)
                        {
                            case Direction.North:
                                rob.currentDirection = Direction.West;
                                break;
                            case Direction.South:
                                rob.currentDirection = Direction.East;
                                break;
                            case Direction.West:
                                rob.currentDirection = Direction.South;
                                break;
                            case Direction.East:
                                rob.currentDirection = Direction.North;
                                break;
                        }
                    }
                    else if (currentCommands[j].ToString() == Commands.R.ToString())
                    {
                        switch (rob.currentDirection)
                        {
                            case Direction.North:
                                rob.currentDirection = Direction.East;
                                break;
                            case Direction.South:
                                rob.currentDirection = Direction.West;
                                break;
                            case Direction.West:
                                rob.currentDirection = Direction.North;
                                break;
                            case Direction.East:
                                rob.currentDirection = Direction.South;
                                break;
                        }
                    }
                }

                if (rob.currentNode[0] == 0 && rob.currentNode[1] == 0)
                {
                    ret[i] = "YES";
                }
                else
                {
                    ret[i] = "NO";
                }
            }

            return ret;
        }

        public class Robot
        {
            public Robot() 
            {
                currentDirection = Direction.North;
                currentNode = new int[2];
                currentNode[0] = 0;
                currentNode[1] = 0;
            }

            public Direction currentDirection { get; set; }
            public int[] currentNode { get; set; }
        }

        public enum Direction
        {
            North,
            South,
            East,
            West
        };

        [Flags]
        public enum Commands
        {
            G,
            L,
            R
        };
    }
}

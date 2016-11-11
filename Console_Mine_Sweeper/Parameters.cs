using System;

namespace Console_Mine_Sweeper
{
    class Parameters
    {
        public int[] parameters = { 10, 10, 10 };
        int cursorLocation = 0;

        string twoDigiter(int number)
        {
            if (number > 9)
            {
                return number.ToString();
            }
            else
            {
                return "0" + number.ToString();
            }
        }

        void displayLine(string lable, int parameter, int lineNum)
        {
            Console.Write(lable + " ");
            if (cursorLocation == lineNum)
            {
                Console.Write("[");
                Console.Write(twoDigiter(parameter));
                Console.WriteLine("]");
            }
            else
            {
                Console.Write(" ");
                Console.Write(twoDigiter(parameter));
                Console.WriteLine(" ");
            }
        }

        public void inputParameters()
        {
            ConsoleKeyInfo input;
            do
            {
                Console.Clear();
                displayLine("Width", parameters[0], 0);
                displayLine("Hight", parameters[1], 1);
                displayLine("Bombs", parameters[2], 2);
                Console.WriteLine("\nUse the arrow keys to move cursor and select parameters \nthen hit enter to start game\n");
                Console.WriteLine("Game controls:\n    arrow keys to move selection\n    'enter' reveals a tile\n    'f' flags a tile");
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        cursorLocation = cursorLocation > 0 ? cursorLocation - 1 : cursorLocation;
                        break;
                    case ConsoleKey.DownArrow:
                        cursorLocation = cursorLocation < 2 ? cursorLocation + 1 : cursorLocation;
                        break;
                    case ConsoleKey.LeftArrow:
                        parameters[cursorLocation] = parameters[cursorLocation] > 0 ? parameters[cursorLocation] - 1 : parameters[cursorLocation];
                        break;
                    case ConsoleKey.RightArrow:
                        parameters[cursorLocation]++;
                        break;
                }

                if (parameters[2] > parameters[0] * parameters[1])
                {
                    parameters[2] = parameters[0] * parameters[1];
                }

            } while (input.Key != ConsoleKey.Enter);
        }
    }
}

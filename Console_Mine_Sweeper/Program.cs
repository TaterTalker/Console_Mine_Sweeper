using System;

namespace Console_Mine_Sweeper
{
	class MainClass
	{

		public static void Main(string[] args)
		{
            bool quit = false;
			do
			{
                Parameters parameters = new Parameters();
				MainClass m = new MainClass();
				Board gameBoard = new Board();
				Cursor cursor = new Cursor(gameBoard);
                parameters.inputParameters();
                //gameBoard.genBoard(10, 10, 10);
                gameBoard.genBoard(parameters.parameters[0], parameters.parameters[1], parameters.parameters[2]);
                ConsoleKeyInfo input;

				do
				{
					gameBoard.drawBoard(gameBoard, cursor);
					input = Console.ReadKey();
					m.getInput(input, cursor, gameBoard);

				} while (!gameBoard.hasGameBeenWon());

				gameBoard.drawBoard(gameBoard, cursor);
				if (gameBoard.hasGameBeenLost)
				{
					Console.WriteLine("you lost");
				}
				else
				{
					Console.WriteLine("you won");
				}
				Console.WriteLine("press 'q' to quit or 'r' to restart");


                do
                {
                    input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Q)
                    {
                        quit = true;
                    }
                        
                        } while (input.Key != ConsoleKey.Q && input.Key != ConsoleKey.R);
            }while(!quit);
		}

        void getInput(ConsoleKeyInfo keyInput, Cursor cursor, Board board)
        {
            switch (keyInput.Key)
            { 
                case ConsoleKey.LeftArrow:
                    cursor.moveCursor(0);
                    break;
                case ConsoleKey.UpArrow:
                    cursor.moveCursor(1);
                    break;
                case ConsoleKey.RightArrow:
                    cursor.moveCursor(2);
                    break;
                case ConsoleKey.DownArrow:
                    cursor.moveCursor(3);
                    break;
                case ConsoleKey.Enter:
                    board.clickTile(cursor.x, cursor.y);
                    break;
                case ConsoleKey.F:
                    board.placeFlag(cursor.x, cursor.y);
                    break;
            }
        }

		void getParameters()
		{
			
		}
	}
}

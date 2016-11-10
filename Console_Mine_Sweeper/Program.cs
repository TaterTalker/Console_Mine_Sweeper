using System;

namespace Console_Mine_Sweeper
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            Board gameBoard = new Board();
            gameBoard.genBoard(10, 10, 10);
            gameBoard.drawBoard(gameBoard);
            Console.WriteLine();
            Console.ReadLine();
		}
	}
}

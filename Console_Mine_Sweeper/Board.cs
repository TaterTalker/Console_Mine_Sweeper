using System;
namespace Console_Mine_Sweeper
{
    public class Board
    {
        Tile[,] tiles;

        public Board()
        {
            //lmao
        }

        public void genBoard(int x, int y, int numBombs){
            Random rng = new Random();
            tiles = new Tile[x,y];

            for (int i = 0; i < x; i++)
            {
                for (int o = 0; o < x; o++)
                {
                    tiles[i, o] = new Tile();
                }
            }


            for (int i = 0; i < numBombs; i++)
            {
                int bombX;
                int bombY;
                do
                {
                    bombX = rng.Next(0, x);
                    bombY = rng.Next(0, y);
                } while (tiles[bombX, bombY].isBomb == true);

                tiles[bombX, bombY].isBomb = true;
            }
        }

        public void drawBoard(Board gameBoard)
        {
            Console.Clear();
            for (int i = 0; i < (tiles.GetLength(1)); i++)
            {
                for (int o = 0; o < (tiles.GetLength(0)); o++)
                {
                    Console.Write(tiles[i,o].tileIcon());
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}

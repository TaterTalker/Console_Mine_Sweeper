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

        public int width;
        public int height;
        public bool hasGameBeenLost = false;

        public void clickTile(int x, int y)
        {
            tiles[x, y].isRevealed = true;
            cascadeReveals(x, y);
            if (tiles[x, y].isBomb)
            {
                foreach (Tile t in tiles)
                {
                    t.isRevealed = true;
                }
                hasGameBeenLost = true;
            }
        }

        public bool hasGameBeenWon()
        {
            bool tmp = true;
            foreach (Tile t in tiles)
            {
                if (!t.isRevealed && !t.isBomb)
                {
                    tmp = false;
				}
            }
			if (tmp)
			{
				foreach (Tile t in tiles)
				{
					t.isRevealed = true;
				}
			}
            return tmp;
        }

        public void generateNumbers()
        {
            for (int y = 0; y < (tiles.GetLength(1)); y++)
            {
                for (int x = 0; x < (tiles.GetLength(0)); x++)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        for (int o = -1; o < 2; o++)
                        {
                            try
                            {
                                if (tiles[x + o, y + i].isBomb == true)
                                {
                                    tiles[x, y].bombCount++;
                                }
                            }
                            catch (Exception e) { }
                        }
                    }
                }
            }
        }

        public void cascadeReveals(int x, int y)
        {
            for (int i = -1; i < 2; i++){
                for (int o = -1; o < 2; o++)
                {
                    try
                    {
                        if (tiles[x + o, y + i].bombCount == 0 && tiles[x + o, y + i].isBomb == false && tiles[x + o, y + i].isRevealed == false)
                        {
                            tiles[x + o, y + i].isRevealed = true;
                            cascadeReveals(x + o, y + i);
                        }
                        else if (tiles[x + o, y + i].isBomb == false && tiles[x + o, y + i].isRevealed == false)
                        {
                            tiles[x + o, y + i].isRevealed = true;
                        }
                    }
                    catch (Exception e) { }
            }
            }
        }

        public void placeFlag(int x, int y)
        {
            tiles[x, y].isFlagged = !tiles[x, y].isFlagged;
        }

        public void genBoard(int x, int y, int numBombs){
            width = x;
            height = y;
            Random rng = new Random();
            tiles = new Tile[width,height];

            for (int i = 0; i < height; i++)
            {
                for (int o = 0; o < width; o++)
                {
                    tiles[o, i] = new Tile();
                }
            }


            for (int i = 0; i < numBombs; i++)
            {
                int bombX;
                int bombY;
                do
                {
                    bombX = rng.Next(0, width);
                    bombY = rng.Next(0, height);
                } while (tiles[bombX, bombY].isBomb == true);

                tiles[bombX, bombY].isBomb = true;
            }
            generateNumbers();
        }

        public void drawBoard(Board gameBoard, Cursor cursor)
        {
            Console.Clear();
            for (int i = 0; i < (tiles.GetLength(1)); i++)
            {
                for (int o = 0; o < (tiles.GetLength(0)); o++)
                {
                    if (o == 0 && !(cursor.x == o && cursor.y == i))
                    {
                        Console.Write(" ");
                    }
                    else if (o==0)
                    {
                        Console.Write("[");
                    }

                    Console.Write(tiles[o,i].tileIcon());

                    if (cursor.x == o && cursor.y == i)
                    {
                        Console.Write("]");
                    }
                    else if (cursor.x == o + 1 && cursor.y == i)
                    {
                        Console.Write("[");
                    }
                    else 
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

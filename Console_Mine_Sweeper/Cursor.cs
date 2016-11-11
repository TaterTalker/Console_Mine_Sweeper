using System;
namespace Console_Mine_Sweeper
{
    public class Cursor
    {
        public int x;
        public int y;
        Board gameBoard;

        public Cursor(Board board)
        {
            x = 0;
            y = 0;
            gameBoard = board;
        }


        public void moveCursor(int direction)
        {
            switch (direction)
            {
                //0=left, 1=up, 2=right, 3=down
                case 0:
                    if (x > 0)
                    {
                        x--;
                    }
                    break;
                    
                case 1:
                    if (y > 0)
                    {
                        y--;
                    }
                    break;
                    
                case 2:
                    if (x < gameBoard.width-1)
                    {
                        x++;
                    }
                    break;
                    
                case 3:
                    if (y < gameBoard.height - 1)
                    {
                        y++;
                    }
                    break;
            }
        }
    }
}

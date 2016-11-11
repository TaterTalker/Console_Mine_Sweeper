using System;
namespace Console_Mine_Sweeper
{

    public class Tile
    {

        public bool isBomb = false;
        public bool isRevealed = false;
        public int bombCount = 0;
        public bool isFlagged = false;

        public string tileIcon()
        {
            if (isFlagged&&!isRevealed)
            {
                return "!";
            }
            else if (isRevealed == false)
            {
                return "#";
            }
            else if (isBomb)
            {
                return "B";
            }
            else {
                return bombCount.ToString();
            }
        }


        public Tile()
        {
        }
    }
}

using System;
namespace Console_Mine_Sweeper
{

    public class Tile
    {

        public bool isBomb = false;
        public bool isRevealed = false;
        public int bombCount()
        {
            return 0;
        }
        public string tileIcon()
        {
            if (isBomb)
            {
                return "B";
            }
            else {
                return "0";
            }
        }


        public Tile()
        {
        }
    }
}

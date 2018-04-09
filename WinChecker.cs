using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class WinChecker
    {
        public int PlayerStep { get; set; } = 0; // 1 - first player's step, 2 - second player's step
        private int IsWin = 0; // 1 - first player's win, 2 - second player's win
        private bool IsDesrtoyed;

        public void CheckWin(Ships[] ships)
        {
            for(int index = 0; index < ships.Length; index++) // Checking ships on damage
            {
                for(int index2 = 0; index2 < ships[index].points.Length; index2++) // Checking decks of ships on damage
                {
                    if (ships[index].points[index2].typeofpoint == 2)
                    {
                        IsDesrtoyed = true; // Deck damaged --> checking continue
                    }

                    else
                    {
                        IsDesrtoyed = false; // Deck don't damaged --> end of cheking
                        break;
                    }
                }
                if (IsDesrtoyed == false)
                    break;
            }

            if (IsDesrtoyed == true) // All decks damaged --> all ships damaged --> WIN
            {
                if (PlayerStep == 1)
                    IsWin = 1;
                else if (PlayerStep == 2)
                    IsWin = 2;
            }

            else if (IsDesrtoyed == false) // Many decks don't damaged --> Not WIN
                IsWin = 0;
        }

        public void Win()
        {
            if (IsWin == 1)
                Console.WriteLine("1 PLAYER WINS!!!");
            else if (IsWin == 2)
                Console.WriteLine("2 PLAYER WINS!!!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class PlayerInput
    {
        private string playeranswer;
        private string[] playeranswers;

        public void Preparation(Point[] points) // Set positions for the ships
        {

        }

        public void GetPlayerInput()
        {
            Console.WriteLine("Write coordinates for your shoot. (Letter, number)");
            playeranswer = Console.ReadLine();
            playeranswers = playeranswer.Split(',');
        }
    }
}

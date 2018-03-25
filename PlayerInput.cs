using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class PlayerInput
    {
        private int letter;
        private int number;
        private string playeranswer;
        private string[] playeranswers;

        public void Preparation(Point[,] points) // Set positions for the ships
        {

        }

        public void GetPlayerInput(Point[,] points)
        {
            Console.WriteLine("Write coordinates for your shoot. (Letter, number)");
            playeranswer = Console.ReadLine();
            playeranswers = playeranswer.Split(',');
            CoordinatesToPoint(playeranswers);
            points[letter, number].Shot();
            
        }

        private void CoordinatesToPoint(string[] playeranswers) // Read input and convert them in point.
        {
            switch(playeranswers[0]) // points[letter,]
            {
                case "A":
                    letter = 0;
                    break;
                case "B":
                    letter = 1;
                    break;
                case "C":
                    letter = 2;
                    break;
                case "D":
                    letter = 3;
                    break;
                case "E":
                    letter = 4;
                    break;
                case "F":
                    letter = 5;
                    break;
                case "G":
                    letter = 6;
                    break;
                case "H":
                    letter = 7;
                    break;
                case "I":
                    letter = 8;
                    break;
                case "J":
                    letter = 9;
                    break;
            }
            number = Convert.ToInt32(playeranswers[1]); // points[,number]

        }
    }
}

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
        private bool WasDamaged = false;

        public void Preparation(Point[,] points, Ships[] ships) // Set positions for the ships
        {
            Console.WriteLine("Choose the positions for 4 1-deck ships. Write 4 coordinates like this:\"A1,A2,A3,A4\".");
            ChoosePositions(points, ships, 4);
            Console.WriteLine("Choose the positions for 3 2-deck ships. Write 6 coordinates like this:\"A1,A2,A3,A4\".");
            ChoosePositions(points, ships, 3);
            Console.WriteLine("Choose the positions for 2 3-deck ships. Write 6 coordinates like this:\"A1,A2,A3,A4\".");
            ChoosePositions(points, ships, 2);
            Console.WriteLine("Choose the positions for 1 4-deck ships. Write 4 coordinates like this:\"A1,A2,A3,A4\".");
            ChoosePositions(points, ships, 1);
        }

        public void GetPlayerInput(Point[,] points, Point[,] pointsforview, Point[,] playerpoints)
        {
            do
            {
                Console.WriteLine("Your turn:");
                Console.WriteLine("Write coordinates for your shoot. (Letter,number)");
                playeranswer = Console.ReadLine();
                playeranswers = playeranswer.Split(",");
                CoordinatesToPoint(playeranswers);
                points[letter, number].Shot();
                pointsforview[letter, number].typeofpoint = points[letter, number].typeofpoint;

                // Render
                Console.Clear();
                Point.SetStringsForPoints(pointsforview);
                Renderer.Render(playerpoints);
                Renderer.Render(pointsforview);
                //

                if (points[letter, number].typeofpoint == 2) // Ship --> Damaged
                    WasDamaged = true;

                else if (points[letter, number].typeofpoint == 3) // Empty --> Miss
                    WasDamaged = false;

            } while (WasDamaged == true);
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

            switch (Convert.ToInt32(playeranswer[1])) // points[,number]
            {
                case 1:
                    number = 0;
                    break;
                case 2:
                    number = 1;
                    break;
                case 3:
                    number = 2;
                    break;
                case 4:
                    number = 3;
                    break;
                case 5:
                    number = 4;
                    break;
                case 6:
                    number = 5;
                    break;
                case 7:
                    number = 6;
                    break;
                case 8:
                    number = 7;
                    break;
                case 9:
                    number = 8;
                    break;
                case 10:
                    number = 9;
                    break;
            }
        }

        private void CoordinatesToPoint(string playeranswer) // Read input and convert them in point.
        {
            switch (playeranswer[0]) // points[letter,]
            {
                case 'A':
                    letter = 0;
                    break;
                case 'B':
                    letter = 1;
                    break;
                case 'C':
                    letter = 2;
                    break;
                case 'D':
                    letter = 3;
                    break;
                case 'E':
                    letter = 4;
                    break;
                case 'F':
                    letter = 5;
                    break;
                case 'G':
                    letter = 6;
                    break;
                case 'H':
                    letter = 7;
                    break;
                case 'I':
                    letter = 8;
                    break;
                case 'J':
                    letter = 9;
                    break;
            }

            if (playeranswer.Length == 3)
            {
                number = 9;
            }

            else
            {
                switch (playeranswer[1]) // points[,number]
                {
                    case '1':
                        number = 0;
                        break;
                    case '2':
                        number = 1;
                        break;
                    case '3':
                        number = 2;
                        break;
                    case '4':
                        number = 3;
                        break;
                    case '5':
                        number = 4;
                        break;
                    case '6':
                        number = 5;
                        break;
                    case '7':
                        number = 6;
                        break;
                    case '8':
                        number = 7;
                        break;
                    case '9':
                        number = 8;
                        break;
                }
            }
        }

        private void ChoosePositions(Point[,] points, Ships[] ships, int numberofships)
        {
            int pindex = 0;
            int pindex2 = 0;

            switch(numberofships)
            {
                case 4: // 4 1-deck ships
                    pindex = 0;
                    break;

                case 3: // 3 2-deck ships
                    pindex = 4;
                    pindex2 = 0;
                    break;

                case 2: // 2 3-deck ships
                    pindex = 7;
                    pindex2 = 0;
                    break;

                case 1: // 1 4-deck ship
                    pindex = 9;
                    pindex2 = 0;
                    break;

            }
            
            string answer = Console.ReadLine(); // A1,A2,A3
            string[] answers = answer.Split(","); // {A1}, {A2}, {A3}
            for (int index = 0; index < answers.Length; index++)
            {
                CoordinatesToPoint(answers[index]);
                points[letter, number].typeofpoint = 1;

                switch(numberofships)
                {
                    case 4:
                        RefOfShipsAndPoints(ref ships[pindex].points[0], ref points[letter, number]); // ship0, ship1, ship2, ship3
                        pindex++;
                        break;

                    case 3:
                        RefOfShipsAndPoints(ref ships[pindex].points[pindex2], ref points[letter, number]); // ship4, ship5, ship6
                        if (pindex2 == 0)
                            pindex2 = 1;
                        else if (pindex2 == 1)
                            pindex++;
                        break;

                    case 2:
                        RefOfShipsAndPoints(ref ships[pindex].points[pindex2], ref points[letter, number]); // ship7, ship8
                        if (pindex2 == 0)
                            pindex2 = 1;
                        else if (pindex2 == 1)
                            pindex2 = 2;
                        else if (pindex2 == 2 && pindex == 7)
                            pindex++;
                        break;

                    case 1:
                        RefOfShipsAndPoints(ref ships[pindex].points[pindex2], ref points[letter, number]); // ship9
                        pindex2++;
                        break;
                }
            }
        }

        private void RefOfShipsAndPoints(ref Point point1, ref Point point2)
        {
            point1 = point2;
        }
    }
}

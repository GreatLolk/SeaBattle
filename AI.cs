using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeaBattle
{
    class AI
    {
        private Random rnd = new Random();
        private int coordinate1;
        private int coordinate2;
        private bool WasDamaged = false;
        private int shipsdecks = 1;

        public void AIShot(Point[,] points, Point[,] aipointsforview)
        {
            while (true)
            {
                if (WasDamaged == false) // CHOOSE NEW TARGET
                {
                    coordinate1 = rnd.Next(0, 9);
                    coordinate2 = rnd.Next(0, 9);
                }

                switch (points[coordinate1, coordinate2].typeofpoint)
                {
                    case 0: // Empty
                        points[coordinate1, coordinate2].typeofpoint = 3; // Empty --> Miss
                        WasDamaged = false;
                        break;

                    case 1: // Ship
                        points[coordinate1, coordinate2].typeofpoint = 2; // Ship --> Damaged
                        WasDamaged = false;

                        Console.WriteLine("Enemy turn.");
                        Thread.Sleep(2000);

                        // Render
                        Console.Clear();
                        Point.SetStringsForPoints(points);
                        Renderer.Render(points);
                        Renderer.Render(aipointsforview);
                        //

                        // CHECKING EMPTY POINTS --> CONTINUE SHOOT or CHOOSE NEW TARGET
                        if (coordinate1 == 0)
                        {
                            if (coordinate2 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate2 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if (coordinate1 == 9)
                        {
                            if (coordinate2 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate2 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if (coordinate2 == 0)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if (coordinate2 == 9)
                        {
                            if (coordinate1 == 0)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else if (coordinate1 == 9)
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }

                            else
                            {
                                if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                    continue; // CHOOSE NEW TARGET
                            }
                        }

                        else if(coordinate1 != 0 && coordinate1 != 9 && coordinate2 != 0 && coordinate2 != 9)
                        {
                            if (points[coordinate1, coordinate2].typeofpoint == 0 || points[coordinate1 + 1, coordinate2].typeofpoint == 0 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 || points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                            {
                                continue; // CHOOSE NEW TARGET
                            }
                        }
                        //CHECKING EMPTY POINTS --> CONTINUE SHOOT or CHOOSE NEW TARGET 
                        
                        // CONTINUE SHOOT --> WHERE SHOOT?

                                                                     // ?Ship                                                                                                                                                                                                
                            if(coordinate1 == 9 && coordinate2 == 0) // Ship -- ?Ship
                            {
                                switch (rnd.Next(1, 2))
                                {
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if(points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;                                        
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                           else if(coordinate1 == 9 && coordinate2 == 9)
                            {                                 // ?Ship
                                switch(rnd.Next(1,2)) // ?Ship -- Ship
                                {
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 == 0 && coordinate2 == 0)
                            {
                                switch (rnd.Next(1, 2)) // Ship -- ?Ship
                                {                       // ?Ship
                                    case 1:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                            else if(coordinate1 == 0 && coordinate2 == 9)
                            {                           // ?Ship -- Ship
                                switch (rnd.Next(1, 2)) //         ?Ship
                                {
                                    case 1:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                            else if(coordinate1 == 0 && coordinate2 > 0 && coordinate2 < 9)
                            {
                                switch(rnd.Next(1,3)) // ?Ship -- Ship -- ?Ship
                                {                     //         ?Ship
                                    case 1:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 == 9 && coordinate2 > 0 && coordinate2 < 9)
                            {
                                switch(rnd.Next(1,3)) //        ?Ship
                                {                    // ?Ship -- Ship -- ?Ship
                                    case 1:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                }
                            }

                            else if(coordinate1 > 0 && coordinate1 < 9 && coordinate2 == 0)
                            {                         // ?Ship
                                switch(rnd.Next(1,3)) //  Ship -- ?Ship
                                {                     // ?Ship
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
                                            coordinate2 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 > 0 && coordinate1 < 9 && coordinate2 == 9)
                            {                         //         ?Ship
                                switch(rnd.Next(1,3)) // ?Ship -- Ship
                                {                     //         ?Ship
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                }
                            }

                            else if(coordinate1 > 0 && coordinate1 < 9 && coordinate2 > 0 && coordinate2 < 9)
                            {                         //         ?Ship
                                switch(rnd.Next(1,4)) // ?Ship -- Ship -- ?Ship
                                {                     //         ?Ship
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                        {
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                            coordinate2 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 3:
                                        if (points[coordinate1 - 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 - 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                            coordinate1 -= 1;
                                            WasDamaged = true;
                                        }
                                        break;

                                    case 4:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                        {
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                            coordinate1 += 1;
                                            WasDamaged = true;
                                        }
                                        break;
                                    }
                                }

                        // CONTINUE SHOOT --> WHERE SHOOT?

                            break;
                }
                        
                        
                      

                Console.WriteLine("Enemy turn.");
                Thread.Sleep(2000);

                // Render
                Console.Clear();
                Point.SetStringsForPoints(points);
                Renderer.Render(points);
                Renderer.Render(aipointsforview);
                //

                if (WasDamaged == true)
                    continue;

                break;
            
            
            }
        }

        public void AIPreparation(Point[,] points, Ships[] ships)
        {
            switch (rnd.Next(1,10))
            {
                case 1:
                    // 1-deck ships
                    points[1, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[1, 1]);
                    points[9, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[9, 0]);
                    points[2, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[2, 8]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 9]);
                    //

                    // 2-deck ships
                    points[0, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 7]);
                    points[0, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[0, 8]);
                    points[1, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[1, 4]);
                    points[2, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[2, 4]);
                    points[5, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[5, 0]);
                    points[6, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[6, 0]);
                    //

                    // 3-deck ships
                    points[4, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[4, 6]);
                    points[4, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[4, 7]);
                    points[4, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[4, 8]);
                    points[7, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[7, 6]);
                    points[8, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[8, 6]);
                    points[9, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[9, 6]);
                    //

                    // 4-deck ship
                    points[5, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[5, 2]);
                    points[6, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[6, 2]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[7, 2]);
                    points[8, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[8, 2]);
                    //
                    break;

                case 2:
                    // 1-deck ships
                    points[5, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[5, 4]);
                    points[1, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[1, 9]);
                    points[3, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[3, 9]);
                    points[9, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[9, 7]);
                    //

                    // 2-deck ships
                    points[0, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 0]);
                    points[1, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[1, 0]);
                    points[7, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[7, 0]);
                    points[8, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[8, 0]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[7, 2]);
                    points[8, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[8, 2]);
                    //

                    // 3-deck ships
                    points[0, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[0, 3]);
                    points[0, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[0, 4]);
                    points[0, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[0, 5]);
                    points[3, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[3, 6]);
                    points[4, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[4, 6]);
                    points[5, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[5, 6]);
                    //

                    // 4-deck ship
                    points[6, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[6, 9]);
                    points[7, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[7, 9]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[8, 9]);
                    points[9, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[9, 9]);
                    //
                    break;

                case 3:
                    // 1-deck ships
                    points[3, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[3, 8]);
                    points[7, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[7, 4]);
                    points[9, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[9, 4]);
                    points[9, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[9, 9]);
                    //

                    // 2-deck ships
                    points[4, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 7]);
                    points[5, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[0, 8]);
                    points[5, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[1, 4]);
                    points[5, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[2, 4]);
                    points[9, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[5, 0]);
                    points[9, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[6, 0]);
                    //

                    // 3-deck ships
                    points[4, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[4, 1]);
                    points[5, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[5, 1]);
                    points[6, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[6, 1]);
                    points[7, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[7, 7]);
                    points[8, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[8, 7]);
                    points[9, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[9, 7]);
                    //

                    // 4-deck ship
                    points[1, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[1, 3]);
                    points[2, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[2, 3]);
                    points[3, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[3, 3]);
                    points[4, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[4, 3]);
                    //
                    break;

                case 4:
                    // 1-deck ships
                    points[3, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[3, 1]);
                    points[9, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[9, 1]);
                    points[7, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[7, 3]);
                    points[8, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 7]);
                    //

                    // 2-deck ships
                    points[0, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 8]);
                    points[0, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[0, 9]);
                    points[4, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[4, 9]);
                    points[5, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[5, 9]);
                    points[6, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[6, 6]);
                    points[6, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[6, 7]);
                    //

                    // 3-deck ships
                    points[3, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[3, 3]);
                    points[4, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[4, 3]);
                    points[5, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[5, 3]);
                    points[2, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[2, 7]);
                    points[3, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[3, 7]);
                    points[4, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[4, 7]);
                    //

                    // 4-deck ship
                    points[0, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[0, 1]);
                    points[0, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[0, 2]);
                    points[0, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[0, 3]);
                    points[0, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[0, 4]);
                    //
                    break;

                case 5:
                    // 1-deck ships
                    points[1, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[1, 4]);
                    points[4, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[4, 5]);
                    points[9, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[9, 4]);
                    points[9, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[9, 6]);
                    //

                    // 2-deck ships
                    points[2, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[2, 0]);
                    points[3, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[3, 0]);
                    points[6, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[6, 7]);
                    points[6, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[6, 8]);
                    points[8, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[8, 8]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[8, 9]);
                    //

                    // 3-deck ships
                    points[7, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[7, 1]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[7, 2]);
                    points[7, 3].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[7, 3]);
                    points[2, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[2, 7]);
                    points[2, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[2, 8]);
                    points[2, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[2, 9]);
                    //

                    // 4-deck ship
                    points[0, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[0, 6]);
                    points[0, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[0, 7]);
                    points[0, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[0, 8]);
                    points[0, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[0, 9]);
                    //
                    break;

                case 6:
                    // 1-deck ships
                    points[0, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[0, 0]);
                    points[5, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[5, 2]);
                    points[9, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[9, 0]);
                    points[8, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 4]);
                    //

                    // 2-deck ships
                    points[0, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 7]);
                    points[1, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[1, 7]);
                    points[1, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[1, 9]);
                    points[2, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[2, 9]);
                    points[8, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[8, 6]);
                    points[8, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[8, 7]);
                    //

                    // 3-deck ships
                    points[3, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[3, 0]);
                    points[4, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[4, 0]);
                    points[5, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[5, 0]);
                    points[4, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[4, 4]);
                    points[5, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[5, 4]);
                    points[6, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[6, 4]);
                    //

                    // 4-deck ship
                    points[5, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[5, 6]);
                    points[6, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[6, 7]);
                    points[7, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[7, 8]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[8, 9]);
                    //
                    break;

                case 7:
                    // 1-deck ships
                    points[0, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[0, 5]);
                    points[5, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[5, 0]);
                    points[7, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[7, 0]);
                    points[8, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 0]);
                    //

                    // 2-deck ships
                    points[3, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[3, 4]);
                    points[3, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[3, 5]);
                    points[5, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[5, 4]);
                    points[5, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[5, 5]);
                    points[7, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[7, 0]);
                    points[8, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[8, 0]);
                    //

                    // 3-deck ships
                    points[1, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[1, 7]);
                    points[2, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[2, 7]);
                    points[3, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[3, 7]);
                    points[5, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[5, 2]);
                    points[6, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[6, 2]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[7, 2]);
                    //

                    // 4-deck ship
                    points[8, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[8, 4]);
                    points[8, 5].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[8, 5]);
                    points[8, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[8, 6]);
                    points[8, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[8, 7]);
                    //
                    break;

                case 8:
                    // 1-deck ships
                    points[1, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[1, 1]);
                    points[9, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[9, 0]);
                    points[2, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[2, 8]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 9]);
                    //

                    // 2-deck ships
                    points[0, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 7]);
                    points[0, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[0, 8]);
                    points[1, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[1, 4]);
                    points[2, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[2, 4]);
                    points[5, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[5, 0]);
                    points[6, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[6, 0]);
                    //

                    // 3-deck ships
                    points[4, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[4, 6]);
                    points[4, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[4, 7]);
                    points[4, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[4, 8]);
                    points[7, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[7, 6]);
                    points[8, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[8, 6]);
                    points[9, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[9, 6]);
                    //

                    // 4-deck ship
                    points[5, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[5, 2]);
                    points[6, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[6, 2]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[7, 2]);
                    points[8, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[8, 2]);
                    //
                    break;

                case 9:
                    // 1-deck ships
                    points[1, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[1, 1]);
                    points[9, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[9, 0]);
                    points[2, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[2, 8]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 9]);
                    //

                    // 2-deck ships
                    points[0, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 7]);
                    points[0, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[0, 8]);
                    points[1, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[1, 4]);
                    points[2, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[2, 4]);
                    points[5, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[5, 0]);
                    points[6, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[6, 0]);
                    //

                    // 3-deck ships
                    points[4, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[4, 6]);
                    points[4, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[4, 7]);
                    points[4, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[4, 8]);
                    points[7, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[7, 6]);
                    points[8, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[8, 6]);
                    points[9, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[9, 6]);
                    //

                    // 4-deck ship
                    points[5, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[5, 2]);
                    points[6, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[6, 2]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[7, 2]);
                    points[8, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[8, 2]);
                    //
                    break;

                case 10:
                    // 1-deck ships
                    points[1, 1].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[0].points[0], ref points[1, 1]);
                    points[9, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[1].points[0], ref points[9, 0]);
                    points[2, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[2].points[0], ref points[2, 8]);
                    points[8, 9].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[3].points[0], ref points[8, 9]);
                    //

                    // 2-deck ships
                    points[0, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[0], ref points[0, 7]);
                    points[0, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[4].points[1], ref points[0, 8]);
                    points[1, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[0], ref points[1, 4]);
                    points[2, 4].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[5].points[1], ref points[2, 4]);
                    points[5, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[0], ref points[5, 0]);
                    points[6, 0].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[6].points[1], ref points[6, 0]);
                    //

                    // 3-deck ships
                    points[4, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[0], ref points[4, 6]);
                    points[4, 7].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[1], ref points[4, 7]);
                    points[4, 8].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[7].points[2], ref points[4, 8]);
                    points[7, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[0], ref points[7, 6]);
                    points[8, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[1], ref points[8, 6]);
                    points[9, 6].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[8].points[2], ref points[9, 6]);
                    //

                    // 4-deck ship
                    points[5, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[0], ref points[5, 2]);
                    points[6, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[1], ref points[6, 2]);
                    points[7, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[2], ref points[7, 2]);
                    points[8, 2].typeofpoint = 1;
                    RefOfShipsAndPoints(ref ships[9].points[3], ref points[8, 2]);
                    //
                    break;
            }
        }

        private void RefOfShipsAndPoints(ref Point point1, ref Point point2)
        {
            point1 = point2;
        }
    }
        
}


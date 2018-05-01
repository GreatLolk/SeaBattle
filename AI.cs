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
            }
        }

        private void RefOfShipsAndPoints(ref Point point1, ref Point point2)
        {
            point1 = point2;
        }
    }
        
}


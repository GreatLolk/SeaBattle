using System;
using System.Collections.Generic;
using System.Text;

 namespace SeaBattle
 {
    class AI
    {
        private Random rnd = new Random();
        private int coordinate1;
        private int coordinate2;
        private bool WasDamaged = false;

        public void AIShot(Point[,] points)
        {
            while (true)
            {
                coordinate1 = rnd.Next(1, 10);
                coordinate2 = rnd.Next(1, 10);

                switch (points[coordinate1, coordinate2].typeofpoint)
                {
                    case 0: // Empty
                        points[coordinate1, coordinate2].typeofpoint = 3; // Miss
                        break;

                    case 1:
                        points[coordinate1, coordinate2].typeofpoint = 2; // Ship --> Damaged
                                                                                                                                                                                                                                                                        // Empty
                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0 && points[coordinate1 - 1, coordinate2].typeofpoint == 0 && points[coordinate1, coordinate2 + 1].typeofpoint == 0  && points[coordinate1, coordinate2 - 1].typeofpoint == 0) // Empty -- Ship -- Empty
                        {                                                                                                                                                                                                                                               // Empty
                            break;
                        }
                                                                                                                                                                                                                                                                             // ?Ship
                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 1 || points[coordinate1 - 1, coordinate2].typeofpoint == 1  || points[coordinate1, coordinate2 + 1].typeofpoint == 1 || points[coordinate1, coordinate2 - 1].typeofpoint == 11) // ?Ship -- Ship -- ?Ship
                        {                                            // ?Ship                                                                                                                                                                                                // ?Ship
                            if(coordinate1 == 9 && coordinate2 == 0) // Ship -- ?Ship
                            {
                                switch (rnd.Next(1, 2))
                                {
                                    case 1:
                                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 3;
                                        else if(points[coordinate1 + 1, coordinate2].typeofpoint == 1)
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
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
                                            points[coordinate1 + 1, coordinate2].typeofpoint = 2;
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
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
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 + 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 + 1].typeofpoint == 1)
                                            points[coordinate1, coordinate2 + 1].typeofpoint = 2;
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
                                            points[coordinate1 - 1, coordinate2].typeofpoint = 2;
                                        break;

                                    case 2:
                                        if (points[coordinate1, coordinate2 - 1].typeofpoint == 0)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 3;
                                        else if (points[coordinate1, coordinate2 - 1].typeofpoint == 1)
                                            points[coordinate1, coordinate2 - 1].typeofpoint = 2;
                                        break;

                                }
                            }
                        }
                        break;
                      }
                if (WasDamaged == true)
                    continue;

                break;
            }

                
        }
    }
}


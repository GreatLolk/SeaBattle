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

                    case 1:                                                                                                                                                                                                                                                                                                                                               // Empty                                                                                                                                                                          
                        if (points[coordinate1 + 1, coordinate2].typeofpoint == 0 && coordinate1 + 1 != 11 && points[coordinate1 - 1, coordinate2].typeofpoint == 0 && coordinate1 - 1 != -1 && points[coordinate1, coordinate2 + 1].typeofpoint == 0 && coordinate2 + 1 != 11 && points[coordinate1, coordinate2 - 1].typeofpoint == 0 && coordinate2 - 1 != -1) // Empty -- Ship -- Empty
                        {                                                                                                                                                                                                                                                                                                                                                 // Empty
                            break;
                        }

                        else if (points[coordinate1 + 1, coordinate2].typeofpoint == 0 && coordinate1 + 1 != 11 || points[coordinate1 - 1, coordinate2].typeofpoint == 0 && coordinate1 - 1 != -1 || points[coordinate1, coordinate2 + 1].typeofpoint == 0 && coordinate2 + 1 != 11 || points[coordinate1, coordinate2 - 1].typeofpoint == 0 && coordinate2 - 1 != -1)
                        {
                            switch (rnd.Next(1, 4))
                            {
                                case 0:
                                    if (coordinate1 != 11)
                                    {

                                    }
                                    break;
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

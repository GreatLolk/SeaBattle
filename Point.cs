using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Point
    {
        public int typeofpoint = 0;
        public string stringofpoint  = ".";

        public static void SetStringsForPoints(Point[,] points)
        {
            foreach (Point point in points)
            {
                if (point.typeofpoint == 0)
                    point.stringofpoint = "."; // Empty

                else if (point.typeofpoint == 1)
                    point.stringofpoint = "*"; // Ship

                else if (point.typeofpoint == 2)
                    point.stringofpoint = "X"; // Damaged

                else if (point.typeofpoint == 3)
                    point.stringofpoint = "O"; // Miss
            }
        }

        public void Shot()
        {
            if (typeofpoint == 0)
            {
                typeofpoint = 3; // Empty -> Miss
            }

            else if (typeofpoint == 1)
            {
                typeofpoint = 2; // Ship -> Damaged
            }
        }
    }
}

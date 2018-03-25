using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Point
    {
        public int typeofpoint = 0;
        public string stringofpoint = ".";

        public void SetStringsForPoints(Point[,] points)
        {
            foreach (Point point in points)
            {
                if (typeofpoint == 0)
                    stringofpoint = "."; // Empty

                else if (typeofpoint == 1)
                    stringofpoint = "*"; // Ship

                else if (typeofpoint == 2)
                    stringofpoint = "X"; // Damaged

                else if (typeofpoint == 3)
                    stringofpoint = "O"; // Miss
            }
        }

        public void Shot()
        {
            if (typeofpoint == 0)
            {
                stringofpoint = "O"; // Empty -> Miss
                typeofpoint = 3;
            }

            else if (typeofpoint == 1)
            {
                stringofpoint = "X"; // Ship -> Damaged
                typeofpoint = 2;
            }
        }
    }
}

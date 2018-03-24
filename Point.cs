using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Point
    {
        public int typeofpoint = 0;

        public void RenderPoint(Point point)
        {
            if (typeofpoint == 0)
                Console.Write("."); // Empty

            else if (typeofpoint == 1)
                Console.Write("*"); // Ship

            else if (typeofpoint == 2)
                Console.Write("X"); // Damaged

            else if (typeofpoint == 3)
                Console.Write("O"); // Miss
        }
    }
}

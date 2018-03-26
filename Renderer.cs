using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Renderer
    {
        public void Render(Point[,] points)
        {
            Console.WriteLine("        A    B    C    D    E   F    G    H   I    J "); // 1 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 2 stirng
            Console.WriteLine($" 1  |  {points[0,0].stringofpoint}   |    {points[0, 1].stringofpoint}   |   {points[0, 2].stringofpoint}   |   {points[0, 3].stringofpoint}    |  {points[0, 4].stringofpoint}  |   {points[0, 5].stringofpoint} |   {points[0, 6].stringofpoint}    |  {points[0, 7].stringofpoint}    |   {points[0, 8].stringofpoint}   |   {points[0, 9].stringofpoint}   |"); // 3 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 4 string
            Console.WriteLine($" 1  |  {points[1, 0].stringofpoint}   |    {points[1, 1].stringofpoint}   |   {points[1, 2].stringofpoint}   |   {points[1, 3].stringofpoint}    |  {points[1, 4].stringofpoint}  |   {points[1, 5].stringofpoint} |   {points[1, 6].stringofpoint}    |  {points[1, 7].stringofpoint}    |   {points[1, 8].stringofpoint}   |   {points[1, 9].stringofpoint}   |"); // 5 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 6 string
            Console.WriteLine($" 1  |  {points[2, 0].stringofpoint}   |    {points[2, 1].stringofpoint}   |   {points[2, 2].stringofpoint}   |   {points[2, 3].stringofpoint}    |  {points[2, 4].stringofpoint}  |   {points[2, 5].stringofpoint} |   {points[2, 6].stringofpoint}    |  {points[2, 7].stringofpoint}    |   {points[2, 8].stringofpoint}   |   {points[2, 9].stringofpoint}   |"); // 7 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 8 string
            Console.WriteLine($" 1  |  {points[3, 0].stringofpoint}   |    {points[3, 1].stringofpoint}   |   {points[3, 2].stringofpoint}   |   {points[3, 3].stringofpoint}    |  {points[3, 4].stringofpoint}  |   {points[3, 5].stringofpoint} |   {points[3, 6].stringofpoint}    |  {points[3, 7].stringofpoint}    |   {points[3, 8].stringofpoint}   |   {points[3, 9].stringofpoint}   |"); // 9 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 10 stirng
            Console.WriteLine($" 1  |  {points[4, 0].stringofpoint}   |    {points[4, 1].stringofpoint}   |   {points[4, 2].stringofpoint}   |   {points[4, 3].stringofpoint}    |  {points[4, 4].stringofpoint}  |   {points[4, 5].stringofpoint} |   {points[4, 6].stringofpoint}    |  {points[4, 7].stringofpoint}    |   {points[4, 8].stringofpoint}   |   {points[4, 9].stringofpoint}   |"); // 11 stirng
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 12 string
            Console.WriteLine($" 1  |  {points[5, 0].stringofpoint}   |    {points[5, 1].stringofpoint}   |   {points[5, 2].stringofpoint}   |   {points[5, 3].stringofpoint}    |  {points[5, 4].stringofpoint}  |   {points[5, 5].stringofpoint} |   {points[5, 6].stringofpoint}    |  {points[5, 7].stringofpoint}    |   {points[5, 8].stringofpoint}   |   {points[5, 9].stringofpoint}   |"); // 13 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 14 string
            Console.WriteLine($" 1  |  {points[6, 0].stringofpoint}   |    {points[6, 1].stringofpoint}   |   {points[6, 2].stringofpoint}   |   {points[6, 3].stringofpoint}    |  {points[6, 4].stringofpoint}  |   {points[6, 5].stringofpoint} |   {points[6, 6].stringofpoint}    |  {points[6, 7].stringofpoint}    |   {points[6, 8].stringofpoint}   |   {points[6, 9].stringofpoint}   |"); // 15 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 16 string
            Console.WriteLine($" 1  |  {points[7, 0].stringofpoint}   |    {points[7, 1].stringofpoint}   |   {points[7, 2].stringofpoint}   |   {points[7, 3].stringofpoint}    |  {points[7, 4].stringofpoint}  |   {points[7, 5].stringofpoint} |   {points[7, 6].stringofpoint}    |  {points[7, 7].stringofpoint}    |   {points[7, 8].stringofpoint}   |   {points[7, 9].stringofpoint}   |"); // 17 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 18 string
            Console.WriteLine($" 1  |  {points[8, 0].stringofpoint}   |    {points[8, 1].stringofpoint}   |   {points[8, 2].stringofpoint}   |   {points[8, 3].stringofpoint}    |  {points[8, 4].stringofpoint}  |   {points[8, 5].stringofpoint} |   {points[8, 6].stringofpoint}    |  {points[8, 7].stringofpoint}    |   {points[8, 8].stringofpoint}   |   {points[8, 9].stringofpoint}   |"); // 19 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 20 string
            Console.WriteLine($" 1  |  {points[9, 0].stringofpoint}   |    {points[9, 1].stringofpoint}   |   {points[9, 2].stringofpoint}   |   {points[9, 3].stringofpoint}    |  {points[9, 4].stringofpoint}  |   {points[9, 5].stringofpoint} |   {points[9, 6].stringofpoint}    |  {points[9, 7].stringofpoint}    |   {points[9, 8].stringofpoint}   |   {points[9, 9].stringofpoint}   |"); // 21 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 22 string

        }
    }
}

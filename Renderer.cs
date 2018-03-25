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
            Console.WriteLine($" 1  |  {points[0,0]}   |    {points[0, 1]}   |   {points[0, 2]}   |   {points[0, 3]}    |  {points[0, 4]}  |   {points[0, 5]} |   {points[0, 6]}    |  {points[0, 7]}    |   {points[0, 8]}   |   {points[0, 9]}   |"); // 3 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 4 string
            Console.WriteLine($" 1  |  {points[1, 0]}   |    {points[1, 1]}   |   {points[1, 2]}   |   {points[1, 3]}    |  {points[1, 4]}  |   {points[1, 5]} |   {points[1, 6]}    |  {points[1, 7]}    |   {points[1, 8]}   |   {points[1, 9]}   |"); // 5 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 6 string
            Console.WriteLine($" 1  |  {points[2, 0]}   |    {points[2, 1]}   |   {points[2, 2]}   |   {points[2, 3]}    |  {points[2, 4]}  |   {points[2, 5]} |   {points[2, 6]}    |  {points[2, 7]}    |   {points[2, 8]}   |   {points[2, 9]}   |"); // 7 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 8 string
            Console.WriteLine($" 1  |  {points[3, 0]}   |    {points[3, 1]}   |   {points[3, 2]}   |   {points[3, 3]}    |  {points[3, 4]}  |   {points[3, 5]} |   {points[3, 6]}    |  {points[3, 7]}    |   {points[3, 8]}   |   {points[3, 9]}   |"); // 9 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 10 stirng
            Console.WriteLine($" 1  |  {points[4, 0]}   |    {points[4, 1]}   |   {points[4, 2]}   |   {points[4, 3]}    |  {points[4, 4]}  |   {points[4, 5]} |   {points[4, 6]}    |  {points[4, 7]}    |   {points[4, 8]}   |   {points[4, 9]}   |"); // 11 stirng
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 12 string
            Console.WriteLine($" 1  |  {points[5, 0]}   |    {points[5, 1]}   |   {points[5, 2]}   |   {points[5, 3]}    |  {points[5, 4]}  |   {points[5, 5]} |   {points[5, 6]}    |  {points[5, 7]}    |   {points[5, 8]}   |   {points[5, 9]}   |"); // 13 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 14 string
            Console.WriteLine($" 1  |  {points[6, 0]}   |    {points[6, 1]}   |   {points[6, 2]}   |   {points[6, 3]}    |  {points[6, 4]}  |   {points[6, 5]} |   {points[6, 6]}    |  {points[6, 7]}    |   {points[6, 8]}   |   {points[6, 9]}   |"); // 15 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 16 string
            Console.WriteLine($" 1  |  {points[7, 0]}   |    {points[7, 1]}   |   {points[7, 2]}   |   {points[7, 3]}    |  {points[7, 4]}  |   {points[7, 5]} |   {points[7, 6]}    |  {points[7, 7]}    |   {points[7, 8]}   |   {points[7, 9]}   |"); // 17 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 18 string
            Console.WriteLine($" 1  |  {points[8, 0]}   |    {points[8, 1]}   |   {points[8, 2]}   |   {points[8, 3]}    |  {points[8, 4]}  |   {points[8, 5]} |   {points[8, 6]}    |  {points[8, 7]}    |   {points[8, 8]}   |   {points[8, 9]}   |"); // 19 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 20 string
            Console.WriteLine($" 1  |  {points[9, 0]}   |    {points[9, 1]}   |   {points[9, 2]}   |   {points[9, 3]}    |  {points[9, 4]}  |   {points[9, 5]} |   {points[9, 6]}    |  {points[9, 7]}    |   {points[9, 8]}   |   {points[9, 9]}   |"); // 21 string
            Console.WriteLine("---+---+---+---+---+---+---+---+---+---+---+"); // 22 string

        }
    }
}

using System;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[,] playerpoints = new Point[10, 10];
            Point[,] AIpoints = new Point[10, 10];
            Ships[] playersships = new Ships[10];
            Ships[] AIships = new Ships[10];

            for(int index = 0; index < 10; index++) // Points in points[]
            {
                for(int index2 = 0; index2 < 10; index2++)
                {
                    playerpoints[index, index2] = new Point();
                    AIpoints[index, index2] = new Point();
                }
            }

            playersships[0] = new Ships(1); // Ships in AIships[].
            playersships[1] = new Ships(1);
            playersships[2] = new Ships(1);
            playersships[3] = new Ships(1);
            playersships[4] = new Ships(2);
            playersships[5] = new Ships(2);
            playersships[6] = new Ships(2);
            playersships[7] = new Ships(3);
            playersships[8] = new Ships(3);
            playersships[9] = new Ships(4);

            AIships[0] = new Ships(1); // Ships in AIships[].
            AIships[1] = new Ships(1);
            AIships[2] = new Ships(1);
            AIships[3] = new Ships(1);
            AIships[4] = new Ships(2);
            AIships[5] = new Ships(2);
            AIships[6] = new Ships(2);
            AIships[7] = new Ships(3);
            AIships[8] = new Ships(3);
            AIships[9] = new Ships(4);

            PlayerInput playerinput1 = new PlayerInput(); // Adding PlayerInput-module.
            AI ai1 = new AI(); // Adding AI-module.
            Renderer renderer1 = new Renderer(); // Adding Renderer-module

            playerinput1.Preparation(playerpoints, playersships); // Creating ships for player.
            ai1.AIPreparation(AIpoints, AIships); // Creating ships for AI.

            renderer1.Render(playerpoints);
            renderer1.Render(AIpoints);

        }
    }
}

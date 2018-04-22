using System;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[,] playerpoints = new Point[10, 10];
            Point[,] AIpoints = new Point[10, 10];
            Point[,] AIpointsForView = new Point[10, 10];
            Ships[] playersships = new Ships[10];
            Ships[] AIships = new Ships[10];

            for(int index = 0; index < 10; index++) // Points in points[]
            {
                for(int index2 = 0; index2 < 10; index2++)
                {
                    playerpoints[index, index2] = new Point();
                    AIpoints[index, index2] = new Point();
                    AIpointsForView[index, index2] = new Point();
                }
            }

            playersships[0] = new Ships(1); // Ships in playerships[].
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
            WinChecker winchecker1 = new WinChecker(); // Adding WinChecker-module.

            playerinput1.Preparation(playerpoints, playersships); // Creating ships for player.
            ai1.AIPreparation(AIpoints, AIships); // Creating ships for AI.

            Point.SetStringsForPoints(AIpointsForView);
            Point.SetStringsForPoints(playerpoints);

            Renderer.Render(playerpoints);
            Renderer.Render(AIpointsForView);

            while(winchecker1.IsWin == 0)
            {
                playerinput1.GetPlayerInput(AIpoints, AIpointsForView, playerpoints); // Player's step.
                winchecker1.PlayerStep = 1;
                winchecker1.CheckWin(AIships);

                if(winchecker1.IsWin != 0)
                {
                    break;
                }

                ai1.AIShot(playerpoints, AIpointsForView); // AI's step.
                winchecker1.PlayerStep = 2;
                winchecker1.CheckWin(playersships);
            }

            winchecker1.Win();

            Console.ReadKey();
        }
    }
}

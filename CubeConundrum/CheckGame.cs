using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeConundrum
{
    internal class CheckGame
    {
        

        public static int CheckIfGameIsPossible(string[] games)
        {
            int possibleGameIdTally = 0;

            foreach (var game in games)
            {
                int gameId;
                string cubePulls;

                (gameId, cubePulls) = GetGameIdValue(game);
                if (IsGamePossible(cubePulls) == true)
                {
                    possibleGameIdTally += gameId;
                }
            }

            return possibleGameIdTally;
        }

        private static bool IsGamePossible(string cubePulls)
        {
            Dictionary<string, int> cubesInBag = new Dictionary<string, int>
            {
                {"red", 12 },
                {"green", 13 },
                {"blue", 14 }
            };
            bool isValidGame = false;

            string[] games = cubePulls.Split(';');

            foreach(var game in games)
            {
                string[] cubePullResult = game.Split(',');

                foreach (var cubePull in cubePullResult)
                {
                    Dictionary<string, int> gameTurn = new Dictionary<string, int>();
                    string[] cubePullValues = cubePull.Trim().Split(" ");

                    int.TryParse(cubePullValues[0], out int cubePullValue);

                    if (cubesInBag.ContainsKey(cubePullValues[1]))
                    {
                        if(cubePullValue <= cubesInBag[cubePullValues[1]])
                        {
                            isValidGame = true;
                        }
                        else
                        {
                            isValidGame = false;
                            break;
                        }
                    }
                }

                if(isValidGame == false)
                {
                    break;
                }
            }

            return isValidGame;
        }

        private static (int, string) GetGameIdValue(string game)
        {
            string[] splitLine = game.Split(':');
            string[] gameId = splitLine[0].Split(' ');

            int.TryParse(gameId[1], out int id);

            return (id, splitLine[1]);
        }
    }
}

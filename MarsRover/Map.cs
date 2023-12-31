﻿namespace MarsRover
{
    public class Map
    {
        public string[,] marsMap = {
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""},
                {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        };

        public void CreateNewMap()
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (y == 0 || y == 9)
                    {
                        marsMap.SetValue("_", y, x);
                    }
                    else if (x == 0 || x == 19)
                    {
                        marsMap.SetValue("|", y, x);
                    }
                    else
                    {
                        int randomNumber = new Random().Next(10);
                        if (randomNumber == 1)
                        {
                            marsMap.SetValue("#", y, x);
                        }
                        else
                        {
                            marsMap.SetValue(" ", y, x);
                        }
                    }
                }
            }
        }
    }
}
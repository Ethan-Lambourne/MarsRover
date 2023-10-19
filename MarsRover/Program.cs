using MarsRover;

Console.WriteLine(@"
                =====================
                WELCOME TO MARS ROVER
                =====================

Place the rover on the map and have a wander around!

Use the WASD keys to move :)

PRESS ENTER TO CONTINUE");
Console.ReadLine();

var _map = new Map();
var _rover = new Rover(_map);

_map.CreateNewMap();

bool validationLoop = true;
while (validationLoop)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            Console.Write(_map.marsMap[i, j]);
        }
        Console.WriteLine("");
    }
    Console.WriteLine("\nWhat coordinates do you want to drop the rover at?");
    Console.Write("X: ");
    int xCoordinate = GetCoordinate(true);
    Console.Write("Y: ");
    int yCoordinate = GetCoordinate(false);
    bool check = _rover.PlaceRover(xCoordinate, yCoordinate);
    if (check)
    {
        validationLoop = false;
    }
}

Console.Clear();
Console.WriteLine("Feel free to move your rover around the map! (press 'x' to exit)");

bool playLoop = true;
while (playLoop)
{
    Console.Clear();
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            Console.Write(_map.marsMap[i, j]);
        }
        Console.WriteLine("");
    }
    Console.WriteLine($"Current Coordinates [{_rover.currentXcoordinate},{10 - _rover.currentYcoordinate}]");

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.W:
            _rover.MoveRover("north");
            break;

        case ConsoleKey.S:
            _rover.MoveRover("south");
            break;

        case ConsoleKey.D:
            _rover.MoveRover("east");
            break;

        case ConsoleKey.A:
            _rover.MoveRover("west");
            break;

        case ConsoleKey.X:
            playLoop = false;
            break;
    }
}
Console.WriteLine("\nThanks for playing! Goodbye!");

int GetCoordinate(bool x)
{
    int number;
    if (x)
    {
        while (!int.TryParse(Console.ReadLine(), out number) || number > 20 || number < 1)
        {
            Console.WriteLine("\nPlease enter a valid integer between 1-19.\n");
        }
    }
    else
    {
        while (!int.TryParse(Console.ReadLine(), out number) || number > 10 || number < 1)
        {
            Console.WriteLine("\nPlease enter a valid integer between 1-9.\n");
        }
    }
    return number;
}
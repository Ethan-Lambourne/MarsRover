namespace MarsRover
{
    public class Rover
    {
        public int currentXcoordinate { get; set; }

        public int currentYcoordinate { get; set; }

        private readonly Map _map;

        public Rover(Map map)
        {
            _map = map;
        }

        public void MoveRover(string direction)
        {
            var roverPosition = _map.marsMap.GetValue(currentYcoordinate, currentXcoordinate);
            if (roverPosition as string == "x")
            {
                switch (direction)
                {
                    case "north":
                        var newPosition = _map.marsMap.GetValue(currentYcoordinate - 1, currentXcoordinate);
                        if (newPosition as string == " ")
                        {
                            UpdateRoverPosition("north");
                        }
                        break;

                    case "south":
                        newPosition = _map.marsMap.GetValue(currentYcoordinate + 1, currentXcoordinate);
                        if (newPosition as string == " ")
                        {
                            UpdateRoverPosition("south");
                        }
                        break;

                    case "east":
                        newPosition = _map.marsMap.GetValue(currentYcoordinate, currentXcoordinate + 1);
                        if (newPosition as string == " ")
                        {
                            UpdateRoverPosition("east");
                        }
                        break;

                    case "west":
                        newPosition = _map.marsMap.GetValue(currentYcoordinate, currentXcoordinate - 1);
                        if (newPosition as string == " ")
                        {
                            UpdateRoverPosition("west");
                        }
                        break;
                }
            }
        }

        public void UpdateRoverPosition(string direction)
        {
            switch (direction)
            {
                case "north":
                    _map.marsMap.SetValue(" ", currentYcoordinate, currentXcoordinate);
                    _map.marsMap.SetValue("x", currentYcoordinate - 1, currentXcoordinate);
                    currentYcoordinate--;
                    break;

                case "south":
                    _map.marsMap.SetValue(" ", currentYcoordinate, currentXcoordinate);
                    _map.marsMap.SetValue("x", currentYcoordinate + 1, currentXcoordinate);
                    currentYcoordinate++;
                    break;

                case "east":
                    _map.marsMap.SetValue(" ", currentYcoordinate, currentXcoordinate);
                    _map.marsMap.SetValue("x", currentYcoordinate, currentXcoordinate + 1);
                    currentXcoordinate++;
                    break;

                case "west":
                    _map.marsMap.SetValue(" ", currentYcoordinate, currentXcoordinate);
                    _map.marsMap.SetValue("x", currentYcoordinate, currentXcoordinate - 1);
                    currentXcoordinate--;
                    break;
            }
        }

        public bool PlaceRover(int x, int y)
        {
            var check = _map.marsMap.GetValue(10 - y, x);
            Console.WriteLine(check);

            switch (check)
            {
                case "#":
                    Console.WriteLine("Cannot drop the rover on an obsticle, choose another spot");
                    return false;

                case "|":
                    Console.WriteLine("Cannot drop the rover on the edge of the map, choose another spot");
                    return false;

                case "_":
                    Console.WriteLine("Cannot drop the rover on the edge of the map, choose another spot");
                    return false;

                default:
                    _map.marsMap.SetValue("x", 10 - y, x);
                    currentXcoordinate = x;
                    currentYcoordinate = 10 - y;
                    return true;
            }
        }
    }
}
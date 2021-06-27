using MarsRover.Models;

namespace MarsRover.Helpers
{
    public static class Coordinates
    {
        public static int GetDegreeFromHeading(string heading)
        {
            heading = heading.ToLower();
            switch (heading)
            {
                case "e":
                    return 90;
                case "s":
                    return 180;
                case "w":
                    return 270;
                default:
                    return 0;
            }
        }

        public static string GetHeadingFromDegree(int degree)
        {
            switch (degree)
            {
                case 90:
                    return "E";
                case 180:
                    return "S";
                case 270:
                    return "W";
                default:
                    return "N";
            }
        }

        public static int GetNewDegreeFromDirection(int degree, string direction)
        {
            direction = direction.ToLower();
            if (direction == "l")
            {
                if (degree == 0)
                {
                    degree = 270;
                } else
                {
                    degree = degree - 90;
                }
            }

            if (direction == "r")
            {
                if (degree == 270)
                {
                    degree = 0;
                } else
                {
                    degree = degree + 90;
                }
            }

            return degree;
        }
        public static Point GetPointFromMovement(Point point, int degree)
        {
            switch (degree)
            {
                case 0:
                    point.North ++;
                    break;
                case 90:
                    point.East++;
                    break;
                case 180:
                    point.North--;
                    break;
                case 270:
                    point.East--;
                    break;
            }
            return point;
        }

    }
}

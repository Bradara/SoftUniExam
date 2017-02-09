namespace IntersectionofCircles
{
    using System;
    using System.Linq;

    class IntersectionofCircles
    {
        class Circle
        {
            public int Radius { get; set; }
            public Point Center { get; set; }
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static void Main()
        {
            var arguments1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Circle circle1 = new Circle()
            {
                Center = new Point()
                {
                    X = arguments1[0],
                    Y = arguments1[1]
                },
                Radius = arguments1[2]
            };

            var arguments2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Circle circle2 = new Circle()
            {
                Center = new Point()
                {
                    X = arguments2[0],
                    Y = arguments2[1]
                },
                Radius = arguments2[2]
            };

            var sideX = circle1.Center.Y - circle2.Center.X;
            var sideY = circle1.Center.Y - circle2.Center.Y;
            var distance = Math.Sqrt(sideX * sideX + sideY * sideY);

            var sumOfRadius = circle1.Radius + circle2.Radius;

            if (sumOfRadius< distance)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }
    }
}



namespace CharityMarathon
{
	using System;
	class CharityMarathon
	{
		static void Main()
		{
			var days = int.Parse(Console.ReadLine());
		    var runners = int.Parse(Console.ReadLine());
		    var averageLaps = int.Parse(Console.ReadLine());
		    var trackLength = int.Parse(Console.ReadLine());
		    var capacityOfTrack = int.Parse(Console.ReadLine());
		    var moneyPerKm = decimal.Parse(Console.ReadLine());

		    var distancePerLaps = capacityOfTrack * days > runners ? (long)runners * trackLength : (long)capacityOfTrack * days * trackLength;
		    var distaneTotal = distancePerLaps * averageLaps / 1000M;

		    Console.WriteLine("Money raised: {0:f2}", distaneTotal*moneyPerKm);

		}
	}
}

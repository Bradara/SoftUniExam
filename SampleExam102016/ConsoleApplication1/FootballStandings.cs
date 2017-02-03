namespace FootballStandings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class FootballStandings
    {
        static void Main(string[] args)
        {
            var pattern = @"((\?{2})([\w]+)(\?{2})).+((\?{2})([\w]+)(\?{2})).*(\d:\d)";
            Regex rgx = new Regex(pattern);

            var text = ""

        }
    }
}

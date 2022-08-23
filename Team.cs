using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    public class Team
    {
        public string TeamName { get; set; }
        public int Games { get; set; }
        public int WonGames { get; set; }


        public Team(string teamName, int games, int wonGames)
        {
            this.TeamName = teamName;
            this.Games = games;
            this.WonGames = wonGames;   
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} ", TeamName, Games, WonGames);
        }
    }
}
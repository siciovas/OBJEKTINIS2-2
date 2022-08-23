using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD2
{
    public static class TaskUtils
    {
        /// <summary>
        /// Method selects players based on their position
        /// </summary>
        /// <param name="player">linked list of players</param>
        /// <param name="position">Player positiomn (GURAD/FORWARD/CENTER)</param>
        /// <returns>linked list of players</returns>
        public static PlayerLink SelectedByPositions(PlayerLink player, string position)
        {
            PlayerLink positionList = new PlayerLink();

            for(player.Start(); player.Is(); player.Next())
            {
                var current = player.Get();
                if(current.Position == position)
                {
                    positionList.Add(current);
                }
            }

            return positionList;
        }
        /// <summary>
        /// Method selects the best team, which has the most wins
        /// </summary>
        /// <param name="team">linked list of teams</param>
        /// <returns>all data of one team</returns>
        public static TeamLink BestTeam(TeamLink team)
        {
            TeamLink bestTeam = new TeamLink();
            int maximum = Int32.MinValue;

            for(team.Start(); team.Is(); team.Next())
            {
                var current = team.Get();
                if(current.WonGames > maximum)
                {
                    maximum = current.WonGames;
                }
            }

            for(team.Start(); team.Is(); team.Next())
            {
                var current = team.Get();
                if(maximum == current.WonGames)
                {
                    bestTeam.Add(current);
                }
            }
            return bestTeam;
        }

        /// <summary>
        /// Method selects the best team players
        /// </summary>
        /// <param name="players">linked list of players</param>
        /// <param name="teams">linked list of teams</param>
        /// <returns>linked list of the best team players</returns>
        public static PlayerLink BestTeamPlayers(PlayerLink players, TeamLink teams)
        {
            string bestTeam = "";
            int maximum = Int32.MinValue;
            PlayerLink bestTeamPlayers = new PlayerLink();

            for(teams.Start(); teams.Is(); teams.Next())
            {
                var current = teams.Get();
                if(current.WonGames > maximum)
                {
                    maximum = current.WonGames;
                    bestTeam = current.TeamName;
                }
            }

            for(players.Start(); players.Is(); players.Next())
            {
                var current = players.Get();
                if (current.Team == bestTeam)
                {
                    bestTeamPlayers.Add(current);
                }
            }

            return bestTeamPlayers;
        }
        /// <summary>
        /// Method selects which team players we want to see
        /// </summary>
        /// <param name="players">linked list of players</param>
        /// <param name="textbox">textbox</param>
        /// <returns>linked list of players</returns>
        public static PlayerLink SelectedTeamsPlayers(PlayerLink players, TextBox textbox)
        {
            PlayerLink selected = new PlayerLink();

            for(players.Start(); players.Is(); players.Next())
            {
                var current = players.Get();
                if(textbox.Text != null && current.Team == textbox.Text)
                {
                    selected.Add(current);
                }
            }   

            return selected;
        }
    }
}
using System;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;

namespace LD2
{
    public static class InOut
    {
        /// <summary>
        /// Reads players data from the file
        /// </summary>
        /// <param name="fileName">current file</param>
        /// <returns>data of players data</returns>
        public static PlayerLink ReadPlayers(string fileName)
        {
            PlayerLink Players = new PlayerLink();
            
            using(StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] value = line.Split(',');
                    string team = value[0];
                    string name = value[1];
                    string surname = value[2];
                    string birth = value[3];
                    int height = Convert.ToInt32(value[4]);
                    string position = value[5];
                    int games = Convert.ToInt32(value[6]);
                    int points = Convert.ToInt32(value[7]);
                    //-----------------------------------------------------------------------------------
                    Player player = new Player(team, name, surname, birth, height, position, games, points);
                    Players.Add(player);
                }
            }
            return Players;
        }
        /// <summary>
        /// Reads teams data from the file
        /// </summary>
        /// <param name="fileName">current file</param>
        /// <returns>list of teams data</returns>
        public static TeamLink ReadTeams(string fileName)
        {
            TeamLink Teams = new TeamLink();
            
            using(StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string line;

                while((line = reader.ReadLine()) != null)
                {
                    string[] value = line.Split(',');

                    string teamName = value[0];
                    int games = Convert.ToInt32(value[1]);
                    int wonGames = Convert.ToInt32(value[2]);
                    //-------------------------------------------------------
                    Team team = new Team(teamName, games, wonGames);
                    Teams.Add(team);
                }
            }
            return Teams;
        }
        /// <summary>
        /// Prints results to the .txt file
        /// </summary>
        /// <param name="players">LinkedList of players</param>
        /// <param name="fileName">result file</param>
        /// <param name="header"></param>
        public static void PrintPlayers(PlayerLink players, string fileName, string header)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                int number = 0;
                writer.WriteLine(header);
                string brackets = new string('-', 200);
                writer.WriteLine(brackets);
                string information = String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} |", "Nr.", "Komanda", "Vardas", 
                    "Pavardė", "Metai", "Ūgis", "Pozicija", "Sužaista", "Taškai");
                writer.WriteLine(information);
                writer.WriteLine(brackets);

                for (players.Start(); players.Is(); players.Next())
                {
                    var current = players.Get();
                    number++;
                    writer.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} |", number, current.Team, current.Name,
                        current.Surname, current.Birth, current.Height, current.Position, current.Games, current.Points);
                }
                writer.WriteLine(brackets);
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Prints teams resuls to the .txt file
        /// </summary>
        /// <param name="teams">linkedlist of teams</param>
        /// <param name="fileName">result file</param>
        /// <param name="header"></param>
        public static void PrintTeams(TeamLink teams, string fileName, string header)
        {
            using(StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine(header);
                string brackets = new string('-', 60);
                writer.WriteLine(brackets);
                string information = String.Format("{0} | {1} | {2}", "Komanda", "Sužaista", "Laimėta");
                writer.WriteLine(information);
                writer.WriteLine(brackets);

                for(teams.Start(); teams.Is(); teams.Next())
                {
                    writer.WriteLine(teams.Get().ToString());
                }
                writer.WriteLine(brackets);
                writer.WriteLine();
            }
        }
        /// <summary>
        /// Writes players results in the WEBform.
        /// </summary>
        /// <param name="table1">Table</param>
        /// <param name="players">linked list of players</param>
        /// <param name="header"></param>
        public static void WritePlayersToTable(Table table1, PlayerLink players, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 9;
            headerRow.Cells.Add(cell);
            table1.Rows.Add(headerRow);
            int number = 0;
            for(players.Start(); players.Is(); players.Next())
            {
                number++;
                TableRow playersRow = new TableRow();

                TableCell num = new TableCell(); num.Text = number.ToString(); playersRow.Cells.Add(num);
                TableCell team = new TableCell(); team.Text = players.Get().Team; playersRow.Cells.Add(team);
                TableCell name = new TableCell(); name.Text = players.Get().Name; playersRow.Cells.Add(name);
                TableCell surname = new TableCell(); surname.Text = players.Get().Surname; playersRow.Cells.Add(surname);
                TableCell birth = new TableCell(); birth.Text = players.Get().Birth; playersRow.Cells.Add(birth);
                TableCell height = new TableCell(); height.Text = players.Get().Height.ToString(); playersRow.Cells.Add(height);
                TableCell position = new TableCell(); position.Text = players.Get().Position; playersRow.Cells.Add(position);
                TableCell games = new TableCell(); games.Text = players.Get().Games.ToString(); playersRow.Cells.Add(games);
                TableCell points = new TableCell(); points.Text = players.Get().Points.ToString(); playersRow.Cells.Add(points);

                table1.Rows.Add(playersRow);
            }
        }
        /// <summary>
        /// Writes teams results in the the WEBform
        /// </summary>
        /// <param name="table2">table</param>
        /// <param name="teams">linked list of teams</param>
        /// <param name="header"></param>
        public static void WriteTeamsToTable(Table table2, TeamLink teams, string header)
        {
            TableRow headerRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = header;
            cell.ColumnSpan = 3;
            headerRow.Cells.Add(cell);
            table2.Rows.Add(headerRow);

            for(teams.Start(); teams.Is(); teams.Next())
            {
                TableRow teamsRow = new TableRow();

                TableCell team = new TableCell(); team.Text = teams.Get().TeamName; teamsRow.Cells.Add(team);
                TableCell games = new TableCell(); games.Text = teams.Get().Games.ToString(); teamsRow.Cells.Add(games);
                TableCell wonGames = new TableCell(); wonGames.Text = teams.Get().WonGames.ToString(); teamsRow.Cells.Add(wonGames);

                table2.Rows.Add(teamsRow);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2
{
    public class Player
    {
        public string Team { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birth { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public int Games { get; set; }
        public int Points { get; set; }

        public Player(string team, string name, string surname, string birth, int height, string position,
        int games, int points)
        {
            this.Team = team;
            this.Name = name;
            this.Surname = surname;
            this.Birth = birth;
            this.Height = height;
            this.Position = position;
            this.Games = games;
            this.Points = points;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Team, Name, Surname, Birth, Height, Position, Games, Points);
        }

        static public bool operator <(Player A, Player B)
        {
            if(A.Points < B.Points)
            {
                return true;
            }
            else if(A.Points == B.Points)
            {
                if(A.Games >= B.Games)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        static public bool operator >(Player A, Player B)
        {
            if(A.Points > B.Points)
            {
                return true;
            }

            else if(A.Points == B.Points)
            {
                if(A.Games <= B.Games)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }

    
}
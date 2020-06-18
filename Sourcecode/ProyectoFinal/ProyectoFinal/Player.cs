using System;

namespace ProyectoFinal
{
    public class Player
    {
       
        public string Username { get; set; }
        
        //private String Username;
        private int Score;

        public Player(string username, int score)
        {
            Username = username;
            Score = score;
        }
    }
}
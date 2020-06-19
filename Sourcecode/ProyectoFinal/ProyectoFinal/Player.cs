using System;

namespace ProyectoFinal
{
    public class Player
    {

        public string Username;
        
        private int Score;

        private int lives;
        public int Lives
        {
            get => lives;
            set => lives = value;
        }

        public string Username1 => Username;

        public int Score1
        {
            get => Score;
            set => Score = value;
        }

        public Player(string username)
        {
            Username = username;
            Score = 0;
            lives = 3;
        }
    }
}
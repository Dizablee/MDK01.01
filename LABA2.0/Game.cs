using System;

namespace LABA2._0
{
    public class Game
    {
        private string name;
        private Genre genre;
        private decimal price;

        public Game(string name, Genre genre, decimal price)
        {
            this.name = name;
            this.genre = genre;
            this.price = price;
        }

        public string GetName()
        {
            return name;
        }

        public Genre GetGenre()
        {
            return genre;
        }

        public decimal GetPrice()
        {
            return price;
        }
    }
}
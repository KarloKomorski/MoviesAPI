﻿namespace MoviesAPI.Data
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;

    }
}
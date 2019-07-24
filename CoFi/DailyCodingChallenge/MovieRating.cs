using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge
{
    public class MovieRating
    {
        public string MovieName { get; set; }
        public int Rating { get; set; }

        public MovieRating(string movieName, int rating)
        {
            MovieName = movieName;
            Rating = rating;
        }
    }
}

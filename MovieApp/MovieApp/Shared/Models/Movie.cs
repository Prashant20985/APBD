
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Shared.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title Is Required")]
        [MaxLength(30, ErrorMessage ="Max Length is 30")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Summary Is Required")]
        [MaxLength(200, ErrorMessage = "Max Length is 200")]
        public string Summary { get; set; }
        public bool InTheaters { get; set; }
        [Required(ErrorMessage = "Trailer Link Is Required")]
        public string Trailer { get; set; }
        [Required(ErrorMessage = "Date of Release Is Required")]
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Link For Poster Is Required")]
        public string Poster { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set; } = new List<MoviesGenres>();
        public List<MoviesActors> MoviesActors { get; set; } = new List<MoviesActors>();
        public string TitleBrief
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}

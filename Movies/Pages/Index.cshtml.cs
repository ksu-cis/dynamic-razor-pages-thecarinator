using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
       
        public IEnumerable<Movie> Movies { get; protected set; }
        [BindProperty]
        public string SearchTerms { get; set; } = "";
        [BindProperty]
        public string[] MPAARatings { get; set; } = new string[0];
        [BindProperty]
        public string[] Genres { get; set; } = new string[0];
        [BindProperty]
        public double? IMDBMin { get; set; }
        [BindProperty]
        public double? IMDBMax { get; set; }
        [BindProperty]
        public double? TomatoesMin { get; set; }
        [BindProperty]
        public double? TomatoesMax { get; set; }
        public void OnGet()
        {
            Movies= MovieDatabase.All;
        }
        public void OnPost()
        {
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            Movies = MovieDatabase.FilterByRottenTomatoes(Movies, TomatoesMin, TomatoesMax);

        }
    }
}

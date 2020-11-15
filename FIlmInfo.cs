using System;
namespace FileInputInterfaces
{

    //Year;Length;Title;Subject;Actor;Actress;Director;Popularity;Awards;*Image
    public class FilmInfo
    {
       public int ReleaseYear { get; set; }
        public int FilmLength { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string ActorName { get; set; }
        public string ActoressName { get; set; }
        public string DirectorName { get; set; }
        public int Popularity { get; set; }
        public int Awards { get; set; }

        public override string ToString()
        {
            return $"Film: {Title} {Subject} and released in {ReleaseYear} Award Status : {Awards}";
        }
    }
}

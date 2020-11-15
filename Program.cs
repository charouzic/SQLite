using System;

namespace FileInputInterfaces
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
             Lecture Task: 
                 We develop a console job that imports the file in memory. 
                 We store all rows of the file into a list of objects.
                 We build methods to achive following descriptive analytics:
 	                CountFilms: A method that returns total number of films in the list
	                ListOfUniqueActors: A method that returns a unique list of All the Actors
	                ListOfUniqueActoresses: A method that returns a unique list of actoresses
	                SearchTitlesStarttingWithCharacters: A method that returns list of Films that start with given characters
	                CountOfFilmsOnThebasisWhetherAwardWonOrNot: A method that takes a value for either award won or not and then returns a count
                We create functionality to output the above descriptive in a csv file

                Year;Length;Title;Subject;Actor;Actress;Director;Popularity;Awards;*Image
             */

            Processor p = new Processor();
            p.Process();

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;
using System.Text;
using System.Data.SQLite;

namespace FileInputInterfaces
{
    public class Processor
    {
        public string PathToFile {
            get {
                return "/users/viki/desktop/c#/";
            }
        }


        public List<FilmInfo> ImportFile(string filename)
        {
            List<FilmInfo> infos = new List<FilmInfo>();

            string fullFileName = $"{PathToFile}{filename}";
            string[] lines = File.ReadAllLines(fullFileName);

            for (int i = 2; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(';');
                FilmInfo info = new FilmInfo();

                info.ReleaseYear = int.Parse(line[0]);

                if (!string.IsNullOrWhiteSpace(line[1]))
                    info.FilmLength = int.Parse(line[1]);

                info.Title = line[2];
                info.Subject = line[3];
  

                if (!string.IsNullOrWhiteSpace(line[7]))
                    info.Popularity = int.Parse(line[7]);

                if (line[8] == "Yes")
                {
                    info.Awards = 1;
                }
                else
                {
                    info.Awards = 0;
                }

                infos.Add(info);
            }

            return infos;

        }

        public IDbCommand dbAuthentication(string conString)
        {
            //creating a connection
            IDbConnection conn = new SqliteConnection(conString);

            //opening connection
            conn.Open();

            IDbCommand cmd = conn.CreateCommand();

            return (cmd);
        }

        public void databaseLoad(List<FilmInfo> infos)
        {
            try
            {
                foreach (var f in infos)
                {

                    string filmName = f.Title;
                    int year = f.ReleaseYear;
                    string subject = f.Subject;
                    int awardStatus = f.Awards;

                    IDbCommand cmd = dbAuthentication(MyUtility.ConnectionString);

                    string insertQuery = ($"INSERT INTO Film(FilmName, Year, Subject, AwardStatus) VALUES('{filmName}', {year}, '{subject}', {awardStatus})");
                    //string insertQuery = $"INSERT INTO Film(FilmName, Year, Subject, AwardStatus) VALUES('Harry Potter', '2004', 'fiction', 'false')";
                    cmd.CommandText = insertQuery;

                    cmd.ExecuteNonQuery();
                }
            }
            

            catch (Exception ex)
            {
                Console.WriteLine($"Error occured. Cause of error is: {ex.Message}");
            }
        }

        public void RetrieveData()
        {
            try
            {
                IDbCommand cmd = dbAuthentication(MyUtility.ConnectionString);

                string qry = "Select * from Film";
                cmd.CommandText = qry;
                var reader = cmd.ExecuteReader();

                int counter = 0;

                while (reader.Read())
                {
                    ++counter;
                    StringBuilder output = new StringBuilder();
                    output.AppendLine($"{counter}) Movie Title: {reader.GetString(0)} ({reader.GetInt32(1)}), Subject: {reader.GetString(2)}, Award (0=No, 1=Yes): {reader.GetInt32(3)}");
                    Console.WriteLine(output.ToString());
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error occured. Cause of error is: {ex.Message}");
            }
        }
        

        public void Process()
        {
            var filmInfos = ImportFile("film.csv");

            /*
            Console.WriteLine("Loading data into table");
            databaseLoad(filmInfos);
            Console.WriteLine("Data successfully loaded into db");
            */

            RetrieveData();

        }
    }
}

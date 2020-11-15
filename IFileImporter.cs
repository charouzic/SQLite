using System;
using System.Collections.Generic;

namespace FileInputInterfaces
{
    public interface IFileImporter
    {        
        string PathToFile { get; }
        List<FilmInfo> ImportFile(string filename);
    }
}

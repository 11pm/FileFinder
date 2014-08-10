
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LineCounter
{
    class FileFinder
    {
        public List<string> files = new List<string>();
        public string path { get; set; }
        private List<string> extensions = new List<string>();
        private bool subDirectories = false;
        

        public FileFinder(string _path, List<string> _extensions, bool _subDirectories = false)
        {
            path = _path;
            extensions = _extensions;
            subDirectories = _subDirectories;
         
            try
            {
                findAndReadFiles(path);
                if (subDirectories) findFolders(path);
            }
            catch (IOException e)
            {
                //do something with error
                Console.WriteLine(e.Message);
            }
        }
        
        private void findAndReadFiles(string path)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                if (extensions.Contains(Path.GetExtension(file)))
                {
                    files.Add(file);
                }
            }
        }
     
        private void findFolders(string path)
        {
            foreach (string folder in Directory.GetDirectories(path))
            {
                findAndReadFiles(folder);
                findFolders(folder);
            }
        }

        public int countFiles
        {
            get { return files.Count(); }   
        }

        public int fileLines(string filePath)
        {
            return File.ReadAllLines(filePath).Count();
        }

    }
}

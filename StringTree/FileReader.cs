using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRead
{
    class FileReader
    {
        public FileReader()
        {

        }

        public string[] ReadFile(string path, string filename)
        {
            var fileContent = System.IO.File.ReadAllLines(path + filename);

            return fileContent;
        }
    }
}

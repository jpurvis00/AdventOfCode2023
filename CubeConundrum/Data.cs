using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeConundrum
{
    internal class Data
    {
        public static string[] ReadDataFromFile(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}

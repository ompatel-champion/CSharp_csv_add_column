using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.csv");

            foreach (string filename in files)
            {

                string[] lines = File.ReadAllLines(filename);

                if (lines.Length == 0)
                {
                    throw new InvalidOperationException("The file is empty");
                }

                //add new column to the header row
                lines[0] += ",File Name";

                //add new column value for each row.
                for (int i = 1; i < lines.Length; i++)
                {
                    int newColumnDataIndex = i - 1;


                    lines[i] += "," + filename.Replace(Environment.CurrentDirectory + "\\", "");
                }

                //write the new content
                File.WriteAllLines(filename, lines);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}

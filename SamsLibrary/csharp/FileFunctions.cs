using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SamsLibrary
{
    public class FileFunctions
    {
        public FileFunctions()
        {

        }

        public static string GetFilesExtension(string fileName)
        {
            Path.GetExtension(fileName);
            // vs.
            var indexOf = fileName.LastIndexOf('.');
            var extension = fileName.Substring(indexOf);
            return extension;
        }


        public string GetSystemDirectory(Environment.SpecialFolder folder = Environment.SpecialFolder.MyDocuments)
        {
            var localData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appData = Path.GetDirectoryName(localData);

            return Environment.GetFolderPath(folder);
        }

        // Read File Line By Line
        public static List<string> FileToStringList(string fileName)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        lines.Add(line);
                    }
                    catch
                    {
                        Console.WriteLine("Error Parsing Person: " + line);
                    }
                }
            }
            return lines;
        }

        // Roberts way of reading the file. Not as good as mine. Bad on Memory vs Line by Line
        public static List<string> FileToMemory(string fileName)
        {
            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                
                string file = sr.ReadToEnd();
                var rawlines = file.Split(new String[] { Environment.NewLine }, new StringSplitOptions());
                foreach (var line in rawlines)
                {
                    lines.Add(line);
                }

            }
            return lines;
        }


        // also checkout File.WriteAllLines(path, linesList, Encoding.Unicode);
        public static void OutputToFile(string outputFile, string output)
        {
            using (StreamWriter sw = File.AppendText(outputFile))
            {
                sw.WriteLine(output);
            }
        }

        public static string GetOutputFileName(string inputFile)
        {
            string filePath = Path.GetDirectoryName(inputFile);
            string fileName = Path.GetFileNameWithoutExtension(inputFile);
            string fileExtension = Path.GetExtension(inputFile);
            string outputFile = String.Format("{0}\\{1}{2}", filePath, fileName, fileExtension);

            return outputFile;
        }

    }
}


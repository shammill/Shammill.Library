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

    }
}


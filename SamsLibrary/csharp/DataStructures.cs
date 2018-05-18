using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SamsLibrary
{
    public class DataStructures
    {
        public DataStructures()
        {

        }

        // List
        public void ListImplementations()
        {
            // Basic new List
            List<string> newStringList1 = new List<String>();

            // New List with default values
            List<string> newStringList2 = new List<String> { "string1", "hello", "world" };
        }

        // Dictionary
        public void DictionaryImplementations()
        {
            // Basic new Dictionary
            IDictionary<int, string> dict1 = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" }
            };
            Console.WriteLine(dict1[1]);

            // New Dictionary with default values
            IDictionary<int, string> dict2 = new Dictionary<int, string>() { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };

            // Looping through a dictionary with foreach
            foreach (KeyValuePair<int, string> item in dict2)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }

            // Looping through a dictionary with for
            for (int i = 0; i < dict2.Count; i++)
            {
                Console.WriteLine("Key: {0}, Value: {1}", dict2.Keys.ElementAt(i), dict2[dict2.Keys.ElementAt(i)]);
            }
        }

        // Array
        public void ArrayImplementations()
        {
            // Standard
            int[] scores;

            // Standard with Array Size
            int[] scores2 = new int[5];

            // With initial data.
            int[] scores3 = new int[] { 97, 92, 81, 60, 19 };

            // Two-dimensional array, with initial data.
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            // Multi dimensional creates a two-dimensional array of four rows and two columns
            int[,] array = new int[4, 2];

            // Multi dimensional creates an array of three dimensions, 4, 2, and 3.
            int[,,] array1 = new int[4, 2, 3];
        }


        //HashSet - Efficient Lookups
        public void HashSetImplementation()
        {
            HashSet<int> hash = new HashSet<int>
            {
                1
            };
            bool hasThing = hash.Contains(1);

        }


    }
}
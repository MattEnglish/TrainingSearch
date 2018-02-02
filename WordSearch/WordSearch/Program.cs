using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = "Heman";
            List<string> allWords = System.IO.File.ReadAllLines("words.txt").ToList();
            allWords.Sort();
            BinarySearch(allWords,x);

            var r = new Random();
            var wordList = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                wordList.Add(allWords[r.Next(0, allWords.Count)]);
            }
            
            var stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var word in wordList)
            {

                LinearSearch(allWords, word);

            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var word in wordList)
            {
               BinarySearch(allWords, word);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public static void LinearSearch(List<string> allWords, string theWord)
        {
            for (int i = 0; i < allWords.Count; i++)
            {
                if (allWords[i] == theWord)
                {
                    return;
                }
            }
            return;
        }

        public static void BinarySearch(List<string> words, string theWord)
        {
            
        }

        public static void BinarySearch(List<string> words, string theWord, int startingIndex, int endIndex)
        {
            int middleWordIndex = startingIndex + words.Count / 2;
            int wordComparedWithMiddle = string.Compare(words[middleWordIndex], theWord);
            if (wordComparedWithMiddle == 0)
            {
                return;
            }
            else if (wordComparedWithMiddle < 0)
            {
                BinarySearch(words.GetRange(middleWordIndex + 1, words.Count - middleWordIndex - 1), theWord);
                return;
            }
            else if (wordComparedWithMiddle > 0)
            {
                BinarySearch(words.GetRange(startingIndex, middleWordIndex), theWord);
                return;
            }
            throw new Exception();
        }
    }
}

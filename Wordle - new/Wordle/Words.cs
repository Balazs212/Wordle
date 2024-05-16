using System.Collections.Generic;
using System.IO;

namespace Wordle
{
    internal class Words
    {
        public List<string> ThreeLetterWords { get; private set; }
        public List<string> FourLetterWords { get; private set; }
        public List<string> FiveLetterWords { get; private set; }
        public List<string> SixLetterWords { get; private set; }

        public Words()
        {
            ThreeLetterWords = new List<string>();
            FourLetterWords = new List<string>();
            FiveLetterWords = new List<string>();
            SixLetterWords = new List<string>();
        }

        public void ReadWordsFromFiles(string threeLetterFilePath, string fourLetterFilePath, string fiveLetterFilePath, string sixLetterFilePath)
        {
            ReadWordsFromFile(threeLetterFilePath, ThreeLetterWords);
            ReadWordsFromFile(fourLetterFilePath, FourLetterWords);
            ReadWordsFromFile(fiveLetterFilePath, FiveLetterWords);
            ReadWordsFromFile(sixLetterFilePath, SixLetterWords);
        }

        private void ReadWordsFromFile(string filePath, List<string> wordList)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string word = line.Trim();
                    wordList.Add(word);
                }
            }
        }
    }
}

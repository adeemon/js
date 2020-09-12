using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_task_3._1._2.WordsCounter
{
    class WordsCounter
    {
        public static List<Word> words = new List<Word>();
        
        public static void Start ()
        {
            CreatingListOfWords();

            var sortedWords = from word in words
                              orderby word.Count
                              select word;

            foreach (Word w in sortedWords)
            {
                PrintOfWord(w);
            }
            OutputHandler.PrintBackToMain();
        }

        private static void CreatingListOfWords ()
        {
            string[] arrayOfWords = BreakInputStringInArray(ConsoleInput());
            foreach (string word in arrayOfWords)
            {
                if (IsItWord(word))
                {
                    if (!IsListContainsWord(word, words))
                    {
                        var newWord = new Word
                        {
                            Data = word,
                            Count = CountingOfWordsInsideArray(word, arrayOfWords)
                        };
                        words.Add(newWord);
                    }
                }
            }
        }

        private static void PrintOfWord(Word inputWord)
        {
            
                Console.WriteLine("The word \"{0}\" was used in text {1} times", inputWord.Data, inputWord.Count);
        }

        private static string ConsoleInput()
        {
            Console.WriteLine("Input the string.");
            return Console.ReadLine();
        }

        private static string[] BreakInputStringInArray(string inputString)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            return inputString.Split(delimiterChars); ;
        }

        private static int CountingOfWordsInsideArray(string word, string[] array)
        {
            int count = 0;
            foreach (string arrayWord in array)
            {
                if (arrayWord.ToLower()== word.ToLower())
                {
                    count++;
                }
            }
            return count;
        }

        private static bool IsListContainsWord (string word, List<Word> listOfWords)
        {
            foreach (Word wordInList in listOfWords)
            {
                if (wordInList.Data.ToLower() == word.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsItWord (string input)
        {
            for (int i=0; i<input.Length;++i)
            {
                if (!Char.IsLetter(input[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

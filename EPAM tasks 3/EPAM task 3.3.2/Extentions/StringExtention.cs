using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EPAM_task_3._3._2.Extentions
{
    enum TypeOfLanguages
    {
        Russian,
        English,
        Number,
        Mixed
    }
    static class StringExtention
    {
        public static TypeOfLanguages Language (this string inputString)
        {
            string russianPattern = @"^[а-яё]+$";
            string englishPattern= @"^[a-z]+$";
            string numberPattern = @"^[0-9]+$";


            Regex regexRussian = new Regex(russianPattern, RegexOptions.IgnoreCase);
            Regex regexEnglish = new Regex(englishPattern, RegexOptions.IgnoreCase);
            Regex regexNumber = new Regex(numberPattern, RegexOptions.IgnoreCase);


            if (regexRussian.IsMatch(inputString)) return TypeOfLanguages.Russian;
            if (regexEnglish.IsMatch(inputString)) return TypeOfLanguages.English;
            if (regexNumber.IsMatch(inputString)) return TypeOfLanguages.Number;

            return TypeOfLanguages.Mixed;

        }
    }
}

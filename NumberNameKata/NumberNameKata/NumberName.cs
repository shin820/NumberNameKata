using System;
using System.Collections.Generic;
using System.Globalization;

namespace NumberNameKata
{
    public class NumberName
    {
        private const int SEGMENT_LEN = 3;

        private readonly string[] _unitsDigits =
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine"
        };

        private readonly string[] _tensDigitsLessThanTweenty =
        {
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
            "sixteen", "seventeen", "eighteen", "nineteen"
        };

        private readonly string[] _tensDigits =
        {
            "ten","twenty", "thirty", "fourty", "fifity", "sixty", "seventy", "eighty",
            "ninety"
        };

        private readonly string[] _units = { "hundred", "thousand", "million", "billion" };

        public string Name { get; private set; }

        public NumberName(int number)
        {
            int[] segments = SplitNumber(number.ToString(CultureInfo.InvariantCulture));
            Name = GetNumberName(segments);
        }

        private string GetNumberName(int[] segments)
        {
            string name = GetNumberName(segments[0]);
            for (int i = 1; i < segments.Length; i++)
            {
                string unit = i == 0 ? string.Empty : _units[i];
                name = GetNumberName(segments[i]) + " " + unit + ", " + name;

            }
            return name;
        }

        private int[] SplitNumber(string number)
        {
            List<int> numbers = new List<int>();

            for (int i = number.Length; i > 0; i = i - SEGMENT_LEN)
            {
                string segment = i < SEGMENT_LEN
                    ? number.Substring(0, i)
                    : number.Substring(i - SEGMENT_LEN, SEGMENT_LEN);
                numbers.Add(Convert.ToInt32(segment));
            }

            return numbers.ToArray();
        }

        private string GetNumberName(int number)
        {
            if (number >= 1000)
            {
                throw new Exception("exception");
            }

            if (number >= 100)
            {
                return PareseHundredsNumber(number);
            }

            if (number >= 10)
            {
                return ParseTensNumber(number);
            }

            //number < 10;
            return ParseUnitsNumber(number);
        }

        private string ParseUnitsNumber(int number)
        {
            int unitsDigit = number % 10;
            return _unitsDigits[unitsDigit];
        }

        private string ParseTensNumber(int number)
        {
            int unitsDigit = number % 10;

            //11~19
            if (number < 20)
            {
                return _tensDigitsLessThanTweenty[unitsDigit];
            }

            int tensDigit = number / 10;
            string tensDigitName = _tensDigits[tensDigit - 1];
            if (unitsDigit > 0)
            {
                //21,22,23 and so on
                return tensDigitName + " " + ParseUnitsNumber(unitsDigit);
            }

            //20,30,40 and so on
            return tensDigitName;
        }

        private string PareseHundredsNumber(int hundredNumber)
        {
            int hundredsDigit = hundredNumber / 100;
            string hundredUnit = _units[0];
            string hunderedName = ParseUnitsNumber(hundredsDigit) + " " + hundredUnit;

            int surpusNumber = hundredNumber - hundredsDigit * 100;
            if (surpusNumber > 0)
            {
                hunderedName = hunderedName + " and " + GetNumberName(surpusNumber);
            }

            return hunderedName;
        }
    }
}
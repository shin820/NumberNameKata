using System;
using System.Collections.Generic;
using System.Globalization;

namespace NumberNameKata
{
    public class NumberName
    {
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
            "twenty", "thirty", "fourty", "fifity", "sixty", "seventy", "eighty",
            "ninety"
        };

        private readonly string[] _units = { "hundred", "thousand", "million", "billion" };

        public string Name { get; private set; }

        public NumberName(int number)
        {
            int[] numbers = SplitNumber(number.ToString(CultureInfo.InvariantCulture));
            string name = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                string unit = i == 0 ? string.Empty : _units[i];
                if (i == 0)
                {
                    name = GetNumberName(numbers[i]);
                }
                else
                {
                    name = GetNumberName(numbers[i]) + " " + unit + ", " + name;
                }
            }
            Name = name;
        }

        private int[] SplitNumber(string number)
        {
            List<int> numbers = new List<int>();

            for (int i = number.Length; i > 0; i = i - 3)
            {
                if (i < 3)
                {
                    numbers.Add(Convert.ToInt32(number.Substring(0, i)));
                }
                else
                {
                    numbers.Add(Convert.ToInt32(number.Substring(i - 3, 3)));
                }
            }

            return numbers.ToArray();
        }

        private string GetNumberName(int number)
        {
            int unitsDigit = number % 10;
            int tensDigit = number / 10;

            if (tensDigit >= 10)
            {
                return PareseHundredsNumber(number);
            }

            if (tensDigit >= 1)
            {
                return ParseTensNumber(tensDigit, unitsDigit);
            }

            return ParseUnitsNumber(unitsDigit);
        }

        private string ParseUnitsNumber(int unitsDigit)
        {
            return _unitsDigits[unitsDigit];
        }

        private string ParseTensNumber(int tensDigit, int unitsDigit)
        {
            bool isLessThanTwenty = tensDigit == 1;
            if (isLessThanTwenty)
            {
                return _tensDigitsLessThanTweenty[unitsDigit];
            }

            string tensNumber = _tensDigits[tensDigit - 2];

            bool isGreaterThanTwenty = unitsDigit > 0;
            if (isGreaterThanTwenty)
            {
                return tensNumber + " " + ParseUnitsNumber(unitsDigit);
            }

            return tensNumber;
        }

        private string PareseHundredsNumber(int number)
        {
            int hundredsDigit = number / 100;
            string hunderedName = ParseUnitsNumber(hundredsDigit) + " " + _units[0];

            int surpusNumber = number - hundredsDigit * 100;
            if (surpusNumber > 0)
            {
                hunderedName = hunderedName + " and " + GetNumberName(surpusNumber);
            }

            return hunderedName;
        }
    }
}
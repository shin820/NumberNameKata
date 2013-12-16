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
            //int[] numbers = SplitNumber(number.ToString(CultureInfo.InvariantCulture));
            //string name = string.Empty;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    name = GetNumberName(numbers[i]) + " " + _units[i] + name;
            //}
            //Name = name;
            Name = GetNumberName(number);
        }

        private int[] SplitNumber(string number)
        {
            List<int> numbers = new List<int>();

            string temp = number;
            while (!string.IsNullOrEmpty(temp) && temp.Length > 3)
            {
                string num = temp.Substring(temp.Length - 3, temp.Length - 1);
                numbers.Add(Convert.ToInt32(num));
                temp = temp.Substring(0, temp.Length - 3);
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
using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const char _positiveChar = '+';
        private const char _negativeChar = '-';
        private string _valuePart;
        private bool _isNegative;

        public int Parse(string stringValue)
        {
            CheckIsNull(stringValue);

            GetTrimedString(ref stringValue);

            CheckIsValidFormat(stringValue);

            return ToInt();
        }

        private static void GetTrimedString(ref string stringValue)
        {
            stringValue = stringValue.Trim();
        }

        private int ToInt()
        {
            var num = 0;
            
            foreach (var temp in _valuePart)
            {
                try
                {
                    checked
                    {
                        num = num * 10 + (temp - '0');
                    }
                }
                catch (OverflowException e)
                {
                    unchecked
                    {
                        num = num * 10 + (temp - '0');
                        if (num == int.MinValue && _isNegative)
                        {
                            continue;
                        }
                    }
                    throw;
                }
            }

            return _isNegative ? num * -1 : num;
        }

        private void CheckIsValidFormat(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue) || !IsDigitsOrFirstMinus(stringValue))
            {
                throw new FormatException("string contains invalid format");
            }
        }

        private static void CheckIsNull(string stringValue)
        {
            if (stringValue is null)
            {
                throw new ArgumentNullException(nameof(stringValue), "value can't be null");
            }
        }

        private bool IsDigitsOrFirstMinus(string str)
        {
            switch (str[0])
            {
                case _negativeChar:
                    _isNegative = true;
                    _valuePart = str[1..];
                    return _valuePart.All(char.IsDigit);
                case _positiveChar:
                    _valuePart = str[1..];
                    _isNegative = false;
                    return _valuePart.All(char.IsDigit);
                default:
                    _valuePart = str;
                    _isNegative = false;
                    return _valuePart.All(char.IsDigit);
            }
        }
    }
}
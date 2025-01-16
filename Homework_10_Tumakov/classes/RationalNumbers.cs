

namespace Homework_10_Tumakov
{
    internal class RationalNumbers
    {
        #region Поля
        public double numerator;
        public double denominator;
        public double fraction;
        #endregion

        #region Конструктор
        public RationalNumbers(double numerator, double denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Делить на 0 нельзя!");
            }

            this.numerator = numerator;
            this.denominator = denominator;
            fraction = numerator / denominator;
        }

        #endregion

        #region Операторы

        public static bool operator ==(RationalNumbers number1, RationalNumbers number2)
        {
            if (ReferenceEquals(number1, number2)) { return true; }
            if (ReferenceEquals(number1, null) || ReferenceEquals(number2, null)) { return false; }

            if (number1.fraction == number2.fraction)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(RationalNumbers number1, RationalNumbers number2)
        {
            return !(number1 == number2);
        }

        public static bool operator <(RationalNumbers number1, RationalNumbers number2)
        {
            return number1.fraction < number2.fraction;

        }

        public static bool operator >(RationalNumbers number1, RationalNumbers number2)
        {
            return number1.fraction > number2.fraction;
        }

        public static bool operator <=(RationalNumbers number1, RationalNumbers number2)
        {
            return number1.fraction <= number2.fraction;
        }

        public static bool operator >=(RationalNumbers number1, RationalNumbers number2)
        {
            return number1.fraction >= number2.fraction;
        }

        public static RationalNumbers operator +(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.denominator == number2.denominator)
            {
                double newNumeratorr = number1.numerator + number2.numerator;
                return new RationalNumbers(newNumeratorr, number2.denominator);
            }
            double newNumerator = number1.numerator * number2.denominator + number2.numerator * number1.denominator;
            double newDenominator = number1.denominator * number2.denominator;
            return new RationalNumbers(newNumerator, newDenominator);
        }

        public static RationalNumbers operator -(RationalNumbers number1, RationalNumbers number2)
        {
            if (number1.denominator == number2.denominator)
            {
                double newNumeratorr = number1.numerator - number2.numerator;
                return new RationalNumbers(newNumeratorr, number2.denominator);
            }
            double newNumerator = number1.numerator * number2.denominator - number2.numerator * number1.denominator;
            double newDenominator = number1.denominator * number2.denominator;
            return new RationalNumbers(newNumerator, newDenominator);
        }

        public static RationalNumbers operator *(RationalNumbers number1, RationalNumbers number2)
        {
            return new RationalNumbers(number1.numerator * number2.numerator, number1.denominator * number2.denominator);
        }

        public static RationalNumbers operator /(RationalNumbers number1, RationalNumbers number2)
        {
            if (number2.numerator == 0)
            {
                throw new DivideByZeroException("Делить на 0 нельзя!");
            }
            return new RationalNumbers(number1.numerator * number2.denominator, number1.denominator * number2.numerator);
        }
    
        public static RationalNumbers operator++(RationalNumbers number)
        {
            number.numerator += number.denominator;
            number.fraction = number.numerator/number.denominator;
            return number;
        }

        public static RationalNumbers operator--(RationalNumbers number)
        {
            number.numerator -= number.denominator;
            number.fraction = number.numerator/ number.denominator;
            return number;
        }

        public static int operator %(RationalNumbers number1, RationalNumbers number2)
        {
            if (number2.fraction == 0)
            {
                throw new DivideByZeroException("Делить на 0 нельзя!");
            }


            double result = number1.fraction % number2.fraction;
            return (int)result;
        }


        public static explicit operator RationalNumbers(float number)
        {
            
            return new RationalNumbers(number, 1);
        }

        public static explicit operator RationalNumbers(int number)
        {
            return new RationalNumbers(number, 1);
        }

        public static explicit operator float(RationalNumbers number)
        {
            return (float)number.fraction;
        }

        public static explicit operator int(RationalNumbers number)
        {
            return (int)number.fraction;
        }

        public override bool Equals(object obj)
        {
            if (obj is RationalNumbers number)
            {
                return this.fraction == number.fraction;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return fraction.GetHashCode();
        }

        public override string ToString()
        {
            return $"Числитель дроби: {numerator}\nЗнаменатель дроби: {denominator}\nИтоговое значение дроби: {fraction}";
        }

        #endregion


    }
}

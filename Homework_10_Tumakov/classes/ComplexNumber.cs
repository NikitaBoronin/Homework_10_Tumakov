

namespace Homework_10_Tumakov
{ 
    internal class ComplexNumber
    {
        #region Поля
        public double ReZ;
        public double ImZ;
        
        #endregion

        #region Конструктор
        public ComplexNumber(double reZ, double imZ)
        {
            ReZ = reZ;
            ImZ = imZ;
        }

        #endregion

        #region Операторы

        public static ComplexNumber operator +(ComplexNumber number1, ComplexNumber number2)
        {
            double NewReZ = number1.ReZ + number2.ReZ;
            double NewImZ = number1.ImZ + number2.ImZ;
            return new ComplexNumber(NewReZ, NewImZ);

        }

        public static ComplexNumber operator -(ComplexNumber number1, ComplexNumber number2)
        {
            double NewReZ = number1.ReZ - number2.ReZ;
            double NewImZ = number1.ImZ - number2.ImZ;
            return new ComplexNumber(NewReZ, NewImZ);
        }

        public static ComplexNumber operator *(ComplexNumber number1, ComplexNumber number2)
        {
            double NewReZ = number1.ReZ * number2.ReZ + (number1.ImZ * number2.ImZ) * -1;
            double NewImZ = number1.ImZ * number2.ReZ + number1.ReZ * number2.ImZ;
            return new ComplexNumber(NewReZ, NewImZ);
        }

        public static bool operator ==(ComplexNumber number1, ComplexNumber number2)
        {
            if (number1.ReZ == number2.ReZ && number1.ImZ == number2.ImZ)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(ComplexNumber number1, ComplexNumber number2)
        {
            return !(number1 == number2);
        }

        #endregion

        #region Метод

        public override string ToString()
        {
            string sign = ImZ >= 0 ? "+" : "-";
            return $"{ReZ} {sign} {Math.Abs(ImZ)}i";
        }

        #endregion
    }
}

using System.Globalization;

namespace CodeKatas
{
    public class FizzBuzz
    {
        public string Answer(int number)
        {
            
            if(number % 3 != 0 && number % 5 != 0)
                return number.ToString(CultureInfo.InvariantCulture);

            string result = string.Empty;
            if (number%3 == 0)
            {
                result = "Fizz";
            }
            if(number%5 == 0)
            {
                result += "Buzz";
            }

            return result;


        }
    }
}
using System.Globalization;

namespace CodeKatas
{
    public class FizzBuzz
    {
        public string Answer(int number)
        {



            string result = string.Empty;
            if (number%3 == 0 || number.ToString(CultureInfo.InvariantCulture).Contains("3"))
            {
                result = "Fizz";
            }
            if (number % 5 == 0 || number.ToString(CultureInfo.InvariantCulture).Contains("5"))
            {
                result += "Buzz";
            }
            
            return result == string.Empty ? number.ToString(CultureInfo.InvariantCulture) : result;


        }
    }
}
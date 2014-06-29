using System;
using System.Globalization;
using NUnit.Framework;


namespace CodeKatas.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void When_getting_divisible_by_3()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(3);

            //Assert
            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void When_getting_divisible_by_5()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(5);

            //Assert
            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void When_getting_number_divisible_by_3_and_5()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(15);

            //Assert
            Assert.AreEqual("FizzBuzz", result);
        }
    }

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

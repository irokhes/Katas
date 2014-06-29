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
    }

    public class FizzBuzz
    {
        public string Answer(int number)
        {

            if (number%3 == 0)
            {
                return "Fizz";
            }
            if(number%5 == 0)
            {
                return "Buzz";
            }
            return number.ToString(CultureInfo.InvariantCulture);
            
        }
    }
}
